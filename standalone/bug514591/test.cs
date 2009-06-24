using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
	static int Main (string [] args)
	{
		int exit = Run (args);
		if (exit != 0)
			SignalError (exit);
		return exit;
	}

	static int Run (string [] args)
	{
		IPEndPoint ep = new IPEndPoint (IPAddress.Parse ("192.168.0.2"), 65099);

		switch (args [0]) {
		case "test":
			return Test (ep);
		case "verify":
			return Verify (ep);
		default:
			Console.WriteLine ("Action '{0}' is not supported.", args [0]);
			return 2;
		}
	}

	static int Test (IPEndPoint ep)
	{
		ManualResetEvent [] evts = new ManualResetEvent [10];

		Uri uri = new Uri ("http://"+ ep.ToString ());

		for (int i = 0; i < 10; i++) {
			evts [i] = new ManualResetEvent (false);
			GetRequestStreamAsync (uri, i, evts [i]);
		}

		if (!EventWaitHandle.WaitAll (evts, 20000)) {
			Console.WriteLine ("Not all requests completed.");
			return 4;
		}

		string quit = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"quit");
		while (true) {
			if (File.Exists (quit))
				break;
			Thread.Sleep (500);
		}

		return 0;
	}

	static int Verify (IPEndPoint ep)
	{
		NetworkConnection con = new NetworkConnection (ep);

		bool active = true;

		try {
			for (int i = 0; i < 30; i++) {
				active = con.IsActive;
				if (!active)
					break;
				Thread.Sleep (1000);
			}
		} finally {
			string quit = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
				"quit");

			try {
				File.Create (quit).Close ();
			} catch {
			}
		}

		if (con.IsActive || active)
			return 3;
		return 0;
	}

	static void GetRequestStreamAsync (Uri uri, int i, EventWaitHandle complete)
	{
		byte [] data = new byte [32];
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create (uri);
		request.Method = "POST";
		request.ContentLength = data.Length;

		RegisteredWaitHandle handle = null;

		BeginGetRequestStreamWithTimeout (request,
			(r1) =>
			{
				try {
					EndGetRequestStreamWithTimeout (request, r1, handle);
					SignalError (5);
					request.Abort ();
				} catch (WebException ex) {
					if (ex.Status != WebExceptionStatus.Timeout) {
						Console.WriteLine ("[{0}] {1}", i, ex.Status);
						SignalError (6);
					}
				}

				complete.Set ();
			},
			null,
			out handle);
	}

	static IAsyncResult BeginGetRequestStreamWithTimeout (HttpWebRequest request, AsyncCallback callback, object state, out RegisteredWaitHandle handle)
	{
		IAsyncResult asyncResult = request.BeginGetRequestStream (callback, state);

		handle = ThreadPool.RegisterWaitForSingleObject (
			asyncResult.AsyncWaitHandle,
			CancelRequest,
			request,
			1000,
			true);

		return asyncResult;
	}

	static Stream EndGetRequestStreamWithTimeout (HttpWebRequest request, IAsyncResult asyncResult, RegisteredWaitHandle handle)
	{
		try {
			handle.Unregister (asyncResult.AsyncWaitHandle);

			return request.EndGetRequestStream (asyncResult);
		} catch (WebException ex) {
			if (ex.Status == WebExceptionStatus.RequestCanceled) {
				throw new WebException ("GetRequestStream operation has timed out.", WebExceptionStatus.Timeout);
			}

			throw;
		}
	}

	static void CancelRequest (object state, bool timedOut)
	{
		if (timedOut) {
			HttpWebRequest request = state as HttpWebRequest;
			request.Abort ();
		}
	}

	static void SignalError (int errorCode)
	{
		string error = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"error");
		if (!File.Exists (error)) {
			using (FileStream fs = File.Create (error)) {
				using (StreamWriter sw = new StreamWriter (fs, Encoding.UTF8)) {
					sw.Write (errorCode.ToString (CultureInfo.InvariantCulture));
				}
			}
		}
	}
}
