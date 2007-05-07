using System;

class Program
{
	static int Main ()
	{
		int hours = Int32.MinValue;
		int hrssec = (hours * 3600);
		long t = ((long) (hrssec) * 1000L);
		if (t != 0)
			return 1;

		return 0;
	}
}
