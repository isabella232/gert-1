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
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				int found = result.IndexOf ("<p>Select Location</p>");
				if (found == -1) {
					Console.WriteLine (result);
					return 1;
				}
				found = result.IndexOf ("<p>Select Location</p>", found + 22);
				if (found == -1) {
					Console.WriteLine (result);
					return 2;
				}
				found = result.IndexOf ("<p>Select Location</p>", found + 22);
				if (found == -1) {
					Console.WriteLine (result);
					return 3;
				}
				found = result.IndexOf ("<p>Select Location</p>", found + 22);
				if (found != -1) {
					Console.WriteLine (result);
					return 4;
				}
			}
			response.Close ();
			return 0;
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 2;
		}
	}
}
