using System;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Please specify test to run.");
			return 1;
		}

		switch (args [0]) {
		case "test1":
			RunTest (1);
			break;
		case "test2":
			RunTest (2);
			break;
		default:
			Console.WriteLine ("Unsupport test '{0}'.", args [0]);
			return 2;
		}

		return 0;
	}

	static void RunTest (int expected)
	{
		IFoo a = (IFoo) new Bar ();
		Assert.AreEqual (expected, a.Execute (), "#A1");
		Assert.AreEqual (expected, a.Count, "#A2");

		Bar b = new Bar ();
		Assert.AreEqual (expected, b.Execute (), "#B1");
		Assert.AreEqual (expected, b.Count, "#B2");

		Foo c = new Foo ();
		Assert.AreEqual (1, c.Execute (), "#C1");
		Assert.AreEqual (1, c.Count, "#C2");

		Assert.AreEqual (expected, ((IFoo) new Bar ()).Execute (), "#D1");
		Assert.AreEqual (expected, ((IFoo) new Bar ()).Count, "#D2");

		Assert.AreEqual (1, new Bar ().Execute (), "#E1");
		Assert.AreEqual (1, new Bar ().Count, "#E2");

		Assert.AreEqual (1, new Foo ().Execute (), "#F1");
		Assert.AreEqual (1, new Foo ().Count, "#F2");

		Assert.AreEqual (expected, CreateBar ().Execute (), "#G1");
		Assert.AreEqual (expected, CreateBar ().Count, "#G2");
	}

	static IFoo CreateBar ()
	{
		return new Bar ();
	}
}
