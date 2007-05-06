using System;
using System.Reflection;
using System.Reflection.Emit;

public class Test
{
	static void Main (string [] args)
	{
		AppDomain domain = AppDomain.CurrentDomain;
		AssemblyName name = new AssemblyName ();
		name.Name = "test";
		AssemblyBuilder assembly = domain.DefineDynamicAssembly (name, AssemblyBuilderAccess.RunAndSave);
		ModuleBuilder module = assembly.DefineDynamicModule ("module");
		TypeBuilder T = module.DefineType ("AType");
		EnumBuilder E = module.DefineEnum ("AnEnum", TypeAttributes.Public, typeof (int));
		MethodBuilder method = T.DefineMethod ("Method", MethodAttributes.Public, typeof(void), Type.EmptyTypes);
		ILGenerator il = method.GetILGenerator ();
		il.Emit (OpCodes.Box, E);
	}
}
