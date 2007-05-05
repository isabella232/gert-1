using System;

abstract class A : I
{
	protected abstract void M ();

	void I.M ()
	{
		Console.WriteLine ("Interface");
	}
}

interface I
{
	void M ();
}

class C : A, I
{
	protected override void M ()
	{
		Console.WriteLine ("Override");
	}

	public static void Main ()
	{
		C c = new C ();
		c.M ();
		I i = c;
		i.M ();
	}
}
