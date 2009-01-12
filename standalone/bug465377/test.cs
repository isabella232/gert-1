using System;
using System.Threading;
using System.Runtime.CompilerServices;

public class main
{
	[MethodImplAttribute (MethodImplOptions.Synchronized)]
	public static void thread_func ()
	{
	}

	static int Main ()
	{
		Thread [] threads = new Thread [250];

		for (int i = 0; i < threads.Length; i++) {
			threads [i] = new Thread (new ThreadStart (thread_func));
		}

		for (int i = 0; i < threads.Length; i++) {
			threads [i].Start ();
		}

		for (int i = 0; i < threads.Length; i++) {
			threads [i].Join ();
		}

		return 0;
	}
}
