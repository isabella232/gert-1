using System;
using System.Reflection;
using System.Reflection.Emit;

public class Test
{
	static int Main (string [] args)
	{
		AssemblyBuilderAccess access = AssemblyBuilderAccess.RunAndSave;
		TypeAttributes attribs = TypeAttributes.Public;

		AssemblyName name = new AssemblyName ();
		name.Name = "enumtest";
		AssemblyBuilder assembly = AppDomain.CurrentDomain.DefineDynamicAssembly (
			name, access);

		ModuleBuilder module = assembly.DefineDynamicModule ("m", "enumtest.dll");
		EnumBuilder e = module.DefineEnum ("E", attribs, typeof (int));

		bool equal = typeof (int).Equals (e);
		return equal ? 0 : 1;
	}
}
