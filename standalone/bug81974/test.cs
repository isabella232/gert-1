using System.Threading;

class Program
{
	static int ThreadCount = 1000;

	static void Main ()
	{
		Thread [] threads = new Thread [ThreadCount];

		for (int i = 0; i < ThreadCount; i++) {
			threads [i] = new Thread (ThreadTask);
			threads [i].Start ();
		}

		for (int i = 0; i < ThreadCount; i++) {
			threads [i].Join ();
		}
	}

	static void ThreadTask ()
	{
		Thread.Sleep (1000);
	}
}
