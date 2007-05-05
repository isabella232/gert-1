using System;
using System.Diagnostics;
using System.Globalization;

class MainClass
{
	public static void Main (string [] args)
	{
		for (int i = 0; i < 200; i++) {
			DiskSpaceUsage ("./");
		}
	}

	private static void DiskSpaceUsage (string directory)
	{
		Process df = new System.Diagnostics.Process ();
		df.StartInfo.FileName = "df";
		df.StartInfo.Arguments = "--block-size=1";
		df.StartInfo.UseShellExecute = false;
		df.StartInfo.RedirectStandardError = true;
		df.StartInfo.RedirectStandardOutput = true;

		df.Start ();
		df.WaitForExit (90000);
		if (!df.HasExited) {
			df.Close ();
			df.Dispose ();
			throw new Exception ("Timeout expired (90'')");
		}

		string error = df.StandardError.ReadToEnd ();
		if (error.Length > 0)
			throw new Exception ("Execution error: " + error);

		string output = df.StandardOutput.ReadToEnd ();
		if (output.Length == 0) {
			System.Console.WriteLine (output);
		}

		df.Close ();
		df.Dispose ();
	}
}
