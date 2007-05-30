using System;
using System.Runtime.InteropServices;
using System.Text;

class Program
{
	[DllImport ("kernel32.dll", EntryPoint="CopyMemory")]
	extern static void Win32CopyMemory(IntPtr Destination, IntPtr Source, int length);

	[DllImport ("kernel32.dll", EntryPoint="FillMemory")]
	static extern void Win32FillMemory (byte [] arr, int size, byte fill);

	[DllImport ("Kernel32.dll", EntryPoint="MoveMemory")]
	static extern void Win32MoveMemory (IntPtr dest, IntPtr src, int size);

	[DllImport ("Kernel32.dll", EntryPoint = "ZeroMemory")]
	static extern void Win32ZeroMemory (IntPtr dest, int size);

	static unsafe int Main ()
	{
		byte [] data = Encoding.Unicode.GetBytes ("Here is some mono testdata");

		IntPtr mem_intptr1 = Marshal.AllocHGlobal (60);
		IntPtr mem_intptr2 = Marshal.AllocHGlobal (60);

		Win32ZeroMemory (mem_intptr1, 60);
		for (int i = 0; i < 60; i++)
			if (Marshal.ReadByte (mem_intptr1, i) != 0x00)
				return 1;

		for (int i = 0; i < data.Length; i++)
			Marshal.WriteByte (mem_intptr1, i, data [i]);

		Win32ZeroMemory (mem_intptr2, 60);
		for (int i = 0; i < 60; i++)
			if (Marshal.ReadByte (mem_intptr2, i) != 0x00)
				return 2;

		Win32CopyMemory (mem_intptr2, mem_intptr1, 60);
		for (int i = 0; i < 60; i++) {
			byte readByte = Marshal.ReadByte (mem_intptr2, i);
			if (i < data.Length) {
				if (readByte != data [i])
					return 3;
			} else if (readByte != 0x00) {
				return 4;
			}
		}

		Win32ZeroMemory (mem_intptr2, 60);
		for (int i = 0; i < 60; i++)
			if (Marshal.ReadByte (mem_intptr2, i) != 0x00)
				return 5;

		Win32MoveMemory (mem_intptr2, mem_intptr1, 20);
		for (int i = 0; i < 60; i++) {
			byte readByte = Marshal.ReadByte (mem_intptr2, i);
			if (i < 20) {
				if (readByte != data [i])
					return 6;
			} else if (readByte != 0x00) {
				return 7;
			}
		}
		for (int i = 0; i < 60; i++) {
			byte readByte = Marshal.ReadByte (mem_intptr1, i);
			if (i < data.Length) {
				if (readByte != data [i])
					return 8;
			} else if (readByte != 0x00) {
				return 9;
			}
		}

		byte [] myArray = new byte [5];
		Win32FillMemory (myArray, 2, 0xFF);
		if (myArray [0] != 0xFF)
			return 10;
		if (myArray [1] != 0xFF)
			return 11;
		if (myArray [2] != 0x00)
			return 12;
		if (myArray [3] != 0x00)
			return 12;
		if (myArray [4] != 0x00)
			return 12;

		return 0;
	}
}
