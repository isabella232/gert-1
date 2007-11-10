using System;
using System.Diagnostics;

class Program
{
	static void Main () {
		for (int i = 0; i < 20; i++)
			RunTest ();
	}

	static void RunTest ()
	{
		ProcessStartInfo info = new ProcessStartInfo ("bash");
		info.Arguments = "test.sh";
		info.UseShellExecute = false;
		info.RedirectStandardOutput = true;
		String line = Process.Start (info).StandardOutput.ReadLine ();
		int pid = Int32.Parse (line);
		Process p = Process.GetProcessById (pid);
		if (p != null) {
			if (p.ProcessName == null)
				throw new Exception ("process name was null");
			p.Kill ();
		} else {
			throw new Exception ("process was null");
		}
	}
}
