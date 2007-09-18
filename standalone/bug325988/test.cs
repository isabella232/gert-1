using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

class Program
{
	static void Main ()
	{
		AppDomain domain = AppDomain.CurrentDomain;
		string temp_folder = Path.Combine (domain.BaseDirectory, "temp");
		const int maxfiles = 2000;

		if (!Directory.Exists (temp_folder))
			Directory.CreateDirectory (temp_folder);

		for (int i = 1; i < maxfiles; ++i) {
			string name = string.Format ("test-{0:000}", i);
			AssemblyName aname = new AssemblyName ();
			aname.Name = name;
			AssemblyBuilder builder = domain.DefineDynamicAssembly (
				aname, AssemblyBuilderAccess.RunAndSave,
				temp_folder);
			builder.Save (name + ".dll");
			Assembly.LoadFile (Path.Combine (temp_folder, name + ".dll"));
		}
	}
}
