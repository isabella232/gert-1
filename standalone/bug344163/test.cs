using System;
using System.IO;
using System.Net;

class Program
{
	static void Main ()
	{
		string location = string.Format ("http://{0}:{1}/",
			IPAddress.Loopback.ToString (), 8081);
		HttpListener listener = new HttpListener ();
		listener.Prefixes.Add (location);
		listener.Start ();

		listener.BeginGetContext (new AsyncCallback (ListenerCallback), 
			listener);
		WebRequest webRequest = WebRequest.Create ("http://localhost:8081");

		IAsyncResult requestResult = webRequest.BeginGetResponse (
			null, null);
		try {
			webRequest.EndGetResponse (requestResult);
			Assert.Fail ("#A1");
		} catch (WebException ex) {
			Assert.AreEqual (typeof (WebException), ex.GetType (), "#A2");
			Assert.IsNull (ex.InnerException, "#A3");
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#A4");
			Assert.IsFalse (_calledBack, "#A5");

			HttpWebResponse response = ex.Response as HttpWebResponse;
			Assert.IsNotNull (response, "#A6");
			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string body = sr.ReadToEnd ();
				Assert.IsTrue (body.IndexOf ("<h1>Bad Request") != -1, "#A7");
			}
			Assert.AreEqual (HttpStatusCode.BadRequest, response.StatusCode, "#A8");
		}

		webRequest = WebRequest.Create (location);
		requestResult = webRequest.BeginGetResponse (null, null);
		HttpWebResponse webResponse = (HttpWebResponse) webRequest.
			EndGetResponse (requestResult);
		using (StreamReader sr = new StreamReader (webResponse.GetResponseStream ())) {
			string body = sr.ReadToEnd ();
			Assert.AreEqual ("<HTML><BODY> Hello world!</BODY></HTML>", body, "#B1");
		}
		Assert.AreEqual (HttpStatusCode.OK, webResponse.StatusCode, "#B2");
		Assert.IsTrue (_calledBack, "#B3");
	}

	static void ListenerCallback (IAsyncResult result)
	{
		_calledBack = true;
		HttpListener listener = (HttpListener) result.AsyncState;
		HttpListenerContext context = listener.EndGetContext (result);

		string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
		byte [] buffer = System.Text.Encoding.UTF8.GetBytes (responseString);

		HttpListenerResponse response = context.Response;
		response.ContentLength64 = buffer.Length;
		Stream output = response.OutputStream;
		output.Write (buffer, 0, buffer.Length);
		output.Flush ();
		output.Close ();
	}

	private static bool _calledBack = false;
}
