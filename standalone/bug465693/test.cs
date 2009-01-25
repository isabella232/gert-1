using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

class Program
{
	static int Main (string [] args)
	{
		string baseDir = AppDomain.CurrentDomain.BaseDirectory;
		string webDir = Path.Combine (baseDir, "web");

		HttpWebRequest request;

		File.Copy (Path.Combine (baseDir, "nested_V1.sitemap"),
			Path.Combine (webDir, "nested.sitemap"), true);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/index.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.AreEqual ("TestV1", result, "#A");
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

		File.Copy (Path.Combine (baseDir, "nested_V2.sitemap"),
			Path.Combine (webDir, "nested.sitemap"), true);
		Thread.Sleep (1000);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/index.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.AreEqual ("TestV2", result, "#A");
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

		return 0;
	}
}
