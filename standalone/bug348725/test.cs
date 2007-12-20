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
#if NET_2_0
				if (result.IndexOf ("<p id=\"p1\">Hello World!</p>") == -1) {
#else
				if (result.IndexOf ("<p id=\"p1\"><%$ AppSettings: Test %></p>") == -1) {
#endif
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

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Index.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
#if NET_2_0
				Console.WriteLine (result);
#else
				if (result.IndexOf ("<p id=\"p2\"><%$ AppSettings: DoesNotExist %></p>") == -1) {
					Console.WriteLine (result);
					return 3;
				}
#endif
			}
			response.Close ();
#if NET_2_0
			return 3;
#endif
		} catch (WebException ex) {
#if NET_2_0
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("The application setting 'DoesNotExist' was not found") == -1) {
					Console.WriteLine (result);
					return 4;
				}
			} else {
				return 5;
			}
#else
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			}
			return 4;
#endif
		}

		return 0;
	}
}
