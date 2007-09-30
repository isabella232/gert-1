using System;
using System.Runtime.InteropServices;

class Program
{
	static int Main ()
	{
		int [] testInts = new int [10];
		if (testRoutine (out testInts) != 5)
			return 1;
		return 0;
	}

	[DllImport ("libtest")]
	static extern int testRoutine (out int [] testInts);
}
