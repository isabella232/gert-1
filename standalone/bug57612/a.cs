class Program
{
	static void Main ()
	{
		b.Foo b = new b.Foo ();
		Assert.AreEqual ("ok b", b.Test (), "#1");

		c.Bar c = new c.Bar ();
		Assert.AreEqual ("ok c", c.Test (), "#2");
	}
}
