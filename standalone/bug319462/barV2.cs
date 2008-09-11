using System;

public class Bar : Foo
{
	public override int Execute ()
	{
		return 2;
	}

	public override int Count {
		get { return 2; }
	}
}
