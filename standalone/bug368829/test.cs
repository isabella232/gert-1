using System;
using System.Diagnostics;

class Program
{
	static void Main ()
	{
		Process process = new Process ();
		process.StartInfo.FileName = "echo";
		process.StartInfo.Arguments = "Mono Rocks!";
		process.StartInfo.CreateNoWindow = true;
		process.StartInfo.UseShellExecute = true;
		process.Start ();
		process.WaitForExit ();
	}
}
