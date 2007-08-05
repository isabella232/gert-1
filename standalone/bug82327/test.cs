class Program
{
	static int Main ()
	{
		int? num1 = null;
		if (num1 is int)
			return 1;

		int? num2 = 5;
		if (!(num2 is int))
			return 2;

		return 0;
	}
}
