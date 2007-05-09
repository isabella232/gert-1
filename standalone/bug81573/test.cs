using System;
using System.Text;
using System.Threading;

class Program
{
	static int Main (string [] args)
	{
		for (int i = 1; i < 56; i++) {
			try {
				ThreadPool.QueueUserWorkItem (new WaitCallback (StartMethod));
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
				Console.WriteLine (ex.StackTrace);
				return 1;
			}
			Thread.Sleep (100);
		}
		return 0;
	}

	static void StartMethod (Object stateInfo)
	{
		DisplayNumbers (DateTime.Now.Millisecond.ToString ());
		Console.WriteLine ("Thread Finished");
	}

	static void DisplayNumbers (string GivenThreadName)
	{
		Console.WriteLine ("Starting thread: " + GivenThreadName);

		for (int i = 1; i <= 800; i++) {
			if (i % 100 == 0) {
				Console.WriteLine ("thread: " + GivenThreadName + " Count " + i);
				Thread.Sleep (1000);
			}
		}
	}
}

