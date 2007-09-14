using System;
using System.Reflection;

class Program
{
	static int Main ()
	{
		Assembly asm = Assembly.LoadFrom ("bin/lib.dll");
		if (asm == null)
			return 1;

		asm = Assembly.LoadFrom ("BiN/LiB.dLl");
		if (asm == null)
			return 2;

		return 0;
	}
}
