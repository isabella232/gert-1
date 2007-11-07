using System;
using System.Net;
using System.Text;
using System.Threading;

class Program
{
	static void Main ()
	{
		Server server = new Server ();
		server.Start ();

		Client client = new Client ();

		try {
			client.SendRequest (false, false);
			Assert.Fail ("#A1");
		} catch (WebException ex) {
			Assert.IsNotNull (ex.Response, "#A2");
			Assert.IsTrue (ex.Response is HttpWebResponse, "#A3");

			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.AreEqual (HttpStatusCode.Unauthorized, response.StatusCode, "#A4");
			Assert.IsNull (ex.InnerException, "#A5");
			Assert.IsFalse (server.Callback, "#A6");
		}

		server.Reset ();

		client.SendRequest (true, false);
		Thread.Sleep (200);
		Assert.IsTrue (server.Callback, "#B");

		server.Reset ();

		client.SendRequest (true, true);
		Thread.Sleep (200);
		Assert.IsTrue (server.Callback, "#C");

		server.Stop ();
	}
}

public class Client
{
	public void SendRequest (bool creds, bool preauth)
	{
		HttpWebResponse response;
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://127.0.0.1:9675/authtest/");

		if (creds) {
			request.Credentials = new NetworkCredential ("username", "password");
			if (preauth) {
				request.PreAuthenticate = true;
			}
		}

		response = (HttpWebResponse) request.GetResponse ();

		response.Close ();
	}
}

public class Server
{
	private HttpListener _listener;
	private bool _callback;

	public Server ()
	{
		_listener = new HttpListener ();
		_listener.Prefixes.Add ("http://*:9675/authtest/");
		_listener.AuthenticationSchemes = AuthenticationSchemes.Basic;
	}

	public bool Callback {
		get { return _callback; }
	}

	public void Start ()
	{
		_listener.Start ();
		_listener.BeginGetContext (new AsyncCallback (ListenerCallback), _listener);
	}

	public void Reset ()
	{
		_callback = false;
	}

	public void Stop ()
	{
		_listener.Close ();
	}

	void ListenerCallback (IAsyncResult result)
	{
		HttpListener listener = (HttpListener) result.AsyncState;
		HttpListenerContext context = listener.EndGetContext (result);
		HttpListenerResponse response = context.Response;

		response.OutputStream.Close ();

		listener.BeginGetContext (new AsyncCallback (ListenerCallback), listener);
		_callback = true;
	}
}
