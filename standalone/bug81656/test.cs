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

		Thread t1 = new Thread (new ThreadStart (Run));
		t1.Start ();
#if NET_2_0
		if (t1.ApartmentState != ApartmentState.MTA)
#else
		if (t1.ApartmentState != ApartmentState.Unknown)
#endif
			return 2;
		t1.Join ();

		Thread t2 = new Thread (new ThreadStart (Run));
		t2.ApartmentState = ApartmentState.STA;
		t2.Start ();
		if (t2.ApartmentState != ApartmentState.STA)
			return 3;
		t2.Join ();

		Thread t3 = new Thread (new ThreadStart (Run));
		t3.ApartmentState = ApartmentState.MTA;
		t3.Start ();
		if (t3.ApartmentState != ApartmentState.MTA)
			return 4;
		t3.Join ();

#if NET_2_0
		if (Thread.CurrentThread.ApartmentState != ApartmentState.MTA)
#else
		if (Thread.CurrentThread.ApartmentState != ApartmentState.Unknown)
#endif
			return 4;

		return 0;
	}

	static void Run ()
	{
	}
}
