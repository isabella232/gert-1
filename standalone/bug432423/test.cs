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

		assembly = AssemblyFactory.GetAssembly (Path.Combine (basedir, "libA.dll"));
		Assert.AreEqual (AssemblyFlags.PublicKey, assembly.Name.Flags, "#A1");

		a = Assembly.LoadFrom (Path.Combine (basedir, "libA.dll"));
		Assert.AreEqual (AssemblyNameFlags.PublicKey, a.GetName ().Flags, "#A2");

		assembly = AssemblyFactory.GetAssembly (Path.Combine (basedir, "libB.dll"));
#if ONLY_1_0
		Assert.AreEqual (AssemblyFlags.PublicKey, assembly.Name.Flags, "#B1");
#elif NET_2_0
		Assert.AreEqual (AssemblyFlags.PublicKey | AssemblyFlags.DisableJITcompileOptimizer, assembly.Name.Flags, "#B1");
#else
		Assert.AreEqual (AssemblyFlags.PublicKey | AssemblyFlags.Retargetable, assembly.Name.Flags, "#B1");
#endif

		a = Assembly.LoadFrom (Path.Combine (basedir, "libB.dll"));
#if ONLY_1_0
		Assert.AreEqual (AssemblyNameFlags.PublicKey, a.GetName ().Flags, "#B2");
#elif NET_2_0
		Assert.AreEqual (AssemblyNameFlags.PublicKey | AssemblyNameFlags.EnableJITcompileOptimizer, a.GetName ().Flags, "#B2");
#else
		Assert.AreEqual (AssemblyNameFlags.PublicKey | AssemblyNameFlags.Retargetable, a.GetName ().Flags, "#B2");
#endif

		assembly = AssemblyFactory.GetAssembly (Path.Combine (basedir, "libC.dll"));
#if NET_2_0
		Assert.AreEqual (AssemblyFlags.SideBySideCompatible, assembly.Name.Flags, "#C1");
#else
		Assert.AreEqual (AssemblyFlags.PublicKey, assembly.Name.Flags, "#C1");
#endif

		a = Assembly.LoadFrom (Path.Combine (basedir, "libC.dll"));
		Assert.AreEqual (AssemblyNameFlags.PublicKey, a.GetName ().Flags, "#C2");

		assembly = AssemblyFactory.GetAssembly (Path.Combine (basedir, "libD.dll"));
		Assert.AreEqual (AssemblyFlags.PublicKey, assembly.Name.Flags, "#D1");

		a = Assembly.LoadFrom (Path.Combine (basedir, "libD.dll"));
		Assert.AreEqual (AssemblyNameFlags.PublicKey, a.GetName ().Flags, "#D2");

		assembly = AssemblyFactory.GetAssembly (Path.Combine (basedir, "test.exe"));
		Assert.AreEqual (AssemblyFlags.SideBySideCompatible, assembly.Name.Flags, "#E1");

		a = Assembly.LoadFrom (Path.Combine (basedir, "test.exe"));
		Assert.AreEqual (AssemblyNameFlags.PublicKey, a.GetName ().Flags, "#E2");
	}
}
