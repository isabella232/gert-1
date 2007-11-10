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
			}
			response.Close ();
			return 1;
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				if (response.StatusCode != HttpStatusCode.InternalServerError)
					return 2;

				StreamReader sr = new StreamReader (response.GetResponseStream ());
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("HttpParseException") == -1) {
					Console.WriteLine (result);
					return 3;
				}
				if (result.IndexOf ("Only Content controls are allowed directly in a content page that contains Content controls.") == -1) {
					Console.WriteLine (result);
					return 4;
				}
			} else {
				return 5;
			}
		}

		return 0;
	}
}
