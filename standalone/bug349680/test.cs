using System.Diagnostics;
using System.Threading;

class Program
{
	public Program ()
	{
		Thread.Sleep (1000);
	}

	static void Main ()
	{
		// allow only one instance of the process
		Mutex onlyOne = new Mutex (true, Process.GetCurrentProcess ().ProcessName);

		if (onlyOne.WaitOne (0, false)) {
			try {
				new Program ();
			} finally {
				onlyOne.Close ();
				onlyOne = null;
			}
		}
	}
}
