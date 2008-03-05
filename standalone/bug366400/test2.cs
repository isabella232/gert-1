using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

class Program
{
	public delegate object BodyDelegate (object [] parameters);

	public static int GetInt (int i)
	{
		return i;
	}

	static void Main (string [] args)
	{
		MethodInfo minfo = typeof (Program).GetMethod ("GetInt");
		DynamicMethod method = new DynamicMethod ("GetInt", typeof (object),
			new Type [] { typeof (object []) }, typeof (Program).Module);

		// generate the method body
		ILGenerator generator = method.GetILGenerator ();

		MethodInfo changetype = typeof (Convert).GetMethod ("ChangeType",
			new Type [] { typeof (object), typeof (Type), typeof (IFormatProvider) });
		MethodInfo gettypefromhandle = typeof (Type).GetMethod ("GetTypeFromHandle",
			new Type [] { typeof (RuntimeTypeHandle) });
		MethodInfo get_InvariantCulture = typeof (CultureInfo).GetMethod (
			"get_InvariantCulture", BindingFlags.Static | BindingFlags.Public,
			null, Type.EmptyTypes, null);

		// for each parameter of the original method, load it on stack
		ParameterInfo [] parameters = minfo.GetParameters ();
		for (int i = 0; i < parameters.Length; i++) {
			ParameterInfo par = parameters [i];
			// load the array
			generator.Emit (OpCodes.Ldarg, 0);
			// load the index in the array
			generator.Emit (OpCodes.Ldc_I4, (int) i);
			// get the element at given index
			generator.Emit (OpCodes.Ldelem_Ref);
			// convert it if necessary
			if (par.ParameterType.IsPrimitive || par.ParameterType == typeof (string)) {
				// load the parameter type onto stack
				generator.Emit (OpCodes.Ldtoken, par.ParameterType);
				generator.EmitCall (OpCodes.Callvirt, gettypefromhandle, null);
				// load the invariant culture onto stack
				generator.EmitCall (OpCodes.Call, get_InvariantCulture, null);
				// call Convert.ChangeType
				generator.EmitCall (OpCodes.Call, changetype, null);
				// if necessary, unbox the value
				if (par.ParameterType.IsValueType)
					generator.Emit (OpCodes.Unbox_Any, par.ParameterType);
			}
		}

		generator.EmitCall (OpCodes.Call, minfo, null);

		if (minfo.ReturnType == typeof (void))
			generator.Emit (OpCodes.Ldnull);
		if (minfo.ReturnType.IsValueType)
			generator.Emit (OpCodes.Box, minfo.ReturnType);
		generator.Emit (OpCodes.Ret);

		BodyDelegate del = (BodyDelegate) method.CreateDelegate (
			typeof (BodyDelegate));
		Assert.AreEqual (0, del (new object [] { 0 }), "#1");
		Assert.AreEqual (5, del (new object [] { 5 }), "#2");
	}
}
