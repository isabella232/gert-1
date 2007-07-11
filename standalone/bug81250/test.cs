using System;
using System.Collections.Generic;

public class App
{
	class MyClass
	{
	}

	static int Main (string [] args)
	{
		MyClass mc = new MyClass ();
		List<string> l = new List<string> ();
		TestMethod ("Some format {0}", l, mc);
		if (!executed)
			return 1;
		return 0;
	}

	static void TestMethod<T> (string format, List<T> l, params MyClass [] parms)
	{
		string x = String.Format (format, parms);
		if (x != null) {
			executed = true;
		}
	}

	static bool executed = false;
}
