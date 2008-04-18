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

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US");
		Thread.CurrentThread.CurrentUICulture = new CultureInfo ("en-US");

		string baseDir = AppDomain.CurrentDomain.BaseDirectory;
		string webDir = Path.Combine (baseDir, "web");

		TestWebService svc = new TestWebService ();
		Assert.AreEqual ("Hello World", svc.HelloWorld (), "#A");

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("Master Web Page") != -1, "#B1:" + result);
				Assert.IsTrue (result.IndexOf ("<h1 class=\"header\">Welcome to Mono XSP!</h1>") != -1, "#B2:" + result);
				Assert.IsTrue (result.IndexOf ("<span id=\"ctl00_ContentPlaceHolder1_Label1\">Page Loaded</span>") != -1, "#B3:" + result);
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

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Index.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<title>OK</title>") != -1, "#C1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>fine</p>") != -1, "#C2:" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 2;
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/index.htm");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<title>Index</title>") != -1, "#D1" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 3;
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Start.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<p>Start</p>") != -1, "#E1" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 4;
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/DoesNotExist.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			Assert.Fail ("#F1");
		} catch (WebException ex) {
			Assert.AreEqual (typeof (WebException), ex.GetType (), "#F2");
			Assert.IsNull (ex.InnerException, "#F3");
			Assert.IsNotNull (ex.Message, "#F4");
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#F5");

			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.IsNotNull (response, "#F6");
			Assert.AreEqual (HttpStatusCode.NotFound, response.StatusCode, "#F7");

			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("The resource cannot be found.") != -1, "#F8:" + result);
				Assert.IsTrue (result.IndexOf ("/DoesNotExist.aspx") != -1, "#F9:" + result);
			}
		}

		return 0;
	}
}
