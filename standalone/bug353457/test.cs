class Program
{
	public delegate void Handler ();

	static void Main ()
	{
		Method (delegate { }, "Hello", "How", "Are", "You");
		Method (delegate { });
		Method (null, null);
		Method (null);
		Method (Main, "Hi");
	}

	public static void Method (Handler handler, params string [] args)
	{
	}
}
