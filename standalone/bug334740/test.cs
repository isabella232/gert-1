using System;
using System.Timers;
using ST = System.Threading;

class Program
{
	static int Main ()
	{
		for (int i = 0; i < 10; i++) {
			if (!new RaceTest (true).Success)
				return 1;
			if (!new RaceTest (false).Success)
				return 2;
		}
		return 0;
	}
}

class RaceTest
{
	const int Threads = 2;
	const int Loops = 100;

	object locker = new object ();
	Timer timer;
	int counter;

	public bool Success
	{
		get { return counter > Loops * Threads; }
	}

	public RaceTest (bool autoReset)
	{
		timer = new Timer ();
		timer.AutoReset = autoReset;
		timer.Interval = 100;
		timer.Elapsed += new ElapsedEventHandler (Tick);
		timer.Start ();

		ST.Thread [] tl = new ST.Thread [Threads];

		for (int i = 0; i < Threads; i++) {
			tl [i] = new ST.Thread (new ST.ThreadStart (Run));
			tl [i].Start ();
		}

		for (int i = 0; i < Threads; i++) {
			tl [i].Join ();
		}

		ST.Thread.Sleep (1000);
	}

	void Restart ()
	{
		lock (locker) {
			timer.Stop ();
			timer.Start ();
		}
		ST.Interlocked.Increment (ref counter);
	}

	void Tick (object sender, ElapsedEventArgs e)
	{
		Restart ();
	}

	void Run ()
	{
		for (int i = 0; i < Loops; i++) {
			ST.Thread.Sleep (0);
			Restart ();
		}
	}
}
