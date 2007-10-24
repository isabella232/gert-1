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

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/static/test.axd");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("TestHandler executed!") == -1) {
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

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/static/test2.axd");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
			}
			response.Close ();
			return 3;
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				string result = sr.ReadToEnd ();
#if ONLY_1_1 && !MONO
				if (result.IndexOf ("File does not exist") == -1) {
#else
				if (result.IndexOf ("Path '/static/test2.axd' was not found") == -1) {
#endif
					Console.WriteLine (result);
					return 4;
				}

				HttpWebResponse response = (HttpWebResponse) ex.Response;
				if (response.StatusCode != HttpStatusCode.NotFound)
					return 5;
			}
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/test3.axd");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("TestHandler executed!") == -1) {
					Console.WriteLine (result);
					return 7;
				}
			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			}
			return 8;
		}

		return 0;
	}
}
