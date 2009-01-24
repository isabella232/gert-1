using System;
using System.Threading;
using System.Runtime.CompilerServices;

public class main
{
	static int global = 0;
	static Random random = new Random ();

	public static int fib (int i)
	{
		if (i < 2)
			return i;
		return fib (i - 2) + fib (i - 1);
	}

	[MethodImplAttribute (MethodImplOptions.Synchronized)]
	public static bool synch ()
	{
		if (global != 0)
			return false;
		global = 1;
		fib (random.Next (5, 12));
		global = 0;
		return true;
	}

	public static void thread_func ()
	{
		int i;

		for (i = 0; i < 1000; ++i)
			if (!synch ()) {
				Environment.Exit (1);
			}
	}

	static int Main ()
	{
		Thread [] threads = new Thread [100];

		for (int i = 0; i < threads.Length; i++) {
			Thread t = new Thread (new ThreadStart (thread_func));
			threads [i] = t;
		}

		for (int i = 0; i < threads.Length; i++)
			threads [i].Start ();

		for (int i = 0; i < threads.Length; i++)
			threads [i].Join ();

		return 0;
	}
}
