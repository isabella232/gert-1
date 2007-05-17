using System;
using System.Threading;

class Program
{
	static int Main ()
	{
		Thread t1 = new Thread (new ThreadStart (Run));
		t1.ApartmentState = ApartmentState.STA;
		t1.Start ();
		if (t1.ApartmentState != ApartmentState.STA) {
			Console.WriteLine ("#1: " + t1.ApartmentState);
			t1.Abort ();
			t1.Join ();
			return 1;
		}
		t1.Abort ();
		t1.Join ();

		Thread t2 = new Thread (new ThreadStart (Run));
		t2.ApartmentState = ApartmentState.MTA;
		t2.Start ();
		try {
			t2.ApartmentState = ApartmentState.STA;
			t2.Abort ();
			t2.Join ();
			Console.WriteLine ("#2: Expected ThreadStateException");
			return 2;
		} catch (ThreadStateException) {
		}
		t2.Abort ();
		t2.Join ();

		Thread.CurrentThread.ApartmentState = ApartmentState.STA;
#if NET_2_0
		if (Thread.CurrentThread.ApartmentState != ApartmentState.MTA) {
#else
		if (Thread.CurrentThread.ApartmentState != ApartmentState.STA) {
#endif
			Console.WriteLine ("#3: " + Thread.CurrentThread.ApartmentState);
			return 3;
		}

#if NET_2_0
		Thread.CurrentThread.ApartmentState = ApartmentState.Unknown;
		if (Thread.CurrentThread.ApartmentState != ApartmentState.MTA) {
			Console.WriteLine ("#4: " + Thread.CurrentThread.ApartmentState);
			return 4;
		}
#else
		try {
			Thread.CurrentThread.ApartmentState = ApartmentState.Unknown;
			Console.WriteLine ("#4: Expected ArgumentOutOfRangeException");
			return 4;
		} catch (ArgumentOutOfRangeException) {
		}
#endif

		Thread.CurrentThread.ApartmentState = ApartmentState.STA;
#if NET_2_0
		if (Thread.CurrentThread.ApartmentState != ApartmentState.STA) {
#else
		if (Thread.CurrentThread.ApartmentState != ApartmentState.STA) {
#endif
			Console.WriteLine ("#5: " + Thread.CurrentThread.ApartmentState);
			return 5;
		}

		Thread.CurrentThread.ApartmentState = ApartmentState.MTA;
#if NET_2_0
		if (Thread.CurrentThread.ApartmentState != ApartmentState.STA) {
#else
		if (Thread.CurrentThread.ApartmentState != ApartmentState.STA) {
#endif
			Console.WriteLine ("#6: " + Thread.CurrentThread.ApartmentState);
			return 6;
		}

		return 0;
	}

	static void Run ()
	{
		Thread.CurrentThread.ApartmentState = ApartmentState.MTA;
		while (true) {
		}
	}
}
