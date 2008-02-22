static class Foo
{
	delegate string [,] SimpleDelegate ();

	static void Baz (SimpleDelegate sd)
	{
		sd ();
	}

	static void Main (string [] args)
	{
		Baz (delegate () {
			return new string [,] { { "aa", "bb" } };
		});
	}
}
