using System;
using System.Collections;
using System.Threading;

class Program
{
	static readonly ArrayList _actions = new ArrayList ();
	static readonly object _lock1 = new object ();
	static readonly object _lock2 = new object ();

	static int Main ()
	{
		lock (_lock2) {
			Thread t1;

			lock (_lock1) {
				t1 = new Thread (new ThreadStart(T1));
				t1.Start ();
				Monitor.Wait (_lock1);
			}
			Thread.Sleep (100);
			_actions.Add ("Main: interrupting T1");
			t1.Interrupt ();
		}

#if NET_2_0
		if (_actions.Count != 3) {
#else
		if (_actions.Count != 3) {
#endif
			Console.WriteLine ("#1: " + _actions.Count);
			return 1;
		}

		if ((string) _actions [0] != "T1: started") {
			Console.WriteLine ("#2: " + (string) _actions [0]);
			return 2;
		}

		if ((string) _actions [1] != "T1: trying Lock1") {
			Console.WriteLine ("#3: " + (string) _actions [1]);
			return 3;
		}

		if ((string) _actions [2] != "Main: interrupting T1") {
			Console.WriteLine ("#4: " + (string) _actions [2]);
			return 4;
		}

		return 0;
	}

	static void T1 ()
	{
		_actions.Add ("T1: started");
		lock (_lock1) {
			Monitor.Pulse (_lock1);
		}

		try {
			_actions.Add ("T1: trying Lock1");
			lock (_lock2) {
				_actions.Add ("T1: got Lock1");
			}
		} catch (Exception) {
			_actions.Add ("T1: interrupted");
		}
	}
}
