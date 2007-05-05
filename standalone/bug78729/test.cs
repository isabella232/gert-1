using System;

public class Test
{
	private static int [,] key2 = new int [,] { { 5, 7 }, { 6, 8 } };
	private static int sum = 0;

	static int Main ()
	{
		test ();
		if (sum != 5)
			return 1;
		return 0;
	}

	private static void test ()
	{
		unsafe {
			fixed (int* k = key2) // Works with "key1", but not with "key2".
		{
				sum += *k; // No cycle here, so NO broken bounds.
			}
		}
	}
}
