using System;
using System.ComponentModel;
using System.Diagnostics;

class Program
{
	static int Main ()
	{
		Process p = Process.GetCurrentProcess ();

		if (IsRunningOnWindows) {
			p.PriorityClass = ProcessPriorityClass.AboveNormal;
			if (p.PriorityClass != ProcessPriorityClass.AboveNormal)
				return 1;

			p.PriorityClass = ProcessPriorityClass.High;
			if (p.PriorityClass != ProcessPriorityClass.High)
				return 2;

			p.PriorityClass = ProcessPriorityClass.BelowNormal;
			if (p.PriorityClass != ProcessPriorityClass.BelowNormal)
				return 3;

			p.PriorityClass = ProcessPriorityClass.Idle;
			if (p.PriorityClass != ProcessPriorityClass.Idle)
				return 4;

			p.PriorityClass = ProcessPriorityClass.Normal;
			if (p.PriorityClass != ProcessPriorityClass.Normal)
				return 5;
		} else {
			// On Unix, non-roots cannot raise the priority
			p.PriorityClass = ProcessPriorityClass.Normal;
			if (p.PriorityClass != ProcessPriorityClass.Normal)
				return 6;

			p.PriorityClass = ProcessPriorityClass.BelowNormal;
			if (p.PriorityClass != ProcessPriorityClass.BelowNormal)
				return 7;

			p.PriorityClass = ProcessPriorityClass.Idle;
			if (p.PriorityClass != ProcessPriorityClass.Idle)
				return 8;
		}

		try {
			p.PriorityClass = (ProcessPriorityClass) (-1);
		} catch (InvalidEnumArgumentException) {
			// ok
		} catch {
			return 9;
		}

		return 0;
	}

	static bool IsRunningOnWindows {
		get {
			int platform = (int) Environment.OSVersion.Platform;
			return !(platform == 4 || platform == 128);
		}
	}
}
