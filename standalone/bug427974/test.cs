using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

class Program : MarshalByRefObject
{
	AutoResetEvent handle;

	static void Main ()
	{
		string url = "http://localhost:6372/";
		HttpListener listener = new HttpListener ();
		listener.Prefixes.Add (url);
		listener.Start ();
		listener.BeginGetContext (new AsyncCallback (ListenerCallback), listener);

		Stopwatch stopwatch = new Stopwatch ();
		stopwatch.Start ();

		Client client = Client.CreateInNewAppDomain ();
		client.Bombard (url, 10000, 20);
		Program p = new Program ();
		p.handle = new AutoResetEvent (false);
		client.Completed += p.CompletedHandler;
		if (!p.handle.WaitOne (30000, false))
			throw new Exception ("Operation timed out");

		Assert.AreEqual (10000, client.total, "#1");
		Assert.IsTrue (stopwatch.Elapsed.TotalMilliseconds < 10000, "#2:" + stopwatch.Elapsed.TotalMilliseconds);
	}

	public void CompletedHandler ()
	{
		handle.Set ();
	}

	static void ListenerCallback (IAsyncResult result)
	{
		HttpListener listener = (HttpListener) result.AsyncState;
		listener.BeginGetContext (new AsyncCallback (ListenerCallback), listener);
		HttpListenerContext ctx = listener.EndGetContext (result);

		MemoryStream ms = new MemoryStream ();
		Client.CopyStream (ctx.Request.InputStream, ms, 1024);
		ctx.Request.InputStream.Close ();
		Client.CopyStream (ms, ctx.Response.OutputStream, 1024);
		ctx.Response.OutputStream.Close ();
	}
}

class Client : MarshalByRefObject
{
	object mtx = new object ();
	public int total;
	int requestsLeft;
	int running;
	string url;
	string body = new string ('a', 2000);

	public delegate void VoidDel ();
	public event VoidDel Completed;

	public static Client CreateInNewAppDomain ()
	{
		AppDomain clientDomain = AppDomain.CreateDomain ("client");
		return (Client) clientDomain.CreateInstanceAndUnwrap (
			typeof (Client).Assembly.FullName,
			typeof (Client).FullName);
	}

	void OnCompleted ()
	{
		if (Completed != null)
			Completed ();
	}

	public void Bombard (string url, int count, int concurrent)
	{
		lock (mtx) {
			if (requestsLeft > 0 || running > 0)
				throw new InvalidOperationException ("Already running");
		}

		this.url = url;
		this.requestsLeft = count;
		this.total = count;
		this.running = concurrent;
		for (int i = 0; i < concurrent; i++) {
			MakeRequest ();
		}
	}

	void MakeRequest ()
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create (url);
		request.Method = "POST";
		request.BeginGetRequestStream (HandleRequest, request);
	}

	void HandleRequest (IAsyncResult result)
	{
		HttpWebRequest request = (HttpWebRequest) result.AsyncState;
		request.Timeout = 1000;
		Stream requestStream = request.EndGetRequestStream (result);
		TextWriter writer = new StreamWriter (requestStream);
		writer.Write (body);
		writer.Close ();
		requestStream.Close ();
		request.BeginGetResponse (HandleResponse, request);
	}

	void HandleResponse (IAsyncResult result)
	{
		HttpWebRequest request = (HttpWebRequest) result.AsyncState;
		HttpWebResponse response = (HttpWebResponse) request.EndGetResponse (result);
		MemoryStream ms = new MemoryStream ();
		CopyStream (response.GetResponseStream (), ms, 1024);
		bool completed = false;
		bool shouldContinue = false;
		lock (mtx) {
			requestsLeft--;
			if (requestsLeft > 0) {
				shouldContinue = true;
			} else {
				running--;
				if (running <= 0)
					completed = true;
			}
		}
		if (shouldContinue)
			MakeRequest ();
		else if (completed)
			OnCompleted ();
	}

	internal static void CopyStream (Stream source, Stream target, int bufferSize)
	{
		byte [] buffer = new byte [bufferSize];
		int readLen = source.Read (buffer, 0, buffer.Length);
		while (readLen > 0) {
			target.Write (buffer, 0, readLen);
			readLen = source.Read (buffer, 0, buffer.Length);
		}
	}
}
