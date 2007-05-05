using System;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static int Main ()
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = "DummyAssembly";
		AssemblyBuilder lAssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave, AppDomain.CurrentDomain.BaseDirectory);
		ModuleBuilder lModuleBuilder = lAssemblyBuilder.DefineDynamicModule (aname.Name, aname.Name + ".dll");
		TypeAttributes lAttributes = TypeAttributes.Public | TypeAttributes.Class;
		TypeBuilder lTypeBuilder = lModuleBuilder.DefineType ("Dummy." + aname.Name, lAttributes, null);

		lTypeBuilder.CreateType ();
		lAssemblyBuilder.Save (aname.Name + ".dll");

		Type t = Type.GetType ("Dummy.DummyAssembly,DummyAssembly", true);
		if (t == null)
			return 1;
		if (t.AssemblyQualifiedName != "Dummy.DummyAssembly, DummyAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")
			return 2;
		return 0;
	}
}
