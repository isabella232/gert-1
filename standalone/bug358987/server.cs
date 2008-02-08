using System;
using System.Net;
using System.IO;
using System.Text;

class Server
{
	static void Main ()
	{
		HttpListener listener = new HttpListener ();
		listener.Prefixes.Add ("http://*:8081/");
		listener.Start ();

		HttpListenerContext context = listener.GetContext ();

		// Create the response.
		HttpListenerResponse response = context.Response;
		string responseString = "<html><body>hi client</body></html>";
		byte [] buffer = Encoding.UTF8.GetBytes (responseString);
		response.ContentLength64 = buffer.Length;
		System.Threading.Thread.Sleep (3000);
		response.OutputStream.Write (buffer, 0, buffer.Length);
		if (response != null)
			response.Close ();
		listener.Close ();

		string dir = AppDomain.CurrentDomain.BaseDirectory;
		File.Create (Path.Combine (dir, "ok")).Close ();
	}
}
