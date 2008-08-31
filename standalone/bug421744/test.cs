using System;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static void Main ()
	{
		NotCreated ();
		Created ();
	}

	static void NotCreated ()
	{
		AssemblyName assemblyName = new AssemblyName ();
		assemblyName.Name = "Lib";

		AssemblyBuilder assembly = AppDomain.CurrentDomain.DefineDynamicAssembly (
			assemblyName, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);

		ModuleBuilder module = assembly.DefineDynamicModule ("Lib");

		TypeBuilder tb = module.DefineType ("Foo", TypeAttributes.Class,
			null, new Type [] { typeof (IBar) });
		tb.DefineGenericParameters ("T");

		Type typeBarOfInt32 = tb.MakeGenericType (typeof (int));

		Assert.IsFalse (typeof (IComparable).IsAssignableFrom (typeBarOfInt32), "#A1");
		Assert.IsFalse (typeof (IBar).IsAssignableFrom (typeBarOfInt32), "#A2");

		tb.CreateType ();
		typeBarOfInt32 = tb.MakeGenericType (typeof (int));

		Assert.IsFalse (typeof (IComparable).IsAssignableFrom (typeBarOfInt32), "#A3");
		Assert.IsFalse (typeof (IBar).IsAssignableFrom (typeBarOfInt32), "#A4");
	}

	static void Created ()
	{
		AssemblyName assemblyName = new AssemblyName ();
		assemblyName.Name = "Lib";

		AssemblyBuilder assembly = AppDomain.CurrentDomain.DefineDynamicAssembly (
			assemblyName, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);

		ModuleBuilder module = assembly.DefineDynamicModule ("Lib");

		TypeBuilder tb = module.DefineType ("Foo", TypeAttributes.Class,
			null, new Type [] { typeof (IBar) });
		tb.DefineGenericParameters ("T");

		Type created = tb.CreateType ();
		Type typeBarOfInt32 = created.MakeGenericType (typeof (int));

		Assert.IsFalse (typeof (IComparable).IsAssignableFrom (typeBarOfInt32), "#B1");
		Assert.IsTrue (typeof (IBar).IsAssignableFrom (typeBarOfInt32), "#B2");
	}
}

public interface IBar
{
}
