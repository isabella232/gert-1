using System;
using System.Threading;

class Program
{
	static void Main ()
	{
		Foo foo = new Foo ();
		foo.Start ();
		lock (foo) {
			Monitor.Wait (foo);
		}
	}
}

public class Foo
{
	public void Start ()
	{
		Thread thread = new Thread (new ThreadStart (DoStuff));
		thread.Start ();
	}

	void DoStuff ()
	{
		Thread.Sleep (5000);
		lock (this) {
			Monitor.Pulse (this);
		}
	}
}

