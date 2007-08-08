using System;
using System.Reflection;

class Program
{
	delegate object test (MethodInfo x);

	static void Main ()
	{
		DoCall (delegate (MethodInfo from) {
			return from.Invoke (null, new object [] { from });
		});
	}

	static void DoCall (test t)
	{
	}
}
