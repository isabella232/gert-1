using System;
using System.Threading;

class Program
{
	static int _progress = 0;

	static int Main ()
	{
		try {
			try {
				_progress += 1;
				Thread.CurrentThread.Interrupt ();
			} finally {
				_progress += 2;
				Thread.Sleep (100);
				_progress += 4;
			}

			try {
				throw new Exception ();
			} catch (Exception) {
				_progress += 8;
				Thread.Sleep (100);
				_progress += 16;
			}

			_progress += 32;
			Thread.Sleep (100);
			_progress += 64;
		} catch (ThreadInterruptedException) {
			_progress += 128;
		}

#if NET_2_0
		return _progress == 191 ? 0 : _progress;
#else
		return _progress == 131 ? 0 : _progress;
#endif
	}
}
