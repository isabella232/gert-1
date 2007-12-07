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

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx?Pippo=ciao,ciao&Pippo=ciao");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("<p>Lenght: 2</p>") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>P[0]: ciao,ciao</p>") != -1, "#2:" + result);
				Assert.IsTrue (result.IndexOf ("<p>P[1]: ciao</p>") != -1, "#3:" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			}
			Assert.Fail ("#4");
		}

		return 0;
	}
}
