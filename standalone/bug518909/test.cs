using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

public class MainClass
{
	public static void Main(string[] args)
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		using (FileStream fs = File.Open (Path.Combine (basedir, "key.snk"), FileMode.Open)) {
			AssemblyName asmname = new AssemblyName ();
			asmname.Name = "snafu2";
			asmname.KeyPair = new StrongNameKeyPair (fs);

			AssemblyBuilder asm = AppDomain.CurrentDomain.DefineDynamicAssembly (asmname, AssemblyBuilderAccess.RunAndSave);
			ModuleBuilder mod = asm.DefineDynamicModule (asmname.Name + ".dll");
			TypeBuilder type = mod.DefineType ("bar", TypeAttributes.Public);
			MethodBuilder meth = type.DefineMethod ("foo", MethodAttributes.Static | MethodAttributes.Public, typeof (string), Type.EmptyTypes);
			ILGenerator il = meth.GetILGenerator ();
			il.Emit (OpCodes.Newobj, typeof (other.MainClass).GetConstructor (Type.EmptyTypes));
			il.Emit (OpCodes.Call, typeof (other.MainClass).GetMethod ("Main", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static));
			il.Emit (OpCodes.Ret);

			Type t = type.CreateType ();
			asm.Save (asmname.Name + ".dll");

			Assembly baked = Assembly.LoadFrom (Path.Combine (basedir, asmname.Name + ".dll"));
			Assert.AreEqual ("internal", baked.GetType ("bar").GetMethod ("foo").Invoke (null, null), "#1");
			Assert.AreEqual ("internal", t.GetMethod ("foo").Invoke (null, null), "#2");
		}
	}
}
