using System;
using System.IO;
using System.Reflection;

using Mono.Cecil;

class Program
{
	static void Main ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyDefinition assembly;
		Assembly a;

		assembly = AssemblyFactory.GetAssembly (Path.Combine (basedir, "lib.dll"));
		Assert.AreEqual (AssemblyFlags.PublicKey, assembly.Name.Flags, "#A1");

		a = Assembly.LoadFrom (Path.Combine (basedir, "lib.dll"));
		Assert.AreEqual (AssemblyNameFlags.PublicKey, a.GetName ().Flags, "#A2");

		assembly = AssemblyFactory.GetAssembly (Path.Combine (basedir, "test.exe"));
		Assert.AreEqual (AssemblyFlags.SideBySideCompatible, assembly.Name.Flags, "#B1");

		a = Assembly.LoadFrom (Path.Combine (basedir, "test.exe"));
		Assert.AreEqual (AssemblyNameFlags.PublicKey, a.GetName ().Flags, "#B2");
	}
}
