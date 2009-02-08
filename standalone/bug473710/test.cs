using System;
using System.IO;
using System.Net;

class Program
{
	const string URL = "http://127.0.0.1:8081/SimpleAsyncHandler.ashx";

	static void Main (string [] args)
	{
		HttpWebRequest request = null;
		HttpWebResponse response = null;
		DateTime start;
		TimeSpan elapsed;

		request = WebRequest.Create (URL) as HttpWebRequest;
		request.KeepAlive = false;
#if NET_2_0
		request.Headers.Add (HttpRequestHeader.IfNoneMatch, "898bbr2347056cc2e096afc66e104653");
#else
		request.Headers.Add ("If-None-Match", "898bbr2347056cc2e096afc66e104653");
#endif
		request.IfModifiedSince = new DateTime (2010, 04, 03);

		start = DateTime.Now;

		try {
			request.GetResponse ();
			Assert.Fail ("#A1");
		} catch (WebException e) {
			response = (HttpWebResponse) e.Response;
		}

		Assert.IsNotNull (response, "#A2");
		Assert.AreEqual (HttpStatusCode.NotModified, response.StatusCode, "#A3");

		using (Stream stream = response.GetResponseStream ()) {
			byte [] buffer = new byte [4096];
			int read = stream.Read (buffer, 0, buffer.Length);
			Assert.AreEqual (0, read, "#A4");
		}

		response.Close ();

		elapsed = DateTime.Now - start;
		Assert.IsTrue (elapsed.TotalMilliseconds < 2000, "#A5:" + elapsed.TotalMilliseconds);

		request = WebRequest.Create ("http://127.0.0.1:8081/test.txt") as HttpWebRequest;
		request.KeepAlive = false;

		response = (HttpWebResponse) request.GetResponse ();

		Assert.IsNotNull (response, "#B1");
		Assert.AreEqual (HttpStatusCode.OK, response.StatusCode, "#B2");

		using (Stream stream = response.GetResponseStream ()) {
			byte [] buffer = new byte [4096];
			int read = stream.Read (buffer, 0, buffer.Length);
			Assert.AreEqual (11, read, "#B3");
		}

		request = WebRequest.Create ("http://127.0.0.1:8081/test.txt") as HttpWebRequest;
		request.KeepAlive = false;
#if NET_2_0
		request.Headers.Add (HttpRequestHeader.IfNoneMatch, response.Headers [HttpResponseHeader.ETag]);
#else
		request.Headers.Add ("If-None-Match", response.Headers ["ETag"]);
#endif
		request.IfModifiedSince = response.LastModified;
		response.Close ();

		start = DateTime.Now;

		try {
			request.GetResponse ();
			Assert.Fail ("#A1");
		} catch (WebException e) {
			response = (HttpWebResponse) e.Response;
		}

		Assert.IsNotNull (response, "#A2");
		Assert.AreEqual (HttpStatusCode.NotModified, response.StatusCode, "#A3");

		using (Stream stream = response.GetResponseStream ()) {
			byte [] buffer = new byte [4096];
			int read = stream.Read (buffer, 0, buffer.Length);
			Assert.AreEqual (0, read, "#A4");
		}

		response.Close ();

		elapsed = DateTime.Now - start;
		Assert.IsTrue (elapsed.TotalMilliseconds < 2000, "#A5:" + elapsed.TotalMilliseconds);
	}
}
