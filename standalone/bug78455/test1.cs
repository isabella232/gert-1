using System;
using System.Threading;

class Program
{
	[STAThread]
	static int Main ()
	{
		AutoResetEvent ae = new AutoResetEvent (true);
		AutoResetEvent ae2 = new AutoResetEvent (true);

		if (Thread.CurrentThread.ApartmentState != ApartmentState.STA)
			return 1;

		try {
			WaitHandle.WaitAll (new WaitHandle [] { ae, ae2 }, 1000, true);
			return 2;
		} catch (NotSupportedException) {
			return 0;
		}
	}
}
