using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

class Program
{
	static StringBuilder sb = null;

	static bool RunProcess (string runtimeEngine, int numLines)
	{
		string stderr, stdout;
		sb = new StringBuilder ();

		string program = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"output.exe");

		Process proc = new Process ();
		if (!string.IsNullOrEmpty (runtimeEngine)) {
			proc.StartInfo.FileName = runtimeEngine;
			proc.StartInfo.Arguments = string.Format (CultureInfo.InvariantCulture,
				"\"{0}\" {1}", program, numLines);
		} else {
			proc.StartInfo.FileName = program;
			proc.StartInfo.Arguments = string.Format (CultureInfo.InvariantCulture,
				 "{0}", numLines);
		}
		proc.StartInfo.UseShellExecute = false;
		proc.StartInfo.RedirectStandardOutput = true;
		proc.StartInfo.RedirectStandardError = true;
		proc.OutputDataReceived += new DataReceivedEventHandler (OutputHandler);
		proc.Start ();

		proc.BeginOutputReadLine ();
		stderr = proc.StandardError.ReadToEnd ();
		proc.WaitForExit ();

		stdout = sb.ToString ();

		string expectedResult = "STDOUT => 1" + Environment.NewLine +
			"STDOUT => 2" + Environment.NewLine + "STDOUT => 3" +
			Environment.NewLine + "STDOUT => 4" + Environment.NewLine +
			" " + Environment.NewLine + "STDOUT => 6" + Environment.NewLine +
			"STDOUT => 7" + Environment.NewLine + "STDOUT => 8" +
			Environment.NewLine + "STDOUT => 9" + Environment.NewLine;
		if (stdout != expectedResult) {
			Console.WriteLine ("expected:");
			Console.WriteLine (expectedResult);
			Console.WriteLine ("was:");
			Console.WriteLine (stdout);
			return false;
		}

		expectedResult = "STDERR => 1" + Environment.NewLine +
			"STDERR => 2" + Environment.NewLine + "STDERR => 3" +
			Environment.NewLine + "STDERR => 4" + Environment.NewLine +
			" " + Environment.NewLine + "STDERR => 6" + Environment.NewLine +
			"STDERR => 7" + Environment.NewLine + "STDERR => 8" +
			Environment.NewLine + "STDERR => 9" + Environment.NewLine;
		if (stderr != expectedResult) {
			Console.WriteLine ("expected:");
			Console.WriteLine (expectedResult);
			Console.WriteLine ("was:");
			Console.WriteLine (stderr);
			return false;
		}

		return true;
	}

	static void OutputHandler (object process, System.Diagnostics.DataReceivedEventArgs line)
	{
		if (line.Data != null) {
			sb.AppendLine (line.Data);
		}
	}

	static int Main (string [] args)
	{
		string runtimeEngine = null;

		if (args.Length == 1) {
			runtimeEngine = args [0].Trim ();
		}

		for (int i = 0; i < 10; i++) {
			if (!RunProcess (runtimeEngine, 10))
				return 1;
		}
		return 0;
	}
}
