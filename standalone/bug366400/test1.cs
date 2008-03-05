using System;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
	public delegate int BodyDelegate ();

	static int Main (string [] args)
	{
		DynamicMethod method = new DynamicMethod ("GetInt", typeof (int),
			Type.EmptyTypes, typeof (Program).Module);
		ILGenerator generator = method.GetILGenerator ();

		MethodInfo parse = typeof (Int32).GetMethod ("Parse",
			new Type [] { typeof (string) });
		generator.Emit (OpCodes.Ldstr, "555");
		generator.EmitCall (OpCodes.Callvirt, parse, null);
		generator.Emit (OpCodes.Ret);

		BodyDelegate del = (BodyDelegate) method.CreateDelegate (typeof (BodyDelegate));
		return (del () == 555) ? 0 : 1;
	}
}
