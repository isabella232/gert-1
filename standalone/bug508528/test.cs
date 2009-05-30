using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		Assembly assembly;
		Type type;

#if NET_2_0
		assembly = Assembly.ReflectionOnlyLoad ("C");

		try {
			assembly.GetType ("TypeLoad.CA");
			Assert.Fail ("#A1");
		} catch (FileLoadException ex) {
			// Cannot resolve dependency to assembly '...' because
			// it has not been preloaded. When using the ReflectionOnly
			// APIs, dependent assemblies must be pre-loaded or loaded
			// on demand through the ReflectionOnlyAssemblyResolve event
			Assert.AreEqual (typeof (FileLoadException), ex.GetType (), "#A2");
			Assert.AreEqual ("A, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ex.FileName, "#A3");
			Assert.IsNull (ex.InnerException, "#A4");
			Assert.IsNotNull (ex.Message, "#A5");
			Assert.IsTrue (ex.Message.IndexOf ("'TypeLoad.A'") == -1, "#A6:" + ex.Message);
			Assert.IsTrue (ex.Message.IndexOf ("'TypeLoad.BA'") == -1, "#A7:" + ex.Message);
			Assert.IsTrue (ex.Message.IndexOf ("'" + ex.FileName + "'") != -1, "#A8:" + ex.Message);
		}

		try {
			assembly.GetType ("TypeLoad.CB");
			Assert.Fail ("#B1");
		} catch (FileLoadException ex) {
			// Cannot resolve dependency to assembly '...' because
			// it has not been preloaded. When using the ReflectionOnly
			// APIs, dependent assemblies must be pre-loaded or loaded
			// on demand through the ReflectionOnlyAssemblyResolve event
			Assert.AreEqual (typeof (FileLoadException), ex.GetType (), "#B2");
			Assert.AreEqual ("B, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ex.FileName, "#B3");
			Assert.IsNull (ex.InnerException, "#B4");
			Assert.IsNotNull (ex.Message, "#B5");
			Assert.IsTrue (ex.Message.IndexOf ("'TypeLoad.A'") == -1, "#B6:" + ex.Message);
			Assert.IsTrue (ex.Message.IndexOf ("'TypeLoad.BA'") == -1, "#B7:" + ex.Message);
			Assert.IsTrue (ex.Message.IndexOf ("'" + ex.FileName + "'") != -1, "#B8:" + ex.Message);
		}

		type = assembly.GetType ("TypeLoad.CC");
		Assert.IsNull (type, "#C1");

		AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler (AppDomain_ReflectionOnlyAssemblyResolve);
		assembly = Assembly.ReflectionOnlyLoad ("C");

		try {
			assembly.GetType ("TypeLoad.CB");
			Assert.Fail ("#D1");
		} catch (FileLoadException ex) {
			// Cannot resolve dependency to assembly '...' because
			// it has not been preloaded. When using the ReflectionOnly
			// APIs, dependent assemblies must be pre-loaded or loaded
			// on demand through the ReflectionOnlyAssemblyResolve event
			Assert.AreEqual (typeof (FileLoadException), ex.GetType (), "#D2");
			Assert.AreEqual ("B, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ex.FileName, "#D3");
			Assert.IsNull (ex.InnerException, "#D4");
			Assert.IsNotNull (ex.Message, "#D5");
			Assert.IsTrue (ex.Message.IndexOf ("'" + ex.FileName + "'") != -1, "#D6:" + ex.Message);
		}
#endif

		File.Delete (Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "A.dll"));
		File.Delete (Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "B.dll"));

		assembly = Assembly.Load ("C");
		type = assembly.GetType ("TypeLoad.CA");
		Assert.IsNull (type, "#E1");
		type = assembly.GetType ("TypeLoad.CB");
		Assert.IsNull (type, "#E2");
		type = assembly.GetType ("TypeLoad.CC");
		Assert.IsNull (type, "#E3");
	}

#if NET_2_0
	static Assembly AppDomain_ReflectionOnlyAssemblyResolve (object sender, ResolveEventArgs args)
	{
		switch (args.Name) {
		case "A, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null":
			return Assembly.ReflectionOnlyLoadFrom (Assembly.GetExecutingAssembly ().Location);
		case "B, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null":
			return null;
		default:
			return null;
		}
	}
#endif
}
