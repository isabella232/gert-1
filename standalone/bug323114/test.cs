using System;

public enum Enum64 : long
{
	A = Int64.MaxValue,
}

delegate Enum64 EnumDelegate (Enum64 value);

class Test
{
	static Enum64 Method (Enum64 value)
	{
		return value;
	}

	static int Main ()
	{
		EnumDelegate d = new EnumDelegate (Method);
		Enum64 r = d.EndInvoke (d.BeginInvoke (Enum64.A, null, null));
		if (r == Enum64.A)
			return 0;
		return 1;
	}
}
