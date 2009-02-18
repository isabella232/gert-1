using System;
using System.Runtime.InteropServices;

class Program
{
	[StructLayout (LayoutKind.Sequential)]
	struct TestStruct
	{
		public TestDelegate test;
	}

	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	delegate int TestDelegate ();

	[DllImport ("libptr_to_struct.so")]
	public static extern IntPtr create_dummy_struct ();

	static void Main ()
	{
		IntPtr struct_ptr = create_dummy_struct ();
		TestStruct structure = (TestStruct) Marshal.PtrToStructure (struct_ptr, typeof (TestStruct));
		Assert.IsNull (structure.test, "#1");
	}
}
