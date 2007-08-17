using System;
using System.IO;
using System.Reflection;

class Program
{
	static int Main ()
	{
		string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libb.dll");
		Assembly a = Assembly.LoadFile (file);
		if (a == null)
			return 1;
#if MONO
		if (a.FullName != "libb, Version=0.0.0.0, Culture=neutral")
#else
		if (a.FullName != "libb, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")
#endif
			return 2;
		return 0;
	}
}
