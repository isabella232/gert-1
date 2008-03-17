using System;
using System.Diagnostics;
using System.Globalization;

class Program
{
	static void Main ()
	{
		Process p = new Process ();
		p.StartInfo.FileName = RunningOnUnix ? "gnome-open" : "explorer.exe";
		p.StartInfo.Arguments = "http://www.google.be#whatever";
		p.Start ();
		p.WaitForExit ();
	}

	static bool RunningOnUnix {
		get {
#if NET_2_0
			return Environment.OSVersion.Platform == PlatformID.Unix;
#else
			return (int) Environment.OSVersion.Platform == 128;
#endif
		}
	}
}
