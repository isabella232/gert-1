using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main ()
	{
		string hostName = Environment.GetEnvironmentVariable ("MONO_TESTS_HOSTNAME");
		if (hostName == null) {
			Console.WriteLine ("The MONO_TESTS_HOSTNAME "
				+ "environment variable is not set.");
			return 1;
		}

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("https://" + hostName + ":4443/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("<p>OK</p>") == -1) {
					Console.WriteLine (result);
					return 1;
				}
			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			} else {
				Console.WriteLine (ex.ToString ());
			}
			return 2;
		}

		return 0;
	}
}
