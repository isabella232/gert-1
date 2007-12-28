using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

class Program
{
	static void Main ()
	{
		// create a dynamic assembly and module 
		AssemblyName assemblyName = new AssemblyName ();
		assemblyName.Name = "HelloWorld";
		AssemblyBuilder assemblyBuilder = Thread.GetDomain ().DefineDynamicAssembly (
			assemblyName, AssemblyBuilderAccess.RunAndSave);

		ModuleBuilder module = assemblyBuilder.DefineDynamicModule ("b.dll");
		// <-- pass 'true' to track debug info.

		// create a new type to hold our Main method 
		TypeBuilder typeBuilder = module.DefineType ("HelloWorldType",
			TypeAttributes.Public | TypeAttributes.Class);

		// create the Main(string[] args) method 
		MethodBuilder methodbuilder = typeBuilder.DefineMethod ("Demo",
			MethodAttributes.HideBySig | MethodAttributes.Static |
			MethodAttributes.Public, typeof (void),
			new Type [] { typeof (string []) });

		// generate the IL for the Main method 
		ILGenerator ilGenerator = methodbuilder.GetILGenerator ();

		// Create a local variable of type 'string', and call it 'xyz'
		LocalBuilder localXYZ = ilGenerator.DeclareLocal (typeof (string));

		// Emit sequence point before the IL instructions. This is start line,
		// start col, end line, end column, 

		// Line 2: xyz = "hello"; 
		ilGenerator.Emit (OpCodes.Ldstr, "Hello world!");
		ilGenerator.Emit (OpCodes.Stloc, localXYZ);

		// Line 3: Write(xyz); 
		MethodInfo infoWriteLine = typeof (System.Console).GetMethod (
			"WriteLine", new Type [] { typeof (string) });
		ilGenerator.Emit (OpCodes.Ldloc, localXYZ);
		ilGenerator.EmitCall (OpCodes.Call, infoWriteLine, null);

		SignatureHelper sh = SignatureHelper.GetMethodSigHelper (module,
			(CallingConventions) 0, typeof (int));
		ilGenerator.Emit (OpCodes.Call, sh);
		// Line 4: return; 
		ilGenerator.Emit (OpCodes.Ret);

		// bake it 
		Type helloWorldType = typeBuilder.CreateType ();

		assemblyBuilder.Save ("b.dll");

		MethodInfo mi = helloWorldType.GetMethod ("Demo");

		try {
			mi.Invoke (null, new string [] { null });
			Assert.Fail ("#1");
		} catch (TargetInvocationException ex) {
			Assert.AreEqual (typeof (TargetInvocationException), ex.GetType (), "#2");
			Assert.IsNotNull (ex.InnerException, "#3");
			Assert.IsNotNull (ex.Message, "#4");

			BadImageFormatException inner = ex.InnerException as BadImageFormatException;
			Assert.IsNotNull (inner, "#5");
			Assert.IsNull (inner.InnerException, "#6");
			Assert.IsNotNull (inner.Message, "#7");
		}
	}
}
