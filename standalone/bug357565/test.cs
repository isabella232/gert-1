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

		string webDir = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"web");

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<p>OK</p>") != -1, "#A1:" + result);
				Assert.IsTrue (File.Exists (Path.Combine (webDir, "app_start")), "#A2");
				Assert.IsFalse (File.Exists (Path.Combine (webDir, "app_end")), "#A3");
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

		File.Create (Path.Combine (webDir, "app_offline.htm")).Close ();
		Thread.Sleep (500);
		Assert.IsTrue (File.Exists (Path.Combine (webDir, "app_start")), "#B1");
		Assert.IsTrue (File.Exists (Path.Combine (webDir, "app_end")), "#B2");

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			return 2;
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#C1");
			Assert.IsNotNull (response, "#C2");
			Assert.AreEqual (HttpStatusCode.NotFound, response.StatusCode, "#C3");
		}

		File.Delete (Path.Combine (webDir, "app_start"));
		File.Delete (Path.Combine (webDir, "app_end"));
		File.Delete (Path.Combine (webDir, "app_offline.htm"));
		Thread.Sleep (500);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<p>OK</p>") != -1, "#D1:" + result);
				Assert.IsTrue (File.Exists (Path.Combine (webDir, "app_start")), "#D2");
				Assert.IsFalse (File.Exists (Path.Combine (webDir, "app_end")), "#D3");
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

		Assert.IsTrue (File.Exists (Path.Combine (webDir, "app_start")), "#E1");
		Assert.IsFalse (File.Exists (Path.Combine (webDir, "app_end")), "#E2");

		File.Create (Path.Combine (webDir, "app_temp.htm")).Close ();
		File.Move (Path.Combine (webDir, "app_temp.htm"), Path.Combine (webDir, "app_offline.htm"));
		Thread.Sleep (200);

		Assert.IsTrue (File.Exists (Path.Combine (webDir, "app_start")), "#E3");
		Assert.IsTrue (File.Exists (Path.Combine (webDir, "app_end")), "#E4");

		return 0;
	}
}
