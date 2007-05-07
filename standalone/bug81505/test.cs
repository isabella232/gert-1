using System;

class Program
{
	static int Main (string [] args)
	{
		Exception ex1 = DoSomething ("moo!");
		if (!ex1.GetType ().Equals (typeof (Exception)))
			return 1;
		if (ex1.Message != "moo!")
			return 2;

		Exception ex2 = DoSomething (new ApplicationException ("foo"));
		if (!ex2.GetType ().Equals (typeof (ApplicationException)))
			return 3;
		if (ex2.Message != "foo")
			return 4

		return 0;
	}

	static Exception DoSomething (object value)
	{
		return value as Exception ?? new Exception (value.ToString ());
	}
}
