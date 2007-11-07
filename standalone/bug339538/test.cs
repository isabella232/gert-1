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
				if (response.StatusCode != HttpStatusCode.Created)
					return 1;
				if (result != "output override: /Default.aspx") {
					Console.WriteLine (result);
					return 2;
				}
			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			}
			return 3;
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Error.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				if (response.StatusCode != HttpStatusCode.Accepted)
					return 4;
#if NET_2_0
				if (result.IndexOf ("error override: System.Web.HttpUnhandledException: Exception of type 'System.Web.HttpUnhandledException' was thrown. ---> System.Exception: my exception") == -1) {
#else
				if (result.IndexOf ("error override: System.Web.HttpUnhandledException: Exception of type System.Web.HttpUnhandledException was thrown. ---> System.Exception: my exception") == -1) {
#endif
					Console.WriteLine (result);
					return 5;
				}
			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			}
			return 6;
		}

		return 0;
	}
}
