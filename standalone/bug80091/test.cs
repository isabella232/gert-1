using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

public class Test
{
	public static int Main ()
	{
		Thread listenThread = new Thread (new ThreadStart (Listen));
		listenThread.Start ();

		HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create ("http://127.0.0.1:8080/a");
		webRequest.Method = "GET";
		HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse ();
		listenThread.Join ();
		using (StreamReader sr = new StreamReader (webResponse.GetResponseStream ())) {
			string response = sr.ReadToEnd ();
			webResponse.Close ();
			if (response == "<ok/>")
				return 0;
		}
		return 1;
	}

	private static void Listen ()
	{
		HttpListener listener = new HttpListener ();
		listener.Prefixes.Add ("http://127.0.0.1:8080/a/");
		listener.Start ();

		HttpListenerResponse response = listener.GetContext().Response;
		response.ContentType = "text/xml";

		byte [] buffer = Encoding.UTF8.GetBytes ("<ok/>");
		response.ContentLength64 = buffer.Length;
		Stream output = response.OutputStream;
		output.Write (buffer, 0, buffer.Length);
		output.Close ();
		listener.Stop ();
	}
}
