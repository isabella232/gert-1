using System;
using System.Threading;

class Program
{
	static ManualResetEvent the_event;

	static void Main ()
	{
		the_event = new ManualResetEvent (false);

		Thread thread = new Thread (new ThreadStart(thread_main));
		thread.IsBackground = true;
		thread.Start ();

		Thread.Sleep (1000);
	}

	static void thread_main ()
	{
		the_event.WaitOne ();
	}
}
