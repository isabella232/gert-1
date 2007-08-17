using System;
using System.Threading;

public class Test
{
	public static void Main (string [] arg)
	{
		for (int i = 0; i < 10; i++)
			new Thread (new ThreadStart(new Test (i).Runner)).Start ();
	}

	public Test (int tid)
	{
		this.tid = tid;
	}

	public void Runner ()
	{
		Console.WriteLine ("Thread {0} Starting", tid);
		timer = new Timer (new TimerCallback(Callback), null, 50, 50);
		Console.WriteLine ("Thread {0} Finished", tid);
	}

	void Callback (object state)
	{
		Console.WriteLine ("Callback on Thread: {0}", tid);
		timer.Dispose ();
	}

	private int tid;
	private Timer timer;
}
