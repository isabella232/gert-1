using System;
using System.IO;
using System.Reflection;

class Program
{
	static int Main ()
	{
		string file = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"liba.dll");
		Assembly assembly = Assembly.LoadFile (file);
		Type type = assembly.GetType ("A");
		if (type == null)
			return 1;

		try {
			type.GetCustomAttributes (true);
			return 2;
		} catch (FileNotFoundException ex) {
#if NET_2_0 || MONO
			if (ex.FileName != "libb, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")
#else
			if (ex.FileName != "libb")
#endif
				return 3;
		}

		return 0;
	}
}
