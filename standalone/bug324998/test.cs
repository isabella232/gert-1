using System;
using System.Reflection;

class Program
{
	private const BindingFlags BINDING_FLAGS
		= BindingFlags.Public | BindingFlags.NonPublic
		| BindingFlags.Instance | BindingFlags.Static
		| BindingFlags.IgnoreCase;

	[STAThread]
	static int Main ()
	{
		Type tB = typeof (B);
		try {
			tB.GetMethod ("f", BINDING_FLAGS);
			return 1;
		} catch (AmbiguousMatchException) {
			return 0;
		}
	}
}

class A
{
	public virtual void f (int i1, int i2) { }
	public virtual void f (int i1, int i2, bool b) { }
}

class B : A
{
	public override void f (int i1, int i2, bool b) { }
}
