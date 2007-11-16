using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;

class Program
{
	static int Main ()
	{
		ArrayList jobs = new ArrayList ();

		Program p = new Program ();

		for (int i = 0; i < 100; i++) {
			ThreadStart job = new ThreadStart (p.regexp_test);
			jobs.Add (new Thread (job));
		}

		foreach (Thread t in jobs)
			t.Start ();

		if (!p.Success)
			return 1;
		return 0;
	}

	void regexp_test ()
	{
		string command = "SELECT READ_WRITE FROM PERMISSIONS WHERE USERID=:puserid AND CALENDARID=:pcalendarid";
		try {
			string [] parames = parameterReplace.Split (command);
			foreach (string param in parames)
				if (param == null)
					return;
		} catch {
			Success = false;
			throw;
		}
	}

	private static Regex parameterReplace = new Regex (@"([:@][\w\.]*)", RegexOptions.Singleline);
	public bool Success = true;
}
