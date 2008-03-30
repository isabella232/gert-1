using System;
using System.Runtime.InteropServices;

class Program
{
	static void Main ()
	{
		Assert.AreEqual ("hello world", goo (), "#1");
	}

	[DllImport ("testcase")]
	[return: MarshalAs (UnmanagedType.LPStr)]
	static extern string goo ();
}
