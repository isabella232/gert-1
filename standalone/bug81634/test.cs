class Program
{
	static int Main ()
	{
		int storedOffset =5;
		int storedLength = 3;
		int opt_len = 67;

		if (storedOffset >= 0 && storedLength + 5 < opt_len >> 3) {
			return 1;
		}
		if (storedOffset >= 0 && storedLength + 4 > opt_len >> 3) {
			return 1;
		}
		if (storedOffset >= 0 && storedLength + 5 == opt_len >> 3) {
			return 0;
		}
		return 1;
	}
}
