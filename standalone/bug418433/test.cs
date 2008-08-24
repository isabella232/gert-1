using System;
using System.IO;
using System.Reflection;

class Program
{
	static int Main ()
	{
		File.Delete ("extension.dll");
		Business.Configure ();
		Assembly [] assemblies = AppDomain.CurrentDomain.GetAssemblies ();
		foreach (Assembly a in assemblies)
			if (a.GetName ().Name == "extension")
				return 1;
		return 0;
	}
}
