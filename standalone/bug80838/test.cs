using System;
using System.Diagnostics;
using System.IO;

class Program
{
	static int Main (string [] args)
	{
		string runtimeEngine = null;

		if (args.Length == 0)
			return 1;

		if (args.Length > 1 && args [1].Length > 0)
			runtimeEngine = args [1];

		if (args [0] == "nested")
			return 0;

		string program = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"test.exe");

		ProcessStartInfo pinfo = null;
		if (runtimeEngine != null) {
			pinfo = new ProcessStartInfo (runtimeEngine, "\"" + program + "\" nested");
		} else {
			pinfo = new ProcessStartInfo (program, "nested");
		}

		pinfo.UseShellExecute = false;
		pinfo.RedirectStandardInput = true;
		pinfo.RedirectStandardOutput = true;

		Process p = Process.Start (pinfo);
		if (p.StandardOutput.CurrentEncoding != Console.OutputEncoding)
			return 2;
		if (p.StandardInput.Encoding != Console.InputEncoding)
			return 3;
		return 0;
	}
}
