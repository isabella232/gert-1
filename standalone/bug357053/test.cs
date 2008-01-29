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
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.GetEncoding ("iso-8859-1"), true)) {
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("<p>Umlaute: צהü</p>") == -1) {
					Console.WriteLine (result);
					return 1;
				}
			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			}
			return 2;
		}

		return 0;
	}
}
