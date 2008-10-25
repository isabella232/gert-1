using System;

public struct ValTyp
{
	public static readonly ValTyp Empty = new ValTyp (Guid.Empty, 0, 0);
	public Guid g;
	public int i1;
	public int i2;

	public ValTyp (Guid g, int i1, int i2)
	{
		this.g = g;
		this.i1 = i1;
		this.i2 = i2;
	}
}

public abstract class Foo
{
	public ValTyp? nvt;

	protected Foo (ValTyp vt, ValTyp? nvt)
	{
		this.nvt = nvt;
		if (nvt.HasValue)
			throw new Exception ();
	}
}

public class Moo : Foo
{
	public Moo (ValTyp vt, int i)
		: base (vt, null)
	{
	}

	public Moo (ValTyp vt)
		: this (vt, 0)
	{
	}
}

class Program
{
	static void Main ()
	{
		Moo moo = new Moo (ValTyp.Empty);
		Assert.IsFalse (moo.nvt.HasValue, "#1");
		moo = new Moo (ValTyp.Empty);
		Assert.IsFalse (moo.nvt.HasValue, "#2");
	}
}
