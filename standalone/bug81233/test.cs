class Program
{
	static int Main ()
	{
		B<int> b = new B<int> ();
		if (b == null)
			return 1;
		return 0;
	}
}

interface B<T>
{
}
