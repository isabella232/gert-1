using System;

class myBase
{
	public virtual int Read ()
	{
		return 1;
	}
}

class myTest : myBase
{
	delegate int TestDelegate ();
	private TestDelegate ReadChar = null;

	public myTest ()
	{
		ReadChar = new TestDelegate (base.Read);
	}

	public override int Read ()
	{
		return ReadChar ();
	}

	static int Main (string [] args)
	{
		myTest test = new myTest ();
		if (test.Read () != 1)
			return 1;
		return 0;
	}
}
