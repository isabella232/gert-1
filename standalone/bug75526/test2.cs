using System;
using System.IO;

class X : MemoryStream
{
	public override int Read (byte [] buffer, int offset, int count)
	{
		buffer [offset + 0] = (byte) 'a';
		buffer [offset + 1] = (byte) 'b';
		return 2;
	}

	static int Main ()
	{
		TextReader tr = new StreamReader (new X ());
		int len = tr.Read (new char [10], 0, 10);
		if (len != 2)
			return 1;
		return 0;
	}
}
