using System;
using System.IO;
using System.Reflection;
using System.Xml;

class Program
{
	static int assembly_resolve_level = 0;
	static int reflection_assembly_resolve_level = 0;

	static void Main ()
	{
		Assembly assembly;

		AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler (AppDomain_AssemblyResolve);
		AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler (AppDomain_AssemblyResolve);
		assembly = Assembly.Load ("abc");
		Assert.AreEqual (typeof (int).Assembly, assembly, "#A1");
		Assert.IsFalse (assembly.ReflectionOnly, "#A2");
		Assert.AreEqual (3, assembly_resolve_level, "#A3");

		assembly_resolve_level = 0;

		AppDomain.CurrentDomain.AssemblyResolve -= new ResolveEventHandler (AppDomain_AssemblyResolve);
		AppDomain.CurrentDomain.AssemblyResolve -= new ResolveEventHandler (AppDomain_AssemblyResolve);
		try {
			Assembly.Load ("xyz");
			Assert.Fail ("#B1");
		} catch (FileNotFoundException) {
			Assert.AreEqual (0, assembly_resolve_level, "#B2");
		}

		assembly_resolve_level = 3;
		reflection_assembly_resolve_level = 0;

		AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler (AppDomain_AssemblyResolve);
		AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler (AppDomain_ReflectionOnlyAssemblyResolve);
		AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler (AppDomain_ReflectionOnlyAssemblyResolve);
		assembly = Assembly.ReflectionOnlyLoad ("C");
		Assert.IsNotNull (assembly, "#C1");
		Assert.IsTrue (assembly.ReflectionOnly, "#C2");
		Assert.AreEqual (3, assembly_resolve_level, "#C3");
		Assert.AreEqual (0, reflection_assembly_resolve_level, "#C4");
		assembly.GetType ("CB");
		Assert.AreEqual (3, assembly_resolve_level, "#C5");
		Assert.AreEqual (2, reflection_assembly_resolve_level, "#C6");
	}

	static Assembly AppDomain_ReflectionOnlyAssemblyResolve (object sender, ResolveEventArgs args)
	{
		reflection_assembly_resolve_level++;

		switch (reflection_assembly_resolve_level) {
		case 1:
			return null;
		case 2:
			return Assembly.ReflectionOnlyLoadFrom (Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "B_org.dll"));
		default:
			return null;
		}
	}

	static Assembly AppDomain_AssemblyResolve (object sender, ResolveEventArgs args)
	{
		assembly_resolve_level++;

		switch (assembly_resolve_level) {
		case 1:
			return Assembly.Load ("abc");
		case 2:
			return null;
		case 3:
			return typeof (int).Assembly;
		case 4:
			return typeof (XmlDocument).Assembly;
		default:
			return typeof (Uri).Assembly;
		}
	}
}
