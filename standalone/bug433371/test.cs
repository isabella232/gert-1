using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

class Listener
{
	private HttpListener listener;
	internal List<IPEndPoint> EndPoints;

	public Listener ()
	{
		EndPoints = new List<IPEndPoint> ();

		listener = new HttpListener ();
		listener.Prefixes.Add (KeepAliveTest.URL);
		listener.Start ();
		listener.BeginGetContext (Handle, null);
	}

	void Handle (IAsyncResult result)
	{
		HttpListenerContext context = listener.EndGetContext (result);
		HttpListenerRequest request = context.Request;
		HttpListenerResponse response = context.Response;

		EndPoints.Add (request.RemoteEndPoint);
		response.KeepAlive = true;
		response.ContentType = "text/plain";

		byte [] buff = Encoding.UTF8.GetBytes ("The response");
		response.ContentLength64 = buff.Length;
		Stream output = response.OutputStream;
		output.Write (buff, 0, buff.Length);
		output.Close ();
		response.Close ();

		listener.BeginGetContext (Handle, null);
	}

	public void Stop ()
	{
		listener.Stop ();
	}
}

class KeepAliveTest
{
	public const string URL = "http://127.0.0.1:2222/";

	static void Main ()
	{
		Listener listener = new Listener ();

		for (int i = 0; i < 5; i++) {
			HttpWebRequest request = WebRequest.Create (URL) as HttpWebRequest;
			HttpWebResponse response = request.GetResponse () as HttpWebResponse;

			using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
				Assert.AreEqual ("The response", reader.ReadToEnd (), "Response");
			}
			response.Close ();
		}

		Assert.AreEqual (5, listener.EndPoints.Count, "#1");
		Assert.IsNotNull (listener.EndPoints [0], "#2");
		Assert.AreEqual (listener.EndPoints [0], listener.EndPoints [1], "#3");
		Assert.AreEqual (listener.EndPoints [0], listener.EndPoints [2], "#4");
		Assert.AreEqual (listener.EndPoints [0], listener.EndPoints [3], "#5");
		Assert.AreEqual (listener.EndPoints [0], listener.EndPoints [4], "#6");
		listener.Stop ();
	}
}
