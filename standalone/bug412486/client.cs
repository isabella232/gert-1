using System;
using System.Diagnostics;
using System.Threading;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Please specify pid.");
			return 1;
		}

		Process p = Process.GetProcessById (int.Parse (args [0]));
		if (p == null) {
			Console.WriteLine ("Process is no longer running.");
			return 2;
		}

		if (!p.WaitForExit (10000)) {
			Console.WriteLine ("Process has not exited: " + p.HasExited);
			return 3;
		}

		if (!p.HasExited)
			return 4;

		return 0;
	}
}
