using System;
using System.Diagnostics;

class Program
{
	static void Main ()
	{
		for (int i = 0; i < 500; i++) {
			using (Process proc = new Process ()) {
				proc.StartInfo = new ProcessStartInfo ("echo");
				proc.EnableRaisingEvents = true;
				proc.StartInfo.RedirectStandardOutput = true;
				proc.StartInfo.UseShellExecute = false;
				proc.Exited += new EventHandler (Process_Exited);
				proc.Start ();
				proc.WaitForExit (2000);

				Assert.IsTrue (proc.HasExited, "#1:" + i);
				Assert.AreEqual (0, proc.ExitCode, "#2:" + i);
			}
		}

		Assert.AreEqual (500, _exitCount, "#3");
	}

	static void Process_Exited (object sender, EventArgs e)
	{
		_exitCount++;
	}

	static int _exitCount;
}
