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
			Console.Error.WriteLine ("Please specify the expected bin directory.");
			return 1;
		}

		string webDir = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"web");

		string binDir = args [0];
		if (!IsRunningOnUnix)
			binDir = args [0].ToLower (CultureInfo.InvariantCulture);
		string fullBinDir = Path.Combine (webDir, binDir);

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.Method = "GET";

		HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
		using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
			string result = sr.ReadToEnd ();
#if NET_2_0
			if (result.IndexOf ("<p>PrivateBinPath=" + fullBinDir + "</p>") == -1) {
#else
			if (result.IndexOf ("<p>PrivateBinPath=" + binDir + "</p>") == -1) {
#endif
				Console.WriteLine (result);
				return 1;
			}
			if (result.IndexOf ("<p>BinDirectory=" + fullBinDir + Path.DirectorySeparatorChar + "</p>") == -1) {
				Console.WriteLine (result);
				return 2;
			}
		}
		response.Close ();

		return 0;
	}

	static bool IsRunningOnUnix {
		get
		{
			PlatformID pid = Environment.OSVersion.Platform;
#if NET_2_0
			return pid == PlatformID.Unix;
#else
			return ((int) pid == 128 || (int) pid == 4);
#endif
		}
	}
}
