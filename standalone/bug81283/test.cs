using System;
using System.Collections.Generic;

public class Bla
{
	public static void Main ()
	{
	}
}

public class Foo
{
	public override IEnumerable<X> getXs ()
	{
		yield break;
	}
}
