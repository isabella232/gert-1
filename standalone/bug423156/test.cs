using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

class test
{
	static string url = "http://localhost:1876/";
	static int count = 10;
	static int server_count = 0;
	static int client_count = 0;

	static void run_server ()
	{
		HttpListener listener = new HttpListener ();
		listener.Prefixes.Add (url);
		listener.Start ();

		while (server_count < count) {
			HttpListenerContext context = listener.GetContext ();
			HttpListenerResponse response = context.Response;
			string responseString = "my data";
			byte [] buffer = Encoding.UTF8.GetBytes (responseString);
			response.ContentLength64 = buffer.Length;
			Stream output = response.OutputStream;
			output.Write (buffer, 0, buffer.Length);
			output.Close ();
			server_count++;
		}
	}

	static void do_get ()
	{
		HttpWebRequest req = WebRequest.Create (url) as HttpWebRequest;
		req.Timeout = 2000;
		HttpWebResponse res = req.GetResponse () as HttpWebResponse;
		res.GetResponseStream ();
		++client_count;
	}

	static void Main ()
	{
		Thread server = new Thread (run_server);
		server.Start ();
		Thread.Sleep (500);
		for (int i = 0; i < count; ++i) {
			do_get ();
		}
		server.Join ();
		Assert.AreEqual (count, server_count, "server");
		Assert.AreEqual (count, client_count, "client");
	}
}
