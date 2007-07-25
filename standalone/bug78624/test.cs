using System;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static void Main ()
	{
		Type t = GenerateType (typeof (Test));
		Activator.CreateInstance (t, new object [0]);
	}

	static ModuleBuilder CreateModule (string name)
	{
		AppDomain myDomain = System.Threading.Thread.GetDomain ();
		AssemblyName myAsmName = new AssemblyName ();
		myAsmName.Name = name;
		AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly (myAsmName, AssemblyBuilderAccess.RunAndSave);
		return myAsmBuilder.DefineDynamicModule (name, name + ".dll");
	}

	static Type GenerateType (Type src)
	{
		ModuleBuilder mod = CreateModule ("test");
		TypeBuilder tb = mod.DefineType (src.Name, TypeAttributes.Public, null);
		ConstructorBuilder ctor = tb.DefineConstructor (MethodAttributes.Public,
			CallingConventions.Standard, Type.EmptyTypes);
		ILGenerator gen = ctor.GetILGenerator ();
		gen.Emit (OpCodes.Ret);
		return tb.CreateType ();
	}
}

public class Test
{
	public Echo echo = new Echo ();

	public class Echo
	{
		public string msg = "hi there";
	}
}
