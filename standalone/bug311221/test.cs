using System;

class Program
{
	static int Main ()
	{
		B b = new B ();
#if ONLY_1_1 && !MONO
		if (b.ToString () != "B:Av2") {
#else
		if (b.ToString () != "B:B") {
#endif
			Console.WriteLine (b.ToString ());
			return 1;
		}

		Mercedes m = new Mercedes ();
#if ONLY_1_1 && !MONO
		try {
			m.Run ();
			return 2;
		} catch (MethodAccessException) {
		}
#else
		if (m.Run () != "Mercedes:Vehicle") {
			Console.WriteLine (m.Run ());
			return 2;
		}
#endif
		return 0;
	}
}

class B : A
{
	public override string ToString ()
	{
		return "B:" + base.ToString ();
	}
}

class Mercedes : Car
{
	public override string Run ()
	{
		return "Mercedes:" + base.Run ();
	}
}
