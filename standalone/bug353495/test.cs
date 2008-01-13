using System;
using System.Net;

class Program
{
	static void Main ()
	{
		const string reqURL = "http://coffeefaq.com/site/node/25";
		
		HttpWebRequest req = (HttpWebRequest) WebRequest.Create (reqURL);
		HttpWebResponse resp = (HttpWebResponse) req.GetResponse ();
		DateTime lastMod = resp.LastModified;
		resp.Close ();

		req = (HttpWebRequest) WebRequest.Create (reqURL);
		req.IfModifiedSince = lastMod;
		try {
			resp = (HttpWebResponse) req.GetResponse ();
			resp.Close ();
			Assert.Fail ("#A1");
		} catch (WebException ex) {
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#A2");
			Assert.IsNotNull (ex.Response, "#A3");

			resp = (HttpWebResponse) ex.Response;
			Assert.AreEqual (HttpStatusCode.NotModified, resp.StatusCode, "#A4");
		}

		req = (HttpWebRequest) WebRequest.Create (reqURL);
		req.IfModifiedSince = new DateTime (2000, 1, 4);
		resp = (HttpWebResponse) req.GetResponse ();
		resp.Close ();
	}
}
