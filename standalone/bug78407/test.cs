using System;
using System.IO;
using System.Reflection;

public class Test
{
	static int Main ()
	{
		Assembly a = Assembly.GetExecutingAssembly ();
		string[] resourceNames = a.GetManifestResourceNames ();
		if (resourceNames.Length != 2) {
			Console.WriteLine ("#1");
			return 1;
		}
		if (resourceNames[0] != "test2.cs") {
			Console.WriteLine ("#2");
			return 1;
		}
		if (resourceNames[1] != "default.build") {
			Console.WriteLine ("#3");
			return 1;
		}
		FileStream f = a.GetFile ("test.cs");
		if (f == null) {
			Console.WriteLine ("#4");
			return 1;
		}
		f = a.GetFile ("test2.cs");
		if (f != null) {
			Console.WriteLine ("#5");
			return 1;
		}
		f = a.GetFile ("default.build");
		if (f == null) {
			Console.WriteLine ("#6");
			return 1;
		}
		Stream s = a.GetManifestResourceStream ("test2.cs");
		if (s == null) {
			Console.WriteLine ("#7");
			return 1;
		}
		s = a.GetManifestResourceStream ("test.cs");
		if (s != null) {
			Console.WriteLine ("#8");
			return 1;
		}
		s = a.GetManifestResourceStream ("default.build");
		if (s == null) {
			Console.WriteLine ("#9");
			return 1;
		}
		return 0;
	}
}
