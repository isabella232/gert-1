using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

class Program
{
	static int Main ()
	{
		ResourceManager resMgr = new ResourceManager ("res", 
			Assembly.GetExecutingAssembly ());
		if (resMgr.GetString ("ProbableCause") != "Mögliche Ursache:")
			return 1;
		return 0;
	}
}
