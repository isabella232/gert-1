using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

public class Test
{
	static int Main ()
	{
		AssemblyBuilderAccess access = AssemblyBuilderAccess.RunAndSave;
		TypeAttributes attribs = TypeAttributes.Public;

		AssemblyName name = new AssemblyName ();
		name.Name = "enumtest";
		AssemblyBuilder assembly = AppDomain.CurrentDomain.DefineDynamicAssembly (name, access);

		ModuleBuilder module = assembly.DefineDynamicModule ("m", "enumtest.dll");
		EnumBuilder e = module.DefineEnum ("E", attribs, typeof (int));
		FieldBuilder field = e.DefineLiteral ("A", 1);
		Type en = e.CreateType ();

#if NET_2_0
		if (field.FieldType.FullName != "E") {
			Console.WriteLine ("#1: " + field.FieldType.FullName);
			return 1;
		}
#else
		if (field.FieldType != typeof (int)) {
			Console.WriteLine ("#1: " +field.FieldType.FullName);
			return 1;
		}
#endif

		FieldInfo f = en.GetField ("A");

#if NET_2_0
		if (f.FieldType.FullName != "E") {
			Console.WriteLine ("#2: " + field.FieldType.FullName);
			return 1;
		}
#else
		if (f.FieldType != typeof (int)) {
			Console.WriteLine ("#2: " + field.FieldType.FullName);
			return 1;
		}
#endif

		return 0;
	}
}
