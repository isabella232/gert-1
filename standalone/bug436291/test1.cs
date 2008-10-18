using System;
using System.Diagnostics;
using System.IO;

namespace App1
{
	class App1
	{
		static void Main (string [] args)
		{
			ProcessStartInfo si;
			string basedir = AppDomain.CurrentDomain.BaseDirectory;
			string exe = Path.Combine (basedir, "test2.exe");
#if MONO
			si = new ProcessStartInfo (args [0], exe);
#else
			si = new ProcessStartInfo (exe);
#endif
			si.UseShellExecute = false;
			si.RedirectStandardInput = true;
			si.RedirectStandardError = true;
			si.RedirectStandardOutput = true;

			Process p = Process.Start (si);
			p.StandardInput.WriteLine ("Hello world");
			p.StandardInput.Write ("Hello world 2");
			p.StandardInput.Flush ();
			p.StandardInput.Close ();

			p.StandardError.Close ();

			string output = p.StandardOutput.ReadToEnd ();
			Assert.AreEqual (string.Concat ("Hello world", Environment.NewLine,
				"Hello world 2"), output, "#1");
		}
	}
}
