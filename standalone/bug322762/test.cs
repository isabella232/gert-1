using System;
using System.Reflection;

class Program
{
	static void Main ()
	{
		GetMethodsTest (typeof (Bar));
		GetMethodsTest (typeof (libA.Bar));
		GetMethodsTest (typeof (libB.Bar));
		GetMethodsTest (typeof (libC.Bar));

		GetMethodsNestedTest (typeof (Bar.Child));
		GetMethodsNestedTest (typeof (libA.Bar.Child));
		GetMethodsNestedTest (typeof (libB.Bar.Child));
		GetMethodsNestedTest (typeof (libC.Bar.Child));

		GetMethodTest (typeof (Bar));
		GetMethodTest (typeof (libA.Bar));
		GetMethodTest (typeof (libB.Bar));
		GetMethodTest (typeof (libC.Bar));

		GetMethodNestedTest (typeof (Bar.Child));
		GetMethodNestedTest (typeof (libA.Bar.Child));
		GetMethodNestedTest (typeof (libB.Bar.Child));
		GetMethodNestedTest (typeof (libC.Bar.Child));

		GetFieldsTest (typeof (Bar));
		GetFieldsTest (typeof (libA.Bar));
		GetFieldsTest (typeof (libB.Bar));
		GetFieldsTest (typeof (libC.Bar));

		GetFieldsNestedTest (typeof (Bar.Child));
		GetFieldsNestedTest (typeof (libA.Bar.Child));
		GetFieldsNestedTest (typeof (libB.Bar.Child));
		GetFieldsNestedTest (typeof (libC.Bar.Child));

		GetFieldTest (typeof (Bar));
		GetFieldTest (typeof (libA.Bar));
		GetFieldTest (typeof (libB.Bar));
		GetFieldTest (typeof (libC.Bar));

		GetFieldNestedTest (typeof (Bar.Child));
		GetFieldNestedTest (typeof (libA.Bar.Child));
		GetFieldNestedTest (typeof (libB.Bar.Child));
		GetFieldNestedTest (typeof (libC.Bar.Child));

		GetConstructorsTest (typeof (Bar), false);
#if MONO
		// Mono's ilasm does not retain the order of the constructors
		// see bug #350517
		GetConstructorsILTest (typeof (libA.Bar));
#else
		GetConstructorsTest (typeof (libA.Bar), true);
#endif
		GetConstructorsTest (typeof (libB.Bar), false);
		GetConstructorsTest (typeof (libC.Bar), false);
	}

	static void GetMethodsTest (Type type)
	{
		MethodInfo [] methods;
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#A1");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#A2");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#A3");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#A4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#A5");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#A6");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#A6");
#endif
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#A7");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#A8");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#A9");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#A10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#A11");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#A12");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#A12");
#endif
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateInstanceBar"), "#A13");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBar"), "#A14");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#A15");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#A16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBar"), "#A17");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#A18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#A19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#A20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#A21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#A22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#A23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#A24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#A25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#A26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#A27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#A28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#A29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#A30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBar"), "#A31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBar"), "#A32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#A33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#A34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBar"), "#A35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBar"), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#B1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#B2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#B3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#B4");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBlue"), "#B5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#B6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#B7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#B8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#B9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#B10");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceFoo"), "#B11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#B12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBar"), "#B13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBar"), "#B14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#B15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#B16");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBar"), "#B17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#B18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#B19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#B20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#B21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#B22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#B23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#B24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#B25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#B26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#B27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#B28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#B29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#B30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBar"), "#B31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBar"), "#B32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#B33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#B34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBar"), "#B35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBar"), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#C1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#C2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#C3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#C4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#C5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#C6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#C7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#C8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#C9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#C10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#C11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#C12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBar"), "#C13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBar"), "#C14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#C15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#C16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBar"), "#C17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#C18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#C19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#C20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#C21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#C22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#C23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#C24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#C25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#C26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#C27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#C28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#C29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#C30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBar"), "#C31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBar"), "#C32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#C33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#C34");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticBar"), "#C35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBar"), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#D1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#D2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#D3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#D4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#D5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#D6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#D7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#D8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#D9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#D10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#D11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#D12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBar"), "#D13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBar"), "#D14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#D15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#D16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBar"), "#D17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#D18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#D19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#D20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#D21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#D22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#D23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#D24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#D25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#D26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#D27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#D28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#D29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#D30");
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateStaticBar"), "#D31");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticBar"), "#D32");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#D33");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#D34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBar"), "#D35");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticBar"), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#E1");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#E2");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#E3");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#E4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#E5");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#E6");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#E6");
#endif
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#E7");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#E8");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#E9");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#E10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#E11");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#E12");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#E12");
#endif
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateInstanceBar"), "#E13");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBar"), "#E14");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#E15");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#E16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBar"), "#E17");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#E18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#E19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#E20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#E21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#E22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#E23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#E24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#E25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#E26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#E27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#E28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#E29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#E30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBar"), "#E31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBar"), "#E32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#E33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#E34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBar"), "#E35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBar"), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#F1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#F2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#F3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#F4");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBlue"), "#F5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#F6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#F7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#F8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#F9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#F10");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceFoo"), "#F11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#F12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBar"), "#F13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBar"), "#F14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#F15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#F16");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBar"), "#F17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#F18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#F19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#F20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#F21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#F22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#F23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#F24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#F25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#F26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#F27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#F28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#F29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#F30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBar"), "#F31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBar"), "#F32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#F33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#F34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBar"), "#F35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBar"), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#G1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#G2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#G3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#G4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#G5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#G6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#G7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#G8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#G9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#G10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#G11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#G12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBar"), "#G13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBar"), "#G14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#G15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#G16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBar"), "#G17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#G18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#G19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#G20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#G21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#G22");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticBlue"), "#G23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#G24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#G25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#G26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#G27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#G28");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticFoo"), "#G29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#G30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBar"), "#G31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBar"), "#G32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#G33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#G34");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticBar"), "#G35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBar"), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#H1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#H2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#H3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#H4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#H5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#H6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#H7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#H8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#H9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#H10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#H11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#H12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBar"), "#H13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBar"), "#H14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#H15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#H16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBar"), "#H17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#H18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#H19");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticBlue"), "#H20");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#H21");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#H22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#H23");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#H24");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#H24");
#endif
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#H25");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticFoo"), "#H26");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#H27");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#H28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#H29");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#H30");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#H30");
#endif
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateStaticBar"), "#H31");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticBar"), "#H32");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#H33");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#H34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBar"), "#H35");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticBar"), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#I1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#I2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#I3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#I4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#I5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#I6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#I7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#I8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#I9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#I10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#I11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#I12");
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateInstanceBar"), "#I13");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBar"), "#I14");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#I15");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#I16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBar"), "#I17");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#I18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#I19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#I20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#I21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#I22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#I23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#I24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#I25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#I26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#I27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#I28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#I29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#I30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBar"), "#I31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBar"), "#I32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#I33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#I34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBar"), "#I35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBar"), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#J1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#J2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#J3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#J4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#J5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#J6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#J7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#J8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#J9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#J10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#J11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#J12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBar"), "#J13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBar"), "#J14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#J15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#J16");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBar"), "#J17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#J18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#J19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#J20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#J21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#J22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#J23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#J24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#J25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#J26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#J27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#J28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#J29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#J30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBar"), "#J31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBar"), "#J32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#J33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#J34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBar"), "#J35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBar"), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#K1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#K2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#K3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#K4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#K5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#K6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#K7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#K8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#K9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#K10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#K11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#K12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBar"), "#K13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBar"), "#K14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#K15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#K16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBar"), "#K17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#K18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#K19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#K20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#K21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#K22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#K23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#K24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#K25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#K26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#K27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#K28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#K29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#K30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBar"), "#K31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBar"), "#K32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#K33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#K34");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticBar"), "#K35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBar"), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#L1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#L2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#L3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#L4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#L5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#L6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#L7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#L8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#L9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#L10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#L11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#L12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBar"), "#L13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBar"), "#L14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#L15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#L16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBar"), "#L17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#L18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#L19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#L20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#L21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#L22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#L23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#L24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#L25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#L26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#L27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#L28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#L29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#L30");
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateStaticBar"), "#L31");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticBar"), "#L32");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#L33");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#L34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBar"), "#L35");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticBar"), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#M1");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#M2");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#M3");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#M4");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBlue"), "#M5");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#M6");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#M6");
#endif
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#M7");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#M8");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#M9");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#M10");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceFoo"), "#M11");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#M12");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#M12");
#endif
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateInstanceBar"), "#M13");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBar"), "#M14");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#M15");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#M16");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBar"), "#M17");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#M18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#M19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#M20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#M21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#M22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#M23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#M24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#M25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#M26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#M27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#M28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#M29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#M30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBar"), "#M31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBar"), "#M32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#M33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#M34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBar"), "#M35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBar"), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlue"), "#N1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlue"), "#N2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlue"), "#N3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlue"), "#N4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlue"), "#N5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlue"), "#N6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFoo"), "#N7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFoo"), "#N8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFoo"), "#N9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFoo"), "#N10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFoo"), "#N11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFoo"), "#N12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBar"), "#N13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBar"), "#N14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBar"), "#N15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBar"), "#N16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBar"), "#N17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBar"), "#N18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlue"), "#N19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlue"), "#N20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlue"), "#N21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlue"), "#N22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlue"), "#N23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlue"), "#N24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFoo"), "#N25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFoo"), "#N26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFoo"), "#N27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFoo"), "#N28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFoo"), "#N29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFoo"), "#N30");
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateStaticBar"), "#N31");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticBar"), "#N32");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticBar"), "#N33");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticBar"), "#N34");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticBar"), "#N35");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticBar"), "#N36");
	}

	static void GetMethodsNestedTest (Type type)
	{
		MethodInfo [] methods;
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#A1");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#A2");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#A3");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#A4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#A5");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#A6");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#A6");
#endif
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#A7");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#A8");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#A9");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#A10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#A11");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#A12");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#A12");
#endif
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#A13");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#A14");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#A15");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#A16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#A17");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#A18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#A19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#A20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#A21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#A22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#A23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#A24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#A25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#A26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#A27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#A28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#A29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#A30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#A31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#A32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#A33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#A34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBarChild"), "#A35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#B1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#B2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#B3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#B4");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#B5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#B6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#B7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#B8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#B9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#B10");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#B11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#B12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#B13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#B14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#B15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#B16");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#B17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#B18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#B19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#B20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#B21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#B22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#B23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#B24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#B25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#B26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#B27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#B28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#B29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#B30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#B31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#B32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#B33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#B34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBarChild"), "#B35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#C1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#C2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#C3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#C4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#C5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#C6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#C7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#C8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#C9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#C10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#C11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#C12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#C13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#C14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#C15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#C16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#C17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#C18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#C19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#C20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#C21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#C22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#C23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#C24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#C25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#C26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#C27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#C28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#C29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#C30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#C31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#C32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#C33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#C34");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticBarChild"), "#C35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#D1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#D2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#D3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#D4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#D5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#D6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#D7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#D8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#D9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#D10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#D11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#D12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#D13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#D14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#D15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#D16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#D17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#D18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#D19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#D20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#D21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#D22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#D23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#D24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#D25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#D26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#D27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#D28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#D29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#D30");
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#D31");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#D32");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#D33");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#D34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBarChild"), "#D35");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#E1");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#E2");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#E3");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#E4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#E5");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#E6");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#E6");
#endif
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#E7");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#E8");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#E9");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#E10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#E11");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#E12");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#E12");
#endif
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#E13");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#E14");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#E15");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#E16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#E17");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#E18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#E19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#E20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#E21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#E22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#E23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#E24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#E25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#E26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#E27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#E28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#E29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#E30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#E31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#E32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#E33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#E34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBarChild"), "#E35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#F1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#F2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#F3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#F4");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#F5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#F6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#F7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#F8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#F9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#F10");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#F11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#F12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#F13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#F14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#F15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#F16");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#F17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#F18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#F19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#F20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#F21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#F22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#F23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#F24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#F25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#F26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#F27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#F28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#F29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#F30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#F31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#F32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#F33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#F34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBarChild"), "#F35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#G1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#G2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#G3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#G4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#G5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#G6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#G7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#G8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#G9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#G10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#G11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#G12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#G13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#G14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#G15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#G16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#G17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#G18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#G19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#G20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#G21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#G22");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#G23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#G24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#G25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#G26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#G27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#G28");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticFooChild"), "#G29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#G30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#G31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#G32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#G33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#G34");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticBarChild"), "#G35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#H1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#H2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#H3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#H4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#H5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#H6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#H7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#H8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#H9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#H10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#H11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#H12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#H13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#H14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#H15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#H16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#H17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#H18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#H19");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#H20");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#H21");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#H22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#H23");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#H24");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#H24");
#endif
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#H25");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#H26");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#H27");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#H28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#H29");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#H30");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#H30");
#endif
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#H31");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#H32");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#H33");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#H34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBarChild"), "#H35");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#I1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#I2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#I3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#I4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#I5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#I6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#I7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#I8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#I9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#I10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#I11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#I12");
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#I13");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#I14");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#I15");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#I16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#I17");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#I18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#I19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#I20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#I21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#I22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#I23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#I24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#I25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#I26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#I27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#I28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#I29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#I30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#I31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#I32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#I33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#I34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBarChild"), "#I35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#J1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#J2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#J3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#J4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#J5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#J6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#J7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#J8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#J9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#J10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#J11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#J12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#J13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#J14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#J15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#J16");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#J17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#J18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#J19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#J20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#J21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#J22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#J23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#J24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#J25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#J26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#J27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#J28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#J29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#J30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#J31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#J32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#J33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#J34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBarChild"), "#J35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#K1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#K2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#K3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#K4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#K5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#K6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#K7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#K8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#K9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#K10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#K11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#K12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#K13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#K14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#K15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#K16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#K17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#K18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#K19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#K20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#K21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#K22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#K23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#K24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#K25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#K26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#K27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#K28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#K29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#K30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#K31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#K32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#K33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#K34");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticBarChild"), "#K35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#L1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#L2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#L3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#L4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#L5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#L6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#L7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#L8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#L9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#L10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#L11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#L12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#L13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#L14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#L15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#L16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#L17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#L18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#L19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#L20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#L21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#L22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#L23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#L24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#L25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#L26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#L27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#L28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#L29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#L30");
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#L31");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#L32");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#L33");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#L34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBarChild"), "#L35");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#M1");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#M2");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#M3");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#M4");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#M5");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#M6");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#M6");
#endif
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#M7");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#M8");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#M9");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#M10");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#M11");
#if NET_2_0
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#M12");
#else
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#M12");
#endif
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#M13");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#M14");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#M15");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#M16");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#M17");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#M18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#M19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#M20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#M21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#M22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#M23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#M24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#M25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#M26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#M27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#M28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#M29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#M30");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#M31");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#M32");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#M33");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#M34");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBarChild"), "#M35");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;
		methods = type.GetMethods (flags);

		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBlueChild"), "#N1");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBlueChild"), "#N2");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBlueChild"), "#N3");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBlueChild"), "#N4");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBlueChild"), "#N5");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBlueChild"), "#N6");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceFooChild"), "#N7");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceFooChild"), "#N8");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceFooChild"), "#N9");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceFooChild"), "#N10");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceFooChild"), "#N11");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceFooChild"), "#N12");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateInstanceBarChild"), "#N13");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyInstanceBarChild"), "#N14");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemInstanceBarChild"), "#N15");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemInstanceBarChild"), "#N16");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicInstanceBarChild"), "#N17");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyInstanceBarChild"), "#N18");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticBlueChild"), "#N19");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticBlueChild"), "#N20");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticBlueChild"), "#N21");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticBlueChild"), "#N22");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticBlueChild"), "#N23");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticBlueChild"), "#N24");
		Assert.IsFalse (ContainsMethod (methods, "GetPrivateStaticFooChild"), "#N25");
		Assert.IsFalse (ContainsMethod (methods, "GetFamilyStaticFooChild"), "#N26");
		Assert.IsFalse (ContainsMethod (methods, "GetFamANDAssemStaticFooChild"), "#N27");
		Assert.IsFalse (ContainsMethod (methods, "GetFamORAssemStaticFooChild"), "#N28");
		Assert.IsFalse (ContainsMethod (methods, "GetPublicStaticFooChild"), "#N29");
		Assert.IsFalse (ContainsMethod (methods, "GetAssemblyStaticFooChild"), "#N30");
		Assert.IsTrue (ContainsMethod (methods, "GetPrivateStaticBarChild"), "#N31");
		Assert.IsTrue (ContainsMethod (methods, "GetFamilyStaticBarChild"), "#N32");
		Assert.IsTrue (ContainsMethod (methods, "GetFamANDAssemStaticBarChild"), "#N33");
		Assert.IsTrue (ContainsMethod (methods, "GetFamORAssemStaticBarChild"), "#N34");
		Assert.IsTrue (ContainsMethod (methods, "GetPublicStaticBarChild"), "#N35");
		Assert.IsTrue (ContainsMethod (methods, "GetAssemblyStaticBarChild"), "#N36");
	}

	static void GetMethodTest (Type type)
	{
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#A1");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#A2");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#A3");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#A4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#A5");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#A6");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#A6");
#endif
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#A7");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#A8");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#A9");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#A10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#A11");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#A12");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#A12");
#endif
		Assert.IsNotNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#A13");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#A14");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#A15");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#A16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBar", flags), "#A17");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#A18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#A19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#A20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#A21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#A22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#A23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#A24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#A25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#A26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#A27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#A28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#A29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#A30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBar", flags), "#A31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBar", flags), "#A32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#A33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#A34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBar", flags), "#A35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#B1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#B2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#B3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#B4");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#B5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#B6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#B7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#B8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#B9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#B10");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#B11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#B12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#B13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#B14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#B15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#B16");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBar", flags), "#B17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#B18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#B19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#B20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#B21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#B22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#B23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#B24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#B25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#B26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#B27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#B28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#B29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#B30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBar", flags), "#B31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBar", flags), "#B32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#B33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#B34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBar", flags), "#B35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#C1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#C2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#C3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#C4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#C5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#C6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#C7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#C8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#C9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#C10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#C11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#C12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#C13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#C14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#C15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#C16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBar", flags), "#C17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#C18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#C19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#C20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#C21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#C22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#C23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#C24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#C25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#C26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#C27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#C28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#C29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#C30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBar", flags), "#C31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBar", flags), "#C32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#C33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#C34");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticBar", flags), "#C35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#D1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#D2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#D3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#D4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#D5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#D6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#D7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#D8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#D9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#D10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#D11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#D12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#D13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#D14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#D15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#D16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBar", flags), "#D17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#D18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#D19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#D20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#D21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#D22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#D23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#D24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#D25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#D26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#D27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#D28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#D29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#D30");
		Assert.IsNotNull (type.GetMethod ("GetPrivateStaticBar", flags), "#D31");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticBar", flags), "#D32");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#D33");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#D34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBar", flags), "#D35");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#E1");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#E2");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#E3");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#E4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#E5");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#E6");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#E6");
#endif
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#E7");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#E8");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#E9");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#E10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#E11");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#E12");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#E12");
#endif
		Assert.IsNotNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#E13");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#E14");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#E15");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#E16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBar", flags), "#E17");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#E18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#E19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#E20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#E21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#E22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#E23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#E24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#E25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#E26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#E27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#E28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#E29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#E30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBar", flags), "#E31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBar", flags), "#E32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#E33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#E34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBar", flags), "#E35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#F1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#F2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#F3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#F4");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#F5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#F6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#F7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#F8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#F9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#F10");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#F11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#F12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#F13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#F14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#F15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#F16");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBar", flags), "#F17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#F18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#F19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#F20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#F21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#F22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#F23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#F24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#F25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#F26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#F27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#F28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#F29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#F30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBar", flags), "#F31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBar", flags), "#F32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#F33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#F34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBar", flags), "#F35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#G1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#G2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#G3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#G4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#G5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#G6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#G7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#G8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#G9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#G10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#G11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#G12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#G13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#G14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#G15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#G16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBar", flags), "#G17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#G18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#G19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#G20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#G21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#G22");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticBlue", flags), "#G23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#G24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#G25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#G26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#G27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#G28");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticFoo", flags), "#G29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#G30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBar", flags), "#G31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBar", flags), "#G32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#G33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#G34");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticBar", flags), "#G35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#H1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#H2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#H3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#H4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#H5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#H6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#H7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#H8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#H9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#H10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#H11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#H12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#H13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#H14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#H15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#H16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBar", flags), "#H17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#H18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#H19");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#H20");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#H21");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#H22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#H23");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#H24");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#H24");
#endif
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#H25");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#H26");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#H27");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#H28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#H29");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#H30");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#H30");
#endif
		Assert.IsNotNull (type.GetMethod ("GetPrivateStaticBar", flags), "#H31");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticBar", flags), "#H32");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#H33");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#H34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBar", flags), "#H35");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#I1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#I2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#I3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#I4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#I5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#I6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#I7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#I8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#I9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#I10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#I11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#I12");
		Assert.IsNotNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#I13");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#I14");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#I15");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#I16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBar", flags), "#I17");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#I18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#I19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#I20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#I21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#I22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#I23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#I24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#I25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#I26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#I27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#I28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#I29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#I30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBar", flags), "#I31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBar", flags), "#I32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#I33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#I34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBar", flags), "#I35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#J1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#J2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#J3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#J4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#J5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#J6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#J7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#J8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#J9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#J10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#J11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#J12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#J13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#J14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#J15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#J16");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBar", flags), "#J17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#J18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#J19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#J20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#J21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#J22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#J23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#J24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#J25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#J26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#J27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#J28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#J29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#J30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBar", flags), "#J31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBar", flags), "#J32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#J33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#J34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBar", flags), "#J35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#K1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#K2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#K3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#K4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#K5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#K6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#K7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#K8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#K9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#K10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#K11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#K12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#K13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#K14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#K15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#K16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBar", flags), "#K17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#K18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#K19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#K20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#K21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#K22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#K23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#K24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#K25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#K26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#K27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#K28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#K29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#K30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBar", flags), "#K31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBar", flags), "#K32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#K33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#K34");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticBar", flags), "#K35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#L1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#L2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#L3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#L4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#L5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#L6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#L7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#L8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#L9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#L10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#L11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#L12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#L13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#L14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#L15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#L16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBar", flags), "#L17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#L18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#L19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#L20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#L21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#L22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#L23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#L24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#L25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#L26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#L27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#L28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#L29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#L30");
		Assert.IsNotNull (type.GetMethod ("GetPrivateStaticBar", flags), "#L31");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticBar", flags), "#L32");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#L33");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#L34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBar", flags), "#L35");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#M1");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#M2");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#M3");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#M4");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#M5");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#M6");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#M6");
#endif
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#M7");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#M8");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#M9");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#M10");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#M11");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#M12");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#M12");
#endif
		Assert.IsNotNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#M13");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#M14");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#M15");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#M16");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBar", flags), "#M17");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#M18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#M19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#M20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#M21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#M22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#M23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#M24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#M25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#M26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#M27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#M28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#M29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#M30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBar", flags), "#M31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBar", flags), "#M32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#M33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#M34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBar", flags), "#M35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlue", flags), "#N1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlue", flags), "#N2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlue", flags), "#N3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlue", flags), "#N4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlue", flags), "#N5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlue", flags), "#N6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFoo", flags), "#N7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFoo", flags), "#N8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFoo", flags), "#N9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFoo", flags), "#N10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFoo", flags), "#N11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFoo", flags), "#N12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBar", flags), "#N13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBar", flags), "#N14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBar", flags), "#N15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBar", flags), "#N16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBar", flags), "#N17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBar", flags), "#N18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlue", flags), "#N19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlue", flags), "#N20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlue", flags), "#N21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlue", flags), "#N22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlue", flags), "#N23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlue", flags), "#N24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFoo", flags), "#N25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFoo", flags), "#N26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFoo", flags), "#N27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFoo", flags), "#N28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFoo", flags), "#N29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFoo", flags), "#N30");
		Assert.IsNotNull (type.GetMethod ("GetPrivateStaticBar", flags), "#N31");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticBar", flags), "#N32");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticBar", flags), "#N33");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticBar", flags), "#N34");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticBar", flags), "#N35");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticBar", flags), "#N36");
	}

	static void GetMethodNestedTest (Type type)
	{
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#A1");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#A2");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#A3");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#A4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#A5");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#A6");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#A6");
#endif
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#A7");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#A8");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#A9");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#A10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#A11");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#A12");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#A12");
#endif
		Assert.IsNotNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#A13");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#A14");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#A15");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#A16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#A17");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#A18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#A19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#A20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#A21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#A22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#A23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#A24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#A25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#A26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#A27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#A28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#A29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#A30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#A31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#A32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#A33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#A34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#A35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#B1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#B2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#B3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#B4");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#B5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#B6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#B7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#B8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#B9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#B10");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#B11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#B12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#B13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#B14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#B15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#B16");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#B17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#B18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#B19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#B20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#B21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#B22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#B23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#B24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#B25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#B26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#B27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#B28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#B29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#B30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#B31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#B32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#B33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#B34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#B35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#C1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#C2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#C3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#C4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#C5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#C6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#C7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#C8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#C9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#C10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#C11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#C12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#C13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#C14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#C15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#C16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#C17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#C18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#C19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#C20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#C21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#C22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#C23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#C24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#C25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#C26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#C27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#C28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#C29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#C30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#C31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#C32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#C33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#C34");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#C35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#D1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#D2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#D3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#D4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#D5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#D6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#D7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#D8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#D9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#D10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#D11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#D12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#D13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#D14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#D15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#D16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#D17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#D18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#D19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#D20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#D21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#D22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#D23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#D24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#D25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#D26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#D27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#D28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#D29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#D30");
		Assert.IsNotNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#D31");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#D32");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#D33");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#D34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#D35");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#E1");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#E2");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#E3");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#E4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#E5");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#E6");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#E6");
#endif
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#E7");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#E8");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#E9");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#E10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#E11");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#E12");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#E12");
#endif
		Assert.IsNotNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#E13");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#E14");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#E15");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#E16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#E17");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#E18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#E19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#E20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#E21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#E22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#E23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#E24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#E25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#E26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#E27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#E28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#E29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#E30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#E31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#E32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#E33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#E34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#E35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#F1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#F2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#F3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#F4");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#F5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#F6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#F7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#F8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#F9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#F10");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#F11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#F12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#F13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#F14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#F15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#F16");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#F17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#F18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#F19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#F20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#F21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#F22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#F23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#F24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#F25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#F26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#F27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#F28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#F29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#F30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#F31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#F32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#F33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#F34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#F35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#G1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#G2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#G3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#G4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#G5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#G6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#G7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#G8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#G9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#G10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#G11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#G12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#G13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#G14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#G15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#G16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#G17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#G18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#G19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#G20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#G21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#G22");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#G23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#G24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#G25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#G26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#G27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#G28");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#G29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#G30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#G31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#G32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#G33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#G34");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#G35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#H1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#H2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#H3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#H4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#H5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#H6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#H7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#H8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#H9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#H10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#H11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#H12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#H13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#H14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#H15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#H16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#H17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#H18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#H19");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#H20");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#H21");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#H22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#H23");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#H24");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#H24");
#endif
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#H25");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#H26");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#H27");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#H28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#H29");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#H30");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#H30");
#endif
		Assert.IsNotNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#H31");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#H32");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#H33");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#H34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#H35");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#I1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#I2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#I3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#I4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#I5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#I6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#I7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#I8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#I9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#I10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#I11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#I12");
		Assert.IsNotNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#I13");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#I14");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#I15");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#I16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#I17");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#I18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#I19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#I20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#I21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#I22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#I23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#I24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#I25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#I26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#I27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#I28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#I29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#I30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#I31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#I32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#I33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#I34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#I35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#J1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#J2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#J3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#J4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#J5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#J6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#J7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#J8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#J9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#J10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#J11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#J12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#J13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#J14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#J15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#J16");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#J17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#J18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#J19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#J20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#J21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#J22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#J23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#J24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#J25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#J26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#J27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#J28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#J29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#J30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#J31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#J32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#J33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#J34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#J35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#K1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#K2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#K3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#K4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#K5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#K6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#K7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#K8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#K9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#K10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#K11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#K12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#K13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#K14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#K15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#K16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#K17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#K18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#K19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#K20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#K21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#K22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#K23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#K24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#K25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#K26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#K27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#K28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#K29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#K30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#K31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#K32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#K33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#K34");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#K35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#L1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#L2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#L3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#L4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#L5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#L6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#L7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#L8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#L9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#L10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#L11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#L12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#L13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#L14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#L15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#L16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#L17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#L18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#L19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#L20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#L21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#L22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#L23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#L24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#L25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#L26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#L27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#L28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#L29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#L30");
		Assert.IsNotNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#L31");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#L32");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#L33");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#L34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#L35");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#M1");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#M2");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#M3");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#M4");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#M5");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#M6");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#M6");
#endif
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#M7");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#M8");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#M9");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#M10");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#M11");
#if NET_2_0
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#M12");
#else
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#M12");
#endif
		Assert.IsNotNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#M13");
		Assert.IsNotNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#M14");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#M15");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#M16");
		Assert.IsNotNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#M17");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#M18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#M19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#M20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#M21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#M22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#M23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#M24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#M25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#M26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#M27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#M28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#M29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#M30");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#M31");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#M32");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#M33");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#M34");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#M35");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBlueChild", flags), "#N1");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBlueChild", flags), "#N2");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBlueChild", flags), "#N3");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBlueChild", flags), "#N4");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBlueChild", flags), "#N5");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBlueChild", flags), "#N6");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceFooChild", flags), "#N7");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceFooChild", flags), "#N8");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceFooChild", flags), "#N9");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceFooChild", flags), "#N10");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceFooChild", flags), "#N11");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceFooChild", flags), "#N12");
		Assert.IsNull (type.GetMethod ("GetPrivateInstanceBarChild", flags), "#N13");
		Assert.IsNull (type.GetMethod ("GetFamilyInstanceBarChild", flags), "#N14");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemInstanceBarChild", flags), "#N15");
		Assert.IsNull (type.GetMethod ("GetFamORAssemInstanceBarChild", flags), "#N16");
		Assert.IsNull (type.GetMethod ("GetPublicInstanceBarChild", flags), "#N17");
		Assert.IsNull (type.GetMethod ("GetAssemblyInstanceBarChild", flags), "#N18");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticBlueChild", flags), "#N19");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticBlueChild", flags), "#N20");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticBlueChild", flags), "#N21");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticBlueChild", flags), "#N22");
		Assert.IsNull (type.GetMethod ("GetPublicStaticBlueChild", flags), "#N23");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticBlueChild", flags), "#N24");
		Assert.IsNull (type.GetMethod ("GetPrivateStaticFooChild", flags), "#N25");
		Assert.IsNull (type.GetMethod ("GetFamilyStaticFooChild", flags), "#N26");
		Assert.IsNull (type.GetMethod ("GetFamANDAssemStaticFooChild", flags), "#N27");
		Assert.IsNull (type.GetMethod ("GetFamORAssemStaticFooChild", flags), "#N28");
		Assert.IsNull (type.GetMethod ("GetPublicStaticFooChild", flags), "#N29");
		Assert.IsNull (type.GetMethod ("GetAssemblyStaticFooChild", flags), "#N30");
		Assert.IsNotNull (type.GetMethod ("GetPrivateStaticBarChild", flags), "#N31");
		Assert.IsNotNull (type.GetMethod ("GetFamilyStaticBarChild", flags), "#N32");
		Assert.IsNotNull (type.GetMethod ("GetFamANDAssemStaticBarChild", flags), "#N33");
		Assert.IsNotNull (type.GetMethod ("GetFamORAssemStaticBarChild", flags), "#N34");
		Assert.IsNotNull (type.GetMethod ("GetPublicStaticBarChild", flags), "#N35");
		Assert.IsNotNull (type.GetMethod ("GetAssemblyStaticBarChild", flags), "#N36");
	}

	static void GetFieldsTest (Type type)
	{
		FieldInfo [] fields;
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#A1");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBlue"), "#A2");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBlue"), "#A3");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBlue"), "#A4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#A5");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBlue"), "#A6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#A7");
		Assert.IsTrue (ContainsField (fields, "familyInstanceFoo"), "#A8");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceFoo"), "#A9");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceFoo"), "#A10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#A11");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceFoo"), "#A12");
		Assert.IsTrue (ContainsField (fields, "privateInstanceBar"), "#A13");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBar"), "#A14");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBar"), "#A15");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBar"), "#A16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBar"), "#A17");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBar"), "#A18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#A19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#A20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#A21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#A22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#A23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#A24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#A25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#A26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#A27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#A28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#A29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#A30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBar"), "#A31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBar"), "#A32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBar"), "#A33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBar"), "#A34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBar"), "#A35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBar"), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#B1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#B2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#B3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#B4");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBlue"), "#B5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#B6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#B7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#B8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#B9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#B10");
		Assert.IsTrue (ContainsField (fields, "publicInstanceFoo"), "#B11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#B12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBar"), "#B13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBar"), "#B14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBar"), "#B15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBar"), "#B16");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBar"), "#B17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBar"), "#B18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#B19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#B20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#B21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#B22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#B23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#B24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#B25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#B26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#B27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#B28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#B29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#B30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBar"), "#B31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBar"), "#B32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBar"), "#B33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBar"), "#B34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBar"), "#B35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBar"), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#C1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#C2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#C3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#C4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#C5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#C6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#C7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#C8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#C9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#C10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#C11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#C12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBar"), "#C13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBar"), "#C14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBar"), "#C15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBar"), "#C16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBar"), "#C17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBar"), "#C18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#C19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#C20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#C21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#C22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#C23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#C24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#C25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#C26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#C27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#C28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#C29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#C30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBar"), "#C31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBar"), "#C32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBar"), "#C33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBar"), "#C34");
		Assert.IsTrue (ContainsField (fields, "publicStaticBar"), "#C35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBar"), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#D1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#D2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#D3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#D4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#D5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#D6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#D7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#D8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#D9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#D10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#D11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#D12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBar"), "#D13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBar"), "#D14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBar"), "#D15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBar"), "#D16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBar"), "#D17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBar"), "#D18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#D19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#D20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#D21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#D22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#D23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#D24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#D25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#D26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#D27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#D28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#D29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#D30");
		Assert.IsTrue (ContainsField (fields, "privateStaticBar"), "#D31");
		Assert.IsTrue (ContainsField (fields, "familyStaticBar"), "#D32");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticBar"), "#D33");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticBar"), "#D34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBar"), "#D35");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticBar"), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#E1");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBlue"), "#E2");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBlue"), "#E3");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBlue"), "#E4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#E5");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBlue"), "#E6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#E7");
		Assert.IsTrue (ContainsField (fields, "familyInstanceFoo"), "#E8");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceFoo"), "#E9");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceFoo"), "#E10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#E11");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceFoo"), "#E12");
		Assert.IsTrue (ContainsField (fields, "privateInstanceBar"), "#E13");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBar"), "#E14");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBar"), "#E15");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBar"), "#E16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBar"), "#E17");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBar"), "#E18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#E19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#E20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#E21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#E22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#E23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#E24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#E25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#E26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#E27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#E28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#E29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#E30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBar"), "#E31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBar"), "#E32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBar"), "#E33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBar"), "#E34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBar"), "#E35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBar"), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#F1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#F2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#F3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#F4");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBlue"), "#F5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#F6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#F7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#F8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#F9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#F10");
		Assert.IsTrue (ContainsField (fields, "publicInstanceFoo"), "#F11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#F12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBar"), "#F13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBar"), "#F14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBar"), "#F15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBar"), "#F16");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBar"), "#F17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBar"), "#F18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#F19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#F20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#F21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#F22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#F23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#F24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#F25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#F26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#F27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#F28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#F29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#F30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBar"), "#F31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBar"), "#F32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBar"), "#F33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBar"), "#F34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBar"), "#F35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBar"), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#G1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#G2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#G3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#G4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#G5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#G6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#G7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#G8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#G9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#G10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#G11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#G12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBar"), "#G13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBar"), "#G14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBar"), "#G15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBar"), "#G16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBar"), "#G17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBar"), "#G18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#G19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#G20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#G21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#G22");
		Assert.IsTrue (ContainsField (fields, "publicStaticBlue"), "#G23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#G24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#G25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#G26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#G27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#G28");
		Assert.IsTrue (ContainsField (fields, "publicStaticFoo"), "#G29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#G30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBar"), "#G31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBar"), "#G32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBar"), "#G33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBar"), "#G34");
		Assert.IsTrue (ContainsField (fields, "publicStaticBar"), "#G35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBar"), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#H1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#H2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#H3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#H4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#H5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#H6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#H7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#H8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#H9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#H10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#H11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#H12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBar"), "#H13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBar"), "#H14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBar"), "#H15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBar"), "#H16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBar"), "#H17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBar"), "#H18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#H19");
		Assert.IsTrue (ContainsField (fields, "familyStaticBlue"), "#H20");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticBlue"), "#H21");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticBlue"), "#H22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#H23");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticBlue"), "#H24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#H25");
		Assert.IsTrue (ContainsField (fields, "familyStaticFoo"), "#H26");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticFoo"), "#H27");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticFoo"), "#H28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#H29");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticFoo"), "#H30");
		Assert.IsTrue (ContainsField (fields, "privateStaticBar"), "#H31");
		Assert.IsTrue (ContainsField (fields, "familyStaticBar"), "#H32");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticBar"), "#H33");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticBar"), "#H34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBar"), "#H35");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticBar"), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#I1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#I2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#I3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#I4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#I5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#I6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#I7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#I8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#I9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#I10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#I11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#I12");
		Assert.IsTrue (ContainsField (fields, "privateInstanceBar"), "#I13");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBar"), "#I14");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBar"), "#I15");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBar"), "#I16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBar"), "#I17");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBar"), "#I18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#I19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#I20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#I21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#I22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#I23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#I24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#I25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#I26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#I27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#I28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#I29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#I30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBar"), "#I31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBar"), "#I32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBar"), "#I33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBar"), "#I34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBar"), "#I35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBar"), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#J1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#J2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#J3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#J4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#J5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#J6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#J7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#J8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#J9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#J10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#J11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#J12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBar"), "#J13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBar"), "#J14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBar"), "#J15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBar"), "#J16");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBar"), "#J17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBar"), "#J18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#J19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#J20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#J21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#J22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#J23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#J24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#J25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#J26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#J27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#J28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#J29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#J30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBar"), "#J31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBar"), "#J32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBar"), "#J33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBar"), "#J34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBar"), "#J35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBar"), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#K1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#K2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#K3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#K4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#K5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#K6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#K7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#K8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#K9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#K10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#K11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#K12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBar"), "#K13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBar"), "#K14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBar"), "#K15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBar"), "#K16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBar"), "#K17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBar"), "#K18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#K19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#K20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#K21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#K22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#K23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#K24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#K25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#K26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#K27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#K28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#K29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#K30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBar"), "#K31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBar"), "#K32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBar"), "#K33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBar"), "#K34");
		Assert.IsTrue (ContainsField (fields, "publicStaticBar"), "#K35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBar"), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#L1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#L2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#L3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#L4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#L5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#L6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#L7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#L8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#L9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#L10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#L11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#L12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBar"), "#L13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBar"), "#L14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBar"), "#L15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBar"), "#L16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBar"), "#L17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBar"), "#L18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#L19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#L20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#L21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#L22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#L23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#L24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#L25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#L26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#L27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#L28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#L29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#L30");
		Assert.IsTrue (ContainsField (fields, "privateStaticBar"), "#L31");
		Assert.IsTrue (ContainsField (fields, "familyStaticBar"), "#L32");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticBar"), "#L33");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticBar"), "#L34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBar"), "#L35");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticBar"), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#M1");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBlue"), "#M2");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBlue"), "#M3");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBlue"), "#M4");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBlue"), "#M5");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBlue"), "#M6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#M7");
		Assert.IsTrue (ContainsField (fields, "familyInstanceFoo"), "#M8");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceFoo"), "#M9");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceFoo"), "#M10");
		Assert.IsTrue (ContainsField (fields, "publicInstanceFoo"), "#M11");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceFoo"), "#M12");
		Assert.IsTrue (ContainsField (fields, "privateInstanceBar"), "#M13");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBar"), "#M14");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBar"), "#M15");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBar"), "#M16");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBar"), "#M17");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBar"), "#M18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#M19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#M20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#M21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#M22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#M23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#M24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#M25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#M26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#M27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#M28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#M29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#M30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBar"), "#M31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBar"), "#M32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBar"), "#M33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBar"), "#M34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBar"), "#M35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBar"), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlue"), "#N1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlue"), "#N2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlue"), "#N3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlue"), "#N4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlue"), "#N5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlue"), "#N6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFoo"), "#N7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFoo"), "#N8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFoo"), "#N9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFoo"), "#N10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFoo"), "#N11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFoo"), "#N12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBar"), "#N13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBar"), "#N14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBar"), "#N15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBar"), "#N16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBar"), "#N17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBar"), "#N18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlue"), "#N19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlue"), "#N20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlue"), "#N21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlue"), "#N22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlue"), "#N23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlue"), "#N24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFoo"), "#N25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFoo"), "#N26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFoo"), "#N27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFoo"), "#N28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFoo"), "#N29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFoo"), "#N30");
		Assert.IsTrue (ContainsField (fields, "privateStaticBar"), "#N31");
		Assert.IsTrue (ContainsField (fields, "familyStaticBar"), "#N32");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticBar"), "#N33");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticBar"), "#N34");
		Assert.IsTrue (ContainsField (fields, "publicStaticBar"), "#N35");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticBar"), "#N36");
	}

	static void GetFieldsNestedTest (Type type)
	{
		FieldInfo [] fields;
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#A1");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBlueChild"), "#A2");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#A3");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBlueChild"), "#A4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#A5");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBlueChild"), "#A6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#A7");
		Assert.IsTrue (ContainsField (fields, "familyInstanceFooChild"), "#A8");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceFooChild"), "#A9");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceFooChild"), "#A10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#A11");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceFooChild"), "#A12");
		Assert.IsTrue (ContainsField (fields, "privateInstanceBarChild"), "#A13");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBarChild"), "#A14");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBarChild"), "#A15");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBarChild"), "#A16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBarChild"), "#A17");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBarChild"), "#A18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#A19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#A20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#A21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#A22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#A23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#A24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#A25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#A26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#A27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#A28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#A29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#A30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBarChild"), "#A31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBarChild"), "#A32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBarChild"), "#A33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBarChild"), "#A34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBarChild"), "#A35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBarChild"), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#B1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#B2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#B3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#B4");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBlueChild"), "#B5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#B6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#B7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#B8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#B9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#B10");
		Assert.IsTrue (ContainsField (fields, "publicInstanceFooChild"), "#B11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#B12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBarChild"), "#B13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBarChild"), "#B14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBarChild"), "#B15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBarChild"), "#B16");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBarChild"), "#B17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBarChild"), "#B18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#B19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#B20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#B21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#B22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#B23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#B24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#B25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#B26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#B27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#B28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#B29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#B30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBarChild"), "#B31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBarChild"), "#B32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBarChild"), "#B33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBarChild"), "#B34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBarChild"), "#B35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBarChild"), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#C1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#C2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#C3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#C4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#C5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#C6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#C7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#C8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#C9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#C10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#C11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#C12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBarChild"), "#C13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBarChild"), "#C14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBarChild"), "#C15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBarChild"), "#C16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBarChild"), "#C17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBarChild"), "#C18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#C19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#C20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#C21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#C22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#C23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#C24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#C25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#C26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#C27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#C28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#C29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#C30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBarChild"), "#C31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBarChild"), "#C32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBarChild"), "#C33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBarChild"), "#C34");
		Assert.IsTrue (ContainsField (fields, "publicStaticBarChild"), "#C35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBarChild"), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#D1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#D2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#D3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#D4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#D5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#D6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#D7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#D8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#D9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#D10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#D11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#D12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBarChild"), "#D13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBarChild"), "#D14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBarChild"), "#D15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBarChild"), "#D16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBarChild"), "#D17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBarChild"), "#D18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#D19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#D20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#D21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#D22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#D23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#D24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#D25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#D26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#D27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#D28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#D29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#D30");
		Assert.IsTrue (ContainsField (fields, "privateStaticBarChild"), "#D31");
		Assert.IsTrue (ContainsField (fields, "familyStaticBarChild"), "#D32");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticBarChild"), "#D33");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticBarChild"), "#D34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBarChild"), "#D35");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticBarChild"), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#E1");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBlueChild"), "#E2");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#E3");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBlueChild"), "#E4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#E5");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBlueChild"), "#E6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#E7");
		Assert.IsTrue (ContainsField (fields, "familyInstanceFooChild"), "#E8");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceFooChild"), "#E9");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceFooChild"), "#E10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#E11");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceFooChild"), "#E12");
		Assert.IsTrue (ContainsField (fields, "privateInstanceBarChild"), "#E13");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBarChild"), "#E14");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBarChild"), "#E15");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBarChild"), "#E16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBarChild"), "#E17");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBarChild"), "#E18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#E19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#E20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#E21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#E22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#E23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#E24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#E25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#E26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#E27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#E28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#E29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#E30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBarChild"), "#E31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBarChild"), "#E32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBarChild"), "#E33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBarChild"), "#E34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBarChild"), "#E35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBarChild"), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#F1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#F2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#F3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#F4");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBlueChild"), "#F5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#F6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#F7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#F8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#F9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#F10");
		Assert.IsTrue (ContainsField (fields, "publicInstanceFooChild"), "#F11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#F12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBarChild"), "#F13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBarChild"), "#F14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBarChild"), "#F15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBarChild"), "#F16");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBarChild"), "#F17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBarChild"), "#F18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#F19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#F20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#F21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#F22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#F23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#F24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#F25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#F26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#F27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#F28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#F29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#F30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBarChild"), "#F31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBarChild"), "#F32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBarChild"), "#F33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBarChild"), "#F34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBarChild"), "#F35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBarChild"), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#G1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#G2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#G3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#G4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#G5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#G6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#G7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#G8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#G9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#G10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#G11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#G12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBarChild"), "#G13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBarChild"), "#G14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBarChild"), "#G15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBarChild"), "#G16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBarChild"), "#G17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBarChild"), "#G18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#G19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#G20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#G21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#G22");
		Assert.IsTrue (ContainsField (fields, "publicStaticBlueChild"), "#G23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#G24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#G25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#G26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#G27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#G28");
		Assert.IsTrue (ContainsField (fields, "publicStaticFooChild"), "#G29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#G30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBarChild"), "#G31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBarChild"), "#G32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBarChild"), "#G33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBarChild"), "#G34");
		Assert.IsTrue (ContainsField (fields, "publicStaticBarChild"), "#G35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBarChild"), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#H1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#H2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#H3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#H4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#H5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#H6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#H7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#H8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#H9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#H10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#H11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#H12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBarChild"), "#H13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBarChild"), "#H14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBarChild"), "#H15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBarChild"), "#H16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBarChild"), "#H17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBarChild"), "#H18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#H19");
		Assert.IsTrue (ContainsField (fields, "familyStaticBlueChild"), "#H20");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticBlueChild"), "#H21");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticBlueChild"), "#H22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#H23");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticBlueChild"), "#H24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#H25");
		Assert.IsTrue (ContainsField (fields, "familyStaticFooChild"), "#H26");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticFooChild"), "#H27");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticFooChild"), "#H28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#H29");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticFooChild"), "#H30");
		Assert.IsTrue (ContainsField (fields, "privateStaticBarChild"), "#H31");
		Assert.IsTrue (ContainsField (fields, "familyStaticBarChild"), "#H32");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticBarChild"), "#H33");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticBarChild"), "#H34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBarChild"), "#H35");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticBarChild"), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#I1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#I2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#I3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#I4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#I5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#I6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#I7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#I8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#I9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#I10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#I11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#I12");
		Assert.IsTrue (ContainsField (fields, "privateInstanceBarChild"), "#I13");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBarChild"), "#I14");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBarChild"), "#I15");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBarChild"), "#I16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBarChild"), "#I17");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBarChild"), "#I18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#I19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#I20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#I21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#I22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#I23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#I24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#I25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#I26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#I27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#I28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#I29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#I30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBarChild"), "#I31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBarChild"), "#I32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBarChild"), "#I33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBarChild"), "#I34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBarChild"), "#I35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBarChild"), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#J1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#J2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#J3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#J4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#J5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#J6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#J7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#J8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#J9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#J10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#J11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#J12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBarChild"), "#J13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBarChild"), "#J14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBarChild"), "#J15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBarChild"), "#J16");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBarChild"), "#J17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBarChild"), "#J18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#J19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#J20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#J21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#J22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#J23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#J24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#J25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#J26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#J27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#J28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#J29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#J30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBarChild"), "#J31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBarChild"), "#J32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBarChild"), "#J33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBarChild"), "#J34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBarChild"), "#J35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBarChild"), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#K1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#K2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#K3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#K4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#K5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#K6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#K7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#K8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#K9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#K10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#K11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#K12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBarChild"), "#K13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBarChild"), "#K14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBarChild"), "#K15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBarChild"), "#K16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBarChild"), "#K17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBarChild"), "#K18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#K19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#K20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#K21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#K22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#K23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#K24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#K25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#K26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#K27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#K28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#K29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#K30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBarChild"), "#K31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBarChild"), "#K32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBarChild"), "#K33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBarChild"), "#K34");
		Assert.IsTrue (ContainsField (fields, "publicStaticBarChild"), "#K35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBarChild"), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#L1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#L2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#L3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#L4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#L5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#L6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#L7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#L8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#L9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#L10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#L11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#L12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBarChild"), "#L13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBarChild"), "#L14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBarChild"), "#L15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBarChild"), "#L16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBarChild"), "#L17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBarChild"), "#L18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#L19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#L20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#L21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#L22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#L23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#L24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#L25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#L26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#L27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#L28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#L29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#L30");
		Assert.IsTrue (ContainsField (fields, "privateStaticBarChild"), "#L31");
		Assert.IsTrue (ContainsField (fields, "familyStaticBarChild"), "#L32");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticBarChild"), "#L33");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticBarChild"), "#L34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBarChild"), "#L35");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticBarChild"), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#M1");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBlueChild"), "#M2");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#M3");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBlueChild"), "#M4");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBlueChild"), "#M5");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBlueChild"), "#M6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#M7");
		Assert.IsTrue (ContainsField (fields, "familyInstanceFooChild"), "#M8");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceFooChild"), "#M9");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceFooChild"), "#M10");
		Assert.IsTrue (ContainsField (fields, "publicInstanceFooChild"), "#M11");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceFooChild"), "#M12");
		Assert.IsTrue (ContainsField (fields, "privateInstanceBarChild"), "#M13");
		Assert.IsTrue (ContainsField (fields, "familyInstanceBarChild"), "#M14");
		Assert.IsTrue (ContainsField (fields, "famANDAssemInstanceBarChild"), "#M15");
		Assert.IsTrue (ContainsField (fields, "famORAssemInstanceBarChild"), "#M16");
		Assert.IsTrue (ContainsField (fields, "publicInstanceBarChild"), "#M17");
		Assert.IsTrue (ContainsField (fields, "assemblyInstanceBarChild"), "#M18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#M19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#M20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#M21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#M22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#M23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#M24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#M25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#M26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#M27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#M28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#M29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#M30");
		Assert.IsFalse (ContainsField (fields, "privateStaticBarChild"), "#M31");
		Assert.IsFalse (ContainsField (fields, "familyStaticBarChild"), "#M32");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBarChild"), "#M33");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBarChild"), "#M34");
		Assert.IsFalse (ContainsField (fields, "publicStaticBarChild"), "#M35");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBarChild"), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;
		fields = type.GetFields (flags);

		Assert.IsFalse (ContainsField (fields, "privateInstanceBlueChild"), "#N1");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBlueChild"), "#N2");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBlueChild"), "#N3");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBlueChild"), "#N4");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBlueChild"), "#N5");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBlueChild"), "#N6");
		Assert.IsFalse (ContainsField (fields, "privateInstanceFooChild"), "#N7");
		Assert.IsFalse (ContainsField (fields, "familyInstanceFooChild"), "#N8");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceFooChild"), "#N9");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceFooChild"), "#N10");
		Assert.IsFalse (ContainsField (fields, "publicInstanceFooChild"), "#N11");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceFooChild"), "#N12");
		Assert.IsFalse (ContainsField (fields, "privateInstanceBarChild"), "#N13");
		Assert.IsFalse (ContainsField (fields, "familyInstanceBarChild"), "#N14");
		Assert.IsFalse (ContainsField (fields, "famANDAssemInstanceBarChild"), "#N15");
		Assert.IsFalse (ContainsField (fields, "famORAssemInstanceBarChild"), "#N16");
		Assert.IsFalse (ContainsField (fields, "publicInstanceBarChild"), "#N17");
		Assert.IsFalse (ContainsField (fields, "assemblyInstanceBarChild"), "#N18");
		Assert.IsFalse (ContainsField (fields, "privateStaticBlueChild"), "#N19");
		Assert.IsFalse (ContainsField (fields, "familyStaticBlueChild"), "#N20");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticBlueChild"), "#N21");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticBlueChild"), "#N22");
		Assert.IsFalse (ContainsField (fields, "publicStaticBlueChild"), "#N23");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticBlueChild"), "#N24");
		Assert.IsFalse (ContainsField (fields, "privateStaticFooChild"), "#N25");
		Assert.IsFalse (ContainsField (fields, "familyStaticFooChild"), "#N26");
		Assert.IsFalse (ContainsField (fields, "famANDAssemStaticFooChild"), "#N27");
		Assert.IsFalse (ContainsField (fields, "famORAssemStaticFooChild"), "#N28");
		Assert.IsFalse (ContainsField (fields, "publicStaticFooChild"), "#N29");
		Assert.IsFalse (ContainsField (fields, "assemblyStaticFooChild"), "#N30");
		Assert.IsTrue (ContainsField (fields, "privateStaticBarChild"), "#N31");
		Assert.IsTrue (ContainsField (fields, "familyStaticBarChild"), "#N32");
		Assert.IsTrue (ContainsField (fields, "famANDAssemStaticBarChild"), "#N33");
		Assert.IsTrue (ContainsField (fields, "famORAssemStaticBarChild"), "#N34");
		Assert.IsTrue (ContainsField (fields, "publicStaticBarChild"), "#N35");
		Assert.IsTrue (ContainsField (fields, "assemblyStaticBarChild"), "#N36");
	}

	static void GetFieldTest (Type type)
	{
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#A1");
		Assert.IsNotNull (type.GetField ("familyInstanceBlue", flags), "#A2");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBlue", flags), "#A3");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBlue", flags), "#A4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#A5");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBlue", flags), "#A6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#A7");
		Assert.IsNotNull (type.GetField ("familyInstanceFoo", flags), "#A8");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceFoo", flags), "#A9");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceFoo", flags), "#A10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#A11");
		Assert.IsNotNull (type.GetField ("assemblyInstanceFoo", flags), "#A12");
		Assert.IsNotNull (type.GetField ("privateInstanceBar", flags), "#A13");
		Assert.IsNotNull (type.GetField ("familyInstanceBar", flags), "#A14");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBar", flags), "#A15");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBar", flags), "#A16");
		Assert.IsNull (type.GetField ("publicInstanceBar", flags), "#A17");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBar", flags), "#A18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#A19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#A20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#A21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#A22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#A23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#A24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#A25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#A26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#A27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#A28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#A29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#A30");
		Assert.IsNull (type.GetField ("privateStaticBar", flags), "#A31");
		Assert.IsNull (type.GetField ("familyStaticBar", flags), "#A32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBar", flags), "#A33");
		Assert.IsNull (type.GetField ("famORAssemStaticBar", flags), "#A34");
		Assert.IsNull (type.GetField ("publicStaticBar", flags), "#A35");
		Assert.IsNull (type.GetField ("assemblyStaticBar", flags), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#B1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#B2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#B3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#B4");
		Assert.IsNotNull (type.GetField ("publicInstanceBlue", flags), "#B5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#B6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#B7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#B8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#B9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#B10");
		Assert.IsNotNull (type.GetField ("publicInstanceFoo", flags), "#B11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#B12");
		Assert.IsNull (type.GetField ("privateInstanceBar", flags), "#B13");
		Assert.IsNull (type.GetField ("familyInstanceBar", flags), "#B14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBar", flags), "#B15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBar", flags), "#B16");
		Assert.IsNotNull (type.GetField ("publicInstanceBar", flags), "#B17");
		Assert.IsNull (type.GetField ("assemblyInstanceBar", flags), "#B18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#B19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#B20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#B21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#B22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#B23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#B24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#B25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#B26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#B27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#B28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#B29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#B30");
		Assert.IsNull (type.GetField ("privateStaticBar", flags), "#B31");
		Assert.IsNull (type.GetField ("familyStaticBar", flags), "#B32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBar", flags), "#B33");
		Assert.IsNull (type.GetField ("famORAssemStaticBar", flags), "#B34");
		Assert.IsNull (type.GetField ("publicStaticBar", flags), "#B35");
		Assert.IsNull (type.GetField ("assemblyStaticBar", flags), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#C1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#C2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#C3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#C4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#C5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#C6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#C7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#C8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#C9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#C10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#C11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#C12");
		Assert.IsNull (type.GetField ("privateInstanceBar", flags), "#C13");
		Assert.IsNull (type.GetField ("familyInstanceBar", flags), "#C14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBar", flags), "#C15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBar", flags), "#C16");
		Assert.IsNull (type.GetField ("publicInstanceBar", flags), "#C17");
		Assert.IsNull (type.GetField ("assemblyInstanceBar", flags), "#C18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#C19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#C20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#C21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#C22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#C23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#C24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#C25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#C26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#C27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#C28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#C29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#C30");
		Assert.IsNull (type.GetField ("privateStaticBar", flags), "#C31");
		Assert.IsNull (type.GetField ("familyStaticBar", flags), "#C32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBar", flags), "#C33");
		Assert.IsNull (type.GetField ("famORAssemStaticBar", flags), "#C34");
		Assert.IsNotNull (type.GetField ("publicStaticBar", flags), "#C35");
		Assert.IsNull (type.GetField ("assemblyStaticBar", flags), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#D1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#D2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#D3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#D4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#D5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#D6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#D7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#D8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#D9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#D10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#D11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#D12");
		Assert.IsNull (type.GetField ("privateInstanceBar", flags), "#D13");
		Assert.IsNull (type.GetField ("familyInstanceBar", flags), "#D14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBar", flags), "#D15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBar", flags), "#D16");
		Assert.IsNull (type.GetField ("publicInstanceBar", flags), "#D17");
		Assert.IsNull (type.GetField ("assemblyInstanceBar", flags), "#D18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#D19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#D20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#D21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#D22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#D23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#D24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#D25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#D26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#D27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#D28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#D29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#D30");
		Assert.IsNotNull (type.GetField ("privateStaticBar", flags), "#D31");
		Assert.IsNotNull (type.GetField ("familyStaticBar", flags), "#D32");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticBar", flags), "#D33");
		Assert.IsNotNull (type.GetField ("famORAssemStaticBar", flags), "#D34");
		Assert.IsNull (type.GetField ("publicStaticBar", flags), "#D35");
		Assert.IsNotNull (type.GetField ("assemblyStaticBar", flags), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#E1");
		Assert.IsNotNull (type.GetField ("familyInstanceBlue", flags), "#E2");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBlue", flags), "#E3");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBlue", flags), "#E4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#E5");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBlue", flags), "#E6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#E7");
		Assert.IsNotNull (type.GetField ("familyInstanceFoo", flags), "#E8");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceFoo", flags), "#E9");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceFoo", flags), "#E10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#E11");
		Assert.IsNotNull (type.GetField ("assemblyInstanceFoo", flags), "#E12");
		Assert.IsNotNull (type.GetField ("privateInstanceBar", flags), "#E13");
		Assert.IsNotNull (type.GetField ("familyInstanceBar", flags), "#E14");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBar", flags), "#E15");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBar", flags), "#E16");
		Assert.IsNull (type.GetField ("publicInstanceBar", flags), "#E17");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBar", flags), "#E18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#E19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#E20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#E21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#E22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#E23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#E24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#E25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#E26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#E27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#E28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#E29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#E30");
		Assert.IsNull (type.GetField ("privateStaticBar", flags), "#E31");
		Assert.IsNull (type.GetField ("familyStaticBar", flags), "#E32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBar", flags), "#E33");
		Assert.IsNull (type.GetField ("famORAssemStaticBar", flags), "#E34");
		Assert.IsNull (type.GetField ("publicStaticBar", flags), "#E35");
		Assert.IsNull (type.GetField ("assemblyStaticBar", flags), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#F1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#F2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#F3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#F4");
		Assert.IsNotNull (type.GetField ("publicInstanceBlue", flags), "#F5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#F6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#F7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#F8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#F9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#F10");
		Assert.IsNotNull (type.GetField ("publicInstanceFoo", flags), "#F11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#F12");
		Assert.IsNull (type.GetField ("privateInstanceBar", flags), "#F13");
		Assert.IsNull (type.GetField ("familyInstanceBar", flags), "#F14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBar", flags), "#F15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBar", flags), "#F16");
		Assert.IsNotNull (type.GetField ("publicInstanceBar", flags), "#F17");
		Assert.IsNull (type.GetField ("assemblyInstanceBar", flags), "#F18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#F19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#F20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#F21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#F22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#F23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#F24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#F25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#F26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#F27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#F28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#F29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#F30");
		Assert.IsNull (type.GetField ("privateStaticBar", flags), "#F31");
		Assert.IsNull (type.GetField ("familyStaticBar", flags), "#F32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBar", flags), "#F33");
		Assert.IsNull (type.GetField ("famORAssemStaticBar", flags), "#F34");
		Assert.IsNull (type.GetField ("publicStaticBar", flags), "#F35");
		Assert.IsNull (type.GetField ("assemblyStaticBar", flags), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#G1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#G2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#G3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#G4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#G5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#G6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#G7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#G8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#G9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#G10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#G11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#G12");
		Assert.IsNull (type.GetField ("privateInstanceBar", flags), "#G13");
		Assert.IsNull (type.GetField ("familyInstanceBar", flags), "#G14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBar", flags), "#G15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBar", flags), "#G16");
		Assert.IsNull (type.GetField ("publicInstanceBar", flags), "#G17");
		Assert.IsNull (type.GetField ("assemblyInstanceBar", flags), "#G18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#G19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#G20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#G21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#G22");
		Assert.IsNotNull (type.GetField ("publicStaticBlue", flags), "#G23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#G24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#G25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#G26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#G27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#G28");
		Assert.IsNotNull (type.GetField ("publicStaticFoo", flags), "#G29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#G30");
		Assert.IsNull (type.GetField ("privateStaticBar", flags), "#G31");
		Assert.IsNull (type.GetField ("familyStaticBar", flags), "#G32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBar", flags), "#G33");
		Assert.IsNull (type.GetField ("famORAssemStaticBar", flags), "#G34");
		Assert.IsNotNull (type.GetField ("publicStaticBar", flags), "#G35");
		Assert.IsNull (type.GetField ("assemblyStaticBar", flags), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#H1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#H2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#H3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#H4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#H5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#H6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#H7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#H8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#H9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#H10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#H11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#H12");
		Assert.IsNull (type.GetField ("privateInstanceBar", flags), "#H13");
		Assert.IsNull (type.GetField ("familyInstanceBar", flags), "#H14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBar", flags), "#H15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBar", flags), "#H16");
		Assert.IsNull (type.GetField ("publicInstanceBar", flags), "#H17");
		Assert.IsNull (type.GetField ("assemblyInstanceBar", flags), "#H18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#H19");
		Assert.IsNotNull (type.GetField ("familyStaticBlue", flags), "#H20");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticBlue", flags), "#H21");
		Assert.IsNotNull (type.GetField ("famORAssemStaticBlue", flags), "#H22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#H23");
		Assert.IsNotNull (type.GetField ("assemblyStaticBlue", flags), "#H24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#H25");
		Assert.IsNotNull (type.GetField ("familyStaticFoo", flags), "#H26");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticFoo", flags), "#H27");
		Assert.IsNotNull (type.GetField ("famORAssemStaticFoo", flags), "#H28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#H29");
		Assert.IsNotNull (type.GetField ("assemblyStaticFoo", flags), "#H30");
		Assert.IsNotNull (type.GetField ("privateStaticBar", flags), "#H31");
		Assert.IsNotNull (type.GetField ("familyStaticBar", flags), "#H32");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticBar", flags), "#H33");
		Assert.IsNotNull (type.GetField ("famORAssemStaticBar", flags), "#H34");
		Assert.IsNull (type.GetField ("publicStaticBar", flags), "#H35");
		Assert.IsNotNull (type.GetField ("assemblyStaticBar", flags), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#I1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#I2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#I3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#I4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#I5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#I6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#I7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#I8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#I9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#I10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#I11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#I12");
		Assert.IsNotNull (type.GetField ("privateInstanceBar", flags), "#I13");
		Assert.IsNotNull (type.GetField ("familyInstanceBar", flags), "#I14");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBar", flags), "#I15");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBar", flags), "#I16");
		Assert.IsNull (type.GetField ("publicInstanceBar", flags), "#I17");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBar", flags), "#I18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#I19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#I20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#I21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#I22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#I23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#I24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#I25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#I26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#I27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#I28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#I29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#I30");
		Assert.IsNull (type.GetField ("privateStaticBar", flags), "#I31");
		Assert.IsNull (type.GetField ("familyStaticBar", flags), "#I32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBar", flags), "#I33");
		Assert.IsNull (type.GetField ("famORAssemStaticBar", flags), "#I34");
		Assert.IsNull (type.GetField ("publicStaticBar", flags), "#I35");
		Assert.IsNull (type.GetField ("assemblyStaticBar", flags), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#J1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#J2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#J3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#J4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#J5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#J6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#J7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#J8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#J9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#J10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#J11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#J12");
		Assert.IsNull (type.GetField ("privateInstanceBar", flags), "#J13");
		Assert.IsNull (type.GetField ("familyInstanceBar", flags), "#J14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBar", flags), "#J15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBar", flags), "#J16");
		Assert.IsNotNull (type.GetField ("publicInstanceBar", flags), "#J17");
		Assert.IsNull (type.GetField ("assemblyInstanceBar", flags), "#J18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#J19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#J20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#J21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#J22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#J23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#J24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#J25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#J26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#J27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#J28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#J29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#J30");
		Assert.IsNull (type.GetField ("privateStaticBar", flags), "#J31");
		Assert.IsNull (type.GetField ("familyStaticBar", flags), "#J32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBar", flags), "#J33");
		Assert.IsNull (type.GetField ("famORAssemStaticBar", flags), "#J34");
		Assert.IsNull (type.GetField ("publicStaticBar", flags), "#J35");
		Assert.IsNull (type.GetField ("assemblyStaticBar", flags), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#K1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#K2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#K3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#K4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#K5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#K6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#K7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#K8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#K9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#K10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#K11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#K12");
		Assert.IsNull (type.GetField ("privateInstanceBar", flags), "#K13");
		Assert.IsNull (type.GetField ("familyInstanceBar", flags), "#K14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBar", flags), "#K15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBar", flags), "#K16");
		Assert.IsNull (type.GetField ("publicInstanceBar", flags), "#K17");
		Assert.IsNull (type.GetField ("assemblyInstanceBar", flags), "#K18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#K19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#K20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#K21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#K22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#K23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#K24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#K25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#K26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#K27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#K28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#K29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#K30");
		Assert.IsNull (type.GetField ("privateStaticBar", flags), "#K31");
		Assert.IsNull (type.GetField ("familyStaticBar", flags), "#K32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBar", flags), "#K33");
		Assert.IsNull (type.GetField ("famORAssemStaticBar", flags), "#K34");
		Assert.IsNotNull (type.GetField ("publicStaticBar", flags), "#K35");
		Assert.IsNull (type.GetField ("assemblyStaticBar", flags), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#L1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#L2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#L3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#L4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#L5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#L6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#L7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#L8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#L9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#L10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#L11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#L12");
		Assert.IsNull (type.GetField ("privateInstanceBar", flags), "#L13");
		Assert.IsNull (type.GetField ("familyInstanceBar", flags), "#L14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBar", flags), "#L15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBar", flags), "#L16");
		Assert.IsNull (type.GetField ("publicInstanceBar", flags), "#L17");
		Assert.IsNull (type.GetField ("assemblyInstanceBar", flags), "#L18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#L19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#L20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#L21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#L22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#L23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#L24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#L25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#L26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#L27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#L28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#L29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#L30");
		Assert.IsNotNull (type.GetField ("privateStaticBar", flags), "#L31");
		Assert.IsNotNull (type.GetField ("familyStaticBar", flags), "#L32");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticBar", flags), "#L33");
		Assert.IsNotNull (type.GetField ("famORAssemStaticBar", flags), "#L34");
		Assert.IsNull (type.GetField ("publicStaticBar", flags), "#L35");
		Assert.IsNotNull (type.GetField ("assemblyStaticBar", flags), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#M1");
		Assert.IsNotNull (type.GetField ("familyInstanceBlue", flags), "#M2");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBlue", flags), "#M3");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBlue", flags), "#M4");
		Assert.IsNotNull (type.GetField ("publicInstanceBlue", flags), "#M5");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBlue", flags), "#M6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#M7");
		Assert.IsNotNull (type.GetField ("familyInstanceFoo", flags), "#M8");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceFoo", flags), "#M9");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceFoo", flags), "#M10");
		Assert.IsNotNull (type.GetField ("publicInstanceFoo", flags), "#M11");
		Assert.IsNotNull (type.GetField ("assemblyInstanceFoo", flags), "#M12");
		Assert.IsNotNull (type.GetField ("privateInstanceBar", flags), "#M13");
		Assert.IsNotNull (type.GetField ("familyInstanceBar", flags), "#M14");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBar", flags), "#M15");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBar", flags), "#M16");
		Assert.IsNotNull (type.GetField ("publicInstanceBar", flags), "#M17");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBar", flags), "#M18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#M19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#M20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#M21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#M22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#M23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#M24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#M25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#M26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#M27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#M28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#M29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#M30");
		Assert.IsNull (type.GetField ("privateStaticBar", flags), "#M31");
		Assert.IsNull (type.GetField ("familyStaticBar", flags), "#M32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBar", flags), "#M33");
		Assert.IsNull (type.GetField ("famORAssemStaticBar", flags), "#M34");
		Assert.IsNull (type.GetField ("publicStaticBar", flags), "#M35");
		Assert.IsNull (type.GetField ("assemblyStaticBar", flags), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetField ("privateInstanceBlue", flags), "#N1");
		Assert.IsNull (type.GetField ("familyInstanceBlue", flags), "#N2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlue", flags), "#N3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlue", flags), "#N4");
		Assert.IsNull (type.GetField ("publicInstanceBlue", flags), "#N5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlue", flags), "#N6");
		Assert.IsNull (type.GetField ("privateInstanceFoo", flags), "#N7");
		Assert.IsNull (type.GetField ("familyInstanceFoo", flags), "#N8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFoo", flags), "#N9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFoo", flags), "#N10");
		Assert.IsNull (type.GetField ("publicInstanceFoo", flags), "#N11");
		Assert.IsNull (type.GetField ("assemblyInstanceFoo", flags), "#N12");
		Assert.IsNull (type.GetField ("privateInstanceBar", flags), "#N13");
		Assert.IsNull (type.GetField ("familyInstanceBar", flags), "#N14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBar", flags), "#N15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBar", flags), "#N16");
		Assert.IsNull (type.GetField ("publicInstanceBar", flags), "#N17");
		Assert.IsNull (type.GetField ("assemblyInstanceBar", flags), "#N18");
		Assert.IsNull (type.GetField ("privateStaticBlue", flags), "#N19");
		Assert.IsNull (type.GetField ("familyStaticBlue", flags), "#N20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlue", flags), "#N21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlue", flags), "#N22");
		Assert.IsNull (type.GetField ("publicStaticBlue", flags), "#N23");
		Assert.IsNull (type.GetField ("assemblyStaticBlue", flags), "#N24");
		Assert.IsNull (type.GetField ("privateStaticFoo", flags), "#N25");
		Assert.IsNull (type.GetField ("familyStaticFoo", flags), "#N26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFoo", flags), "#N27");
		Assert.IsNull (type.GetField ("famORAssemStaticFoo", flags), "#N28");
		Assert.IsNull (type.GetField ("publicStaticFoo", flags), "#N29");
		Assert.IsNull (type.GetField ("assemblyStaticFoo", flags), "#N30");
		Assert.IsNotNull (type.GetField ("privateStaticBar", flags), "#N31");
		Assert.IsNotNull (type.GetField ("familyStaticBar", flags), "#N32");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticBar", flags), "#N33");
		Assert.IsNotNull (type.GetField ("famORAssemStaticBar", flags), "#N34");
		Assert.IsNotNull (type.GetField ("publicStaticBar", flags), "#N35");
		Assert.IsNotNull (type.GetField ("assemblyStaticBar", flags), "#N36");
	}

	static void GetFieldNestedTest (Type type)
	{
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#A1");
		Assert.IsNotNull (type.GetField ("familyInstanceBlueChild", flags), "#A2");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#A3");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#A4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#A5");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBlueChild", flags), "#A6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#A7");
		Assert.IsNotNull (type.GetField ("familyInstanceFooChild", flags), "#A8");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#A9");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceFooChild", flags), "#A10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#A11");
		Assert.IsNotNull (type.GetField ("assemblyInstanceFooChild", flags), "#A12");
		Assert.IsNotNull (type.GetField ("privateInstanceBarChild", flags), "#A13");
		Assert.IsNotNull (type.GetField ("familyInstanceBarChild", flags), "#A14");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#A15");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBarChild", flags), "#A16");
		Assert.IsNull (type.GetField ("publicInstanceBarChild", flags), "#A17");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBarChild", flags), "#A18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#A19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#A20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#A21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#A22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#A23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#A24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#A25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#A26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#A27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#A28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#A29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#A30");
		Assert.IsNull (type.GetField ("privateStaticBarChild", flags), "#A31");
		Assert.IsNull (type.GetField ("familyStaticBarChild", flags), "#A32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBarChild", flags), "#A33");
		Assert.IsNull (type.GetField ("famORAssemStaticBarChild", flags), "#A34");
		Assert.IsNull (type.GetField ("publicStaticBarChild", flags), "#A35");
		Assert.IsNull (type.GetField ("assemblyStaticBarChild", flags), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#B1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#B2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#B3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#B4");
		Assert.IsNotNull (type.GetField ("publicInstanceBlueChild", flags), "#B5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#B6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#B7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#B8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#B9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#B10");
		Assert.IsNotNull (type.GetField ("publicInstanceFooChild", flags), "#B11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#B12");
		Assert.IsNull (type.GetField ("privateInstanceBarChild", flags), "#B13");
		Assert.IsNull (type.GetField ("familyInstanceBarChild", flags), "#B14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#B15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBarChild", flags), "#B16");
		Assert.IsNotNull (type.GetField ("publicInstanceBarChild", flags), "#B17");
		Assert.IsNull (type.GetField ("assemblyInstanceBarChild", flags), "#B18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#B19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#B20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#B21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#B22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#B23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#B24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#B25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#B26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#B27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#B28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#B29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#B30");
		Assert.IsNull (type.GetField ("privateStaticBarChild", flags), "#B31");
		Assert.IsNull (type.GetField ("familyStaticBarChild", flags), "#B32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBarChild", flags), "#B33");
		Assert.IsNull (type.GetField ("famORAssemStaticBarChild", flags), "#B34");
		Assert.IsNull (type.GetField ("publicStaticBarChild", flags), "#B35");
		Assert.IsNull (type.GetField ("assemblyStaticBarChild", flags), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#C1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#C2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#C3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#C4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#C5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#C6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#C7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#C8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#C9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#C10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#C11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#C12");
		Assert.IsNull (type.GetField ("privateInstanceBarChild", flags), "#C13");
		Assert.IsNull (type.GetField ("familyInstanceBarChild", flags), "#C14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#C15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBarChild", flags), "#C16");
		Assert.IsNull (type.GetField ("publicInstanceBarChild", flags), "#C17");
		Assert.IsNull (type.GetField ("assemblyInstanceBarChild", flags), "#C18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#C19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#C20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#C21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#C22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#C23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#C24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#C25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#C26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#C27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#C28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#C29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#C30");
		Assert.IsNull (type.GetField ("privateStaticBarChild", flags), "#C31");
		Assert.IsNull (type.GetField ("familyStaticBarChild", flags), "#C32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBarChild", flags), "#C33");
		Assert.IsNull (type.GetField ("famORAssemStaticBarChild", flags), "#C34");
		Assert.IsNotNull (type.GetField ("publicStaticBarChild", flags), "#C35");
		Assert.IsNull (type.GetField ("assemblyStaticBarChild", flags), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#D1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#D2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#D3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#D4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#D5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#D6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#D7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#D8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#D9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#D10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#D11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#D12");
		Assert.IsNull (type.GetField ("privateInstanceBarChild", flags), "#D13");
		Assert.IsNull (type.GetField ("familyInstanceBarChild", flags), "#D14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#D15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBarChild", flags), "#D16");
		Assert.IsNull (type.GetField ("publicInstanceBarChild", flags), "#D17");
		Assert.IsNull (type.GetField ("assemblyInstanceBarChild", flags), "#D18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#D19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#D20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#D21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#D22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#D23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#D24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#D25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#D26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#D27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#D28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#D29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#D30");
		Assert.IsNotNull (type.GetField ("privateStaticBarChild", flags), "#D31");
		Assert.IsNotNull (type.GetField ("familyStaticBarChild", flags), "#D32");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticBarChild", flags), "#D33");
		Assert.IsNotNull (type.GetField ("famORAssemStaticBarChild", flags), "#D34");
		Assert.IsNull (type.GetField ("publicStaticBarChild", flags), "#D35");
		Assert.IsNotNull (type.GetField ("assemblyStaticBarChild", flags), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#E1");
		Assert.IsNotNull (type.GetField ("familyInstanceBlueChild", flags), "#E2");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#E3");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#E4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#E5");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBlueChild", flags), "#E6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#E7");
		Assert.IsNotNull (type.GetField ("familyInstanceFooChild", flags), "#E8");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#E9");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceFooChild", flags), "#E10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#E11");
		Assert.IsNotNull (type.GetField ("assemblyInstanceFooChild", flags), "#E12");
		Assert.IsNotNull (type.GetField ("privateInstanceBarChild", flags), "#E13");
		Assert.IsNotNull (type.GetField ("familyInstanceBarChild", flags), "#E14");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#E15");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBarChild", flags), "#E16");
		Assert.IsNull (type.GetField ("publicInstanceBarChild", flags), "#E17");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBarChild", flags), "#E18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#E19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#E20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#E21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#E22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#E23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#E24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#E25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#E26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#E27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#E28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#E29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#E30");
		Assert.IsNull (type.GetField ("privateStaticBarChild", flags), "#E31");
		Assert.IsNull (type.GetField ("familyStaticBarChild", flags), "#E32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBarChild", flags), "#E33");
		Assert.IsNull (type.GetField ("famORAssemStaticBarChild", flags), "#E34");
		Assert.IsNull (type.GetField ("publicStaticBarChild", flags), "#E35");
		Assert.IsNull (type.GetField ("assemblyStaticBarChild", flags), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#F1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#F2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#F3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#F4");
		Assert.IsNotNull (type.GetField ("publicInstanceBlueChild", flags), "#F5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#F6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#F7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#F8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#F9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#F10");
		Assert.IsNotNull (type.GetField ("publicInstanceFooChild", flags), "#F11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#F12");
		Assert.IsNull (type.GetField ("privateInstanceBarChild", flags), "#F13");
		Assert.IsNull (type.GetField ("familyInstanceBarChild", flags), "#F14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#F15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBarChild", flags), "#F16");
		Assert.IsNotNull (type.GetField ("publicInstanceBarChild", flags), "#F17");
		Assert.IsNull (type.GetField ("assemblyInstanceBarChild", flags), "#F18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#F19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#F20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#F21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#F22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#F23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#F24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#F25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#F26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#F27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#F28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#F29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#F30");
		Assert.IsNull (type.GetField ("privateStaticBarChild", flags), "#F31");
		Assert.IsNull (type.GetField ("familyStaticBarChild", flags), "#F32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBarChild", flags), "#F33");
		Assert.IsNull (type.GetField ("famORAssemStaticBarChild", flags), "#F34");
		Assert.IsNull (type.GetField ("publicStaticBarChild", flags), "#F35");
		Assert.IsNull (type.GetField ("assemblyStaticBarChild", flags), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#G1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#G2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#G3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#G4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#G5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#G6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#G7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#G8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#G9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#G10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#G11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#G12");
		Assert.IsNull (type.GetField ("privateInstanceBarChild", flags), "#G13");
		Assert.IsNull (type.GetField ("familyInstanceBarChild", flags), "#G14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#G15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBarChild", flags), "#G16");
		Assert.IsNull (type.GetField ("publicInstanceBarChild", flags), "#G17");
		Assert.IsNull (type.GetField ("assemblyInstanceBarChild", flags), "#G18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#G19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#G20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#G21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#G22");
		Assert.IsNotNull (type.GetField ("publicStaticBlueChild", flags), "#G23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#G24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#G25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#G26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#G27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#G28");
		Assert.IsNotNull (type.GetField ("publicStaticFooChild", flags), "#G29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#G30");
		Assert.IsNull (type.GetField ("privateStaticBarChild", flags), "#G31");
		Assert.IsNull (type.GetField ("familyStaticBarChild", flags), "#G32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBarChild", flags), "#G33");
		Assert.IsNull (type.GetField ("famORAssemStaticBarChild", flags), "#G34");
		Assert.IsNotNull (type.GetField ("publicStaticBarChild", flags), "#G35");
		Assert.IsNull (type.GetField ("assemblyStaticBarChild", flags), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#H1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#H2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#H3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#H4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#H5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#H6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#H7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#H8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#H9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#H10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#H11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#H12");
		Assert.IsNull (type.GetField ("privateInstanceBarChild", flags), "#H13");
		Assert.IsNull (type.GetField ("familyInstanceBarChild", flags), "#H14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#H15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBarChild", flags), "#H16");
		Assert.IsNull (type.GetField ("publicInstanceBarChild", flags), "#H17");
		Assert.IsNull (type.GetField ("assemblyInstanceBarChild", flags), "#H18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#H19");
		Assert.IsNotNull (type.GetField ("familyStaticBlueChild", flags), "#H20");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#H21");
		Assert.IsNotNull (type.GetField ("famORAssemStaticBlueChild", flags), "#H22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#H23");
		Assert.IsNotNull (type.GetField ("assemblyStaticBlueChild", flags), "#H24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#H25");
		Assert.IsNotNull (type.GetField ("familyStaticFooChild", flags), "#H26");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticFooChild", flags), "#H27");
		Assert.IsNotNull (type.GetField ("famORAssemStaticFooChild", flags), "#H28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#H29");
		Assert.IsNotNull (type.GetField ("assemblyStaticFooChild", flags), "#H30");
		Assert.IsNotNull (type.GetField ("privateStaticBarChild", flags), "#H31");
		Assert.IsNotNull (type.GetField ("familyStaticBarChild", flags), "#H32");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticBarChild", flags), "#H33");
		Assert.IsNotNull (type.GetField ("famORAssemStaticBarChild", flags), "#H34");
		Assert.IsNull (type.GetField ("publicStaticBarChild", flags), "#H35");
		Assert.IsNotNull (type.GetField ("assemblyStaticBarChild", flags), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#I1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#I2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#I3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#I4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#I5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#I6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#I7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#I8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#I9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#I10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#I11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#I12");
		Assert.IsNotNull (type.GetField ("privateInstanceBarChild", flags), "#I13");
		Assert.IsNotNull (type.GetField ("familyInstanceBarChild", flags), "#I14");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#I15");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBarChild", flags), "#I16");
		Assert.IsNull (type.GetField ("publicInstanceBarChild", flags), "#I17");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBarChild", flags), "#I18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#I19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#I20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#I21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#I22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#I23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#I24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#I25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#I26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#I27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#I28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#I29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#I30");
		Assert.IsNull (type.GetField ("privateStaticBarChild", flags), "#I31");
		Assert.IsNull (type.GetField ("familyStaticBarChild", flags), "#I32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBarChild", flags), "#I33");
		Assert.IsNull (type.GetField ("famORAssemStaticBarChild", flags), "#I34");
		Assert.IsNull (type.GetField ("publicStaticBarChild", flags), "#I35");
		Assert.IsNull (type.GetField ("assemblyStaticBarChild", flags), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#J1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#J2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#J3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#J4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#J5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#J6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#J7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#J8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#J9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#J10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#J11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#J12");
		Assert.IsNull (type.GetField ("privateInstanceBarChild", flags), "#J13");
		Assert.IsNull (type.GetField ("familyInstanceBarChild", flags), "#J14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#J15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBarChild", flags), "#J16");
		Assert.IsNotNull (type.GetField ("publicInstanceBarChild", flags), "#J17");
		Assert.IsNull (type.GetField ("assemblyInstanceBarChild", flags), "#J18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#J19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#J20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#J21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#J22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#J23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#J24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#J25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#J26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#J27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#J28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#J29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#J30");
		Assert.IsNull (type.GetField ("privateStaticBarChild", flags), "#J31");
		Assert.IsNull (type.GetField ("familyStaticBarChild", flags), "#J32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBarChild", flags), "#J33");
		Assert.IsNull (type.GetField ("famORAssemStaticBarChild", flags), "#J34");
		Assert.IsNull (type.GetField ("publicStaticBarChild", flags), "#J35");
		Assert.IsNull (type.GetField ("assemblyStaticBarChild", flags), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#K1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#K2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#K3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#K4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#K5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#K6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#K7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#K8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#K9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#K10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#K11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#K12");
		Assert.IsNull (type.GetField ("privateInstanceBarChild", flags), "#K13");
		Assert.IsNull (type.GetField ("familyInstanceBarChild", flags), "#K14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#K15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBarChild", flags), "#K16");
		Assert.IsNull (type.GetField ("publicInstanceBarChild", flags), "#K17");
		Assert.IsNull (type.GetField ("assemblyInstanceBarChild", flags), "#K18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#K19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#K20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#K21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#K22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#K23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#K24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#K25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#K26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#K27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#K28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#K29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#K30");
		Assert.IsNull (type.GetField ("privateStaticBarChild", flags), "#K31");
		Assert.IsNull (type.GetField ("familyStaticBarChild", flags), "#K32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBarChild", flags), "#K33");
		Assert.IsNull (type.GetField ("famORAssemStaticBarChild", flags), "#K34");
		Assert.IsNotNull (type.GetField ("publicStaticBarChild", flags), "#K35");
		Assert.IsNull (type.GetField ("assemblyStaticBarChild", flags), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#L1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#L2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#L3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#L4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#L5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#L6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#L7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#L8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#L9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#L10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#L11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#L12");
		Assert.IsNull (type.GetField ("privateInstanceBarChild", flags), "#L13");
		Assert.IsNull (type.GetField ("familyInstanceBarChild", flags), "#L14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#L15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBarChild", flags), "#L16");
		Assert.IsNull (type.GetField ("publicInstanceBarChild", flags), "#L17");
		Assert.IsNull (type.GetField ("assemblyInstanceBarChild", flags), "#L18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#L19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#L20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#L21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#L22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#L23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#L24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#L25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#L26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#L27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#L28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#L29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#L30");
		Assert.IsNotNull (type.GetField ("privateStaticBarChild", flags), "#L31");
		Assert.IsNotNull (type.GetField ("familyStaticBarChild", flags), "#L32");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticBarChild", flags), "#L33");
		Assert.IsNotNull (type.GetField ("famORAssemStaticBarChild", flags), "#L34");
		Assert.IsNull (type.GetField ("publicStaticBarChild", flags), "#L35");
		Assert.IsNotNull (type.GetField ("assemblyStaticBarChild", flags), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#M1");
		Assert.IsNotNull (type.GetField ("familyInstanceBlueChild", flags), "#M2");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#M3");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#M4");
		Assert.IsNotNull (type.GetField ("publicInstanceBlueChild", flags), "#M5");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBlueChild", flags), "#M6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#M7");
		Assert.IsNotNull (type.GetField ("familyInstanceFooChild", flags), "#M8");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#M9");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceFooChild", flags), "#M10");
		Assert.IsNotNull (type.GetField ("publicInstanceFooChild", flags), "#M11");
		Assert.IsNotNull (type.GetField ("assemblyInstanceFooChild", flags), "#M12");
		Assert.IsNotNull (type.GetField ("privateInstanceBarChild", flags), "#M13");
		Assert.IsNotNull (type.GetField ("familyInstanceBarChild", flags), "#M14");
		Assert.IsNotNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#M15");
		Assert.IsNotNull (type.GetField ("famORAssemInstanceBarChild", flags), "#M16");
		Assert.IsNotNull (type.GetField ("publicInstanceBarChild", flags), "#M17");
		Assert.IsNotNull (type.GetField ("assemblyInstanceBarChild", flags), "#M18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#M19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#M20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#M21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#M22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#M23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#M24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#M25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#M26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#M27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#M28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#M29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#M30");
		Assert.IsNull (type.GetField ("privateStaticBarChild", flags), "#M31");
		Assert.IsNull (type.GetField ("familyStaticBarChild", flags), "#M32");
		Assert.IsNull (type.GetField ("famANDAssemStaticBarChild", flags), "#M33");
		Assert.IsNull (type.GetField ("famORAssemStaticBarChild", flags), "#M34");
		Assert.IsNull (type.GetField ("publicStaticBarChild", flags), "#M35");
		Assert.IsNull (type.GetField ("assemblyStaticBarChild", flags), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetField ("privateInstanceBlueChild", flags), "#N1");
		Assert.IsNull (type.GetField ("familyInstanceBlueChild", flags), "#N2");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBlueChild", flags), "#N3");
		Assert.IsNull (type.GetField ("famORAssemInstanceBlueChild", flags), "#N4");
		Assert.IsNull (type.GetField ("publicInstanceBlueChild", flags), "#N5");
		Assert.IsNull (type.GetField ("assemblyInstanceBlueChild", flags), "#N6");
		Assert.IsNull (type.GetField ("privateInstanceFooChild", flags), "#N7");
		Assert.IsNull (type.GetField ("familyInstanceFooChild", flags), "#N8");
		Assert.IsNull (type.GetField ("famANDAssemInstanceFooChild", flags), "#N9");
		Assert.IsNull (type.GetField ("famORAssemInstanceFooChild", flags), "#N10");
		Assert.IsNull (type.GetField ("publicInstanceFooChild", flags), "#N11");
		Assert.IsNull (type.GetField ("assemblyInstanceFooChild", flags), "#N12");
		Assert.IsNull (type.GetField ("privateInstanceBarChild", flags), "#N13");
		Assert.IsNull (type.GetField ("familyInstanceBarChild", flags), "#N14");
		Assert.IsNull (type.GetField ("famANDAssemInstanceBarChild", flags), "#N15");
		Assert.IsNull (type.GetField ("famORAssemInstanceBarChild", flags), "#N16");
		Assert.IsNull (type.GetField ("publicInstanceBarChild", flags), "#N17");
		Assert.IsNull (type.GetField ("assemblyInstanceBarChild", flags), "#N18");
		Assert.IsNull (type.GetField ("privateStaticBlueChild", flags), "#N19");
		Assert.IsNull (type.GetField ("familyStaticBlueChild", flags), "#N20");
		Assert.IsNull (type.GetField ("famANDAssemStaticBlueChild", flags), "#N21");
		Assert.IsNull (type.GetField ("famORAssemStaticBlueChild", flags), "#N22");
		Assert.IsNull (type.GetField ("publicStaticBlueChild", flags), "#N23");
		Assert.IsNull (type.GetField ("assemblyStaticBlueChild", flags), "#N24");
		Assert.IsNull (type.GetField ("privateStaticFooChild", flags), "#N25");
		Assert.IsNull (type.GetField ("familyStaticFooChild", flags), "#N26");
		Assert.IsNull (type.GetField ("famANDAssemStaticFooChild", flags), "#N27");
		Assert.IsNull (type.GetField ("famORAssemStaticFooChild", flags), "#N28");
		Assert.IsNull (type.GetField ("publicStaticFooChild", flags), "#N29");
		Assert.IsNull (type.GetField ("assemblyStaticFooChild", flags), "#N30");
		Assert.IsNotNull (type.GetField ("privateStaticBarChild", flags), "#N31");
		Assert.IsNotNull (type.GetField ("familyStaticBarChild", flags), "#N32");
		Assert.IsNotNull (type.GetField ("famANDAssemStaticBarChild", flags), "#N33");
		Assert.IsNotNull (type.GetField ("famORAssemStaticBarChild", flags), "#N34");
		Assert.IsNotNull (type.GetField ("publicStaticBarChild", flags), "#N35");
		Assert.IsNotNull (type.GetField ("assemblyStaticBarChild", flags), "#N36");
	}

	static void GetConstructorsTest (Type type, bool fromIL)
	{
		BindingFlags flags;
		ConstructorInfo [] ctors;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (5, ctors.Length, "#A1");
		Assert.IsFalse (ctors [0].IsAssembly, "#A2:" + type.FullName);
		Assert.IsFalse (ctors [0].IsFamily, "#A3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#A4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#A5");
		Assert.IsTrue (ctors [0].IsPrivate, "#A6");
		Assert.IsFalse (ctors [0].IsPublic, "#A7");
		Assert.IsFalse (ctors [0].IsStatic, "#A8");
		Assert.IsFalse (ctors [1].IsAssembly, "#A9");
		Assert.IsTrue (ctors [1].IsFamily, "#A10");
		Assert.IsFalse (ctors [1].IsFamilyAndAssembly, "#A11");
		Assert.IsFalse (ctors [1].IsFamilyOrAssembly, "#A12");
		Assert.IsFalse (ctors [1].IsPrivate, "#A13");
		Assert.IsFalse (ctors [1].IsPublic, "#A14");
		Assert.IsFalse (ctors [1].IsStatic, "#A15");
		Assert.IsFalse (ctors [2].IsAssembly, "#A16");
		Assert.IsFalse (ctors [2].IsFamily, "#A17");
		if (fromIL) {
			Assert.IsTrue (ctors [2].IsFamilyAndAssembly, "#A18");
			Assert.IsFalse (ctors [2].IsFamilyOrAssembly, "#A19");
		} else {
			Assert.IsFalse (ctors [2].IsFamilyAndAssembly, "#A18");
			Assert.IsTrue (ctors [2].IsFamilyOrAssembly, "#A19");
		}
		Assert.IsFalse (ctors [2].IsPrivate, "#A20");
		Assert.IsFalse (ctors [2].IsPublic, "#A21");
		Assert.IsFalse (ctors [2].IsStatic, "#A22");
		Assert.IsFalse (ctors [3].IsAssembly, "#A23");
		Assert.IsFalse (ctors [3].IsFamily, "#A24");
		Assert.IsFalse (ctors [3].IsFamilyAndAssembly, "#A25");
		Assert.IsTrue (ctors [3].IsFamilyOrAssembly, "#A26");
		Assert.IsFalse (ctors [3].IsPrivate, "#A27");
		Assert.IsFalse (ctors [3].IsPublic, "#A28");
		Assert.IsFalse (ctors [3].IsStatic, "#A29");
		Assert.IsTrue (ctors [4].IsAssembly, "#A30");
		Assert.IsFalse (ctors [4].IsFamily, "#A31");
		Assert.IsFalse (ctors [4].IsFamilyAndAssembly, "#A32");
		Assert.IsFalse (ctors [4].IsFamilyOrAssembly, "#A33");
		Assert.IsFalse (ctors [4].IsPrivate, "#A34");
		Assert.IsFalse (ctors [4].IsPublic, "#A35");
		Assert.IsFalse (ctors [4].IsStatic, "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#B1");
		Assert.IsFalse (ctors [0].IsAssembly, "#B2");
		Assert.IsFalse (ctors [0].IsFamily, "#B3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#B4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#B5");
		Assert.IsFalse (ctors [0].IsPrivate, "#B6");
		Assert.IsTrue (ctors [0].IsPublic, "#B7");
		Assert.IsFalse (ctors [0].IsStatic, "#B8");

		flags = BindingFlags.Static | BindingFlags.Public;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (0, ctors.Length, "#C1");

		flags = BindingFlags.Static | BindingFlags.NonPublic;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#D1");
		Assert.IsFalse (ctors [0].IsAssembly, "#D2");
		Assert.IsFalse (ctors [0].IsFamily, "#D3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#D4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#D5");
		Assert.IsTrue (ctors [0].IsPrivate, "#D6");
		Assert.IsFalse (ctors [0].IsPublic, "#D7");
		Assert.IsTrue (ctors [0].IsStatic, "#D8");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (5, ctors.Length, "#E1");
		Assert.IsFalse (ctors [0].IsAssembly, "#E2");
		Assert.IsFalse (ctors [0].IsFamily, "#E3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#E4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#E5");
		Assert.IsTrue (ctors [0].IsPrivate, "#E6");
		Assert.IsFalse (ctors [0].IsPublic, "#E7");
		Assert.IsFalse (ctors [0].IsStatic, "#E8");
		Assert.IsFalse (ctors [1].IsAssembly, "#E9");
		Assert.IsTrue (ctors [1].IsFamily, "#E10");
		Assert.IsFalse (ctors [1].IsFamilyAndAssembly, "#E11");
		Assert.IsFalse (ctors [1].IsFamilyOrAssembly, "#E12");
		Assert.IsFalse (ctors [1].IsPrivate, "#E13");
		Assert.IsFalse (ctors [1].IsPublic, "#E14");
		Assert.IsFalse (ctors [1].IsStatic, "#E15");
		Assert.IsFalse (ctors [2].IsAssembly, "#E16");
		Assert.IsFalse (ctors [2].IsFamily, "#E17");
		if (fromIL) {
			Assert.IsTrue (ctors [2].IsFamilyAndAssembly, "#E18");
			Assert.IsFalse (ctors [2].IsFamilyOrAssembly, "#E19");
		} else {
			Assert.IsFalse (ctors [2].IsFamilyAndAssembly, "#E18");
			Assert.IsTrue (ctors [2].IsFamilyOrAssembly, "#E19");
		}
		Assert.IsFalse (ctors [2].IsPrivate, "#E20");
		Assert.IsFalse (ctors [2].IsPublic, "#E21");
		Assert.IsFalse (ctors [2].IsStatic, "#E22");
		Assert.IsFalse (ctors [3].IsAssembly, "#E23");
		Assert.IsFalse (ctors [3].IsFamily, "#E24");
		Assert.IsFalse (ctors [3].IsFamilyAndAssembly, "#E25");
		Assert.IsTrue (ctors [3].IsFamilyOrAssembly, "#E26");
		Assert.IsFalse (ctors [3].IsPrivate, "#E27");
		Assert.IsFalse (ctors [3].IsPublic, "#E28");
		Assert.IsFalse (ctors [3].IsStatic, "#E29");
		Assert.IsTrue (ctors [4].IsAssembly, "#E30");
		Assert.IsFalse (ctors [4].IsFamily, "#E31");
		Assert.IsFalse (ctors [4].IsFamilyAndAssembly, "#E32");
		Assert.IsFalse (ctors [4].IsFamilyOrAssembly, "#E33");
		Assert.IsFalse (ctors [4].IsPrivate, "#E34");
		Assert.IsFalse (ctors [4].IsPublic, "#E35");
		Assert.IsFalse (ctors [4].IsStatic, "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#F1");
		Assert.IsFalse (ctors [0].IsAssembly, "#F2");
		Assert.IsFalse (ctors [0].IsFamily, "#F3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#F4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#F5");
		Assert.IsFalse (ctors [0].IsPrivate, "#F6");
		Assert.IsTrue (ctors [0].IsPublic, "#F7");
		Assert.IsFalse (ctors [0].IsStatic, "#F8");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (0, ctors.Length, "#G1");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#H1");
		Assert.IsFalse (ctors [0].IsAssembly, "#H2");
		Assert.IsFalse (ctors [0].IsFamily, "#H3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#H4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#H5");
		Assert.IsTrue (ctors [0].IsPrivate, "#H6");
		Assert.IsFalse (ctors [0].IsPublic, "#H7");
		Assert.IsTrue (ctors [0].IsStatic, "#H8");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (5, ctors.Length, "#I1");
		Assert.IsFalse (ctors [0].IsAssembly, "#I2");
		Assert.IsFalse (ctors [0].IsFamily, "#I3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#I4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#I5");
		Assert.IsTrue (ctors [0].IsPrivate, "#I6");
		Assert.IsFalse (ctors [0].IsPublic, "#I7");
		Assert.IsFalse (ctors [0].IsStatic, "#I8");
		Assert.IsFalse (ctors [1].IsAssembly, "#I9");
		Assert.IsTrue (ctors [1].IsFamily, "#I10");
		Assert.IsFalse (ctors [1].IsFamilyAndAssembly, "#I11");
		Assert.IsFalse (ctors [1].IsFamilyOrAssembly, "#I12");
		Assert.IsFalse (ctors [1].IsPrivate, "#I13");
		Assert.IsFalse (ctors [1].IsPublic, "#I14");
		Assert.IsFalse (ctors [1].IsStatic, "#I15");
		Assert.IsFalse (ctors [2].IsAssembly, "#I16");
		Assert.IsFalse (ctors [2].IsFamily, "#I17");
		if (fromIL) {
			Assert.IsTrue (ctors [2].IsFamilyAndAssembly, "#I18");
			Assert.IsFalse (ctors [2].IsFamilyOrAssembly, "#I19");
		} else {
			Assert.IsFalse (ctors [2].IsFamilyAndAssembly, "#I18");
			Assert.IsTrue (ctors [2].IsFamilyOrAssembly, "#I19");
		}
		Assert.IsFalse (ctors [2].IsPrivate, "#I20");
		Assert.IsFalse (ctors [2].IsPublic, "#I21");
		Assert.IsFalse (ctors [2].IsStatic, "#I22");
		Assert.IsFalse (ctors [3].IsAssembly, "#I23");
		Assert.IsFalse (ctors [3].IsFamily, "#I24");
		Assert.IsFalse (ctors [3].IsFamilyAndAssembly, "#I25");
		Assert.IsTrue (ctors [3].IsFamilyOrAssembly, "#I26");
		Assert.IsFalse (ctors [3].IsPrivate, "#I27");
		Assert.IsFalse (ctors [3].IsPublic, "#I28");
		Assert.IsFalse (ctors [3].IsStatic, "#I29");
		Assert.IsTrue (ctors [4].IsAssembly, "#I30");
		Assert.IsFalse (ctors [4].IsFamily, "#I31");
		Assert.IsFalse (ctors [4].IsFamilyAndAssembly, "#I32");
		Assert.IsFalse (ctors [4].IsFamilyOrAssembly, "#I33");
		Assert.IsFalse (ctors [4].IsPrivate, "#I34");
		Assert.IsFalse (ctors [4].IsPublic, "#I35");
		Assert.IsFalse (ctors [4].IsStatic, "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#J1");
		Assert.IsFalse (ctors [0].IsAssembly, "#J2");
		Assert.IsFalse (ctors [0].IsFamily, "#J3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#J4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#J5");
		Assert.IsFalse (ctors [0].IsPrivate, "#J6");
		Assert.IsTrue (ctors [0].IsPublic, "#J7");
		Assert.IsFalse (ctors [0].IsStatic, "#J8");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (0, ctors.Length, "#K1");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#L1");
		Assert.IsFalse (ctors [0].IsAssembly, "#L2");
		Assert.IsFalse (ctors [0].IsFamily, "#L3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#L4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#L5");
		Assert.IsTrue (ctors [0].IsPrivate, "#L6");
		Assert.IsFalse (ctors [0].IsPublic, "#L7");
		Assert.IsTrue (ctors [0].IsStatic, "#L8");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (6, ctors.Length, "#M1");
		Assert.IsFalse (ctors [0].IsAssembly, "#M2");
		Assert.IsFalse (ctors [0].IsFamily, "#M3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#M4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#M5");
		Assert.IsTrue (ctors [0].IsPrivate, "#M6");
		Assert.IsFalse (ctors [0].IsPublic, "#M7");
		Assert.IsFalse (ctors [0].IsStatic, "#M8");
		Assert.IsFalse (ctors [1].IsAssembly, "#M9");
		Assert.IsTrue (ctors [1].IsFamily, "#M10");
		Assert.IsFalse (ctors [1].IsFamilyAndAssembly, "#M11");
		Assert.IsFalse (ctors [1].IsFamilyOrAssembly, "#M12");
		Assert.IsFalse (ctors [1].IsPrivate, "#M13");
		Assert.IsFalse (ctors [1].IsPublic, "#M14");
		Assert.IsFalse (ctors [1].IsStatic, "#M15");
		Assert.IsFalse (ctors [2].IsAssembly, "#M16");
		Assert.IsFalse (ctors [2].IsFamily, "#M17");
		if (fromIL) {
			Assert.IsTrue (ctors [2].IsFamilyAndAssembly, "#M18");
			Assert.IsFalse (ctors [2].IsFamilyOrAssembly, "#M19");
		} else {
			Assert.IsFalse (ctors [2].IsFamilyAndAssembly, "#M18");
			Assert.IsTrue (ctors [2].IsFamilyOrAssembly, "#M19");
		}
		Assert.IsFalse (ctors [2].IsPrivate, "#M20");
		Assert.IsFalse (ctors [2].IsPublic, "#M21");
		Assert.IsFalse (ctors [2].IsStatic, "#M22");
		Assert.IsFalse (ctors [3].IsAssembly, "#M23");
		Assert.IsFalse (ctors [3].IsFamily, "#M24");
		Assert.IsFalse (ctors [3].IsFamilyAndAssembly, "#M25");
		Assert.IsTrue (ctors [3].IsFamilyOrAssembly, "#M26");
		Assert.IsFalse (ctors [3].IsPrivate, "#M27");
		Assert.IsFalse (ctors [3].IsPublic, "#M28");
		Assert.IsFalse (ctors [3].IsStatic, "#M29");
		Assert.IsFalse (ctors [4].IsAssembly, "#M30");
		Assert.IsFalse (ctors [4].IsFamily, "#M31");
		Assert.IsFalse (ctors [4].IsFamilyAndAssembly, "#M32");
		Assert.IsFalse (ctors [4].IsFamilyOrAssembly, "#M33");
		Assert.IsFalse (ctors [4].IsPrivate, "#M34");
		Assert.IsTrue (ctors [4].IsPublic, "#M35");
		Assert.IsFalse (ctors [4].IsStatic, "#M36");
		Assert.IsTrue (ctors [5].IsAssembly, "#M37");
		Assert.IsFalse (ctors [5].IsFamily, "#M38");
		Assert.IsFalse (ctors [5].IsFamilyAndAssembly, "#M39");
		Assert.IsFalse (ctors [5].IsFamilyOrAssembly, "#M40");
		Assert.IsFalse (ctors [5].IsPrivate, "#M41");
		Assert.IsFalse (ctors [5].IsPublic, "#M42");
		Assert.IsFalse (ctors [5].IsStatic, "#M43");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#N1");
		Assert.IsFalse (ctors [0].IsAssembly, "#N2");
		Assert.IsFalse (ctors [0].IsFamily, "#N3");
		Assert.IsFalse (ctors [0].IsFamilyAndAssembly, "#N4");
		Assert.IsFalse (ctors [0].IsFamilyOrAssembly, "#N5");
		Assert.IsTrue (ctors [0].IsPrivate, "#N6");
		Assert.IsFalse (ctors [0].IsPublic, "#N7");
		Assert.IsTrue (ctors [0].IsStatic, "#N8");
	}

#if MONO
	static void GetConstructorsILTest (Type type)
	{
		BindingFlags flags;
		ConstructorInfo [] ctors;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (5, ctors.Length, "#A1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Private, false, "#A2"), "#A2");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Family, false, "#A3"), "#A3");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.FamANDAssem, false, "#A4"), "#A4");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.FamORAssem, false, "#A5"), "#A5");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Assembly, false, "#A6"), "#A6");

		flags = BindingFlags.Instance | BindingFlags.Public;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#B1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Public, false, "#B2"), "#B2");

		flags = BindingFlags.Static | BindingFlags.Public;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (0, ctors.Length, "#C1");

		flags = BindingFlags.Static | BindingFlags.NonPublic;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#D1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Private, true, "#D2"), "#D2");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (5, ctors.Length, "#E1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Private, false, "#E2"), "#E2");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Family, false, "#E3"), "#E3");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.FamANDAssem, false, "#E4"), "#E4");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.FamORAssem, false, "#E5"), "#E5");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Assembly, false, "#E6"), "#E6");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#F1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Public, false, "#F2"), "#F2");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (0, ctors.Length, "#G1");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#H1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Private, true, "#H2"), "#H2");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (5, ctors.Length, "#I1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Private, false, "#I2"), "#I2");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Family, false, "#I3"), "#I3");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.FamANDAssem, false, "#I4"), "#I4");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.FamORAssem, false, "#I5"), "#I5");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Assembly, false, "#I6"), "#I6");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#J1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Public, false, "#J2"), "#J2");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (0, ctors.Length, "#K1");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#L1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Private, true, "#L2"), "#L2");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (6, ctors.Length, "#M1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Private, false, "#M2"), "#M2");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Family, false, "#M3"), "#M3");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.FamANDAssem, false, "#M4"), "#M4");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.FamORAssem, false, "#M5"), "#M5");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Assembly, false, "#M6"), "#M6");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Public, false, "#M7"), "#M7");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;
		ctors = type.GetConstructors (flags);

		Assert.AreEqual (1, ctors.Length, "#N1");
		Assert.IsTrue (ContainsConstructor (ctors, MethodAttributes.Private, true, "#N2"), "#N2");
	}

	static bool ContainsConstructor (ConstructorInfo [] ctors, MethodAttributes access, bool isStatic, string msg)
	{
		foreach (ConstructorInfo c in ctors) {
			if ((c.Attributes & MethodAttributes.MemberAccessMask) != access)
				continue;

			if (c.IsStatic != isStatic)
				continue;

			bool isAssembly = (access == MethodAttributes.Assembly);
			bool IsFamily = (access == MethodAttributes.Family);
			bool isFamilyAndAssembly = (access == MethodAttributes.FamANDAssem);
			bool isFamilyOrAssembly = (access == MethodAttributes.FamORAssem);
			bool isPrivate = (access == MethodAttributes.Private);
			bool isPublic = (access == MethodAttributes.Public);

			Assert.AreEqual (isAssembly, c.IsAssembly, msg + "1");
			Assert.AreEqual (IsFamily, c.IsFamily, msg + "2");
			Assert.AreEqual (isFamilyAndAssembly, c.IsFamilyAndAssembly, msg + "3");
			Assert.AreEqual (isFamilyOrAssembly, c.IsFamilyOrAssembly, msg + "4");
			Assert.AreEqual (isPrivate, c.IsPrivate, msg + "5");
			Assert.AreEqual (isPublic, c.IsPublic, msg + "6");

			return true;
		}

		return false;
	}
#endif

	static bool ContainsMethod (MethodInfo [] methods, string name)
	{
		foreach (MethodInfo m in methods)
			if (m.Name == name)
				return true;
		return false;
	}

	static bool ContainsField (FieldInfo [] fields, string name)
	{
		foreach (FieldInfo f in fields)
			if (f.Name == name)
				return true;
		return false;
	}
}

public class Blue
{
	public class Child
	{
		private Child (int x, int y)
		{
		}

		protected Child (string x)
		{
		}

		protected internal Child (string x, string y)
		{
		}

		protected internal Child (int x)
		{
		}

		public Child ()
		{
		}

		internal Child (string x, int y)
		{
		}

		static Child ()
		{
		}

		private string GetPrivateInstanceBlueChild ()
		{
			return privateInstanceBlueChild;
		}

		protected string GetFamilyInstanceBlueChild ()
		{
			return familyInstanceBlueChild;
		}

		protected internal string GetFamANDAssemInstanceBlueChild ()
		{
			return famANDAssemInstanceBlueChild;
		}

		protected internal string GetFamORAssemInstanceBlueChild ()
		{
			return GetPrivateInstanceBlueChild ();
		}

		public string GetPublicInstanceBlueChild ()
		{
			return publicInstanceBlueChild;
		}

		internal string GetAssemblyInstanceBlueChild ()
		{
			return assemblyInstanceBlueChild;
		}

		private static string GetPrivateStaticBlueChild ()
		{
			return privateStaticBlueChild;
		}

		protected static string GetFamilyStaticBlueChild ()
		{
			return familyStaticBlueChild;
		}

		protected static internal string GetFamANDAssemStaticBlueChild ()
		{
			return GetPrivateStaticBlueChild ();
		}

		protected static internal string GetFamORAssemStaticBlueChild ()
		{
			return null;
		}

		public static string GetPublicStaticBlueChild ()
		{
			return null;
		}

		internal static string GetAssemblyStaticBlueChild ()
		{
			return null;
		}

		private string privateInstanceBlueChild = null;
		protected string familyInstanceBlueChild;
		protected internal string famANDAssemInstanceBlueChild;
		protected internal string famORAssemInstanceBlueChild;
		public string publicInstanceBlueChild;
		internal string assemblyInstanceBlueChild = null;

		private static string privateStaticBlueChild = null;
		protected static string familyStaticBlueChild;
		protected static internal string famANDAssemStaticBlueChild;
		protected static internal string famORAssemStaticBlueChild;
		public static string publicStaticBlueChild;
		internal static string assemblyStaticBlueChild = null;
	}

	private Blue (int x, int y)
	{
	}

	protected Blue (string x)
	{
	}

	protected internal Blue (string x, string y)
	{
	}

	protected internal Blue (int x)
	{
	}

	public Blue ()
	{
	}

	internal Blue (string x, int y)
	{
	}

	static Blue ()
	{
	}

	private string GetPrivateInstanceBlue ()
	{
		return privateInstanceBlue;
	}

	protected string GetFamilyInstanceBlue ()
	{
		return familyInstanceBlue;
	}

	protected internal string GetFamANDAssemInstanceBlue ()
	{
		return famANDAssemInstanceBlue;
	}

	protected internal string GetFamORAssemInstanceBlue ()
	{
		return GetPrivateInstanceBlue ();
	}

	public string GetPublicInstanceBlue ()
	{
		return null;
	}

	internal string GetAssemblyInstanceBlue ()
	{
		return null;
	}

	private static string GetPrivateStaticBlue ()
	{
		return privateStaticBlue;
	}

	protected static string GetFamilyStaticBlue ()
	{
		return GetPrivateStaticBlue ();
	}

	protected static internal string GetFamANDAssemStaticBlue ()
	{
		return null;
	}

	protected static internal string GetFamORAssemStaticBlue ()
	{
		return null;
	}

	public static string GetPublicStaticBlue ()
	{
		return null;
	}

	internal static string GetAssemblyStaticBlue ()
	{
		return null;
	}

	private string privateInstanceBlue = null;
	protected string familyInstanceBlue = null;
	protected internal string famANDAssemInstanceBlue = null;
	protected internal string famORAssemInstanceBlue = null;
	public string publicInstanceBlue = null;
	internal string assemblyInstanceBlue = null;

	private static string privateStaticBlue = null;
	protected static string familyStaticBlue = null;
	protected static internal string famANDAssemStaticBlue = null;
	protected static internal string famORAssemStaticBlue = null;
	public static string publicStaticBlue = null;
	internal static string assemblyStaticBlue = null;
}

public class Foo : Blue
{
	public new class Child : Blue.Child
	{
		private Child (int x, int y)
		{
		}

		protected Child (string x)
		{
		}

		protected internal Child (string x, string y)
		{
		}

		protected internal Child (int x)
		{
		}

		public Child ()
		{
		}

		internal Child (string x, int y)
		{
		}

		static Child ()
		{
		}

		private string GetPrivateInstanceFooChild ()
		{
			return privateInstanceFooChild;
		}

		protected string GetFamilyInstanceFooChild ()
		{
			return familyInstanceFooChild;
		}

		protected internal string GetFamANDAssemInstanceFooChild ()
		{
			return famANDAssemInstanceFooChild;
		}

		protected internal string GetFamORAssemInstanceFooChild ()
		{
			return famORAssemInstanceFooChild;
		}

		public string GetPublicInstanceFooChild ()
		{
			return GetPrivateInstanceFooChild ();
		}

		internal string GetAssemblyInstanceFooChild ()
		{
			return assemblyInstanceFooChild;
		}

		private static string GetPrivateStaticFooChild ()
		{
			return privateStaticFooChild;
		}

		protected static string GetFamilyStaticFooChild ()
		{
			return GetPrivateStaticFooChild ();
		}

		protected static internal string GetFamANDAssemStaticFooChild ()
		{
			return null;
		}

		protected static internal string GetFamORAssemStaticFooChild ()
		{
			return null;
		}

		public static string GetPublicStaticFooChild ()
		{
			return null;
		}

		internal static string GetAssemblyStaticFooChild ()
		{
			return assemblyStaticFooChild;
		}

		private string privateInstanceFooChild = null;
		protected string familyInstanceFooChild;
		protected internal string famANDAssemInstanceFooChild;
		protected internal string famORAssemInstanceFooChild;
		public string publicInstanceFooChild;
		internal string assemblyInstanceFooChild = null;

		private static string privateStaticFooChild = null;
		protected static string familyStaticFooChild;
		protected static internal string famANDAssemStaticFooChild;
		protected static internal string famORAssemStaticFooChild;
		public static string publicStaticFooChild;
		internal static string assemblyStaticFooChild = null;
	}

	private Foo (int x, int y)
	{
	}

	protected Foo (string x)
	{
	}

	protected internal Foo (string x, string y)
	{
	}

	protected internal Foo (int x)
	{
	}

	public Foo ()
	{
	}

	internal Foo (string x, int y)
	{
	}

	static Foo ()
	{
	}

	private string GetPrivateInstanceFoo ()
	{
		return privateInstanceFoo;
	}

	protected string GetFamilyInstanceFoo ()
	{
		return familyInstanceFoo;
	}

	protected internal string GetFamANDAssemInstanceFoo ()
	{
		return GetPrivateInstanceFoo ();
	}

	protected internal string GetFamORAssemInstanceFoo ()
	{
		return null;
	}

	public string GetPublicInstanceFoo ()
	{
		return null;
	}

	internal string GetAssemblyInstanceFoo ()
	{
		return null;
	}

	private static string GetPrivateStaticFoo ()
	{
		return privateStaticFoo;
	}

	protected static string GetFamilyStaticFoo ()
	{
		return GetPrivateStaticFoo ();
	}

	protected static internal string GetFamANDAssemStaticFoo ()
	{
		return null;
	}

	protected static internal string GetFamORAssemStaticFoo ()
	{
		return null;
	}

	public static string GetPublicStaticFoo ()
	{
		return null;
	}

	internal static string GetAssemblyStaticFoo ()
	{
		return assemblyStaticFoo;
	}

	private string privateInstanceFoo = null;
	protected string familyInstanceFoo;
	protected internal string famANDAssemInstanceFoo;
	protected internal string famORAssemInstanceFoo;
	public string publicInstanceFoo;
	internal string assemblyInstanceFoo = null;

	private static string privateStaticFoo = null;
	protected static string familyStaticFoo;
	protected static internal string famANDAssemStaticFoo;
	protected static internal string famORAssemStaticFoo;
	public static string publicStaticFoo;
	internal static string assemblyStaticFoo = null;
}

public class Bar : Foo
{
	public new class Child : Foo.Child
	{
		private Child (int x, int y)
		{
		}

		protected Child (string x)
		{
		}

		protected internal Child (string x, string y)
		{
		}

		protected internal Child (int x)
		{
		}

		public Child ()
		{
		}

		internal Child (string x, int y)
		{
		}

		static Child ()
		{
		}

		private string GetPrivateInstanceBarChild ()
		{
			return privateInstanceBarChild;
		}

		protected string GetFamilyInstanceBarChild ()
		{
			return GetPrivateInstanceBarChild ();
		}

		protected internal string GetFamANDAssemInstanceBarChild ()
		{
			return null;
		}

		protected internal string GetFamORAssemInstanceBarChild ()
		{
			return null;
		}

		public string GetPublicInstanceBarChild ()
		{
			return null;
		}

		internal string GetAssemblyInstanceBarChild ()
		{
			return assemblyInstanceBarChild;
		}

		private static string GetPrivateStaticBarChild ()
		{
			return privateStaticBarChild;
		}

		protected static string GetFamilyStaticBarChild ()
		{
			return GetPrivateStaticBarChild ();
		}

		protected static internal string GetFamANDAssemStaticBarChild ()
		{
			return null;
		}

		protected static internal string GetFamORAssemStaticBarChild ()
		{
			return null;
		}

		public static string GetPublicStaticBarChild ()
		{
			return null;
		}

		internal static string GetAssemblyStaticBarChild ()
		{
			return assemblyStaticBarChild;
		}

		private string privateInstanceBarChild = null;
		protected string familyInstanceBarChild;
		protected internal string famANDAssemInstanceBarChild;
		protected internal string famORAssemInstanceBarChild;
		public string publicInstanceBarChild;
		internal string assemblyInstanceBarChild = null;

		private static string privateStaticBarChild = null;
		protected static string familyStaticBarChild;
		protected static internal string famANDAssemStaticBarChild;
		protected static internal string famORAssemStaticBarChild;
		public static string publicStaticBarChild;
		internal static string assemblyStaticBarChild = null;
	}

	private Bar (int x, int y)
	{
	}

	protected Bar (string x)
	{
	}

	protected internal Bar (string x, string y)
	{
	}

	protected internal Bar (int x)
	{
	}

	public Bar ()
	{
	}

	internal Bar (string x, int y)
	{
	}

	static Bar ()
	{
	}

	private string GetPrivateInstanceBar ()
	{
		return privateInstanceBar;
	}

	protected string GetFamilyInstanceBar ()
	{
		return GetPrivateInstanceBar ();
	}

	protected internal string GetFamANDAssemInstanceBar ()
	{
		return null;
	}

	protected internal string GetFamORAssemInstanceBar ()
	{
		return null;
	}

	public string GetPublicInstanceBar ()
	{
		return null;
	}

	internal string GetAssemblyInstanceBar ()
	{
		return assemblyInstanceBar;
	}

	private static string GetPrivateStaticBar ()
	{
		return privateStaticBar;
	}

	protected static string GetFamilyStaticBar ()
	{
		return GetPrivateStaticBar ();
	}

	protected static internal string GetFamANDAssemStaticBar ()
	{
		return null;
	}

	protected static internal string GetFamORAssemStaticBar ()
	{
		return null;
	}

	public static string GetPublicStaticBar ()
	{
		return null;
	}

	internal static string GetAssemblyStaticBar ()
	{
		return assemblyStaticBar;
	}

	private string privateInstanceBar = null;
	protected string familyInstanceBar;
	protected internal string famANDAssemInstanceBar;
	protected internal string famORAssemInstanceBar;
	public string publicInstanceBar;
	internal string assemblyInstanceBar = null;

	private static string privateStaticBar = null;
	protected static string familyStaticBar;
	protected static internal string famANDAssemStaticBar;
	protected static internal string famORAssemStaticBar;
	public static string publicStaticBar;
	internal static string assemblyStaticBar = null;
}

namespace libC
{
	public class Bar : libC.Foo
	{
		public new class Child : libC.Foo.Child
		{
			private Child (int x, int y)
			{
			}

			protected Child (string x)
			{
			}

			protected internal Child (string x, string y)
			{
			}

			protected internal Child (int x)
			{
			}

			public Child ()
			{
			}

			internal Child (string x, int y)
			{
			}

			static Child ()
			{
			}

			private string GetPrivateInstanceBarChild ()
			{
				return privateInstanceBarChild;
			}

			protected string GetFamilyInstanceBarChild ()
			{
				return GetPrivateInstanceBarChild ();
			}

			protected internal string GetFamANDAssemInstanceBarChild ()
			{
				return null;
			}

			protected internal string GetFamORAssemInstanceBarChild ()
			{
				return null;
			}

			public string GetPublicInstanceBarChild ()
			{
				return null;
			}

			internal string GetAssemblyInstanceBarChild ()
			{
				return assemblyInstanceBarChild;
			}

			private static string GetPrivateStaticBarChild ()
			{
				return privateStaticBarChild;
			}

			protected static string GetFamilyStaticBarChild ()
			{
				return GetPrivateStaticBarChild ();
			}

			protected static internal string GetFamANDAssemStaticBarChild ()
			{
				return null;
			}

			protected static internal string GetFamORAssemStaticBarChild ()
			{
				return null;
			}

			public static string GetPublicStaticBarChild ()
			{
				return null;
			}

			internal static string GetAssemblyStaticBarChild ()
			{
				return assemblyStaticBarChild;
			}

			private string privateInstanceBarChild = null;
			protected string familyInstanceBarChild;
			protected internal string famANDAssemInstanceBarChild;
			protected internal string famORAssemInstanceBarChild;
			public string publicInstanceBarChild;
			internal string assemblyInstanceBarChild = null;

			private static string privateStaticBarChild = null;
			protected static string familyStaticBarChild;
			protected static internal string famANDAssemStaticBarChild;
			protected static internal string famORAssemStaticBarChild;
			public static string publicStaticBarChild;
			internal static string assemblyStaticBarChild = null;
		}

		private Bar (int x, int y)
		{
		}

		protected Bar (string x)
		{
		}

		protected internal Bar (string x, string y)
		{
		}

		protected internal Bar (int x)
		{
		}

		public Bar ()
		{
		}

		internal Bar (string x, int y)
		{
		}

		static Bar ()
		{
		}

		private string GetPrivateInstanceBar ()
		{
			return privateInstanceBar;
		}

		protected string GetFamilyInstanceBar ()
		{
			return GetPrivateInstanceBar ();
		}

		protected internal string GetFamANDAssemInstanceBar ()
		{
			return null;
		}

		protected internal string GetFamORAssemInstanceBar ()
		{
			return null;
		}

		public string GetPublicInstanceBar ()
		{
			return null;
		}

		internal string GetAssemblyInstanceBar ()
		{
			return assemblyInstanceBar;
		}

		private static string GetPrivateStaticBar ()
		{
			return privateStaticBar;
		}

		protected static string GetFamilyStaticBar ()
		{
			return GetPrivateStaticBar ();
		}

		protected static internal string GetFamANDAssemStaticBar ()
		{
			return null;
		}

		protected static internal string GetFamORAssemStaticBar ()
		{
			return null;
		}

		public static string GetPublicStaticBar ()
		{
			return null;
		}

		internal static string GetAssemblyStaticBar ()
		{
			return assemblyStaticBar;
		}

		private string privateInstanceBar = null;
		protected string familyInstanceBar;
		protected internal string famANDAssemInstanceBar;
		protected internal string famORAssemInstanceBar;
		public string publicInstanceBar;
		internal string assemblyInstanceBar = null;

		private static string privateStaticBar = null;
		protected static string familyStaticBar;
		protected static internal string famANDAssemStaticBar;
		protected static internal string famORAssemStaticBar;
		public static string publicStaticBar;
		internal static string assemblyStaticBar = null;
	}
}
