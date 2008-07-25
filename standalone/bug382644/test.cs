using System;
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

		CookieContainer cookies = new CookieContainer ();

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/index.aspx");
		request.CookieContainer = cookies;
		request.Method = "GET";

		DateTime start = DateTime.Now;

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<p>Index</p>") != -1, "#A:" + result);
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

		Assert.IsTrue (File.Exists (Path.Combine (webDir, "session_start")), "#B1");
		Assert.IsFalse (File.Exists (Path.Combine (webDir, "session_end")), "#B2");

		TimeSpan totalSessionTime;

		while (true) {
			Thread.Sleep (1000);
			totalSessionTime = DateTime.Now - start;
			if (File.Exists (Path.Combine (webDir, "session_end")))
				break;
			if (totalSessionTime.TotalSeconds > 180)
				break;
		}

		Assert.IsTrue (totalSessionTime.TotalSeconds > 60, "#C1:" + totalSessionTime.TotalSeconds);
		Assert.IsTrue (totalSessionTime.TotalSeconds < 150, "#C2:" + totalSessionTime.TotalSeconds);

		return 0;
	}
}
