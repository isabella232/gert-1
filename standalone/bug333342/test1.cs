using System;
using System.Reflection;

struct T
{
	public delegate void Do ();
	public event Do MyDo2;

	static int Main ()
	{
		T t = new T ();
		B.test (ref t);
		t.MyDo2 ();

		MethodInfo m = typeof (T).GetMethod ("add_MyDo2", BindingFlags.Public | BindingFlags.Instance);
		MethodImplAttributes implAttr = m.GetMethodImplementationFlags ();
		if (implAttr != MethodImplAttributes.Managed)
			return 1;

		m = typeof (T).GetMethod ("remove_MyDo2", BindingFlags.Public | BindingFlags.Instance);
		implAttr = m.GetMethodImplementationFlags ();
		if (implAttr != MethodImplAttributes.Managed)
			return 2;

		return 0;
	}
}

class B
{
	static void p () { }
	public static void test (ref T t)
	{
		t.MyDo2 += p;
	}
}
