using System;

class Program
{
	unsafe static int Main ()
	{
		try {
			byte* b = (byte*) (-1);
			if (b + 5 < b) {
			}
			return 1;
		} catch (OverflowException) {
		}

		unchecked {
			return CheckPtr ((byte*) (-1), 1);
		}
	}

	unsafe static int CheckPtr (byte* ptr, int offset)
	{
		int result = 3;

		try {
			if (ptr + offset < ptr)
				Console.WriteLine ("#A");
		} catch (OverflowException) {
			result--;
		}

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
