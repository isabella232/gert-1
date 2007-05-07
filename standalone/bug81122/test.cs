using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

class Program
{
	static int Main ()
	{
		ResourceManager resMgr = new ResourceManager ("Resources", 
			Assembly.GetExecutingAssembly ());
		object data = resMgr.GetObject ("implant");
		if (data == null)
			return 1;
		if (data.GetType () != typeof (byte []))
			return 2;
		byte [] buffer = data as byte [];
		if (buffer.Length != 111971)
			return 3;
		if (buffer [0] != 35)
			return 4;
		return 0;
	}
}
