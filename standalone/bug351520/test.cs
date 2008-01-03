using System;
using System.Runtime.InteropServices;

class Program
{
	static void Main ()
	{
		DoNothing ();
		Callback callback = null;
		callback = GetCallbackI ();
		callback ();
		GetCallbackII (out callback);
		callback ();
	}

	[UnmanagedFunctionPointer (convention)]
	internal delegate void Callback ();

	[DllImport ("libhello.dll", CallingConvention = convention)]
	internal static extern void DoNothing ();

	[DllImport ("libhello.dll", CallingConvention = convention)]
	internal static extern Callback GetCallbackI ();

	[DllImport ("libhello.dll", CallingConvention = convention)]
	internal static extern void GetCallbackII (out Callback callback);

	const CallingConvention convention = CallingConvention.Cdecl;
}
