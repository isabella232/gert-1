using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	static ArrayList _assemblyBuilders = new ArrayList ();

	static void Main ()
	{
		AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler (
			AppDomain_AssemblyResolve);

		AssemblyBuilder ab1 = AppDomain.CurrentDomain.DefineDynamicAssembly (
			CreateAssemblyName ("bug331601a"),
			AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);
		_assemblyBuilders.Add (ab1);

		Console.WriteLine ("A");
		object p1 = Create (ab1, "A", typeof (MyClass));
		Serialize (p1);

		AssemblyBuilder ab2 = AppDomain.CurrentDomain.DefineDynamicAssembly (
			CreateAssemblyName ("bug331601b"),
			AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);
		_assemblyBuilders.Add (ab2);

		Console.WriteLine ("B");
		object p2 = Create (ab2, "B", p1.GetType ());
		Serialize (p2);

		Console.WriteLine ("C");
		object q1 = Save ("C", p2.GetType ());
		Serialize (q1);
	}

	static AssemblyName CreateAssemblyName (string name)
	{
		AssemblyName aname = new AssemblyName ();
		aname.Name = name;
		return aname;
	}

	static void Serialize (object value)
	{
		MemoryStream ms = new MemoryStream ();

		BinaryFormatter bf = new BinaryFormatter ();
		bf.Serialize (ms, value);

		ms.Position = 0;

		bf = new BinaryFormatter ();
		bf.Deserialize (ms);
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

	static object Save (string typeName, Type baseType)
	{
		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			CreateAssemblyName ("bug331601c"),
			AssemblyBuilderAccess.RunAndSave,
			AppDomain.CurrentDomain.BaseDirectory);

		ModuleBuilder mb = ab.DefineDynamicModule (ab.GetName ().Name + ".dll");
		TypeBuilder tb = mb.DefineType (typeName, TypeAttributes.Public, baseType);
		tb.SetCustomAttribute (new CustomAttributeBuilder (
			typeof (SerializableAttribute).GetConstructor (
			Type.EmptyTypes), new object [0]));
		Type emittedType = tb.CreateType ();
		ab.Save (ab.GetName ().Name + ".dll");
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
