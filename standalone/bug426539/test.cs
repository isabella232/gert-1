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
			Console.WriteLine ("Please specify test to run.");
			return 1;
		}

		switch (args [0]) {
		case "test1":
			return Test1 ();
		case "test2":
			return Test2 ();
		case "test3":
			return Test3 ();
		default:
			Console.WriteLine ("Unsupported test '{0}'.", args [0]);
			return 2;
		}
	}

	static int Test1 ()
	{
		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/DecodeHandler.ashx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<t1>%c3%bc</t1>") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("<t2>%fc</t2>") != -1, "#2:" + result);
				Assert.IsTrue (result.IndexOf ("<t3>%c3%bc</t3>") != -1, "#3:" + result);
				Assert.IsTrue (result.IndexOf ("<t4>%fc</t4>") != -1, "#4:" + result);
				Assert.IsTrue (result.IndexOf ("<t5>True</t5>") != -1, "#5:" + result);
				Assert.IsTrue (result.IndexOf ("<t6>True</t6>") != -1, "#6:" + result);
				Assert.IsTrue (result.IndexOf ("<t7>True</t7>") != -1, "#7:" + result);
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

	static int Test2 ()
	{
		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/DecodeHandler.ashx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<t1>%c3%bc</t1>") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("<t2>%c3%bc</t2>") != -1, "#2:" + result);
				Assert.IsTrue (result.IndexOf ("<t3>%c3%bc</t3>") != -1, "#3:" + result);
				Assert.IsTrue (result.IndexOf ("<t4>%c3%bc</t4>") != -1, "#4:" + result);
				Assert.IsTrue (result.IndexOf ("<t5>True</t5>") != -1, "#5:" + result);
				Assert.IsTrue (result.IndexOf ("<t6>True</t6>") != -1, "#6:" + result);
				Assert.IsTrue (result.IndexOf ("<t7>True</t7>") != -1, "#7:" + result);
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

	static int Test3 ()
	{
		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/DecodeHandler.ashx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

				Assert.IsTrue (result.IndexOf ("<t1>%c3%bc</t1>") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("<t2>%a8%b9</t2>") != -1, "#2:" + result);
				Assert.IsTrue (result.IndexOf ("<t3>%c3%bc</t3>") != -1, "#3:" + result);
				Assert.IsTrue (result.IndexOf ("<t4>%a8%b9</t4>") != -1, "#4:" + result);
				Assert.IsTrue (result.IndexOf ("<t5>True</t5>") != -1, "#5:" + result);
				Assert.IsTrue (result.IndexOf ("<t6>True</t6>") != -1, "#6:" + result);
				Assert.IsTrue (result.IndexOf ("<t7>True</t7>") != -1, "#7:" + result);
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
