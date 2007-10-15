using System;
using System.Globalization;
using System.Threading;

class Program
{
	static int _counter;

	static void Main ()
	{
		new Timer (new TimerCallback (tmrThreadingTimer_TimerCallback), null, 0, 1000);
		while (_counter < 5) {
		}
	}

	static void tmrThreadingTimer_TimerCallback (object state)
	{
		_counter++;
		throw new Exception ("Booom" + _counter.ToString (CultureInfo.InvariantCulture));
	}
}
