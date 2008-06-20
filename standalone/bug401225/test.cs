using System;
using System.Diagnostics;
using System.IO;

public class Test
{
	public static int Main (string [] args)
	{
		if (args.Length < 1) {
			Console.WriteLine ("Specify the test to run.");
			return 1;
		}

		if (args [0] == "fork") {
#if MONO
			if (args.Length != 2) {
				Console.WriteLine ("Specify the path to the mono runtime.");
				return 2;
			}
#endif

			Process proc = new Process ();
#if MONO
			proc.StartInfo.FileName = args [1];
			proc.StartInfo.Arguments = "\"" + Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "test.exe") + "\" test";
#else
			proc.StartInfo.FileName = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "test.exe");
			proc.StartInfo.Arguments = "test";
#endif
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.RedirectStandardInput = true;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.Start ();

			try {
				string output = proc.StandardOutput.ReadLine ();
				if (output != (new string ('h', 10000) + 'a'))
					return 1;
			} finally {
				proc.Kill ();
			}
		} else {
			Console.WriteLine (new string ('h', 10000) + 'a');
			Console.ReadLine ();
		}

		return 0;
	}
}
