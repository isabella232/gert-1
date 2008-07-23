using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main ()
	{
		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("title>bug #411213</title>") != -1, "#A1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>BeginRequest:<span id=\"BeginRequestCountLabel\">1</span></p>") != -1, "#A2:" + result);
				Assert.IsTrue (result.IndexOf ("<p>EndRequest:<span id=\"EndRequestCountLabel\">0</span></p>") != -1, "#A3:" + result);
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

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("title>bug #411213</title>") != -1, "#B1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>BeginRequest:<span id=\"BeginRequestCountLabel\">2</span></p>") != -1, "#B2:" + result);
				Assert.IsTrue (result.IndexOf ("<p>EndRequest:<span id=\"EndRequestCountLabel\">1</span></p>") != -1, "#B3:" + result);
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
