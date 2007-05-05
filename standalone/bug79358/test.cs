using System;
using System.Threading;

class Program
{
	static int Main (string [] args)
	{
		Mutex mutex = new Mutex ();
		mutex.WaitOne ();
		mutex.ReleaseMutex ();
		try {
			mutex.ReleaseMutex ();
			return 1;
		} catch (ApplicationException) {
			return 0;
		}
	}
}
