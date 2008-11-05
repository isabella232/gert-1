using System;
using System.IO;
using System.Reflection;

using Mono.Cecil;

class Program
{
	static void Main ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyDefinition assembly = AssemblyFactory.GetAssembly (Path.Combine (basedir, "lib.dll"));
		Assert.AreEqual (AssemblyFlags.PublicKey, assembly.Name.Flags, "#1");

		Assembly a = Assembly.LoadFrom (Path.Combine (basedir, "lib.dll"));
		Assert.AreEqual (AssemblyNameFlags.PublicKey, a.GetName ().Flags, "#2");
	}
}
