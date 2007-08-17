using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main ()
	{
		HttpListener listener = new HttpListener ();
		listener.Prefixes.Add ("http://" + IPAddress.Loopback.ToString () + ":8001/");

		listener.Start ();
		IAsyncResult result = listener.BeginGetContext (new AsyncCallback (ListenerCallback), listener);

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://" + IPAddress.Loopback.ToString () + ":8001/?a=1&b=2");
		request.Accept = "image/png,text/html";
		request.Method = "GET";
		HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
		response.Close ();
		result.AsyncWaitHandle.WaitOne ();

		return exitCode;
	}

	static void ListenerCallback (IAsyncResult result)
	{
		HttpListener listener = (HttpListener) result.AsyncState;
		HttpListenerContext context = listener.EndGetContext (result);
		HttpListenerRequest request = context.Request;
		string [] acceptTypes = request.AcceptTypes;
		if (acceptTypes == null || acceptTypes.Length != 2) {
			exitCode = 1;
		} else {
			if (acceptTypes [0] != "image/png")
				exitCode = 2;
			if (acceptTypes [1] != "text/html")
				exitCode = 3;
		}

		if (request.QueryString == null || request.QueryString.Count != 2) {
			exitCode = 4;
		} else {
			if (request.QueryString.GetKey (0) != "a")
				exitCode = 5;
			if (request.QueryString.Get (0) != "1")
				exitCode = 5;
			if (request.QueryString.GetKey (1) != "b")
				exitCode = 5;
			if (request.QueryString.Get (1) != "2")
				exitCode = 5;
		}

		if (request.HttpMethod != "GET")
			exitCode = 6;
		if (request.RawUrl != "/?a=1&b=2")
			exitCode = 7;
		if (request.Url.ToString () != "http://127.0.0.1:8001/?a=1&b=2")
			exitCode = 8;

		HttpListenerResponse response = context.Response;
		string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
		byte [] buffer = Encoding.UTF8.GetBytes (responseString);
		response.ContentLength64 = buffer.Length;
		Stream output = response.OutputStream;
		if (exitCode == -1)
			exitCode = 0;
		output.Write (buffer, 0, buffer.Length);
		output.Close ();
	}

	static int exitCode = -1;
}
