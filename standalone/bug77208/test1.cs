using System;
using System.Threading;

class Program
{
	static int _progress = 0;

	static int Main ()
	{
		Thread t = new Thread (new ThreadStart (Oops));
		t.Start ();
		Thread.Sleep (1000);
		t.Abort ();
		t.Join ();
#if NET_2_0
		return _progress == 23 ? 0 : _progress;
#else
		return _progress == 27 ? 0 : _progress;
#endif
	}

	static void Oops ()
	{
		try {
			try {
				_progress += 1;
			} finally {
				_progress += 2;
				Thread.Sleep (5000);
				_progress += 4;
			}
		} catch (ThreadAbortException) {
			_progress += 8;
		} finally {
			_progress += 16;
		}
	}
}
