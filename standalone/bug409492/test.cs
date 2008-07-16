using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main ()
	{
		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("bug #409492") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("<input type=\"submit\" name=\"btn1\" value=\"Button 1\" id=\"btn1\" />") != -1, "#2:" + result);
				Assert.IsTrue (result.IndexOf ("<input type=\"submit\" name=\"btn2\" value=\"Button 5\" id=\"btn2\" />") != -1, "#3:" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 1;
		}

		return 0;
	}
}
