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
		string baseDir = AppDomain.CurrentDomain.BaseDirectory;
		string webDir = Path.Combine (baseDir, "web");

		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		File.Copy (Path.Combine (baseDir, "Config_Ok.xml"),
			Path.Combine (webDir, "Web.config"), true);
		Thread.Sleep (200);

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<p>ok</p>") != -1, "#A:" + result);
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

		File.Copy (Path.Combine (baseDir, "Config_Bad.xml"),
			Path.Combine (webDir, "Web.config"), true);
		File.SetLastAccessTime (Path.Combine (webDir, "Web.config"), DateTime.Now);
		Thread.Sleep (200);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			Assert.Fail ("#B1");
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#B1");
			Assert.IsNotNull (response, "#B2");
			Assert.AreEqual (HttpStatusCode.InternalServerError, response.StatusCode, "#B3");

			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("Configuration Error") != -1, "#B4:" + result);
			}
		}

		File.Copy (Path.Combine (baseDir, "Config_Ok.xml"),
			Path.Combine (webDir, "Web.config"), true);
		File.SetLastAccessTime (Path.Combine (webDir, "Web.config"), DateTime.Now);
		Thread.Sleep (200);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<p>ok</p>") != -1, "#C:" + result);
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

		return 0;
	}
}
