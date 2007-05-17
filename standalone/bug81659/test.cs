using System;
using System.Runtime.InteropServices;

class Program
{
	static int Main ()
	{
		//int CF_TEXT = 1;
		int CF_UNICODETEXT = 13;

		if (!OpenClipboard (IntPtr.Zero))
			return 1;

		if (!EmptyClipboard ())
			return 2;

		IntPtr hmem = Marshal.StringToHGlobalUni ("test");

		if (SetClipboardData ((uint) CF_UNICODETEXT, hmem) == IntPtr.Zero)
			return 3;
		if (!CloseClipboard ())
			return 4;
		return 0;
	}

	[DllImport ("user32.dll", SetLastError=true)]
	private extern static IntPtr SetClipboardData (uint format, IntPtr handle);
	[DllImport ("user32.dll", SetLastError=true)]
	private extern static bool OpenClipboard (IntPtr hwnd);
	[DllImport ("user32.dll", SetLastError=true)]
	private extern static bool CloseClipboard ();
	[DllImport ("user32.dll", SetLastError=true)]
	private extern static bool EmptyClipboard ();
}
