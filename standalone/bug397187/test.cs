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
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

#if MONO
				Assert.IsTrue (result.IndexOf ("<link href=\"/App_Themes/Default/StyleSheet.css\" type=\"text/css\" rel=\"stylesheet\" />") != -1, "#1:" + result);
#else
				Assert.IsTrue (result.IndexOf ("<link href=\"App_Themes/Default/StyleSheet.css\" type=\"text/css\" rel=\"stylesheet\" />") != -1, "#1:" + result);
#endif
				Assert.IsTrue (result.IndexOf ("bug #397187") != -1, "#2:" + result);
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
