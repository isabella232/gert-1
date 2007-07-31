using System;
using System.Reflection;

class Program
{
	[STAThread]
	static int Main ()
	{
		Type [] ts = Assembly.LoadFrom ("lib.dll").GetTypes ();
		if (ts.Length != 3)
			return 1;
		return 0;
	}
}
