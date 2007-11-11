using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main ()
	{
	

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("https://localhost:4443/Default.aspx");
		request.Method = "POST";
		request.KeepAlive = true;
		request.AllowAutoRedirect = true;
		request.AllowWriteStreamBuffering = true;
		request.ContentType = "application/x-www-form-urlencoded";

		ASCIIEncoding ascii = new ASCIIEncoding ();
		byte [] byData = ascii.GetBytes ("MONO ASP.NET");
		request.ContentLength = byData.Length;
		using (Stream rs = request.GetRequestStream ()) {
			rs.Write (byData, 0, byData.Length);
			rs.Flush ();
		}

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
