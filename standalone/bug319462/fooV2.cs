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
	public virtual int Execute ()
	{
		return 1;
	}

	public virtual int Count {
		get { return 1; }
	}
}
