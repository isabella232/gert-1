using System;
using System.Threading;

class Program
{
	static int numThreads = 10;
	static int iterationsPerThread = 200;
	static int errorCount;

	static int Main ()
	{
		Thread [] threads = new Thread [numThreads];
		for (int i = 0; i < numThreads; i++) {
			threads [i] = new Thread (new ThreadStart (RunBugReportService));
			threads [i].Start ();
		}

		for (int i = 0; i < threads.Length; i++) {
			Thread thread = threads [i];
			thread.Join ();
		}

		return errorCount;
	}

	static void RunBugReportService ()
	{
		for (int i = 0; i < iterationsPerThread; i++) {
			try {
				using (BugReportService service = new BugReportService ()) {
					service.Connect ("google.com", 80);
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.ToString ());
				errorCount++;
			}
		}
	}
}
