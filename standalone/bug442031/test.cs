using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		Assembly bar = Assembly.LoadFrom (Path.Combine (basedir, "bar.dll"));
		Type [] types = bar.GetTypes ();
		foreach (Type t in types) {
			Console.WriteLine (t.FullName);

			MethodInfo [] methods = t.GetMethods (BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
			foreach (MethodInfo m in methods)
				Console.WriteLine (m.Name);

			FieldInfo [] fields = t.GetFields (BindingFlags.NonPublic | BindingFlags.Instance);
			foreach (FieldInfo f in fields)
				Console.WriteLine (f.Name);

		}
	}
}
