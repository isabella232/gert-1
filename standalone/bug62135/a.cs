using System;
using System.Reflection;

namespace a
{
	public class SomeClass
	{
		static int Main (string [] args)
		{
			Assembly assemblyB = Assembly.LoadFrom ("b.dll");
			if (assemblyB.FullName == null)
				return 1;
			b.SomeClass some = new b.SomeClass ();
			if (some.GetType ().FullName == null)
				return 2;
			return 0;
		}
	}
}
