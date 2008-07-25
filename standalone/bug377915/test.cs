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
		string controlsDir = Path.Combine (webDir, "controls");

		File.Copy (Path.Combine (baseDir, "Index_v1.aspx"), Path.Combine (webDir, "Index.aspx"), true);
		File.Copy (Path.Combine (baseDir, "MyControl_v1.ascx"), Path.Combine (controlsDir, "MyControl.ascx"), true);
		Thread.Sleep (200);

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Index.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<h1>Index_V1</h1>") != -1, "#A1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>Control_V1</p>") != -1, "#A2:" + result);
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

		File.Copy (Path.Combine (baseDir, "MyControl_v2.ascx"), Path.Combine (controlsDir, "MyControl.ascx"), true);
		Thread.Sleep (1000);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Index.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<h1>Index_V1</h1>") != -1, "#B1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>Control_V2</p>") != -1, "#B2:" + result);
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

		File.Copy (Path.Combine (baseDir, "Index_v2.aspx"), Path.Combine (webDir, "Index.aspx"), true);
		Thread.Sleep (1000);

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Index.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<h1>Index_V2</h1>") != -1, "#C1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>Control_V2</p>") != -1, "#C2:" + result);
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
