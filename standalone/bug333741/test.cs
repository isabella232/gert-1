using System;
using System.Diagnostics;

class Program
{
	static int Main ()
	{
		Process p = Process.GetCurrentProcess ();
		if (p.ProcessName != "test") {
			Console.WriteLine (p.ProcessName);
			return 1;
		}
		return 0;
	}
}
