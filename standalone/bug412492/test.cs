using System;
using System.Diagnostics;
using System.Threading;

class Program
{
	static int Main ()
	{
		int pid = LaunchScript ();
		Process p = Process.GetProcessById (pid);
		if (p == null) {
			Console.WriteLine ("Process was not running.");
			return 1;
		}

		Assert.IsFalse (p.HasExited, "#A1");
		p.Kill ();
		// allow application to exit
		Thread.Sleep (500);
		Assert.IsTrue (p.HasExited, "#A2");

		try {
			Process.GetProcessById (pid);
			Assert.Fail ("#B1");
		} catch (ArgumentException ex) {
			// Process with an Id of 2228 is not running
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");
			Assert.IsNull (ex.ParamName, "#B5");
		}

		return 0;
	}

	static int LaunchScript ()
	{
		ProcessStartInfo info;

		if (RunningOnUnix) {
			info = new ProcessStartInfo ("bash");
			info.Arguments = "test.sh";
		} else {
			info = new ProcessStartInfo ("cmd");
			info.Arguments = "/c PING -n 5 127.0.0.1 > nul";
		}
		info.UseShellExecute = false;
		info.RedirectStandardOutput = true;

		if (RunningOnUnix) {
			String line = Process.Start (info).StandardOutput.ReadLine ();
			return Int32.Parse (line);
		} else {
			Process p = Process.Start (info);
			return p.Id;
		}
	}

	static bool RunningOnUnix {
		get {
#if NET_2_0
			return Environment.OSVersion.Platform == PlatformID.Unix;
#else
			return (int) Environment.OSVersion.Platform == 128;
#endif
		}
	}
}
