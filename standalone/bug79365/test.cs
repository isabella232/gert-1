using System;
using System.Globalization;
using System.Reflection;

class T
{
	static int Main ()
	{
		new Lib ();

		Assembly me = Assembly.GetExecutingAssembly ();
		AssemblyName [] names = me.GetReferencedAssemblies ();
		if (names.Length != 2) {
			Console.WriteLine ("#1: " + names.Length);
			return 1;
		}
		if (names [0].Name != "mscorlib") {
			Console.WriteLine ("#2: " + names [0].Name);
			return 1;
		}

		if (names [1].Name != "lib") {
			Console.WriteLine ("#3: " + names [1].Name);
			return 1;
		}

		Assembly a = Assembly.Load (names [1]);
		if (!CultureInfo.InvariantCulture.CompareInfo.IsSuffix (a.CodeBase, "lib.dll", CompareOptions.IgnoreCase)) {
			Console.WriteLine ("#4: " + a.CodeBase);
			return 1;
		}

		if (!a.Location.EndsWith ("lib.dll")) {
			Console.WriteLine ("#5: " + a.Location);
			return 1;
		}
		return 0;
	}
}
