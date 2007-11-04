using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main ()
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/albums/3.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("<title>albumListing</title>") == -1) {
					Console.WriteLine (result);
					return 1;
				}
			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				string result = sr.ReadToEnd ();
#if NET_2_0
#if MONO
				if (result.IndexOf ("System.Web.HttpException: Transfer may only be called from within a Page instance") == -1) {
#else
				if (result.IndexOf ("HttpException") == -1) {
#endif
					Console.WriteLine (result);
					return 2;
				}
				return 0;
#else
				Console.WriteLine (result);
#endif
			}
			return 3;
		}

#if NET_2_0
		return 1;
#else
		return 0;
#endif
	}
}
