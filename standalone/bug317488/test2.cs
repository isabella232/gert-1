using System;
using System.Reflection;

class Program
{
	public delegate void D (C c);

	static void Main ()
	{
#if NET_2_0
		MethodInfo mi = typeof (I).GetMethod ("M");
		D d = (D) Delegate.CreateDelegate (typeof (D), null, mi);
		d (new C ());
#endif
	}
}

public interface I
{
	void M ();
}

public class C : I
{
	public void M () { }
}
