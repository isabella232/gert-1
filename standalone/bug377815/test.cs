using System;
using System.Diagnostics;
using System.IO;

class Program
{
	static int Main (string [] args)
	{
		ProcessStartInfo processStartInfo = new ProcessStartInfo ();
		processStartInfo.FileName = "launchee.exe";
		processStartInfo.UseShellExecute = false;
		Process launchee = Process.Start (processStartInfo);
		launchee.WaitForExit ();
		if (launchee.ExitCode != 0)
			return 1;

		string dir = AppDomain.CurrentDomain.BaseDirectory;
		if (!File.Exists (Path.Combine (dir, "started")))
			return 2;

		return 0;
	}
}
