using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		Assembly assembly;

		AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler (AppDomain_AssemblyResolve);
		try {
			assembly = Assembly.Load ("abc");
			Assert.Fail ("#A");
		} catch (FileLoadException ex) {
			// AssemblyResolveEvent handlers cannot return Assemblies
			// loaded for reflection only
		}

		Console.WriteLine ();
		Console.WriteLine ();

		AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler (AppDomain_ReflectionOnlyAssemblyResolve);
		assembly = Assembly.ReflectionOnlyLoad ("B");
		try {
			assembly.GetType ("CA");
			Assert.Fail ("#B");
		} catch (FileLoadException ex) {
			// ReflectionOnlyAssemblyResolve handlers must return Assemblies
			// loaded for reflection only
		}
	}

	static Assembly AppDomain_ReflectionOnlyAssemblyResolve (object sender, ResolveEventArgs args)
	{
		return typeof (int).Assembly;
	}

	static Assembly AppDomain_AssemblyResolve (object sender, ResolveEventArgs args)
	{
		return Assembly.ReflectionOnlyLoadFrom (Assembly.GetExecutingAssembly ().Location);
	}
}
