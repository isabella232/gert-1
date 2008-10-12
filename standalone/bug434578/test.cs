using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

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
		default:
			Console.WriteLine ("Test '{0}' is not supported.", args [0]);
			return 1;
		}
	}

	static int Test1 ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;
		string webdir = Path.Combine (basedir, "web");

		File.Delete (Path.Combine (webdir, "Web.config"));

#if NET_2_0
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/HttpRuntimeConfig_V20.ashx");
#else
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/HttpRuntimeConfig_V11.ashx");
#endif
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

#if NET_2_0
				Assert.IsTrue (result.IndexOf ("<p>ApartmentThreading=False</p>") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>AppRequestQueueLimit=5000</p>") != -1, "#2:" + result);
				Assert.IsTrue (result.IndexOf ("<p>DelayNotificationTimeout=00:00:05</p>") != -1, "#3:" + result);
				Assert.IsTrue (result.IndexOf ("<p>Enable=True</p>") != -1, "#4:" + result);
				Assert.IsTrue (result.IndexOf ("<p>EnableHeaderChecking=True</p>") != -1, "#5:" + result);
				Assert.IsTrue (result.IndexOf ("<p>EnableKernelOutputCache=True</p>") != -1, "#6:" + result);
				Assert.IsTrue (result.IndexOf ("<p>EnableVersionHeader=True</p>") != -1, "#7:" + result);
				Assert.IsTrue (result.IndexOf ("<p>ExecutionTimeout=00:01:50</p>") != -1, "#8:" + result);
				Assert.IsTrue (result.IndexOf ("<p>MaxRequestLength=4096</p>") != -1, "#9:" + result);
				Assert.IsTrue (result.IndexOf ("<p>MaxWaitChangeNotification=0</p>") != -1, "#10:" + result);
				Assert.IsTrue (result.IndexOf ("<p>MinFreeThreads=8</p>") != -1, "#11:" + result);
				Assert.IsTrue (result.IndexOf ("<p>MinLocalRequestFreeThreads=4</p>") != -1, "#12:" + result);
				Assert.IsTrue (result.IndexOf ("<p>RequestLengthDiskThreshold=80</p>") != -1, "#13:" + result);
				Assert.IsTrue (result.IndexOf ("<p>RequireRootedSaveAsPath=True</p>") != -1, "#14:" + result);
				Assert.IsTrue (result.IndexOf ("<p>SendCacheControlHeader=True</p>") != -1, "#15:" + result);
				Assert.IsTrue (result.IndexOf ("<p>ShutdownTimeout=00:01:30</p>") != -1, "#16:" + result);
				Assert.IsTrue (result.IndexOf ("<p>UseFullyQualifiedRedirectUrl=False</p>") != -1, "#17:" + result);
				Assert.IsTrue (result.IndexOf ("<p>WaitChangeNotification=0</p>") != -1, "#18:" + result);
#else
				Hashtable settings = GetSettings (result);
				Setting s;

				Assert.AreEqual (14, settings.Count, "#A");

				s = (Setting) settings ["ApartmentThreading"];
				Assert.IsNotNull (s, "#B1");
				Assert.AreEqual ("ApartmentThreading", s.Name, "#B2");
				Assert.AreEqual ("System.Boolean", s.Type, "#B3");
				Assert.AreEqual ("False", s.Value, "#B4");

				s = (Setting) settings ["AppRequestQueueLimit"];
				Assert.IsNotNull (s, "#C1");
				Assert.AreEqual ("AppRequestQueueLimit", s.Name, "#C2");
				Assert.AreEqual ("System.Int32", s.Type, "#C3");
				Assert.AreEqual ("100", s.Value, "#C4");

				s = (Setting) settings ["DelayNotificationTimeout"];
				Assert.IsNotNull (s, "#D1");
				Assert.AreEqual ("DelayNotificationTimeout", s.Name, "#D2");
				Assert.AreEqual ("System.Int32", s.Type, "#D3");
				Assert.AreEqual ("5", s.Value, "#D4");

				s = (Setting) settings ["EnableHeaderChecking"];
				Assert.IsNotNull (s, "#E1");
				Assert.AreEqual ("EnableHeaderChecking", s.Name, "#E2");
				Assert.AreEqual ("System.Boolean", s.Type, "#E3");
				Assert.AreEqual ("True", s.Value, "#E4");

				s = (Setting) settings ["EnableKernelOutputCache"];
				Assert.IsNotNull (s, "#F1");
				Assert.AreEqual ("EnableKernelOutputCache", s.Name, "#F2");
				Assert.AreEqual ("System.Boolean", s.Type, "#F3");
				Assert.AreEqual ("True", s.Value, "#F4");

				s = (Setting) settings ["ExecutionTimeout"];
				Assert.IsNotNull (s, "#G1");
				Assert.AreEqual ("ExecutionTimeout", s.Name, "#G2");
				Assert.AreEqual ("System.Int32", s.Type, "#G3");
				Assert.AreEqual ("90", s.Value, "#G4");

				s = (Setting) settings ["MaxRequestLength"];
				Assert.IsNotNull (s, "#H1");
				Assert.AreEqual ("MaxRequestLength", s.Name, "#H2");
				Assert.AreEqual ("System.Int32", s.Type, "#H3");
#if MONO
				Assert.AreEqual ("4096", s.Value, "#H4");
#else
				Assert.AreEqual ("4194304", s.Value, "#H4");
#endif

				s = (Setting) settings ["MaxWaitChangeNotification"];
				Assert.IsNotNull (s, "#I1");
				Assert.AreEqual ("MaxWaitChangeNotification", s.Name, "#I2");
				Assert.AreEqual ("System.Int32", s.Type, "#I3");
				Assert.AreEqual ("0", s.Value, "#I4");

				s = (Setting) settings ["MinFreeThreads"];
				Assert.IsNotNull (s, "#J1");
				Assert.AreEqual ("MinFreeThreads", s.Name, "#J2");
				Assert.AreEqual ("System.Int32", s.Type, "#J3");
				Assert.AreEqual ("8", s.Value, "#J4");

				s = (Setting) settings ["MinLocalRequestFreeThreads"];
				Assert.IsNotNull (s, "#K1");
				Assert.AreEqual ("MinLocalRequestFreeThreads", s.Name, "#K2");
				Assert.AreEqual ("System.Int32", s.Type, "#K3");
				Assert.AreEqual ("4", s.Value, "#K4");

				s = (Setting) settings ["SendCacheControlHeader"];
				Assert.IsNotNull (s, "#L1");
				Assert.AreEqual ("SendCacheControlHeader", s.Name, "#L2");
				Assert.AreEqual ("System.Boolean", s.Type, "#L3");
				Assert.AreEqual ("True", s.Value, "#L4");

				s = (Setting) settings ["ShutdownTimeout"];
				Assert.IsNotNull (s, "#M1");
				Assert.AreEqual ("ShutdownTimeout", s.Name, "#M2");
				Assert.AreEqual ("System.Int32", s.Type, "#M3");
				Assert.AreEqual ("90", s.Value, "#M4");

				s = (Setting) settings ["UseFullyQualifiedRedirectUrl"];
				Assert.IsNotNull (s, "#N1");
				Assert.AreEqual ("UseFullyQualifiedRedirectUrl", s.Name, "#N2");
				Assert.AreEqual ("System.Boolean", s.Type, "#N3");
				Assert.AreEqual ("False", s.Value, "#N4");

				s = (Setting) settings ["WaitChangeNotification"];
				Assert.IsNotNull (s, "#O1");
				Assert.AreEqual ("WaitChangeNotification", s.Name, "#O2");
				Assert.AreEqual ("System.Int32", s.Type, "#O3");
				Assert.AreEqual ("0", s.Value, "#O4");
#endif
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
		string basedir = AppDomain.CurrentDomain.BaseDirectory;
		string webdir = Path.Combine (basedir, "web");

#if NET_2_0
		File.Copy (Path.Combine (basedir, "Web_V20.config"),
			Path.Combine (webdir, "Web.config"), true);
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/HttpRuntimeConfig_V20.ashx");
#else
		File.Copy (Path.Combine (basedir, "Web_V11.config"),
			Path.Combine (webdir, "Web.config"), true);
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/HttpRuntimeConfig_V11.ashx");
#endif
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();

#if NET_2_0
				Assert.IsTrue (result.IndexOf ("<p>ApartmentThreading=True</p>") != -1, "#1:" + result);
				Assert.IsTrue (result.IndexOf ("<p>AppRequestQueueLimit=10</p>") != -1, "#2:" + result);
				Assert.IsTrue (result.IndexOf ("<p>DelayNotificationTimeout=00:00:13</p>") != -1, "#3:" + result);
				Assert.IsTrue (result.IndexOf ("<p>Enable=True</p>") != -1, "#4:" + result);
				Assert.IsTrue (result.IndexOf ("<p>EnableHeaderChecking=False</p>") != -1, "#5:" + result);
				Assert.IsTrue (result.IndexOf ("<p>EnableKernelOutputCache=False</p>") != -1, "#6:" + result);
				Assert.IsTrue (result.IndexOf ("<p>EnableVersionHeader=False</p>") != -1, "#7:" + result);
				Assert.IsTrue (result.IndexOf ("<p>ExecutionTimeout=00:00:50</p>") != -1, "#8:" + result);
				Assert.IsTrue (result.IndexOf ("<p>MaxRequestLength=20</p>") != -1, "#9:" + result);
				Assert.IsTrue (result.IndexOf ("<p>MaxWaitChangeNotification=14</p>") != -1, "#10:" + result);
				Assert.IsTrue (result.IndexOf ("<p>MinFreeThreads=7</p>") != -1, "#11:" + result);
				Assert.IsTrue (result.IndexOf ("<p>MinLocalRequestFreeThreads=5</p>") != -1, "#12:" + result);
				Assert.IsTrue (result.IndexOf ("<p>RequestLengthDiskThreshold=543</p>") != -1, "#13:" + result);
				Assert.IsTrue (result.IndexOf ("<p>RequireRootedSaveAsPath=False</p>") != -1, "#14:" + result);
				Assert.IsTrue (result.IndexOf ("<p>SendCacheControlHeader=False</p>") != -1, "#15:" + result);
				Assert.IsTrue (result.IndexOf ("<p>ShutdownTimeout=00:00:08</p>") != -1, "#16:" + result);
				Assert.IsTrue (result.IndexOf ("<p>UseFullyQualifiedRedirectUrl=True</p>") != -1, "#17:" + result);
				Assert.IsTrue (result.IndexOf ("<p>WaitChangeNotification=9</p>") != -1, "#18:" + result);
#else
				Hashtable settings = GetSettings (result);
				Setting s;

				Assert.AreEqual (14, settings.Count, "#A");

				s = (Setting) settings ["ApartmentThreading"];
				Assert.IsNotNull (s, "#B1");
				Assert.AreEqual ("ApartmentThreading", s.Name, "#B2");
				Assert.AreEqual ("System.Boolean", s.Type, "#B3");
				Assert.AreEqual ("True", s.Value, "#B4");

				s = (Setting) settings ["AppRequestQueueLimit"];
				Assert.IsNotNull (s, "#C1");
				Assert.AreEqual ("AppRequestQueueLimit", s.Name, "#C2");
				Assert.AreEqual ("System.Int32", s.Type, "#C3");
				Assert.AreEqual ("10", s.Value, "#C4");

				s = (Setting) settings ["DelayNotificationTimeout"];
				Assert.IsNotNull (s, "#D1");
				Assert.AreEqual ("DelayNotificationTimeout", s.Name, "#D2");
				Assert.AreEqual ("System.Int32", s.Type, "#D3");
				Assert.AreEqual ("13", s.Value, "#D4");

				s = (Setting) settings ["EnableHeaderChecking"];
				Assert.IsNotNull (s, "#E1");
				Assert.AreEqual ("EnableHeaderChecking", s.Name, "#E2");
				Assert.AreEqual ("System.Boolean", s.Type, "#E3");
				Assert.AreEqual ("False", s.Value, "#E4");

				s = (Setting) settings ["EnableKernelOutputCache"];
				Assert.IsNotNull (s, "#F1");
				Assert.AreEqual ("EnableKernelOutputCache", s.Name, "#F2");
				Assert.AreEqual ("System.Boolean", s.Type, "#F3");
				Assert.AreEqual ("False", s.Value, "#F4");

				s = (Setting) settings ["ExecutionTimeout"];
				Assert.IsNotNull (s, "#G1");
				Assert.AreEqual ("ExecutionTimeout", s.Name, "#G2");
				Assert.AreEqual ("System.Int32", s.Type, "#G3");
				Assert.AreEqual ("50", s.Value, "#G4");

				s = (Setting) settings ["MaxRequestLength"];
				Assert.IsNotNull (s, "#H1");
				Assert.AreEqual ("MaxRequestLength", s.Name, "#H2");
				Assert.AreEqual ("System.Int32", s.Type, "#H3");
#if MONO
				Assert.AreEqual ("20", s.Value, "#H4");
#else
				Assert.AreEqual ("20480", s.Value, "#H4");
#endif

				s = (Setting) settings ["MaxWaitChangeNotification"];
				Assert.IsNotNull (s, "#I1");
				Assert.AreEqual ("MaxWaitChangeNotification", s.Name, "#I2");
				Assert.AreEqual ("System.Int32", s.Type, "#I3");
				Assert.AreEqual ("14", s.Value, "#I4");

				s = (Setting) settings ["MinFreeThreads"];
				Assert.IsNotNull (s, "#J1");
				Assert.AreEqual ("MinFreeThreads", s.Name, "#J2");
				Assert.AreEqual ("System.Int32", s.Type, "#J3");
				Assert.AreEqual ("7", s.Value, "#J4");

				s = (Setting) settings ["MinLocalRequestFreeThreads"];
				Assert.IsNotNull (s, "#K1");
				Assert.AreEqual ("MinLocalRequestFreeThreads", s.Name, "#K2");
				Assert.AreEqual ("System.Int32", s.Type, "#K3");
				Assert.AreEqual ("5", s.Value, "#K4");

				s = (Setting) settings ["SendCacheControlHeader"];
				Assert.IsNotNull (s, "#L1");
				Assert.AreEqual ("SendCacheControlHeader", s.Name, "#L2");
				Assert.AreEqual ("System.Boolean", s.Type, "#L3");
				Assert.AreEqual ("False", s.Value, "#L4");

				s = (Setting) settings ["ShutdownTimeout"];
				Assert.IsNotNull (s, "#M1");
				Assert.AreEqual ("ShutdownTimeout", s.Name, "#M2");
				Assert.AreEqual ("System.Int32", s.Type, "#M3");
				Assert.AreEqual ("8", s.Value, "#M4");

				s = (Setting) settings ["UseFullyQualifiedRedirectUrl"];
				Assert.IsNotNull (s, "#N1");
				Assert.AreEqual ("UseFullyQualifiedRedirectUrl", s.Name, "#N2");
				Assert.AreEqual ("System.Boolean", s.Type, "#N3");
				Assert.AreEqual ("True", s.Value, "#N4");

				s = (Setting) settings ["WaitChangeNotification"];
				Assert.IsNotNull (s, "#O1");
				Assert.AreEqual ("WaitChangeNotification", s.Name, "#O2");
				Assert.AreEqual ("System.Int32", s.Type, "#O3");
				Assert.AreEqual ("9", s.Value, "#O4");
#endif
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

#if ONLY_1_1
	static Hashtable GetSettings (string response)
	{
		Hashtable settings = new Hashtable ();

		MatchCollection matches = Regex.Matches (response, @"<p>(?<name>[\w]+)=(?<type>[\w\\.]+)\|(?<value>[\w\\.]+)</p>", RegexOptions.None);
		foreach (Match m in matches) {
			Setting setting = new Setting (m.Groups ["name"].Value,
				m.Groups ["type"].Value, m.Groups ["value"].Value);
			settings.Add (setting.Name, setting);
		}
		return settings;
	}

	class Setting
	{
		readonly string _name;
		readonly string _type;
		readonly string _value;

		public Setting (string name, string type, string value)
		{
			_name = name;
			_type = type;
			_value = value;
		}

		public string Name {
			get { return _name; }
		}

		public string Type {
			get { return _type; }
		}

		public string Value {
			get { return _value; }
		}
	}
#endif
}
