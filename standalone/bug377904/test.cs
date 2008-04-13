using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

class Program
{
	static void Main ()
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/index.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			Assert.Fail ("#1");
		} catch (WebException ex) {
			Assert.AreEqual (typeof (WebException), ex.GetType (), "#2");
			Assert.IsNull (ex.InnerException, "#3");
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#4");

			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.IsNotNull (response, "#5");
			Assert.AreEqual (HttpStatusCode.InternalServerError, response.StatusCode, "#6");

			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<title>Compilation Error</title>") != -1, "#7:" + result);
				Assert.IsTrue (result.IndexOf ("Compiler Error Message:") != -1, "#8:" + result);
			}
		}
	}
}
