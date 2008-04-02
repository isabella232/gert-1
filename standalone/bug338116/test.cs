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

			string [] privateBinPaths = ExtractPath ("PrivateBinPath", result);
			if (privateBinPaths == null) {
				Console.WriteLine (result);
				return 1;
			}
			if (privateBinPaths.Length != 1) {
				Console.WriteLine (result);
				return 2;
			}
#if NET_2_0
			if (!ContainsPath (privateBinPaths, fullBinDir)) {
#else
			if (!ContainsPath (privateBinPaths, binDir)) {
#endif
				Console.WriteLine (result);
				return 3;
			}

			string [] binDirectories = ExtractPath ("BinDirectory", result);
			if (binDirectories == null) {
				Console.WriteLine (result);
				return 4;
			}
			if (binDirectories.Length != 1) {
				Console.WriteLine (result);
				return 5;
			}
			if (binDirectories [0] != (fullBinDir + Path.DirectorySeparatorChar)) {
				Console.WriteLine (result);
				return 6;
			}
		}
		response.Close ();

		return 0;
	}

	static string [] ExtractPath (string name, string output)
	{
		string search = "<p>" + name + "=";

		int start = output.IndexOf (search);
		if (start != -1) {
			int end = output.IndexOf ("</p>", start + search.Length);
			if (end != -1) {
				string paths = output.Substring (start + search.Length,
					end - (start + search.Length));
				return paths.Split (';');
			}
		}
		return null;
	}

	static bool ContainsPath (string [] paths, string search)
	{
		for (int i = 0; i < paths.Length; i++) {
			if (paths [i] == search)
				return true;
		}
		return false;
	}

	static bool IsRunningOnUnix
	{
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
