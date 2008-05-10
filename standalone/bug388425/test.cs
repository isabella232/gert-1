using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Please specify the test to run.");
			return 1;
		}

		switch (args [0]) {
		case "test1":
			return Test1 ();
		case "test2":
			return Test2 ();
		default:
			Console.WriteLine ("Specified test is not supported.");
			return 2;
		}
	}

	static int Test1 ()
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("bug #388425") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("<span id=\"CompanyV1\">Mono_V1</span>") != -1, "#2:" + result);
				Assert.IsTrue (result.IndexOf ("<span id=\"CompanyV2\">Mono_V2</span>") != -1, "#3:" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			HttpWebResponse response = (HttpWebResponse) ex.Response;
			if (response != null) {
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					Console.WriteLine (sr.ReadToEnd ());
				}
			}
			return 3;
		}

		return 0;
	}

	static int Test2 ()
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		try {
			request.GetResponse ();
			return 3;
		} catch (WebException ex) {
			Assert.AreEqual (typeof (WebException), ex.GetType (), "#1");
			Assert.IsNull (ex.InnerException, "#2");
			Assert.IsNotNull (ex.Message, "#3");
			Assert.AreEqual (WebExceptionStatus.ProtocolError, ex.Status, "#4");

			HttpWebResponse response = (HttpWebResponse) ex.Response;
			Assert.IsNotNull (response, "#5");
			Assert.AreEqual (HttpStatusCode.InternalServerError, response.StatusCode, "#6");

			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("FileLoadException") != -1, "#7");
				Assert.IsTrue (result.IndexOf ("Mono.Web.Test, Version=2.0.0.0, Culture=neutral, PublicKeyToken=8dcf90ebde298dcd") != -1, "#8");
			}
			return 0;
		}
	}
}
