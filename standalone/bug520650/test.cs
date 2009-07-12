using System;
using System.Diagnostics;
using System.IO;

class MainClass
{
	static void Main ()
	{
		Process p;

		ProcessStartInfo psi = CreateStartInfo ();
		p = Process.Start (psi);
		p.WaitForExit ();
		Assert.AreEqual ("FOO=\"bar\"", p.StandardOutput.ReadLine (), "#1");
		psi.EnvironmentVariables.Clear ();
		p = Process.Start (psi);
		p.WaitForExit ();
		Assert.AreEqual (RunningOnWindows ? "FOO=\"%foo%\"" : "FOO=\"$foo\"",
			p.StandardOutput.ReadLine (), "#2");
	}

	static ProcessStartInfo CreateStartInfo ()
	{
		ProcessStartInfo psi = new ProcessStartInfo ();
		psi.FileName = RunningOnWindows ? "cmd" : "/bin/sh";
		psi.UseShellExecute = false;
		psi.Arguments = RunningOnWindows ? "/c echo FOO=\"%foo%\"" : "-c 'echo FOO=\"$foo\"'";
		psi.RedirectStandardOutput = true;
		return psi;
	}

	static bool RunningOnWindows {
		get { return Path.DirectorySeparatorChar == '\\'; }
	}
}
