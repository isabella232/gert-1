using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

class Program
{
	static void Main (string [] args)
	{
		if (args.Length == 1)
			Environment.Exit (Int32.Parse (args [0]));

		Run ("false", string.Empty, 1, "#1");
		Run ("true", string.Empty, 0, "#2");

		// absolute paths may need updating
		Run (args [0], "test.exe 1", 1, "#3");
		Run (args [0], "./test.exe 234", 234, "#4");
	}

	static void Run (string fileName, string arguments, int expected, string msg)
	{
		Process proc = new Process ();
		proc.StartInfo = new ProcessStartInfo ();
		proc.StartInfo.FileName = fileName;
		proc.StartInfo.Arguments = arguments;
		proc.Start ();
		while (!proc.HasExited)
			Thread.Sleep (100);
		if (proc.ExitCode != expected)
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Exit status was {0}, expected {1}. {2}",
				proc.ExitCode, expected, msg));
	}
}
