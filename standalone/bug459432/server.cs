using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

class Server
{
	static void Main ()
	{
		HttpListener listener = new HttpListener ();
		listener.IgnoreWriteExceptions = true;
		listener.Prefixes.Add ("http://*:8081/");
		listener.Start ();
		listener.BeginGetContext (RequestHandler, listener);
		while (true) {
			Thread.Sleep (250);
			if (File.Exists ("stop-server.tmp"))
				break;
		}
		listener.Close ();
		File.Create ("finish-server.tmp").Close ();
	}

	static void RequestHandler (IAsyncResult ar)
	{
		HttpListenerContext httpContext = null;
		try {
			HttpListener listener = (HttpListener) ar.AsyncState;
			httpContext = listener.EndGetContext (ar);

			// start listening for next request
			listener.BeginGetContext (RequestHandler, listener);

			// invoke response handler
			ResponseHandler (httpContext);
		} catch (Exception e) {
			using (StreamWriter sw = new StreamWriter ("failure-server.tmp", false, Encoding.UTF8)) {
				sw.Write (e.ToString ());
			}
			if (httpContext != null)
				httpContext.Response.Close ();
		}
	}

	static void ResponseHandler (HttpListenerContext httpContext)
	{
		byte [] buffer = Encoding.ASCII.GetBytes ("hello world");
		httpContext.Response.StatusCode = 200;
		httpContext.Response.OutputStream.Write (buffer, 0, buffer.Length);
		httpContext.Response.Close ();
	}
}
