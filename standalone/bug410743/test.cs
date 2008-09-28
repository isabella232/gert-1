using System;
using System.Diagnostics;
using System.Threading;

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
				bool exited = proc.WaitForExit (2000);

				Assert.IsTrue (exited, "#1:" + i);
				Assert.IsTrue (proc.HasExited, "#2:" + i);
				Assert.AreEqual (0, proc.ExitCode, "#3:" + i);
				Assert.AreEqual (1, _exitCount, "#4:" + i);

				Thread.Sleep (50);
				_exitCount = 0;
			}
		}
	}

	static void Process_Exited (object sender, EventArgs e)
	{
		_exitCount++;
	}

	static int _exitCount;
}
