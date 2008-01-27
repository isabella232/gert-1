using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;

class Program
{
	static void Main ()
	{
		SortedList<FileInfo, int> daBug = new SortedList<FileInfo, int> (new MemberComparer<FileInfo> ("FullName"));
		daBug.Add (new FileInfo ("."), 666);
	}
}

class MemberComparer<T> : IComparer<T>
{
	private delegate int CompareDelegate (T x, T y);
	private readonly CompareDelegate _compare;
	private static readonly Dictionary<string, CompareDelegate> _memberGetDelegates =
		new Dictionary<string, CompareDelegate> ();

	public MemberComparer (string memberName)
	{
		_compare = GetCachedCompareDelegate (memberName);
	}

	public int Compare (T x, T y)
	{
		return _compare (x, y);
	}

	private static CompareDelegate GetCachedCompareDelegate (string memberName)
	{
		CompareDelegate cache;
		if (!_memberGetDelegates.TryGetValue (memberName, out cache))
			lock (_memberGetDelegates) {
				// Could have been added by the time we got a lock
				if (_memberGetDelegates.ContainsKey (memberName))
					return _memberGetDelegates [memberName];

				// OK, We definitely need to CG this now
				cache = GetCompareDelegate (memberName);
				_memberGetDelegates [memberName] = cache;
			}
		return cache;
	}

	private static CompareDelegate GetCompareDelegate (string memberName)
	{
		Type T = typeof (T);

		PropertyInfo pi = T.GetProperty (memberName);
		FieldInfo fi = T.GetField (memberName);
		MethodInfo mi = T.GetMethod (memberName);
		Type memberType = null;
		bool isMethod = false;

		if (pi != null) {
			if (pi.GetGetMethod () != null) {
				memberType = pi.PropertyType;
				mi = pi.GetGetMethod ();
				isMethod = true;
			} else
				throw new ArgumentException (
					String.Format ("Property: '{0}' of Type: '{1}' does not have a Public Get accessor", memberName, T.Name),
					memberName);
		} else if (mi != null) {
			if (mi.GetParameters ().Length > 0)
				throw new ArgumentException (
					String.Format ("Method: '{0}' of Type: '{1}' required arguments, and cannot be used", memberName, T.Name),
					memberName);

			memberType = mi.ReturnType;
			isMethod = true;
		} else if (fi != null)
			memberType = fi.FieldType;
		else
			throw new Exception (String.Format (
				"Property: '{0}' of Type: '{1}' does not have a Public Get accessor",
				memberName, T.Name));

		Type comparerType = typeof (Comparer<>).MakeGenericType (new Type [] { memberType });
		MethodInfo getDefaultMethod = comparerType.GetProperty ("Default").GetGetMethod ();
		MethodInfo compareMethod = getDefaultMethod.ReturnType.GetMethod ("Compare");

		DynamicMethod dm = new DynamicMethod ("Compare_" + memberName, typeof (int), new Type [] { T, T }, comparerType);
		ILGenerator il = dm.GetILGenerator ();

		// Load Comparer<memberType>.Default onto the stack
		il.EmitCall (OpCodes.Call, getDefaultMethod, null);

		// Load the member from arg 0 onto the stack
		il.Emit (OpCodes.Ldarg_0);
		if (isMethod)
			il.EmitCall (OpCodes.Callvirt, mi, null);
		else
			il.Emit (OpCodes.Ldfld);

		// Load the member from arg 1 onto the stack
		il.Emit (OpCodes.Ldarg_1);
		if (isMethod)
			il.EmitCall (OpCodes.Callvirt, mi, null);
		else
			il.Emit (OpCodes.Ldfld);

		// Call the Compare method
		il.EmitCall (OpCodes.Callvirt, compareMethod, null);

		il.Emit (OpCodes.Ret);

		return (CompareDelegate) dm.CreateDelegate (typeof (CompareDelegate));
	}
}
