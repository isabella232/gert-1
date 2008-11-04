using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 2) {
			Console.WriteLine ("Please specify test to run.");
			return 1;
		}

		switch (args [0]) {
		case "Global_V1.asax.cs":
			switch (args [1]) {
			case "Global_V1.asax":
				return RunTest ("2", "2", "4", "V1_1");
			case "Global_V2.asax":
#if NET_2_0
				return RunTest ("2", "2", "4", "V1_2");
#else
				return RunTest ("1", "2", "4", "V1_2");
#endif
			case "Global_V3.asax":
#if NET_2_0
				return RunTest ("2", "2", "1", "V1_3");
#else
				return RunTest ("1", "2", "1", "V1_3");
#endif
			default:
				Console.WriteLine ("Unsupported test '{0}|{1}'.", args [0], args [1]);
				return 2;
			}
		case "Global_V2.asax.cs":
			switch (args [1]) {
			case "Global_V1.asax":
				return RunTest ("0", "0", "0", "V2_1");
			case "Global_V2.asax":
				return RunTest ("1", "0", "4", "V2_2");
			case "Global_V3.asax":
				return RunTest ("1", "0", "1", "V2_3");
			default:
				Console.WriteLine ("Unsupported test '{0}|{1}'.", args [0], args [1]);
				return 2;
			}
		case "Global_V3.asax.cs":
			switch (args [1]) {
			case "Global_V1.asax":
#if NET_2_0
				return RunTest ("4", "2", "4", "V3_1");
#else
				return RunTest ("0", "2", "0", "V3_1");
#endif
			case "Global_V2.asax":
#if NET_2_0
				return RunTest ("4", "2", "4", "V3_2");
#else
				return RunTest ("1", "2", "4", "V3_2");
#endif
			case "Global_V3.asax":
#if NET_2_0
				return RunTest ("4", "2", "1", "V3_3");
#else
				return RunTest ("1", "2", "1", "V3_3");
#endif
			default:
				Console.WriteLine ("Unsupported test '{0}|{1}'.", args [0], args [1]);
				return 2;
			}
		case "Global_V4.asax.cs":
			switch (args [1]) {
			case "Global_V1.asax":
				return RunTest ("0", "8", "0", "V4_1");
			case "Global_V2.asax":
				return RunTest ("1", "8", "0", "V4_2");
			case "Global_V3.asax":
				return RunTest ("1", "8", "1", "V4_3");
			default:
				Console.WriteLine ("Unsupported test '{0}|{1}'.", args [0], args [1]);
				return 2;
			}
		case "Global_V5.asax.cs":
			switch (args [1]) {
			case "Global_V1.asax":
				return RunTest ("4", "4", "4", "V5_1");
			case "Global_V2.asax":
				return RunTest ("4", "4", "4", "V5_2");
			case "Global_V3.asax":
				return RunTest ("4", "4", "5", "V5_3");
			default:
				Console.WriteLine ("Unsupported test '{0}|{1}'.", args [0], args [1]);
				return 2;
			}
		case "Global_V6.asax.cs":
			switch (args [1]) {
			case "Global_V1.asax":
				return RunTest ("4", "2", "6", "V6_1");
			case "Global_V2.asax":
				return RunTest ("4", "2", "6", "V6_2");
			case "Global_V3.asax":
				return RunTest ("4", "2", "7", "V6_3");
			default:
				Console.WriteLine ("Unsupported test '{0}|{1}'.", args [0], args [1]);
				return 2;
			}
		default:
			Console.WriteLine ("Unsupported test '{0}'.", args [0]);
			return 2;
		}
	}

	static int RunTest (string appStart, string appBeginRequest, string sessionStart, string id)
	{
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.CookieContainer = new CookieContainer ();
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<span id=\"AppStart\">" + appStart + "</span>") != -1, id + " #1:" + result);
				Assert.IsTrue (result.IndexOf ("<span id=\"AppBeginRequest\">" + appBeginRequest + "</span>") != -1, id + " #2:" + result);
				Assert.IsTrue (result.IndexOf ("<span id=\"SessionStart\">" + sessionStart + "</span>") != -1, id + "#3:" + result);
			}
			response.Close ();
		} catch (WebException ex) {
			Console.WriteLine ("Test " + id + " failed.");
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
