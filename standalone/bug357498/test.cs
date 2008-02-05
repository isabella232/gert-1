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
				Assert.IsTrue (result.IndexOf ("<html>") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("his is pretty much the same as registertest.aspx") != -1, "#2:" + result);
				Assert.IsTrue (result.IndexOf ("<span id=\"Message\" style=\"color:blue\">This is a default One!</span>") != -1, "#3:" + result);
				Assert.IsTrue (result.IndexOf ("</html>") != -1, "#4:" + result);
			}
			response.Close ();
			return 0;
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 1;
		}
	}
}
