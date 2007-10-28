using System;
using System.Runtime.InteropServices;

class Program
{
	static int Main ()
	{
		const int size = 4096;
		string s1 = "Mono".PadLeft (size, '\0');
		IntPtr ptr = Marshal.StringToHGlobalAnsi (s1);
		string s2 = Marshal.PtrToStringAnsi (ptr);
		if (s2 != string.Empty)
			return 1;
		
		for (int i = 0; i < size; i += 4)
			Marshal.WriteInt32 (ptr, i, 0);
		Marshal.FreeHGlobal (ptr);

		s1 = "Gert" + '\0' + "Mono";
		ptr = Marshal.StringToHGlobalAnsi (s1);
		s2 = Marshal.PtrToStringAnsi (ptr);
		if (s2 != "Gert")
			return 2;

		return 0;
	}
}
