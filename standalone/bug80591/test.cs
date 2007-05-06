using System;

public class Test
{
	static int Main ()
	{
		FromUShort y = (FromUShort) 1;
		if (y.ToString () != "1")
			return 1;
		FromUint z = (FromUint) y;
		if (z != FromUint.B)
			return 2;
		if (z.ToString () != "B")
			return 3;
		return 0;
	}
}

enum FromUint : uint
{
	A,
	B,
	Ma = uint.MaxValue
}

enum FromUShort : ushort
{
	AA,
	BB = 2334
}
