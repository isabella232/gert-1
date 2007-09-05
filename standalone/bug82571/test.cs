using System;

class Program
{
	public delegate void Foo ();

	static void Main ()
	{
		Foo x = delegate () { };
		x ();
	}
}
