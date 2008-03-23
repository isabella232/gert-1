using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;

public class Program
{
	static ThreadStart del = Foo;

	static void Main ()
	{
		AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (
			new AssemblyName ("foo"), AssemblyBuilderAccess.Run);
		ModuleBuilder modb = ab.DefineDynamicModule ("foo.dll");
		TypeBuilder tb = modb.DefineType ("Foo");
		MethodBuilder mb = tb.DefineMethod ("Frub", MethodAttributes.Static,
			null, new Type [] { typeof (IntPtr) });
		mb.SetImplementationFlags (MethodImplAttributes.NoInlining);
		ILGenerator ilgen = mb.GetILGenerator ();
		ilgen.Emit (OpCodes.Ldarg_0);
		ilgen.EmitCalli (OpCodes.Calli, CallingConvention.StdCall,
			typeof (void), Type.EmptyTypes);
		ilgen.Emit (OpCodes.Ret);
		Type type = tb.CreateType ();
		type.GetMethod ("Frub", BindingFlags.NonPublic | BindingFlags.Static)
			.Invoke (null, new object [] { Marshal.GetFunctionPointerForDelegate(del) });
	}

	public static void Foo ()
	{
		MethodBase m;

		m = new StackFrame (0).GetMethod ();
		Assert.AreEqual (typeof (Program), m.DeclaringType, "#A1");
		Assert.AreEqual ("Foo", m.Name, "#A2");

		m = new StackFrame (1).GetMethod ();
		Assert.AreEqual ("Foo", m.DeclaringType.Name, "#B1");
		Assert.AreEqual ("Frub", m.Name, "#B2");
	}
}
