class Program : FooBase
{
	static int Main ()
	{
		if (Bar.RunTest<Program> (new Program ()) != 5)
			return 1;
		return 0;
	}

	protected override int Test ()
	{
		return 5;
	}
}
