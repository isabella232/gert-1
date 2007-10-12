using System.Runtime.CompilerServices;

struct Test
{
	[MethodImplAttribute (MethodImplOptions.Synchronized)]
	public int test ()
	{
		return 2 + 2;
	}

	static int Main (string [] args)
	{
		Test b = new Test ();
		int res = b.test ();

		return 0;
	}
}
