using System;
using System.Reflection;
using System.Threading;

class Program
{
	static int Main ()
	{
		ParameterizedThreadStart ts = new ParameterizedThreadStart (TestThread);
		Thread t = new Thread (ts);
		t.Start (100);
		t.Join ();
		return (_success ? 0 : 1);
	}

	static void TestThread (object obj)
	{
		int testCount = ((int) obj);

		if (testCount > 0) {
			TryAnotherWay (); // This one is always okay

			Test1Class test1 = new Test1Class ();
			Test1Class test2 = new Test1Class (); // Coment me and 23 out and it works
			if (!test1.Run ())
				_success = false;
			if (!test2.Run ()) // Coment me and 21 out and it works
				_success = false;
				

			TryAnotherWay (); // This one is now bad
		} else {
			// Or Remove this entire else block and it works
			ParameterizedThreadStart ts = new ParameterizedThreadStart (TestThread);
			Thread t = new Thread (ts);
			t.Start (2);
			t.Join ();
		}
	}

	static void TryAnotherWay ()
	{
		Test1Class test1 = new Test1Class ();
		Test1Class test2 = new Test1Class ();
		if (!test1.Run ())
			_success = false;
		if (!test2.Run ())
			_success = false;
	}

	private static volatile bool _success = true;
}

public class Test1Class
{
	public bool Run ()
	{
		Assembly a = Assembly.GetExecutingAssembly ();
		return (a.GetName ().Name == "test");
	}
}
