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
		if (a.FullName != "libb, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")
			return 2;
		return 0;
	}
}
