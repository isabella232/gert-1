using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

class Program
{
	static void Main ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		AssemblyName aname = new AssemblyName ();
		aname.Name = "bug424663";

		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			aname, AssemblyBuilderAccess.Save, basedir);
		ModuleBuilder module = ab.DefineDynamicModule ("bug424663.dll");

		TypeBuilder tb1 = module.DefineType ("Gen", TypeAttributes.Class | TypeAttributes.Public);
		tb1.DefineGenericParameters ("T");
		FieldBuilder fb = tb1.DefineField ("str", typeof (string), new Type [] {
			typeof (IsVolatile) }, Type.EmptyTypes, FieldAttributes.Family | FieldAttributes.Static);

		Type genT = tb1.MakeGenericType (typeof (string));

		FieldInfo fi = TypeBuilder.GetField (genT, fb);

		TypeBuilder tb2 = module.DefineType ("Program", TypeAttributes.Public);
		MethodBuilder mb = tb2.DefineMethod ("Main", MethodAttributes.Static | MethodAttributes.Public);
		ILGenerator ilgen = mb.GetILGenerator ();
		ilgen.DeclareLocal (typeof (string));
		ilgen.Emit (OpCodes.Ldsfld, fi);
		ilgen.EmitCall (OpCodes.Call, typeof (Console).GetMethod ("WriteLine", BindingFlags.Public | BindingFlags.Static, null, new Type [] { typeof (string) }, new ParameterModifier [0]), null);
		ilgen.Emit (OpCodes.Nop);
		ilgen.Emit (OpCodes.Ret);
		tb2.CreateType ();

		tb1.CreateType ();

		ab.Save ("bug424663.dll");
	}
}
