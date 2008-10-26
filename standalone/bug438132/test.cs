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
		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/foo.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("<p>Groove</p>") != -1, "#A1:" + result);
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

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/bar.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			Assert.Fail ("#B1");
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.IsNotNull (response, "#B2");

			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("CS0103") != -1, "#B3");
				Assert.IsTrue (result.IndexOf ("FunkyTextBox") != -1, "#B4");
			}
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/baz.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("<p>Groove</p>") != -1, "#C1:" + result);
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
