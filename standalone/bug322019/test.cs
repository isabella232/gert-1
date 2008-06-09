using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Threading;

class Program
{
	static readonly object _lock = new object ();
	static int _domainCount;

	public static void ThreadProc ()
	{
		int counter;

		lock (_lock) {
			_domainCount++;
			counter = _domainCount;
		}
		AppDomain domain = AppDomain.CreateDomain ("UnityRuntime " + counter);
		domain.ExecuteAssembly ("fork.exe", null,
			new string [] { counter.ToString (CultureInfo.InvariantCulture) });
	}

	static void Main ()
	{
		Thread [] threads = new Thread [50];

		for (int i = 0; i < threads.Length; i++) {
			Thread t = new Thread (new ThreadStart (ThreadProc));
			threads [i] = t;
			t.Start ();
		}

		for (int i = 0; i < threads.Length; i++) {
			Thread t = threads [i];
			t.Join ();
		}

		for (int i = 0; i < threads.Length; i++) {
			string file = "started_" + (i + 1).ToString (CultureInfo.InvariantCulture);
			Assert.IsTrue (File.Exists (file), file);
		}
	}
}
