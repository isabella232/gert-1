using System;

class Program
{
	unsafe static int Main ()
	{
		return CheckPtr ((byte*) (-1), 1);
	}

	unsafe static int CheckPtr (byte* ptr, int offset)
	{
		int result = 3;

		if (ptr + offset < ptr)
			result--;

		if (unchecked (ptr + offset < ptr))
			result--;

		try {
			if (checked (ptr + offset < ptr))
				Console.WriteLine ("#C");
		} catch (OverflowException) {
			result--;
		}

		return result;
	}
}
