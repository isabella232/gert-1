using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main (string [] args)
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("https://www.microsoft.com");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("<title>Microsoft Corporation</title>") == -1) {
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
