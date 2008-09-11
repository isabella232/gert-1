using System;

public interface IFoo
{
	int Execute ();

	int Count {
		get;
	}
}

public class Foo : IFoo
{
	public int Execute ()
	{
		return 1;
	}

	public int Count {
		get { return 1; }
	}
}
