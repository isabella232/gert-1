using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static ArrayList _assemblyBuilders = new ArrayList ();

	static void Main ()
	{
		AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler (
			AppDomain_AssemblyResolve);

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			CreateAssemblyName ("bug331601a"),
			AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);
		_assemblyBuilders.Add (ab);

		object p1 = Create (ab, "A", typeof (MyClass));

		Type t1 = ab.GetType (p1.GetType ().FullName, true);
		Console.WriteLine (t1.AssemblyQualifiedName);

		Type t2 = Type.GetType (p1.GetType ().AssemblyQualifiedName, true, false);
		Console.WriteLine (t2.AssemblyQualifiedName);
	}

	static AssemblyName CreateAssemblyName (string name)
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = name;
		return aname;
	}

	static object Create (AssemblyBuilder ab, string typeName, Type baseType)
	{
		ModuleBuilder mb = ab.DefineDynamicModule (ab.GetName ().Name + ".dll");
		TypeBuilder tb = mb.DefineType (typeName, TypeAttributes.Public, baseType);
		tb.SetCustomAttribute (new CustomAttributeBuilder (
			typeof (SerializableAttribute).GetConstructor (
			Type.EmptyTypes), new object [0]));
		Type emittedType = tb.CreateType ();
		return Activator.CreateInstance (emittedType);
	}

	static Assembly AppDomain_AssemblyResolve (object sender, ResolveEventArgs args)
	{
		foreach (AssemblyBuilder ab in _assemblyBuilders) {
			if (args.Name.StartsWith (ab.GetName ().Name))
				return ab;
		}
		return null;
	}
}

[Serializable]
public class MyClass
{
}
