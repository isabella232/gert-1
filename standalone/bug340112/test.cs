using System;
using System.Reflection;

class Program
{
	public void foo (out ParameterModifier p)
	{
		p = new ParameterModifier (1);
		p [0] = true;
	}

	static int Main ()
	{
		Program program = new Program ();
		ParameterModifier p;
		program.foo (out p);
		if (!p [0])
			return 1;
		return 0;
	}
}
