using System;
using System.Runtime.InteropServices;

class Program
{
	[DllImport ("kernel32.dll", EntryPoint="CopyMemory")]
	internal extern static void Win32CopyMemory(IntPtr Destination, IntPtr Source, int length);

	static void Main ()
	{
		Win32CopyMemory (IntPtr.Zero, IntPtr.Zero, 5);
	}
}	
