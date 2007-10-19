using System;
using System.Reflection;
using System.Reflection.Emit;

public class G<T>  // this class is going to be defined in instance()
{
	public static T F;
	public static bool B;

	public static void Foo ()
	{
		bool b = B;
		if (b) {
		}

		Foo ();

		G<object>.Foo ();

		new G<T> ();

		new G<object> ();
	}

	public static void M<S> ()
	{
		T t = F;
		S s = default (S);

		object boxVar = t;
		if (boxVar == null) {
		}

		object boxMVar = s;
		if (boxMVar == null) {
		}

		G<object>.M<string> ();

		M<string> ();

		M<S> ();

		G<object>.M<S> ();
	}
}

public class Entry
{
	public static int Main ()
	{
		Instance ();
		Reference ();
		Constrained ();

		return 100;
	}

	public static void Instance ()
	{
		AssemblyName name = new AssemblyName ("Instance");
		AssemblyBuilder asmbuild = System.Threading.Thread.GetDomain ().DefineDynamicAssembly (name, AssemblyBuilderAccess.RunAndSave);
		ModuleBuilder mod = asmbuild.DefineDynamicModule ("Instance.exe");

		TypeBuilder G = mod.DefineType ("G", TypeAttributes.Public);
		Type T = G.DefineGenericParameters ("T") [0];
		Type GObj = G.MakeGenericType (new Type [] { typeof (object) });

		FieldBuilder F = G.DefineField ("F", T, FieldAttributes.Public);
		FieldBuilder B = G.DefineField ("B", typeof (bool), FieldAttributes.Public | FieldAttributes.Static);

		ConstructorBuilder Ctor = G.DefineConstructor (MethodAttributes.Public, CallingConventions.Standard, null);
		{
			ILGenerator il = Ctor.GetILGenerator ();
			il.Emit (OpCodes.Ldarg_0);
			il.Emit (OpCodes.Call, typeof (object).GetConstructor (new Type [0]));
			il.Emit (OpCodes.Ret);
		}

		MethodBuilder Foo = G.DefineMethod ("Foo", MethodAttributes.Public);
		{
			// G<object>.Foo()
			MethodInfo GObjFoo = TypeBuilder.GetMethod (GObj, Foo);

			// new G<object>()
			ConstructorInfo GObjCtor = TypeBuilder.GetConstructor (GObj, Ctor);

			ILGenerator il = Foo.GetILGenerator ();
			CompileButDontRunMe (il, B);

			il.Emit (OpCodes.Ldarg_0);
			il.Emit (OpCodes.Ldfld, F);
			il.Emit (OpCodes.Box, T);
			il.Emit (OpCodes.Pop);

			il.Emit (OpCodes.Ldnull);
			il.Emit (OpCodes.Call, Foo); // G<T>.Foo()
			il.Emit (OpCodes.Ldnull);
			il.EmitCall (OpCodes.Call, Foo, null);

			il.Emit (OpCodes.Ldnull);
			il.Emit (OpCodes.Call, GObjFoo); // G<object>.Foo()
			il.Emit (OpCodes.Ldnull);
			il.EmitCall (OpCodes.Call, GObjFoo, null);

			il.Emit (OpCodes.Newobj, Ctor);  // new G<T>()          
			il.Emit (OpCodes.Pop);

			il.Emit (OpCodes.Newobj, GObjCtor); // new G<object>()
			il.Emit (OpCodes.Pop);

			il.Emit (OpCodes.Ret);
		}

		MethodBuilder M = G.DefineMethod ("M", MethodAttributes.Public);
		{
			Type S = M.DefineGenericParameters ("S") [0];

			// G<object>.M<S>
			MethodInfo GObjM = TypeBuilder.GetMethod (GObj, M);

			// G<object>.M<string>()
			MethodInfo GObjMStr = GObjM.MakeGenericMethod (typeof (string));

			// G<T>.M<string>()
			MethodInfo GMStr = M.MakeGenericMethod (typeof (string));

			ILGenerator il = M.GetILGenerator ();
			CompileButDontRunMe (il, B);
			il.DeclareLocal (S);
			il.Emit (OpCodes.Ldarg_0);
			il.Emit (OpCodes.Ldloc_1);
			il.Emit (OpCodes.Box, S);
			il.Emit (OpCodes.Stloc, il.DeclareLocal (typeof (object)));
			il.Emit (OpCodes.Pop);
			il.DeclareLocal (T);
			il.Emit (OpCodes.Ldarg_0);
			il.Emit (OpCodes.Ldfld, F);
			il.Emit (OpCodes.Stloc_0);
			il.Emit (OpCodes.Ldnull);
			il.Emit (OpCodes.Call, GObjMStr); // G<object>.M<string>()
			il.Emit (OpCodes.Ldnull);
			il.EmitCall (OpCodes.Call, GObjMStr, null); // G<object>.M<string>()
			il.Emit (OpCodes.Ldnull);
			il.Emit (OpCodes.Call, GMStr); // G<T>.M<string>()
			il.Emit (OpCodes.Ldnull);
			il.EmitCall (OpCodes.Call, GMStr, null); // G<T>.M<string>()
			il.Emit (OpCodes.Ldnull);
			il.Emit (OpCodes.Call, M); // G<T>.M<S>()
			il.Emit (OpCodes.Ldnull);
			il.EmitCall (OpCodes.Call, M, null); // G<T>.M<S>()
			il.Emit (OpCodes.Ldnull);
			il.Emit (OpCodes.Call, GObjM); // G<object>.M<S>
			il.Emit (OpCodes.Ldnull);
			il.EmitCall (OpCodes.Call, GObjM, null); // G<object>.M<S>
			il.Emit (OpCodes.Ret);
		}

		Type rtG = G.CreateType ();

		asmbuild.Save ("Instance.exe");

		object target = Activator.CreateInstance (rtG.MakeGenericType (typeof (object)), null);
		rtG.MakeGenericType (typeof (object)).InvokeMember ("Foo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, target, null);
		rtG.MakeGenericType (typeof (object)).GetMethod ("M").MakeGenericMethod (typeof (string)).Invoke (target, null);
	}


	public static void Reference ()
	{
		AssemblyName name = new AssemblyName ("Reference");
		AssemblyBuilder asmbuild = System.Threading.Thread.GetDomain ().DefineDynamicAssembly (name, AssemblyBuilderAccess.RunAndSave);
		ModuleBuilder mod = asmbuild.DefineDynamicModule ("Reference.exe");

		TypeBuilder H = mod.DefineType ("H", TypeAttributes.Public);
		Type U = H.DefineGenericParameters ("U") [0];
		Type G = typeof (G<>);
		Type GObj = typeof (G<object>);
		Type GU = G.MakeGenericType (U);

		FieldBuilder B = H.DefineField ("B", typeof (bool), FieldAttributes.Public | FieldAttributes.Static);

		MethodBuilder Baz = H.DefineMethod ("Baz", MethodAttributes.Static | MethodAttributes.Public);
		{
			// G<object>.Foo()
			MethodInfo GObjFoo = GObj.GetMethod ("Foo");

			// G<object>.M<object>()
			MethodInfo GObjMObj = GObj.GetMethod ("M").MakeGenericMethod (typeof (object));

			// G<U>.Foo()
			MethodInfo GFoo = G.GetMethod ("Foo");
			MethodInfo GUFoo = TypeBuilder.GetMethod (GU, GFoo);

			// G<U>.M<U>()
			MethodInfo GM = G.GetMethod ("M");
			MethodInfo GUM = TypeBuilder.GetMethod (GU, GM);
			MethodInfo GUMU = GUM.MakeGenericMethod (U);

			// G<object>.M<U>
			MethodInfo GObjM = GObj.GetMethod ("M");
			MethodInfo GObjMU = GObjM.MakeGenericMethod (U);

			// new G<object>()
			ConstructorInfo GObjCtor = GObj.GetConstructor (new Type [0]);

			// G<U>()
			ConstructorInfo GCtor = G.GetConstructor (new Type [0]);
			ConstructorInfo GUCtor = TypeBuilder.GetConstructor (GU, GCtor);

			// G<U>.F
			FieldInfo GF = G.GetField ("F");
			FieldInfo GUF = TypeBuilder.GetField (GU, GF);

			// G<U>.B
			FieldInfo GB = G.GetField ("B");
			FieldInfo GUB = TypeBuilder.GetField (GU, GB);

			// Nullable<int>()
			Type Nullable = typeof (Nullable<>);
			Type NullableInt = Nullable.MakeGenericType (typeof (int));
			ConstructorInfo NullableIntCtor = NullableInt.GetConstructor (new Type [] { typeof (int) });

			ILGenerator il = Baz.GetILGenerator ();
			il.Emit (OpCodes.Ldloca, il.DeclareLocal (NullableInt));
			il.Emit (OpCodes.Ldc_I4_3);
			il.Emit (OpCodes.Call, NullableIntCtor);
			CompileButDontRunMe (il, B);
			il.Emit (OpCodes.Ldsfld, GUF); // G<U>.F
			il.Emit (OpCodes.Pop);
			il.Emit (OpCodes.Ldsfld, GUB); // G<U>.B
			il.Emit (OpCodes.Pop);
			il.Emit (OpCodes.Call, GObjFoo); // G<object>.Foo()
			il.Emit (OpCodes.Call, GObjMU); // G<object>.M<U>()
			il.Emit (OpCodes.Newobj, GObjCtor); // new G<object>()
			il.Emit (OpCodes.Pop);
			il.Emit (OpCodes.Newobj, GUCtor); // new G<U>()
			il.Emit (OpCodes.Pop);
			il.Emit (OpCodes.Call, GUFoo); // G<U>.Foo()
			il.Emit (OpCodes.Call, GUMU); // G<U>.M<U>
			il.Emit (OpCodes.Call, GObjMObj); // G<object>.M<object>()
			il.Emit (OpCodes.Ret);
		}

		Type rtH = H.CreateType ();

		asmbuild.Save ("Reference.exe");

		rtH.MakeGenericType (typeof (object)).InvokeMember ("Baz", BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, null);
	}

	public static void Constrained ()
	{
		AssemblyName name = new AssemblyName ("Constrained");
		AssemblyBuilder asmbuild = System.Threading.Thread.GetDomain ().DefineDynamicAssembly (name, AssemblyBuilderAccess.RunAndSave);
		ModuleBuilder mod = asmbuild.DefineDynamicModule ("Constrained.exe");

		TypeBuilder IFoo = mod.DefineType ("IFoo", TypeAttributes.Public | TypeAttributes.Interface | TypeAttributes.Abstract);
		MethodBuilder IFooM = IFoo.DefineMethod ("IFooM", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.Abstract);

		TypeBuilder G = mod.DefineType ("G", TypeAttributes.Public);
		GenericTypeParameterBuilder T = G.DefineGenericParameters ("T") [0];
		T.SetInterfaceConstraints (IFoo);
		G.MakeGenericType (new Type [] { typeof (object) });

		FieldBuilder F = G.DefineField ("F", T, FieldAttributes.Public | FieldAttributes.Static);
		FieldBuilder B = G.DefineField ("B", typeof (bool), FieldAttributes.Public | FieldAttributes.Static);

		MethodBuilder Foo = G.DefineMethod ("Foo", MethodAttributes.Static | MethodAttributes.Public);
		{
			ILGenerator il = Foo.GetILGenerator ();
			CompileButDontRunMe (il, B);
			il.Emit (OpCodes.Ldsflda, F);
			il.Emit (OpCodes.Constrained, T);
			il.Emit (OpCodes.Callvirt, IFooM);
			il.Emit (OpCodes.Ret);
		}

		Type rtIFoo = IFoo.CreateType ();
		Type rtG = G.CreateType ();

		asmbuild.Save ("Constrained.exe");

		rtG.MakeGenericType (rtIFoo).InvokeMember ("Foo", BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, null);
	}

	public static void CompileButDontRunMe (ILGenerator il, FieldBuilder B)
	{
		il.Emit (OpCodes.Ldsfld, B);
		Label label = il.DefineLabel ();
		il.Emit (OpCodes.Brtrue_S, label);
		il.Emit (OpCodes.Ret);
		il.MarkLabel (label);
	}
}