using System;
using System.Net;

class Program
{
	const string URL = "http://ntlmauth.omni-ts.com/";
	const string USERID = "mono";
	const string PASSWD = "mono";

	static void Main ()
	{
		for (int i = 0; i < 10; i++)
			Valid ();

		for (int i = 0; i < 10; i++)
			InvalidUsername ();

		for (int i = 0; i < 10; i++)
			InvalidPassword ();
	}

	static void Valid ()
	{
		WebRequest req = WebRequest.Create (URL);
		req.Credentials = new NetworkCredential (USERID, PASSWD, string.Empty);

		HttpWebResponse resp = (HttpWebResponse) req.GetResponse ();
		Assert.AreEqual (HttpStatusCode.OK, resp.StatusCode, "#A");
	}

	static void InvalidUsername ()
	{
		WebRequest req = WebRequest.Create (URL);

		req.Credentials = new NetworkCredential ("invalidusername", PASSWD, string.Empty);

		try {
			req.GetResponse ();
			Assert.Fail ("#B1");
		} catch (WebException ex) {
			HttpWebResponse resp = (HttpWebResponse) ex.Response;
			Assert.AreEqual (HttpStatusCode.Unauthorized, resp.StatusCode, "#B2");
		}

	}

	static void InvalidPassword ()
	{
		WebRequest req = WebRequest.Create (URL);

		req.Credentials = new NetworkCredential (USERID, "invalidpassword", string.Empty);

		try {
			req.GetResponse ();
			Assert.Fail ("#C1");
		} catch (WebException ex) {
			HttpWebResponse resp = (HttpWebResponse) ex.Response;
			Assert.AreEqual (HttpStatusCode.Unauthorized, resp.StatusCode, "#C2");
		}
	}
}
