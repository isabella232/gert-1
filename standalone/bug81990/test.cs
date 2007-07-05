using System;
using System.Runtime.InteropServices;

static class Program
{
	[STAThread]
	static void Main ()
	{
		//
		// Give a 'function pointer' of our static CreateWString function to the C library
		//
		SWIG_WStringDelegate wstringDelegate = new SWIG_WStringDelegate (CreateWString);
		SWIGRegisterUTF16StringCallback_libtest (wstringDelegate);

		//
		// Invoke a function in the C library that will use the above registered CreateWString function pointer.
		//
		my_test_func ();
	}

	[return: MarshalAs (UnmanagedType.LPWStr)]
	public delegate string SWIG_WStringDelegate ([MarshalAs (UnmanagedType.LPWStr)] string message);

	[return: MarshalAs (UnmanagedType.LPWStr)]
	public static string CreateWString ([MarshalAs (UnmanagedType.LPWStr)] string cString)
	{
		Console.Write (cString + "|");
		return cString;
	}

	[DllImport ("libtest")]
	public static extern void SWIGRegisterUTF16StringCallback_libtest (SWIG_WStringDelegate wstringDelegate);

	[DllImport ("libtest")]
	static extern void my_test_func ();
}
