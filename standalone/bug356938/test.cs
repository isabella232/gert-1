using System;
using System.Reflection;
using Specialized = System.Collections.Specialized;
using System.Reflection.Emit;
using System.Diagnostics;
using System.Threading;

class Program
{
	static void Main (string [] args)
	{
		Module [] modules;
		Assembly a;
		Type [] types;
		MethodInfo [] methods;

		CreateDynamicAssembly createAssembly = new CreateDynamicAssembly ();
		AssemblyBuilder ab = createAssembly.CreateDynamicAssemblyByInjectingIL ();

		ab.Save ("test_assembly.dll");

		a = Assembly.LoadFrom ("test_assembly.dll");
		modules = a.GetModules ();

		Assert.AreEqual (2, modules.Length, "#A1");
		Assert.AreEqual ("test_assembly.dll", modules [0].Name, "#A2");
		types = modules [0].GetTypes ();
		Assert.AreEqual (0, types.Length, "#A3");
		types = modules [0].GetTypes ();
#if NET_2_0
		Assert.AreEqual ("myDynamicModule.dll", modules [1].Name, "#A4");
#else
		Assert.IsTrue (string.Compare (modules [1].Name, "myDynamicModule.dll", true) == 0, "#A4");
#endif
		types = modules [1].GetTypes ();
		Assert.AreEqual (1, types.Length, "#A5");
		Assert.AreEqual ("myDynamicModuleType", types [0].FullName, "#A6");
		methods = types [0].GetMethods (BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static);
		Assert.AreEqual (1, methods.Length, "#A7");
		Assert.AreEqual ("testDynamic", methods [0].Name, "#A8");

		// Access the assembly in memory
		a = (Assembly) ab;
		modules = a.GetModules ();

		Assert.AreEqual (2, modules.Length, "#B1");

		bool foundModule = false;

		for (int i = 0; i < modules.Length; i++) {
			Assert.IsNotNull (modules [i].Name, "#B2");
			types = modules [i].GetTypes ();

			if (types.Length > 0) {
				Assert.IsFalse (foundModule, "#B3");
				Assert.AreEqual (1, types.Length, "#B4");
				Assert.AreEqual ("myDynamicModuleType", types [0].FullName, "#B5");
				methods = types [0].GetMethods (BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static);
				Assert.AreEqual (1, methods.Length, "#B6");
				Assert.AreEqual ("testDynamic", methods [0].Name, "#B7");
				foundModule = true;
			} else {
				Assert.AreEqual (0, types.Length, "#B8");
			}
		}

		Assert.IsTrue (foundModule, "#C");
	}
}

class CreateDynamicAssembly
{
	public void AddMethodDynamically (ref TypeBuilder myTypeBld,
			 string mthdName,
			 Type [] mthdParams,
			 Type returnType,
			 string mthdAction)
	{
		MethodBuilder myMthdBld = myTypeBld.DefineMethod (
					mthdName,
					MethodAttributes.Public |
					MethodAttributes.Static,
					returnType,
					mthdParams);

		ILGenerator ILout = myMthdBld.GetILGenerator ();

		int numParams = mthdParams.Length;

		for (byte x = 0; x < numParams; x++)
			ILout.Emit (OpCodes.Ldarg_S, x);

		if (numParams > 1) {
			for (int y = 0; y < (numParams - 1); y++) {
				switch (mthdAction) {
				case "A": ILout.Emit (OpCodes.Add);
					break;
				case "M": ILout.Emit (OpCodes.Mul);
					break;
				default: ILout.Emit (OpCodes.Add);
					break;
				}
			}
		}
		ILout.Emit (OpCodes.Ret);
	}

	public AssemblyBuilder CreateDynamicAssemblyByInjectingIL ()
	{
		AssemblyName newName = new AssemblyName ();
		newName.Name = "myDynamicAssembly";

		AssemblyBuilder asmBuilder = Thread.GetDomain ().DefineDynamicAssembly (
			newName, AssemblyBuilderAccess.RunAndSave);

		ModuleBuilder newModule = asmBuilder.DefineDynamicModule (
			"myDynamicModule1", "myDynamicModule.dll", true);

		TypeBuilder myTypeBld = newModule.DefineType ("myDynamicModuleType",
			TypeAttributes.Public);

		string myMthdName = "testDynamic";

		Int32 [] inputValsList = new Int32 [] { 1, 2 };
		object [] inputValsListOBJECT = new object [inputValsList.Length];

		Type [] myMthdParams = new Type [inputValsList.Length];
		for (int i = 0; i < inputValsList.Length; i++) {
			inputValsListOBJECT [i] = (object) inputValsList [i];
			myMthdParams [i] = typeof (Int32);
		}

		AddMethodDynamically (ref myTypeBld,
					myMthdName,
					myMthdParams,
					typeof (int),
					"A");
		myTypeBld.CreateType ();
		return asmBuilder;
	}
}
