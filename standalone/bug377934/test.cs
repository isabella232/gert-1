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
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8082/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<span id=\"Label1\">13/08/2008</span>") != -1, "#A1:" + result);
				Assert.IsTrue (result.IndexOf ("<span id=\"Label2\">13/08/2008</span>") != -1, "#A2:" + result);
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
