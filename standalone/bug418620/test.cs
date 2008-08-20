using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Please specify the test to run.");
			return 1;
		}

		switch (args [0]) {
		case "safe":
			return TestSafe ();
		case "unsafe":
			return TestUnsafe ();
		default:
			Console.WriteLine ("Unsupported test '{0}'.", args [0]);
			return 2;
		}
	}

	static int TestSafe ()
	{
		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx?text=esiu%0D%0ASet-Cookie%3A%20HackedCookie=Hacked");
		request.CookieContainer = new CookieContainer ();
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("title>bug #418620</title>") != -1, "#A1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>OK</p>") != -1, "#A2:" + result);

				Cookie cookie;

				cookie = response.Cookies ["userName"];
				Assert.IsNotNull (cookie, "#B1");
				Assert.AreEqual ("esiu%0d%0aSet-Cookie: HackedCookie=Hacked", cookie.Value, "#B2");
				cookie = response.Cookies ["HackedCookie"];
				Assert.IsNull (cookie, "#B3");
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 1;
		}

		return 0;
	}

	static int TestUnsafe ()
	{
		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx?text=esiu%0D%0ASet-Cookie%3A%20HackedCookie=Hacked");
		request.CookieContainer = new CookieContainer ();
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("title>bug #418620</title>") != -1, "#A1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>OK</p>") != -1, "#A2:" + result);

				Cookie cookie;

				cookie = response.Cookies ["userName"];
				Assert.IsNotNull (cookie, "#B1");
				Assert.AreEqual ("esiu", cookie.Value, "#B2");
				cookie = response.Cookies ["HackedCookie"];
				Assert.IsNotNull (cookie, "#B3");
				Assert.AreEqual ("Hacked", cookie.Value, "#B4");
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 1;
		}

		return 0;
	}
}
