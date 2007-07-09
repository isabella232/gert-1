using System;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static void Main ()
	{
		AssemblyBuilderAccess access = AssemblyBuilderAccess.RunAndSave;
		TypeAttributes attribs = TypeAttributes.Public;

		AssemblyName name = new AssemblyName ();
		name.Name = "test";
		AssemblyBuilder assembly = AppDomain.CurrentDomain.DefineDynamicAssembly (name, access);

		ModuleBuilder module = assembly.DefineDynamicModule ("m", "test.dll");
		TypeBuilder t = module.DefineType ("T", attribs, null);
		MethodBuilder m = t.DefineMethod ("M", MethodAttributes.Public, typeof (void),
			new Type [0]);
		ILGenerator il = m.GetILGenerator ();
		il.BeginExceptionBlock ();
		il.BeginExceptFilterBlock ();
		il.BeginCatchBlock (null);
		il.BeginCatchBlock (typeof (SystemException));
		il.EndExceptionBlock ();

		il.Emit (OpCodes.Ret);
		t.CreateType ();
	}
}
