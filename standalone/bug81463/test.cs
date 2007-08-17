using System;
using System.IO;
using System.Reflection;

class Program
{
	static int Main ()
	{
		string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libb.dll");
		Assembly a = Assembly.LoadFile (file);
		try {
			a.GetExportedTypes ();
			return 2;
		} catch (FileNotFoundException) {
			return 0;
		}
	}
}
