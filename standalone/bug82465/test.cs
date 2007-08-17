using System;
using System.Reflection;
using System.Runtime.InteropServices;

class Program
{
	static int Main ()
	{
		object [] attrs = typeof (Class2).GetField ("f3").GetCustomAttributes (true);
#if NET_2_0
		if (attrs.Length != 1)
			return 1;

		MarshalAsAttribute attr = (MarshalAsAttribute) attrs [0];
		if (attr.Value != UnmanagedType.CustomMarshaler)
			return 2;
		if (attr.MarshalCookie != "5")
			return 3;
		if (Type.GetType (attr.MarshalType) != typeof (Marshal1))
			return 4;
#else
		if (attrs.Length != 0)
			return 1;
#endif
		return 0;
	}
}

public class Marshal1 : ICustomMarshaler
{
	public static ICustomMarshaler GetInstance (string s)
	{
		return new Marshal1 ();
	}

	public void CleanUpManagedData (object managedObj)
	{
	}

	public void CleanUpNativeData (IntPtr pNativeData)
	{
	}

	public int GetNativeDataSize ()
	{
		return 4;
	}

	public IntPtr MarshalManagedToNative (object managedObj)
	{
		return IntPtr.Zero;
	}

	public object MarshalNativeToManaged (IntPtr pNativeData)
	{
		return null;
	}
}

[StructLayout (LayoutKind.Sequential)]
public class Class2
{
	[MarshalAsAttribute (UnmanagedType.Bool)]
	public int f0;

	[MarshalAs (UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
	public string [] f1;

	[MarshalAs (UnmanagedType.ByValTStr, SizeConst = 100)]
	public string f2;

	[MarshalAs (UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (Marshal1), MarshalCookie = "5")]
	public object f3;
}
