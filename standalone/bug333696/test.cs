using System;
using System.Reflection;
using System.Reflection.Emit;

public class Testcase
{
	public static int [] Array = new int [] { 1, 2, 3, 4 };
	private static readonly FieldInfo ArrayFI = typeof (Testcase).GetField ("Array");
	
	static int Main ()
	{
		if (!DoLdelem ())
			return 1;
		if (!DoStelem ())
			return 2;
		return 0;
	}
	
	static bool DoStelem ()
	{
		DynamicMethod dm = new DynamicMethod ("EmittedStelem", null, null, typeof (Testcase));
		ILGenerator il = dm.GetILGenerator ();
		il.Emit (OpCodes.Ldsfld, ArrayFI);
		il.Emit (OpCodes.Ldc_I4_0);
		il.Emit (OpCodes.Ldc_I4_0);
		il.Emit (OpCodes.Stelem, typeof (int));
		il.Emit (OpCodes.Ret);
		dm.Invoke (null, null);
		return (Array [0] == 0);
	}
	
	static bool DoLdelem ()
	{
		DynamicMethod dm = new DynamicMethod ("EmittedLdelem", typeof (int), null, typeof (Testcase));
		ILGenerator il = dm.GetILGenerator ();
		il.Emit (OpCodes.Ldsfld, ArrayFI);
		il.Emit (OpCodes.Ldc_I4_1);
		il.Emit (OpCodes.Ldelem, typeof (int));
		il.Emit (OpCodes.Ret);
		int i = (int) dm.Invoke (null, null);
		return (i == 2);
	}
}
