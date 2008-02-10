using System;
using System.Runtime.InteropServices;

class Program
{
	[DllImport ("testcase")]
	static extern void test (ref test_struct ts);

	[StructLayout (LayoutKind.Explicit)]
	struct test_union
	{
		[FieldOffset (0)]
		public byte a;
		[FieldOffset (0)]
		public int b;
	}

	[StructLayout (LayoutKind.Sequential)]
	struct test_struct
	{
		public byte a;
		public test_union b;
	}

	static int Main ()
	{
		test_struct ts = new test_struct ();
		test (ref ts);
		return (ts.b.b == 42) ? 0 : 1;
	}
}
