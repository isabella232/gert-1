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

		HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
		using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
			string result = sr.ReadToEnd ();
			if (result.IndexOf ("<title>albumListing</title>") == -1) {
				Console.WriteLine (result);
				return 1;
			}
		}
		response.Close ();

		return 0;
	}
}
