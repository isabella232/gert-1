using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
	static int Main (string [] args)
	{
		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<p>Name: UnknownUser</p>") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>Authenticated: True</p>") != -1, "#2:" + result);
				Assert.IsTrue (result.IndexOf ("<p>AuthenticationType: Custom</p>") != -1, "#3:" + result);
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

		return 0;
	}
}
