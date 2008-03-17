using System;
using System.Diagnostics;
using System.Globalization;

class Program
{
	static void Main ()
	{
		Process p = new Process ();
		p.StartInfo.FileName = "echo";
		p.StartInfo.Arguments = "http://www.google.be#whatever";
		p.StartInfo.RedirectStandardOutput = true;
		p.StartInfo.UseShellExecute = false;
		p.Start ();
		p.WaitForExit ();
		Assert.AreEqual (0, p.ExitCode, "#1");

		string result = p.StandardOutput.ReadToEnd ();
		Assert.AreEqual ("http://www.google.be#whatever\n", result, "#2");
	}
}
