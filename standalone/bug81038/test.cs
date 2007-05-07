using System;
using System.IO;

class Program
{
	static int Main ()
	{
		string dir = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"files");
		string [] files = Directory.GetFiles (dir, "test*.tXt");
		if (files.Length != 2)
			return 1;
		if (files [0] == Path.Combine (dir, "TesT1.TxT")) {
			if (files [1] != Path.Combine (dir, "test2.txt"))
				return 2;
		} else if (files [0] == Path.Combine (dir, "test2.txt")) {
			if (files [1] != Path.Combine (dir, "TesT1.TxT"))
				return 3;
		} else {
			return 4;
		}
		return 0;
	}
}
