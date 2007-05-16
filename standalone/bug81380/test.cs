using System;

class Program
{
	public static void Main ()
	{
		IFoo foo = null;
		if (foo is IFoo)
			Console.WriteLine ("got an IFoo");
		Bar bar = null;
		if (bar is Bar)
			Console.WriteLine ("got a bar");
#if NET_2_0
		int? num = null;
		if (num is int)
			Console.WriteLine ("got a nullable int");
#endif
	}
}

interface IFoo
{
}

class Bar
{
}
