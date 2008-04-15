using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

class Program
{
	static int Main ()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		CookieContainer cookies = new CookieContainer ();

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.CookieContainer = cookies;
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("Classifieds Online") != -1, "#A1:" + result);
				Assert.IsTrue (result.IndexOf ("Browse all Categories") != -1, "#A2:" + result);
				Assert.IsTrue (result.IndexOf ("Site Administration") == -1, "#A3:" + result);
				Assert.IsTrue (result.IndexOf ("Post an Ad") != -1, "#A4:" + result);
				Assert.IsTrue (result.IndexOf ("My Ads & Profile") != -1, "#A5:" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				Console.WriteLine (response.StatusCode);
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 2;
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/ManagePhotos.aspx");
		request.CookieContainer = cookies;
		request.Method = "GET";

		try {
			request.GetResponse ();
			Assert.Fail ("#B1");
		} catch (WebException ex) {
			Assert.AreEqual (typeof (WebException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#B4");

			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.IsNotNull (response, "#B5");
			Assert.AreEqual (HttpStatusCode.InternalServerError, response.StatusCode, "#B6");

			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("NotImplementedException") != -1, "#B7:" + result);
			}
			response.Close ();
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/ManagePhotos.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			Assert.Fail ("#C1");
		} catch (WebException ex) {
			Assert.AreEqual (typeof (WebException), ex.GetType (), "#C2");
			Assert.IsNull (ex.InnerException, "#C3");
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#C4");

			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.IsNotNull (response, "#C5");
			Assert.AreEqual (HttpStatusCode.Found, response.StatusCode, "#C6");

			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("<title>Object moved</title>") != -1, "#C7:" + result);
				Assert.IsTrue (result.IndexOf ("<a href=\"/login.aspx?ReturnUrl=%2fManagePhotos.aspx\">here</a>") != -1, "#C8:" + result);
			}

			response.Close ();
		}

		return 0;
	}
}
