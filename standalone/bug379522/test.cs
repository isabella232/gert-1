using System;
using System.Globalization;
using System.Threading;

class Program
{
	static void Main (string [] args)
	{
		for (int i = 0; i < 1000; ++i) {
			Thread thread = new Thread (new ThreadStart (Test));
			thread.CurrentCulture = new CultureInfo ("en-CA");
			thread.Start ();
		}
	}

	static void Test ()
	{
		string name = Thread.CurrentThread.CurrentCulture.Name;
		Console.WriteLine (name);
	}
}
