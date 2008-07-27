using System;
using System.Diagnostics;

class Program
{
	static int Main ()
	{
		int result = 0;

		for (int i = 0; i < 5; i++) {
			result = Test1 ();
			if (result != 0)
				return result;
		}

		for (int i = 0; i < 5; i++) {
			result = Test2 ();
			if (result != 0)
				break;
		}

		return result;
	}

	static int Test1 ()
	{
		DateTime start = DateTime.Now;
		int pid = LaunchScript ();
		Process p = Process.GetProcessById (pid);
		if (p == null) {
			Console.WriteLine ("Process was not running.");
			return 1;
		}

		Assert.IsFalse (p.HasExited, "#A1");
		Assert.IsNotNull (p.ProcessName, "#A2");

		if (!p.WaitForExit (7000)) {
			Console.WriteLine ("Process has not exited: " + p.HasExited);
			return 2;
		}

		TimeSpan wait_time = DateTime.Now - start;
		Assert.IsTrue (p.HasExited, "#A3");
		Assert.IsTrue (wait_time.TotalMilliseconds > 3000, "#A4:" + wait_time.TotalMilliseconds);
		Assert.IsTrue (wait_time.TotalMilliseconds < 7000, "#A5:" + wait_time.TotalMilliseconds);

		return 0;
	}

	static int Test2 ()
	{
		DateTime start = DateTime.Now;
		int pid = LaunchScript ();
		Process p = Process.GetProcessById (pid);
		if (p == null) {
			Console.WriteLine ("Process was not running.");
			return 3;
		}
		
		Assert.IsFalse (p.HasExited, "#B1");
		Assert.IsNotNull (p.ProcessName, "#B2");

		if (p.WaitForExit (1500)) {
			Console.WriteLine ("Process has exited: " + p.HasExited);
			return 4;
		}

		TimeSpan wait_time = DateTime.Now - start;
		Assert.IsFalse (p.HasExited, "#B3");
		Assert.IsTrue (wait_time.TotalMilliseconds > 1000, "#B4:" + wait_time.TotalMilliseconds);
		Assert.IsTrue (wait_time.TotalMilliseconds < 2000, "#B5:" + wait_time.TotalMilliseconds);

		if (!p.WaitForExit (7000)) {
			Console.WriteLine ("Process has not exited: " + p.HasExited);
			return 5;
		}

		wait_time = DateTime.Now - start;
		Assert.IsTrue (p.HasExited, "#B6");
		Assert.IsTrue (wait_time.TotalMilliseconds > 3000, "#B7:" + wait_time.TotalMilliseconds);
		Assert.IsTrue (wait_time.TotalMilliseconds < 7000, "#B8:" + wait_time.TotalMilliseconds);

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
