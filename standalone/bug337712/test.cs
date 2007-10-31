using System;
using System.Reflection;

class Program
{
	public delegate R Function<T1, T2, R> (T1 arg1, T2 arg2);

	static void Main ()
	{
		Delegate [] d = new Delegate [] { new Function<int, int, bool> (f1) };
		Assert.AreEqual (1, d.Length, "#1");
		MethodInfo mi = d [0].Method;
		Assert.AreEqual (typeof (Program), mi.DeclaringType, "#2");
		Assert.AreEqual ("Boolean f1(Int32, Int32)", mi.ToString (), "#2");
	}

	static bool f1 (int a, int b)
	{
		return false;
	}

	static bool f1 (int a, object b)
	{
		return false;
	}

	public static void Run ()
	{
		f1 (5, 6);
		f1 (5, (object) 7);
	}
}
