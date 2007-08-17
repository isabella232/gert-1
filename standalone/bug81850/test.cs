using System;
using System.Collections;
#if NET_2_0
using System.Collections.Generic;
#endif
using System.Reflection;

class Program
{
	static int Main ()
	{
		Type t = typeof (Foo);
		BindingFlags f = BindingFlags.Instance |
				BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic |
				BindingFlags.DeclaredOnly;

		PropertyInfo pi = t.GetProperty ("System.Collections.IEnumerator.Current", f);
		if (pi == null)
			return 1;

#if NET_2_0
		pi = t.GetProperty ("System.Collections.Generic.IEnumerator<Foo>.Current", f);
		if (pi == null)
			return 2;
#endif

		MethodInfo mi = t.GetMethod ("System.Collections.IEnumerable.GetEnumerator", f);
		if (mi == null)
			return 3;

#if NET_2_0
		mi = t.GetMethod ("System.Collections.Generic.IEnumerable<Foo>.GetEnumerator", f);
		if (mi == null)
			return 4;
#endif

		return 0;
	}
}

class Foo : IEnumerable, IEnumerator, IDisposable
#if NET_2_0
	, IEnumerable<Foo>, IEnumerator<Foo>
#endif
{
	IEnumerator IEnumerable.GetEnumerator ()
	{
		return null;
	}

#if NET_2_0
	IEnumerator<Foo> IEnumerable<Foo>.GetEnumerator ()
	{
		return null;
	}
#endif

	bool IEnumerator.MoveNext ()
	{
		return false;
	}

	object IEnumerator.Current {
		get { return null; }
	}

#if NET_2_0
	Foo IEnumerator<Foo>.Current {
		get { return null; }
	}
#endif

	void IEnumerator.Reset ()
	{
	}

	void IDisposable.Dispose ()
	{
	}
}
