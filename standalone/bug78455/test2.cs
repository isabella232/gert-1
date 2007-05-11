using System;
using System.Threading;

class Program
{
	static int Main ()
	{
#if NET_2_0
		if (Thread.CurrentThread.ApartmentState != ApartmentState.MTA)
#else
		if (Thread.CurrentThread.ApartmentState != ApartmentState.Unknown)
#endif
			return 1;

		AutoResetEvent ae = new AutoResetEvent (true);
		AutoResetEvent ae2 = new AutoResetEvent (true);
		if (WaitHandle.WaitAll (new WaitHandle [] { ae, ae2 }, 1000, true))
			return 0;
		return 2;
	}
}
