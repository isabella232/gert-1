using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static int Main (string [] args)
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;
		string webdir = Path.Combine (basedir, "web");
		string bindir = Path.Combine (webdir, "bin");
		string assembly_file = Path.Combine (bindir, "Foo.dll");

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/ShadowCopy.ashx");
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				Assert.IsTrue (IndexOf (result, "<p>CodeBase=" + new Uri (assembly_file).ToString () + "</p>") != -1, "#1:" + result);
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

	static int IndexOf (string source, string value)
	{
		CompareInfo ci = CultureInfo.InvariantCulture.CompareInfo;

		CompareOptions co = RunningOnWindows ? CompareOptions.IgnoreCase
			: CompareOptions.None;

		return ci.IndexOf (source, value, co);
	}

	static bool RunningOnWindows {
		get {
			return (Path.DirectorySeparatorChar == '\\');
		}
	}
}
