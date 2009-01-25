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

		File.Copy (Path.Combine (baseDir, "SiteMapFile.sitemap"),
			Path.Combine (webDir, "Web.sitemap"), true);
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
				Assert.AreEqual ("TestV2", result, "#B");
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

		File.Copy (Path.Combine (baseDir, "SiteMapFile_Empty.sitemap"),
			Path.Combine (webDir, "Web.sitemap"), true);
		Thread.Sleep (1000);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/index.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			Assert.Fail ("#C1");
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.IsNotNull (response, "#C2");
			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("ConfigurationErrorsException") != -1, "#C3:" + result);
				Assert.IsTrue (result.IndexOf ("The 'siteMapFile' attribute cannot be an empty string.") != -1, "#C4:" + result);
			}
		}

		File.Copy (Path.Combine (baseDir, "SiteMapFile_InvalidExtension.sitemap"),
			Path.Combine (webDir, "Web.sitemap"), true);
		Thread.Sleep (1000);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/index.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			Assert.Fail ("#D1");
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.IsNotNull (response, "#D2");
			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("InvalidOperationException") != -1, "#D3:" + result);
				Assert.IsTrue (result.IndexOf ("The file /index.aspx has an invalid extension, only .sitemap files are allowed in XmlSiteMapProvider.") != -1, "#D4:" + result);
			}
		}

		File.Copy (Path.Combine (baseDir, "SiteMapFile_NotFound.sitemap"),
			Path.Combine (webDir, "Web.sitemap"), true);
		Thread.Sleep (1000);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/index.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			Assert.Fail ("#E1");
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.IsNotNull (response, "#E2");
			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("InvalidOperationException") != -1, "#E3:" + result);
				Assert.IsTrue (result.IndexOf ("The file /doesnotexist.sitemap required by XmlSiteMapProvider does not exist.") != -1, "#E4:" + result);
			}
		}

		return 0;
	}
}
