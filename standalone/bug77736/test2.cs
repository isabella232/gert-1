using System;
using System.Diagnostics;

public class MyClass
{
	public static int Main ()
	{
		Process p = Process.GetCurrentProcess ();

		DateTime t1 = DateTime.Now;
		p.WaitForExit (2000);
		DateTime t2 = DateTime.Now;

		TimeSpan waitTime = t2 - t1;
		if (waitTime < new TimeSpan(0, 0, 2) || waitTime > new TimeSpan(0, 0, 3))
			return 1;
		return 0;
	}
}
