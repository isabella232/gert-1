using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		Assembly assembly;

#if NET_2_0
		AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler (AppDomain_ReflectionOnlyAssemblyResolve);
		assembly = Assembly.ReflectionOnlyLoad ("B");
		try {
			assembly.GetType ("TypeLoad.BA");
			Assert.Fail ("#A1");
		} catch (TypeLoadException ex) {
			// Could not load type 'A' from assembly '...'
			Assert.AreEqual (typeof (TypeLoadException), ex.GetType (), "#A2");
			Assert.IsNull (ex.InnerException, "#A3");
			Assert.IsNotNull (ex.Message, "#A4");
			Assert.IsTrue (ex.Message.IndexOf ("'" + ex.TypeName + "'") != -1, "#A5:" + ex.Message);
			Assert.IsTrue (ex.Message.IndexOf (Assembly.GetExecutingAssembly ().FullName) != -1, "#A6:" + ex.Message);
			Assert.AreEqual ("TypeLoad.A", ex.TypeName, "#A7");
		}
#endif

		File.Delete (Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "A.dll"));

		AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler (AppDomain_AssemblyResolve);
		assembly = Assembly.Load ("B");
#if NET_2_0
		try {
			assembly.GetType ("TypeLoad.BA");
			Assert.Fail ("#B1");
		} catch (TypeLoadException ex) {
			// Could not load type 'A' from assembly '...'
			Assert.AreEqual (typeof (TypeLoadException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");
			Assert.IsTrue (ex.Message.IndexOf ("'TypeLoad.A'") != -1, "#B5:" + ex.Message);
			Assert.IsTrue (ex.Message.IndexOf (typeof (int).Assembly.FullName) != -1, "#B6:" + ex.Message);
			Assert.AreEqual ("TypeLoad.A", ex.TypeName, "#B7");
		}
#else
		Type type = assembly.GetType ("TypeLoad.BA");
		Assert.IsNull (type, "#B1");
#endif
	}

	static Assembly AppDomain_AssemblyResolve (object sender, ResolveEventArgs args)
	{
		switch (args.Name) {
		case "A, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null":
			return typeof (int).Assembly;
		default:
			return null;
		}
	}

#if NET_2_0
	static Assembly AppDomain_ReflectionOnlyAssemblyResolve (object sender, ResolveEventArgs args)
	{
		switch (args.Name) {
		case "A, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null":
			return Assembly.ReflectionOnlyLoadFrom (Assembly.GetExecutingAssembly ().Location);
		default:
			return null;
		}
	}
#endif
}
