using System.Diagnostics;

class Program
{
	static int Main ()
	{
		ProcessStartInfo info = new ProcessStartInfo ("echo", null);
		info.UseShellExecute = false;
		Process p = Process.Start (info);
		p.WaitForExit ();
		if (p.ExitCode != 0)
			return 1;
		return 0;
	}
}
