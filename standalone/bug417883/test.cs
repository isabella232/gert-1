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
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/WebForm1.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<html dir=\"LTR\">") != -1, "#A1:" + result);
				Assert.IsTrue (result.IndexOf ("<title>bug #417883</title>") != -1, "#A2:" + result);
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

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/WebForm2.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			return 2;
		} catch (WebException ex) {
			Assert.AreEqual (typeof (WebException), ex.GetType (), "#B1");
			Assert.IsNull (ex.InnerException, "#B2");
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#B3");

			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.IsNotNull (response, "#B4");

			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (result.IndexOf ("<title>Parser Error</title>") != -1, "#B5:" + result);
			}
		}

		return 0;
	}
}
