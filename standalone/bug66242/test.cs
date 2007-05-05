using System;
using System.Reflection;
using System.Reflection.Emit;

public class EntryPoint
{
	static int Main ()
	{
		AssemblyName assemblyName = new AssemblyName();
		assemblyName.Name = "DynamicAssembly";

		AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.
			DefineDynamicAssembly(assemblyName,
				AssemblyBuilderAccess.Save);

		ModuleBuilder moduleBuilder = assemblyBuilder.
			DefineDynamicModule(assemblyName.Name,
			assemblyName.Name + ".dll");

		TypeBuilder tb = moduleBuilder.DefineType("NewType",
			TypeAttributes.Public | TypeAttributes.Class,
			Assembly.GetExecutingAssembly().GetType("TestNoDefaultCtor"));

		try {
			tb.CreateType ();
			return 1;
		} catch (NotSupportedException) {
			return 0;
		}
	}
}

public class TestNoDefaultCtor
{
	public TestNoDefaultCtor(string value)
	{
	}
}
