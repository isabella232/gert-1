using System.Globalization;
using System.IO;

public class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1)
			return 1;

		File.Create ("started_" + args [0]).Close ();
		return 0;
	}
}
