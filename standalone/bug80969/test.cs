using System;

class C<T>
{
	public Type Test ()
	{
		T [,] a = new T [0, 0];
		return a.GetType ();
	}
}

class M
{
	static int Main ()
	{
		C<string> c1 = new C<string> ();
		C<bool> c2 = new C<bool> ();
		Type t1 = c1.Test ();
		Type t2 = c2.Test ();
		if (t1 != typeof (string [,])) {
			Console.WriteLine ("#1: " + t1.FullName);
			return 1;
		}
		if (t2 != typeof (bool [,])) {
			Console.WriteLine ("#2: " + t2.FullName);
			return 2;
		}
		return 0;
	}
}

