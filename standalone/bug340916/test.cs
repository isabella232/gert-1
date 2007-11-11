using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main ()
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "POST";

		ASCIIEncoding ascii = new ASCIIEncoding ();
		byte [] byData = ascii.GetBytes ("Mono ASP.NET");
		request.ContentLength = byData.Length;
		Stream rs = request.GetRequestStream ();
		rs.Write (byData, 0, byData.Length);
		rs.Flush ();

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("<p>REQ:0</p>") == -1) {
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
