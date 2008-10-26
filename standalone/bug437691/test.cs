using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Please specify test to run.");
			return 1;
		}

		switch (args [0]) {
		case "test1":
			return RunTest ("6", "1");
		case "test2":
			return RunTest ("0", "0");
		case "test3":
#if NET_2_0
			return RunTest ("6", "0");
#else
			return RunTest ("4", "0");
#endif
		case "test4":
			return RunTest ("9", "1");
		default:
			Console.WriteLine ("Unsupported test '{0}'.", args [0]);
			return 2;
		}
	}

	static int RunTest (string appStart, string sessionStart)
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.CookieContainer = new CookieContainer ();
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<span id=\"AppStart\">" + appStart + "</span>") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("<span id=\"SessionStart\">" + sessionStart + "</span>") != -1, "#2:" + result);
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
