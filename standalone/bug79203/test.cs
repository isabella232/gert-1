using System;
using System.Runtime.InteropServices;

class Test
{
	private delegate void Fptr (string arg, object [] args);

	private static void MyFptr (string arg, object [] args) { }

	public static void Main (string [] args)
	{
		set_fptr (MyFptr);
	}

	[DllImport ("libtest")]
	private static extern void set_fptr (Fptr fptr);
}
