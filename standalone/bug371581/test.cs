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

		File.Copy (Path.Combine (baseDir, "global1.asax"), Path.Combine (webDir, "global.asax"), true);
		Thread.Sleep (200);

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Whatever.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<p>1-ok</p>") != -1, "#A:" + result);
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

		File.Copy (Path.Combine (baseDir, "global2.asax"), Path.Combine (webDir, "global.asax"), true);
		Thread.Sleep (200);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Whatever.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<p>1-ok</p>") != -1, "#B:" + result);
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

		File.Copy (Path.Combine (baseDir, "global3.asax"), Path.Combine (webDir, "global.asax"), true);
		Thread.Sleep (200);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Whatever.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			Assert.Fail ("#C1");
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#C2");
			Assert.IsNull (ex.InnerException , "#C3");
			Assert.IsNotNull (response, "#C4");
			Assert.AreEqual (HttpStatusCode.NotFound, response.StatusCode, "#C5");
		}

		return 0;
	}
}
