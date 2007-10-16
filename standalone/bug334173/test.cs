using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static int Main ()
	{
		AppDomain domain = AppDomain.CreateDomain ("bug334173");
		RemoteSerializer remser = (RemoteSerializer) domain.CreateInstanceFromAndUnwrap (
			typeof (Program).Assembly.Location, typeof (RemoteSerializer).FullName);
		object p1 = remser.Run ("bug334173a", typeof (MyClass));
		if (p1 == null)
			return 1;
		object p2 = remser.Run ("bug334173b", p1.GetType ());
		if (p2 == null)
			return 2;
		return 0;
	}
}

class RemoteSerializer : MarshalByRefObject
{
	public object Run (string assemblyName, Type baseType)
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = assemblyName;
		aname.Version = new Version (4, 1);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);

		ModuleBuilder mb = ab.DefineDynamicModule (assemblyName + ".dll");
		TypeBuilder tb = mb.DefineType ("Person", TypeAttributes.Public,
			baseType);
		tb.SetCustomAttribute (new CustomAttributeBuilder (
			typeof (SerializableAttribute).GetConstructor (
			Type.EmptyTypes), new object [0]));

		Type emittedType = tb.CreateType ();

		ab.Save (assemblyName + ".dll");
		return Activator.CreateInstance (emittedType);
	}
}

[Serializable]
public class MyClass
{
}
