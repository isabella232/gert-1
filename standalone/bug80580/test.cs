using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Structs
{
	[StructLayout (LayoutKind.Sequential, Pack = 1)]
	// Size: 5  
	internal class a
	{
		public byte d;
		private IntPtr next;

		public void Test ()
		{
			next = IntPtr.Zero;
			d = 1;
		}

		public a Next
		{
			get
			{
				a result;

				if (next == IntPtr.Zero)
					result = null;
				else
					result = (a) Marshal.PtrToStructure (next, typeof (a));

				return result;
			}
		}
	}

	class MainClass
	{
		private static ArrayList TestOfData ()
		{
			ArrayList result = new ArrayList ();
			IntPtr x = Marshal.AllocHGlobal (5);
			try {
				IntPtr x2 = Marshal.AllocHGlobal (5);
				try {
					IntPtr x3 = Marshal.AllocHGlobal (5);
					try {
						Marshal.WriteByte (x, 0x01);
						Marshal.WriteIntPtr (x, 1, x2);

						Marshal.WriteByte (x2, 0x02);
						Marshal.WriteIntPtr (x2, 1, x3);

						Marshal.WriteByte (x3, 0x03);
						Marshal.WriteIntPtr (x3, 1, IntPtr.Zero);

						a validation = (a) Marshal.PtrToStructure (x, typeof (a));
						while (validation != null) {
							result.Add (validation.d);
							validation = validation.Next;
						}
					} finally {
						Marshal.FreeHGlobal (x3);
					}
				} finally {
					Marshal.FreeHGlobal (x2);
				}
			} finally {
				Marshal.FreeHGlobal (x);
			}
			return result;
		}

		private static ArrayList TestOfData2 ()
		{
			ArrayList result = new ArrayList ();
			IntPtr x = Marshal.AllocHGlobal (15);
			try {
				Marshal.WriteByte (x, 0x01);
				Marshal.WriteIntPtr (x, 1, new IntPtr (x.ToInt32 () + 5));

				Marshal.WriteByte (x, 5, 0x02);
				Marshal.WriteIntPtr (x, 6, new IntPtr (x.ToInt32 () + 10));

				Marshal.WriteByte (x, 10, 0x03);
				Marshal.WriteIntPtr (x, 11, IntPtr.Zero);

				a validation = (a) Marshal.PtrToStructure (x, typeof (a));
				while (validation != null) {
					result.Add (validation.d);
					validation = validation.Next;
				}
			} finally {
				Marshal.FreeHGlobal (x);
			}
			return result;
		}


		public static int Main (string [] args)
		{
			// Crash happens here
			a data = new a ();
			if (data == null) { // avoid CS0219
			}

			// Verify that code does what is needed
			// 
			// Expected result : 1 2 3 
			ArrayList result = TestOfData ();
			if (result.Count != 3)
				return 1;
			if ((byte) result [0] != 1 || (byte) result [1] != 2 || (byte) result [2] != 3)
				return 2;

			// Expected result : 1 2 3 
			result = TestOfData2 ();
			if (result.Count != 3)
				return 3;
			if ((byte) result [0] != 1 || (byte) result [1] != 2 || (byte) result [2] != 3)
				return 4;

			return 0;
		}
	}
}
