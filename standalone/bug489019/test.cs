using System;
using System.IO;

class Program
{
	static int Main ()
	{
		StreamWriter w = new StreamWriter ("test-file.log");
		w.Write ("Hello world");
		w.Flush ();
		w.Close ();
		return 0;
	}
}
