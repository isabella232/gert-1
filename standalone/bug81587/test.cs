using System;
using System.Threading;

class Program
{
	static void MyThreadStart ()
	{
		throw new Exception ();
	}

	static void Main ()
	{
		Thread t = new Thread (new ThreadStart (MyThreadStart));
		t.Start ();
	}
}
