using System;
using System.Runtime.InteropServices;

class Program
{
	static int Main ()
	{
		GCHandle h;
		bool failed;

		h = GCHandle.Alloc (new byte [] { 1, 2, 3, 4, 5 }, GCHandleType.Pinned);
		if (CheckBytes (h, 0, 1))
			return 1;
		if (CheckBytes (h, 4, 5))
			return 2;
		h.Free ();
		h = GCHandle.Alloc (new String ('\u2222', 6), GCHandleType.Pinned);
		if (CheckBytes (h, 0, 0x22))
			return 3;
		if (CheckBytes (h, 4, 0x22))
			return 4;
		h.Free ();
		h = GCHandle.Alloc (new TestClass (6, 10), GCHandleType.Pinned);
		if (CheckBytes (h, 0, 6))
			return 5;
		if (CheckBytes (h, 8, 10))
			return 6;
		h.Free ();
		// allocate a normal handle, but use AddrOfPinnedObject ()
		h = GCHandle.Alloc (new TestClass (6, 10), GCHandleType.Normal);
		failed = false;
		try {
			IntPtr v = h.AddrOfPinnedObject ();
			if (v == IntPtr.Zero) {
				return 1;
			}
		} catch (InvalidOperationException) {
			failed = true;
		}
		if (!failed)
			return 7;
		h.Free ();

		failed = false;
		try {
			h = GCHandle.Alloc (new TestClassNoBlit (), GCHandleType.Pinned);
		} catch (ArgumentException) {
			failed = true;
		}
		if (!failed)
			return 8;

		failed = false;
		try {
			h = GCHandle.Alloc (new TestClassNoBlit2 (), GCHandleType.Pinned);
		} catch (ArgumentException) {
			failed = true;
		}
		if (!failed)
			return 9;

		failed = false;
		try {
			h = GCHandle.Alloc (new TestClassAutoLayout (2, 3), GCHandleType.Pinned);
		} catch (ArgumentException) {
			failed = true;
		}
		if (!failed)
			return 10;

		return 0;
	}

	public unsafe static bool CheckBytes (GCHandle h, int pos, byte val)
	{
		IntPtr p = h.AddrOfPinnedObject ();
		byte* a = (byte*) p.ToPointer ();
		return a [pos] != val;
	}
}

[StructLayout (LayoutKind.Sequential)]
public class TestClass
{
	private byte mByte;
	public int mInt;
	private byte mByte2;
	public TestClass (byte b, int i)
	{
		mByte = b;
		mInt = i;
		mByte2 = (byte) i;
	}
}

[StructLayout (LayoutKind.Sequential)]
public class TestClassNoBlit
{
	bool bval;
}

[StructLayout (LayoutKind.Sequential)]
public class TestClassNoBlit2
{
	string sval;
}

public class TestClassAutoLayout
{
	private byte mByte;
	public int mInt;
	public TestClassAutoLayout (byte b, int i)
	{
		mByte = b;
		mInt = i;
	}
}
