using System;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static int Main ()
	{
		AppDomain currentDomain = AppDomain.CurrentDomain;
		AssemblyName asmName = new AssemblyName ();
		asmName.Name = "lib";
		string asmFileName = asmName.Name + ".dll";
		AssemblyBuilder asmBuilder =
		currentDomain.DefineDynamicAssembly (asmName,
			AssemblyBuilderAccess.RunAndSave);
		ModuleBuilder builder =
		asmBuilder.DefineDynamicModule ("_Created.netmodule", asmFileName);
		TypeBuilder typeBuilder =
			builder.DefineType ("TestClass2");
		typeBuilder.AddInterfaceImplementation (typeof (TestInterface));
		typeBuilder.AddInterfaceImplementation (typeof (TestInterface2));
		typeBuilder.CreateType ();

		Type testClass2Type = builder.GetType ("TestClass2");
		Type result = testClass2Type.GetInterface ("TestInterface");
		if (result.FullName != "TestInterface")
			return 1;
		result = testClass2Type.GetInterface ("TestInterface2");
		if (result.FullName != "TestInterface2")
			return 2;

		TypeBuilder typeBuilder2 = builder.DefineType ("TestDynIf",
			TypeAttributes.Interface | TypeAttributes.Public |
			TypeAttributes.Abstract);
		typeBuilder2.AddInterfaceImplementation (typeof (TestInterface));
		typeBuilder2.CreateType ();

		Type testIfDynType = builder.GetType ("TestDynIf");
		result = testIfDynType.GetInterface ("TestInterface");
		if (result.FullName != "TestInterface")
			return 3;

		asmBuilder.Save (asmFileName);
		return 0;
	}
}
