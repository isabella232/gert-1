using System;
using System.Reflection;

namespace a
{
	public class SomeClass
	{
		static int Main (string [] args)
		{
			if (args.Length == 0) {
				Console.WriteLine ("No arguments specified.");
				return 1;
			}

			AppDomain.CurrentDomain.AppendPrivatePath (args [0]);

			Assembly assemblyB = Assembly.LoadFrom ("b.dll");
			object someclass = assemblyB.CreateInstance ("b.SomeClass");
			if (someclass == null) {
				return 2;
			}
			MethodInfo method = someclass.GetType ().GetMethod ("Test");
			if (method == null) {
				return 3;
			}
			method.Invoke (someclass, new object [0]);
			return 0;
		}
	}
}
