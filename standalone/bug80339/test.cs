using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

public class Test
{
	static void Main ()
	{
		AppDomain domain = AppDomain.CurrentDomain;
		AssemblyName name = new AssemblyName ("test");
		AssemblyBuilder assembly = domain.DefineDynamicAssembly (name, AssemblyBuilderAccess.Save);
		ModuleBuilder module = assembly.DefineDynamicModule ("module", "module.dll");
		module.DefineManifestResource ("Res1", new MemoryStream (), ResourceAttributes.Public);
		module.DefineResource ("Res2", "desc");
		assembly.Save ("module.dll");
	}
}
