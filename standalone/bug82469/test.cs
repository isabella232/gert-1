using System;
using System.Collections;

class Program
{
	static int Main ()
	{
		if (!ArrayTest ())
			return 1;
		return 0;
	}

	public static bool ArrayTest ()
	{
		int index = 0;
		byte [] array = new byte [1100000000];
		array [array.Length - 1] = 1;
		index = Array.BinarySearch (array, (byte) 1);
		return (index == (array.Length - 1));
	}
}
