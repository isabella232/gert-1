using System;

class IncompatibleDimensionException : ApplicationException
{
	public IncompatibleDimensionException (String message)
		: base (message)
	{
	}
}

class InvalidArrayShapeException : ApplicationException
{
	public InvalidArrayShapeException (String message)
		: base (message)
	{
	}
}

class InvalidArrayMarginException : ApplicationException
{
	public InvalidArrayMarginException (String message)
		: base (message)
	{
	}
}

class IncompatibleArrayShapeException : ApplicationException
{
	public IncompatibleArrayShapeException (String message)
		: base (message)
	{
	}
}

class PrematureValuesEndException : ApplicationException
{
	private readonly int copied;
	private readonly int requested;

	public int NumCopied
	{
		get { return copied; }
	}

	public int NumRequested
	{
		get { return requested; }
	}

	public PrematureValuesEndException (int copied, int requested)
		: base ("Could only copy " + copied + " values ("
			+ requested + " were requested)")
	{
		this.copied = copied;
		this.requested = requested;
	}
}
