using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

public class Program
{
	static int Main ()
	{
		AssemblyName assemblyName = new AssemblyName ();
		assemblyName.Name = "customMod";
		assemblyName.Version = new Version (1, 2, 3, 4);

		AssemblyBuilder assembly
			= Thread.GetDomain ().DefineDynamicAssembly (
				  assemblyName, AssemblyBuilderAccess.RunAndSave);

		ModuleBuilder module = assembly.DefineDynamicModule ("res", "res.dll");

		TypeBuilder tb = module.DefineType ("Test2", TypeAttributes.Public, typeof (object));

		{
			MethodBuilder mb =
				tb.DefineMethod ("test", MethodAttributes.Public | MethodAttributes.Static,
								 typeof (object), null);
			ILGenerator il = mb.GetILGenerator ();

			il.Emit (OpCodes.Newobj, typeof (Bar).GetConstructor (new Type [] { }));
			il.Emit (OpCodes.Ldftn, typeof (FOO).GetMethod ("handler"));
			il.Emit (OpCodes.Newobj, typeof (ResolveEventHandler).GetConstructor (new Type [] { typeof (object), typeof (IntPtr) }));
			il.Emit (OpCodes.Ldnull);
			il.Emit (OpCodes.Ldnull);
			il.Emit (OpCodes.Call, typeof (ResolveEventHandler).GetMethod ("Invoke"));
			il.Emit (OpCodes.Ret);
		}

		Type t = tb.CreateType ();

		Object obj = Activator.CreateInstance (t, new object [0] { });

		Assembly a = (Assembly) t.GetMethod ("test").Invoke (obj, null);
		if (a != typeof (int).Assembly)
			return 1;
		return 0;
	}

	public interface FOO
	{
		Assembly handler (object sender, ResolveEventArgs e);
	}

	public class Bar : FOO
	{
		public Bar ()
		{
		}

		public Assembly handler (object sender, ResolveEventArgs e)
		{
			return typeof (int).Assembly;
		}
	}
}
