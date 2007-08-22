using System;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static int Main ()
	{
		string t = "Test";
		AssemblyName name = new AssemblyName ();
		name.Name = t;

		AssemblyBuilder asm = AppDomain.CurrentDomain.DefineDynamicAssembly (name,
			AssemblyBuilderAccess.RunAndSave);
		ModuleBuilder mod = asm.DefineDynamicModule ("Test.dll");

		TypeBuilder type = mod.DefineType ("C", TypeAttributes.Public, typeof (B));

		PropertyBuilder pb = type.DefineProperty ("S",
			PropertyAttributes.None, typeof (string), new Type [0]);

		MethodBuilder mb = type.DefineMethod ("get_S", MethodAttributes.Public |
			MethodAttributes.Virtual | MethodAttributes.HideBySig |
			MethodAttributes.SpecialName | MethodAttributes.ReuseSlot,
			typeof (string), new Type [0]);
		ILGenerator ilg = mb.GetILGenerator ();
		ilg.Emit (OpCodes.Ret);

		pb.SetSetMethod (mb);

		Type emittedType = type.CreateType ();

		PropertyInfo [] properties = emittedType.GetProperties ();
		if (properties.Length != 2)
			return 1;

		PropertyInfo property = properties [0];
		if (property.Name != "S")
			return 2;
		if (property.DeclaringType != emittedType)
			return 3;

		property = properties [1];
		if (property.Name != "S")
			return 4;
		if (property.DeclaringType != typeof (B))
			return 5;

		return 0;
	}
}

public class A
{
	string _s = "A";

	public virtual string S
	{
		get { return _s; }
	}

	public static string V
	{
		get { return null; }
	}
}

public class B : A
{
	public override string S
	{
		get { return ""; }
	}
}
