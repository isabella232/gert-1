using System;
using System.Reflection;

class Program
{
	static void Main ()
	{
		GetPropertiesTest (typeof (Bar));
		GetPropertiesTest (typeof (libA.Bar));
		GetPropertiesTest (typeof (libB.Bar));
		GetPropertiesTest (typeof (libC.Bar));

		GetPropertiesNestedTest (typeof (Bar.Child));
		GetPropertiesNestedTest (typeof (libA.Bar.Child));
		GetPropertiesNestedTest (typeof (libB.Bar.Child));
		GetPropertiesNestedTest (typeof (libC.Bar.Child));

		GetPropertyTest (typeof (Bar));
		GetPropertyTest (typeof (libA.Bar));
		GetPropertyTest (typeof (libB.Bar));
		GetPropertyTest (typeof (libC.Bar));

		GetPropertyNestedTest (typeof (Bar.Child));
		GetPropertyNestedTest (typeof (libA.Bar.Child));
		GetPropertyNestedTest (typeof (libB.Bar.Child));
		GetPropertyNestedTest (typeof (libC.Bar.Child));
	}

	static void GetPropertiesTest (Type type)
	{
		PropertyInfo [] props;
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#A1");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBlue"), "#A2");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#A3");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBlue"), "#A4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#A5");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBlue"), "#A6");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#A6");
#endif
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#A7");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceFoo"), "#A8");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#A9");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceFoo"), "#A10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#A11");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceFoo"), "#A12");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#A12");
#endif
		Assert.IsTrue (ContainsProperty (props, "PrivateInstanceBar"), "#A13");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBar"), "#A14");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBar"), "#A15");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBar"), "#A16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBar"), "#A17");
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBar"), "#A18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#A19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#A20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#A21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#A22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#A23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#A24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#A25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#A26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#A27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#A28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#A29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#A30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBar"), "#A31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBar"), "#A32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBar"), "#A33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBar"), "#A34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBar"), "#A35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBar"), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#B1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#B2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#B3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#B4");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBlue"), "#B5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#B6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#B7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#B8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#B9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#B10");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceFoo"), "#B11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#B12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBar"), "#B13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBar"), "#B14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBar"), "#B15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBar"), "#B16");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBar"), "#B17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBar"), "#B18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#B19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#B20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#B21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#B22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#B23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#B24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#B25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#B26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#B27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#B28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#B29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#B30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBar"), "#B31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBar"), "#B32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBar"), "#B33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBar"), "#B34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBar"), "#B35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBar"), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#C1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#C2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#C3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#C4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#C5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#C6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#C7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#C8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#C9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#C10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#C11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#C12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBar"), "#C13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBar"), "#C14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBar"), "#C15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBar"), "#C16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBar"), "#C17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBar"), "#C18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#C19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#C20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#C21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#C22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#C23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#C24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#C25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#C26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#C27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#C28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#C29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#C30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBar"), "#C31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBar"), "#C32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBar"), "#C33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBar"), "#C34");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticBar"), "#C35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBar"), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#D1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#D2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#D3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#D4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#D5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#D6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#D7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#D8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#D9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#D10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#D11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#D12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBar"), "#D13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBar"), "#D14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBar"), "#D15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBar"), "#D16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBar"), "#D17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBar"), "#D18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#D19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#D20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#D21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#D22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#D23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#D24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#D25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#D26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#D27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#D28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#D29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#D30");
		Assert.IsTrue (ContainsProperty (props, "PrivateStaticBar"), "#D31");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticBar"), "#D32");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticBar"), "#D33");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticBar"), "#D34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBar"), "#D35");
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticBar"), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#E1");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBlue"), "#E2");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#E3");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBlue"), "#E4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#E5");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBlue"), "#E6");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#E6");
#endif
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#E7");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceFoo"), "#E8");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#E9");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceFoo"), "#E10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#E11");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceFoo"), "#E12");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#E12");
#endif
		Assert.IsTrue (ContainsProperty (props, "PrivateInstanceBar"), "#E13");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBar"), "#E14");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBar"), "#E15");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBar"), "#E16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBar"), "#E17");
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBar"), "#E18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#E19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#E20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#E21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#E22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#E23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#E24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#E25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#E26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#E27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#E28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#E29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#E30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBar"), "#E31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBar"), "#E32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBar"), "#E33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBar"), "#E34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBar"), "#E35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBar"), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#F1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#F2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#F3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#F4");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBlue"), "#F5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#F6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#F7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#F8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#F9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#F10");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceFoo"), "#F11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#F12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBar"), "#F13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBar"), "#F14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBar"), "#F15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBar"), "#F16");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBar"), "#F17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBar"), "#F18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#F19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#F20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#F21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#F22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#F23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#F24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#F25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#F26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#F27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#F28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#F29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#F30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBar"), "#F31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBar"), "#F32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBar"), "#F33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBar"), "#F34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBar"), "#F35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBar"), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#G1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#G2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#G3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#G4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#G5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#G6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#G7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#G8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#G9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#G10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#G11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#G12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBar"), "#G13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBar"), "#G14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBar"), "#G15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBar"), "#G16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBar"), "#G17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBar"), "#G18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#G19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#G20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#G21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#G22");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticBlue"), "#G23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#G24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#G25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#G26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#G27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#G28");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticFoo"), "#G29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#G30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBar"), "#G31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBar"), "#G32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBar"), "#G33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBar"), "#G34");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticBar"), "#G35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBar"), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#H1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#H2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#H3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#H4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#H5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#H6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#H7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#H8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#H9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#H10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#H11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#H12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBar"), "#H13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBar"), "#H14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBar"), "#H15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBar"), "#H16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBar"), "#H17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBar"), "#H18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#H19");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticBlue"), "#H20");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticBlue"), "#H21");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticBlue"), "#H22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#H23");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticBlue"), "#H24");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#H24");
#endif
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#H25");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticFoo"), "#H26");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticFoo"), "#H27");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticFoo"), "#H28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#H29");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticFoo"), "#H30");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#H30");
#endif
		Assert.IsTrue (ContainsProperty (props, "PrivateStaticBar"), "#H31");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticBar"), "#H32");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticBar"), "#H33");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticBar"), "#H34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBar"), "#H35");
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticBar"), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#I1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#I2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#I3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#I4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#I5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#I6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#I7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#I8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#I9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#I10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#I11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#I12");
		Assert.IsTrue (ContainsProperty (props, "PrivateInstanceBar"), "#I13");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBar"), "#I14");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBar"), "#I15");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBar"), "#I16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBar"), "#I17");
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBar"), "#I18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#I19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#I20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#I21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#I22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#I23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#I24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#I25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#I26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#I27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#I28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#I29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#I30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBar"), "#I31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBar"), "#I32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBar"), "#I33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBar"), "#I34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBar"), "#I35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBar"), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#J1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#J2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#J3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#J4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#J5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#J6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#J7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#J8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#J9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#J10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#J11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#J12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBar"), "#J13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBar"), "#J14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBar"), "#J15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBar"), "#J16");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBar"), "#J17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBar"), "#J18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#J19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#J20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#J21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#J22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#J23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#J24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#J25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#J26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#J27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#J28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#J29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#J30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBar"), "#J31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBar"), "#J32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBar"), "#J33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBar"), "#J34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBar"), "#J35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBar"), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#K1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#K2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#K3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#K4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#K5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#K6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#K7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#K8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#K9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#K10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#K11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#K12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBar"), "#K13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBar"), "#K14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBar"), "#K15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBar"), "#K16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBar"), "#K17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBar"), "#K18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#K19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#K20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#K21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#K22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#K23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#K24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#K25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#K26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#K27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#K28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#K29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#K30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBar"), "#K31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBar"), "#K32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBar"), "#K33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBar"), "#K34");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticBar"), "#K35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBar"), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#L1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#L2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#L3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#L4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#L5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#L6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#L7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#L8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#L9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#L10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#L11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#L12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBar"), "#L13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBar"), "#L14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBar"), "#L15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBar"), "#L16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBar"), "#L17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBar"), "#L18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#L19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#L20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#L21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#L22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#L23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#L24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#L25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#L26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#L27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#L28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#L29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#L30");
		Assert.IsTrue (ContainsProperty (props, "PrivateStaticBar"), "#L31");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticBar"), "#L32");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticBar"), "#L33");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticBar"), "#L34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBar"), "#L35");
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticBar"), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#M1");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBlue"), "#M2");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#M3");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBlue"), "#M4");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBlue"), "#M5");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBlue"), "#M6");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#M6");
#endif
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#M7");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceFoo"), "#M8");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#M9");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceFoo"), "#M10");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceFoo"), "#M11");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceFoo"), "#M12");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#M12");
#endif
		Assert.IsTrue (ContainsProperty (props, "PrivateInstanceBar"), "#M13");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBar"), "#M14");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBar"), "#M15");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBar"), "#M16");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBar"), "#M17");
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBar"), "#M18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#M19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#M20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#M21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#M22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#M23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#M24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#M25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#M26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#M27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#M28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#M29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#M30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBar"), "#M31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBar"), "#M32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBar"), "#M33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBar"), "#M34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBar"), "#M35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBar"), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlue"), "#N1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlue"), "#N2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlue"), "#N3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlue"), "#N4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlue"), "#N5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlue"), "#N6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFoo"), "#N7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFoo"), "#N8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFoo"), "#N9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFoo"), "#N10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFoo"), "#N11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFoo"), "#N12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBar"), "#N13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBar"), "#N14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBar"), "#N15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBar"), "#N16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBar"), "#N17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBar"), "#N18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlue"), "#N19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlue"), "#N20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlue"), "#N21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlue"), "#N22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlue"), "#N23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlue"), "#N24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFoo"), "#N25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFoo"), "#N26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFoo"), "#N27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFoo"), "#N28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFoo"), "#N29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFoo"), "#N30");
		Assert.IsTrue (ContainsProperty (props, "PrivateStaticBar"), "#N31");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticBar"), "#N32");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticBar"), "#N33");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticBar"), "#N34");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticBar"), "#N35");
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticBar"), "#N36");
	}

	static void GetPropertiesNestedTest (Type type)
	{
		PropertyInfo [] props;
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#A1");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBlueChild"), "#A2");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#A3");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#A4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#A5");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#A6");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#A6");
#endif
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#A7");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceFooChild"), "#A8");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#A9");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#A10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#A11");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceFooChild"), "#A12");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#A12");
#endif
		Assert.IsTrue (ContainsProperty (props, "PrivateInstanceBarChild"), "#A13");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBarChild"), "#A14");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#A15");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#A16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBarChild"), "#A17");
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBarChild"), "#A18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#A19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#A20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#A21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#A22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#A23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#A24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#A25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#A26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#A27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#A28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#A29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#A30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBarChild"), "#A31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBarChild"), "#A32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#A33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBarChild"), "#A34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBarChild"), "#A35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBarChild"), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#B1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#B2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#B3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#B4");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBlueChild"), "#B5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#B6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#B7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#B8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#B9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#B10");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceFooChild"), "#B11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#B12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBarChild"), "#B13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBarChild"), "#B14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#B15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#B16");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBarChild"), "#B17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBarChild"), "#B18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#B19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#B20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#B21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#B22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#B23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#B24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#B25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#B26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#B27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#B28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#B29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#B30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBarChild"), "#B31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBarChild"), "#B32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#B33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBarChild"), "#B34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBarChild"), "#B35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBarChild"), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#C1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#C2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#C3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#C4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#C5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#C6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#C7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#C8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#C9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#C10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#C11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#C12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBarChild"), "#C13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBarChild"), "#C14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#C15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#C16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBarChild"), "#C17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBarChild"), "#C18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#C19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#C20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#C21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#C22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#C23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#C24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#C25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#C26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#C27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#C28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#C29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#C30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBarChild"), "#C31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBarChild"), "#C32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#C33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBarChild"), "#C34");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticBarChild"), "#C35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBarChild"), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#D1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#D2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#D3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#D4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#D5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#D6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#D7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#D8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#D9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#D10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#D11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#D12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBarChild"), "#D13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBarChild"), "#D14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#D15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#D16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBarChild"), "#D17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBarChild"), "#D18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#D19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#D20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#D21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#D22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#D23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#D24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#D25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#D26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#D27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#D28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#D29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#D30");
		Assert.IsTrue (ContainsProperty (props, "PrivateStaticBarChild"), "#D31");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticBarChild"), "#D32");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#D33");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticBarChild"), "#D34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBarChild"), "#D35");
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticBarChild"), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#E1");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBlueChild"), "#E2");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#E3");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#E4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#E5");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#E6");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#E6");
#endif
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#E7");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceFooChild"), "#E8");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#E9");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#E10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#E11");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceFooChild"), "#E12");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#E12");
#endif
		Assert.IsTrue (ContainsProperty (props, "PrivateInstanceBarChild"), "#E13");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBarChild"), "#E14");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#E15");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#E16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBarChild"), "#E17");
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBarChild"), "#E18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#E19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#E20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#E21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#E22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#E23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#E24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#E25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#E26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#E27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#E28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#E29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#E30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBarChild"), "#E31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBarChild"), "#E32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#E33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBarChild"), "#E34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBarChild"), "#E35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBarChild"), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#F1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#F2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#F3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#F4");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBlueChild"), "#F5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#F6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#F7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#F8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#F9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#F10");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceFooChild"), "#F11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#F12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBarChild"), "#F13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBarChild"), "#F14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#F15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#F16");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBarChild"), "#F17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBarChild"), "#F18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#F19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#F20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#F21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#F22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#F23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#F24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#F25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#F26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#F27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#F28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#F29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#F30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBarChild"), "#F31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBarChild"), "#F32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#F33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBarChild"), "#F34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBarChild"), "#F35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBarChild"), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#G1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#G2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#G3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#G4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#G5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#G6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#G7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#G8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#G9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#G10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#G11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#G12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBarChild"), "#G13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBarChild"), "#G14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#G15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#G16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBarChild"), "#G17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBarChild"), "#G18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#G19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#G20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#G21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#G22");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticBlueChild"), "#G23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#G24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#G25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#G26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#G27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#G28");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticFooChild"), "#G29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#G30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBarChild"), "#G31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBarChild"), "#G32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#G33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBarChild"), "#G34");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticBarChild"), "#G35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBarChild"), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#H1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#H2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#H3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#H4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#H5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#H6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#H7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#H8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#H9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#H10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#H11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#H12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBarChild"), "#H13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBarChild"), "#H14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#H15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#H16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBarChild"), "#H17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBarChild"), "#H18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#H19");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticBlueChild"), "#H20");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#H21");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#H22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#H23");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticBlueChild"), "#H24");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#H24");
#endif
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#H25");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticFooChild"), "#H26");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#H27");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticFooChild"), "#H28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#H29");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticFooChild"), "#H30");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#H30");
#endif
		Assert.IsTrue (ContainsProperty (props, "PrivateStaticBarChild"), "#H31");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticBarChild"), "#H32");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#H33");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticBarChild"), "#H34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBarChild"), "#H35");
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticBarChild"), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#I1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#I2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#I3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#I4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#I5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#I6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#I7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#I8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#I9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#I10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#I11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#I12");
		Assert.IsTrue (ContainsProperty (props, "PrivateInstanceBarChild"), "#I13");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBarChild"), "#I14");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#I15");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#I16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBarChild"), "#I17");
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBarChild"), "#I18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#I19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#I20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#I21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#I22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#I23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#I24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#I25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#I26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#I27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#I28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#I29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#I30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBarChild"), "#I31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBarChild"), "#I32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#I33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBarChild"), "#I34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBarChild"), "#I35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBarChild"), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#J1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#J2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#J3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#J4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#J5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#J6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#J7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#J8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#J9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#J10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#J11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#J12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBarChild"), "#J13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBarChild"), "#J14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#J15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#J16");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBarChild"), "#J17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBarChild"), "#J18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#J19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#J20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#J21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#J22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#J23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#J24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#J25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#J26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#J27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#J28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#J29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#J30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBarChild"), "#J31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBarChild"), "#J32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#J33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBarChild"), "#J34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBarChild"), "#J35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBarChild"), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#K1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#K2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#K3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#K4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#K5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#K6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#K7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#K8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#K9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#K10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#K11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#K12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBarChild"), "#K13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBarChild"), "#K14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#K15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#K16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBarChild"), "#K17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBarChild"), "#K18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#K19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#K20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#K21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#K22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#K23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#K24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#K25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#K26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#K27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#K28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#K29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#K30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBarChild"), "#K31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBarChild"), "#K32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#K33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBarChild"), "#K34");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticBarChild"), "#K35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBarChild"), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#L1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#L2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#L3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#L4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#L5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#L6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#L7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#L8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#L9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#L10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#L11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#L12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBarChild"), "#L13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBarChild"), "#L14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#L15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#L16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBarChild"), "#L17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBarChild"), "#L18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#L19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#L20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#L21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#L22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#L23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#L24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#L25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#L26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#L27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#L28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#L29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#L30");
		Assert.IsTrue (ContainsProperty (props, "PrivateStaticBarChild"), "#L31");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticBarChild"), "#L32");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#L33");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticBarChild"), "#L34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBarChild"), "#L35");
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticBarChild"), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#M1");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBlueChild"), "#M2");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#M3");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#M4");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBlueChild"), "#M5");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#M6");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#M6");
#endif
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#M7");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceFooChild"), "#M8");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#M9");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#M10");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceFooChild"), "#M11");
#if NET_2_0
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceFooChild"), "#M12");
#else
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#M12");
#endif
		Assert.IsTrue (ContainsProperty (props, "PrivateInstanceBarChild"), "#M13");
		Assert.IsTrue (ContainsProperty (props, "FamilyInstanceBarChild"), "#M14");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#M15");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#M16");
		Assert.IsTrue (ContainsProperty (props, "PublicInstanceBarChild"), "#M17");
		Assert.IsTrue (ContainsProperty (props, "AssemblyInstanceBarChild"), "#M18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#M19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#M20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#M21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#M22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#M23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#M24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#M25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#M26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#M27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#M28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#M29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#M30");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBarChild"), "#M31");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBarChild"), "#M32");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#M33");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBarChild"), "#M34");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBarChild"), "#M35");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBarChild"), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;
		props = type.GetProperties (flags);

		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBlueChild"), "#N1");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBlueChild"), "#N2");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBlueChild"), "#N3");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBlueChild"), "#N4");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBlueChild"), "#N5");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBlueChild"), "#N6");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceFooChild"), "#N7");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceFooChild"), "#N8");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceFooChild"), "#N9");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceFooChild"), "#N10");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceFooChild"), "#N11");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceFooChild"), "#N12");
		Assert.IsFalse (ContainsProperty (props, "PrivateInstanceBarChild"), "#N13");
		Assert.IsFalse (ContainsProperty (props, "FamilyInstanceBarChild"), "#N14");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemInstanceBarChild"), "#N15");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemInstanceBarChild"), "#N16");
		Assert.IsFalse (ContainsProperty (props, "PublicInstanceBarChild"), "#N17");
		Assert.IsFalse (ContainsProperty (props, "AssemblyInstanceBarChild"), "#N18");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticBlueChild"), "#N19");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticBlueChild"), "#N20");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticBlueChild"), "#N21");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticBlueChild"), "#N22");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticBlueChild"), "#N23");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticBlueChild"), "#N24");
		Assert.IsFalse (ContainsProperty (props, "PrivateStaticFooChild"), "#N25");
		Assert.IsFalse (ContainsProperty (props, "FamilyStaticFooChild"), "#N26");
		Assert.IsFalse (ContainsProperty (props, "FamANDAssemStaticFooChild"), "#N27");
		Assert.IsFalse (ContainsProperty (props, "FamORAssemStaticFooChild"), "#N28");
		Assert.IsFalse (ContainsProperty (props, "PublicStaticFooChild"), "#N29");
		Assert.IsFalse (ContainsProperty (props, "AssemblyStaticFooChild"), "#N30");
		Assert.IsTrue (ContainsProperty (props, "PrivateStaticBarChild"), "#N31");
		Assert.IsTrue (ContainsProperty (props, "FamilyStaticBarChild"), "#N32");
		Assert.IsTrue (ContainsProperty (props, "FamANDAssemStaticBarChild"), "#N33");
		Assert.IsTrue (ContainsProperty (props, "FamORAssemStaticBarChild"), "#N34");
		Assert.IsTrue (ContainsProperty (props, "PublicStaticBarChild"), "#N35");
		Assert.IsTrue (ContainsProperty (props, "AssemblyStaticBarChild"), "#N36");
	}

	static void GetPropertyTest (Type type)
	{
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#A1");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBlue", flags), "#A2");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#A3");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#A4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#A5");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#A6");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#A6");
#endif
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#A7");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceFoo", flags), "#A8");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#A9");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#A10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#A11");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#A12");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#A12");
#endif
		Assert.IsNotNull (type.GetProperty ("PrivateInstanceBar", flags), "#A13");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBar", flags), "#A14");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#A15");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#A16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBar", flags), "#A17");
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBar", flags), "#A18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#A19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#A20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#A21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#A22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#A23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#A24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#A25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#A26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#A27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#A28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#A29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#A30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBar", flags), "#A31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBar", flags), "#A32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#A33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBar", flags), "#A34");
		Assert.IsNull (type.GetProperty ("PublicStaticBar", flags), "#A35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBar", flags), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#B1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#B2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#B3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#B4");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBlue", flags), "#B5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#B6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#B7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#B8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#B9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#B10");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceFoo", flags), "#B11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#B12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBar", flags), "#B13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBar", flags), "#B14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#B15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#B16");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBar", flags), "#B17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBar", flags), "#B18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#B19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#B20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#B21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#B22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#B23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#B24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#B25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#B26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#B27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#B28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#B29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#B30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBar", flags), "#B31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBar", flags), "#B32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#B33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBar", flags), "#B34");
		Assert.IsNull (type.GetProperty ("PublicStaticBar", flags), "#B35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBar", flags), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#C1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#C2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#C3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#C4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#C5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#C6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#C7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#C8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#C9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#C10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#C11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#C12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBar", flags), "#C13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBar", flags), "#C14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#C15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#C16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBar", flags), "#C17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBar", flags), "#C18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#C19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#C20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#C21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#C22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#C23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#C24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#C25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#C26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#C27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#C28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#C29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#C30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBar", flags), "#C31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBar", flags), "#C32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#C33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBar", flags), "#C34");
		Assert.IsNotNull (type.GetProperty ("PublicStaticBar", flags), "#C35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBar", flags), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#D1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#D2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#D3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#D4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#D5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#D6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#D7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#D8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#D9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#D10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#D11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#D12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBar", flags), "#D13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBar", flags), "#D14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#D15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#D16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBar", flags), "#D17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBar", flags), "#D18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#D19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#D20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#D21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#D22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#D23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#D24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#D25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#D26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#D27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#D28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#D29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#D30");
		Assert.IsNotNull (type.GetProperty ("PrivateStaticBar", flags), "#D31");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticBar", flags), "#D32");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#D33");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticBar", flags), "#D34");
		Assert.IsNull (type.GetProperty ("PublicStaticBar", flags), "#D35");
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticBar", flags), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#E1");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBlue", flags), "#E2");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#E3");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#E4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#E5");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#E6");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#E6");
#endif
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#E7");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceFoo", flags), "#E8");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#E9");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#E10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#E11");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#E12");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#E12");
#endif
		Assert.IsNotNull (type.GetProperty ("PrivateInstanceBar", flags), "#E13");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBar", flags), "#E14");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#E15");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#E16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBar", flags), "#E17");
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBar", flags), "#E18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#E19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#E20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#E21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#E22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#E23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#E24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#E25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#E26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#E27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#E28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#E29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#E30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBar", flags), "#E31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBar", flags), "#E32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#E33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBar", flags), "#E34");
		Assert.IsNull (type.GetProperty ("PublicStaticBar", flags), "#E35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBar", flags), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#F1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#F2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#F3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#F4");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBlue", flags), "#F5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#F6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#F7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#F8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#F9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#F10");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceFoo", flags), "#F11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#F12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBar", flags), "#F13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBar", flags), "#F14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#F15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#F16");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBar", flags), "#F17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBar", flags), "#F18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#F19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#F20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#F21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#F22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#F23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#F24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#F25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#F26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#F27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#F28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#F29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#F30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBar", flags), "#F31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBar", flags), "#F32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#F33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBar", flags), "#F34");
		Assert.IsNull (type.GetProperty ("PublicStaticBar", flags), "#F35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBar", flags), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#G1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#G2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#G3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#G4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#G5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#G6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#G7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#G8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#G9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#G10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#G11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#G12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBar", flags), "#G13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBar", flags), "#G14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#G15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#G16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBar", flags), "#G17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBar", flags), "#G18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#G19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#G20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#G21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#G22");
		Assert.IsNotNull (type.GetProperty ("PublicStaticBlue", flags), "#G23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#G24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#G25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#G26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#G27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#G28");
		Assert.IsNotNull (type.GetProperty ("PublicStaticFoo", flags), "#G29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#G30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBar", flags), "#G31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBar", flags), "#G32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#G33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBar", flags), "#G34");
		Assert.IsNotNull (type.GetProperty ("PublicStaticBar", flags), "#G35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBar", flags), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#H1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#H2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#H3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#H4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#H5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#H6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#H7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#H8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#H9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#H10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#H11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#H12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBar", flags), "#H13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBar", flags), "#H14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#H15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#H16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBar", flags), "#H17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBar", flags), "#H18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#H19");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticBlue", flags), "#H20");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#H21");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#H22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#H23");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticBlue", flags), "#H24");
#else
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#H24");
#endif
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#H25");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticFoo", flags), "#H26");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#H27");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#H28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#H29");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticFoo", flags), "#H30");
#else
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#H30");
#endif
		Assert.IsNotNull (type.GetProperty ("PrivateStaticBar", flags), "#H31");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticBar", flags), "#H32");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#H33");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticBar", flags), "#H34");
		Assert.IsNull (type.GetProperty ("PublicStaticBar", flags), "#H35");
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticBar", flags), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#I1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#I2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#I3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#I4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#I5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#I6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#I7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#I8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#I9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#I10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#I11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#I12");
		Assert.IsNotNull (type.GetProperty ("PrivateInstanceBar", flags), "#I13");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBar", flags), "#I14");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#I15");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#I16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBar", flags), "#I17");
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBar", flags), "#I18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#I19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#I20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#I21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#I22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#I23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#I24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#I25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#I26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#I27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#I28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#I29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#I30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBar", flags), "#I31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBar", flags), "#I32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#I33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBar", flags), "#I34");
		Assert.IsNull (type.GetProperty ("PublicStaticBar", flags), "#I35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBar", flags), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#J1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#J2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#J3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#J4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#J5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#J6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#J7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#J8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#J9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#J10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#J11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#J12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBar", flags), "#J13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBar", flags), "#J14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#J15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#J16");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBar", flags), "#J17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBar", flags), "#J18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#J19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#J20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#J21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#J22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#J23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#J24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#J25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#J26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#J27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#J28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#J29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#J30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBar", flags), "#J31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBar", flags), "#J32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#J33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBar", flags), "#J34");
		Assert.IsNull (type.GetProperty ("PublicStaticBar", flags), "#J35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBar", flags), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#K1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#K2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#K3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#K4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#K5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#K6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#K7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#K8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#K9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#K10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#K11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#K12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBar", flags), "#K13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBar", flags), "#K14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#K15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#K16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBar", flags), "#K17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBar", flags), "#K18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#K19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#K20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#K21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#K22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#K23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#K24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#K25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#K26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#K27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#K28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#K29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#K30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBar", flags), "#K31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBar", flags), "#K32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#K33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBar", flags), "#K34");
		Assert.IsNotNull (type.GetProperty ("PublicStaticBar", flags), "#K35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBar", flags), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#L1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#L2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#L3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#L4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#L5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#L6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#L7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#L8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#L9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#L10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#L11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#L12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBar", flags), "#L13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBar", flags), "#L14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#L15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#L16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBar", flags), "#L17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBar", flags), "#L18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#L19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#L20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#L21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#L22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#L23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#L24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#L25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#L26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#L27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#L28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#L29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#L30");
		Assert.IsNotNull (type.GetProperty ("PrivateStaticBar", flags), "#L31");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticBar", flags), "#L32");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#L33");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticBar", flags), "#L34");
		Assert.IsNull (type.GetProperty ("PublicStaticBar", flags), "#L35");
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticBar", flags), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#M1");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBlue", flags), "#M2");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#M3");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#M4");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBlue", flags), "#M5");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#M6");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#M6");
#endif
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#M7");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceFoo", flags), "#M8");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#M9");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#M10");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceFoo", flags), "#M11");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#M12");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#M12");
#endif
		Assert.IsNotNull (type.GetProperty ("PrivateInstanceBar", flags), "#M13");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBar", flags), "#M14");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#M15");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#M16");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBar", flags), "#M17");
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBar", flags), "#M18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#M19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#M20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#M21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#M22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#M23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#M24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#M25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#M26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#M27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#M28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#M29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#M30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBar", flags), "#M31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBar", flags), "#M32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#M33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBar", flags), "#M34");
		Assert.IsNull (type.GetProperty ("PublicStaticBar", flags), "#M35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBar", flags), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlue", flags), "#N1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlue", flags), "#N2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlue", flags), "#N3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlue", flags), "#N4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlue", flags), "#N5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlue", flags), "#N6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFoo", flags), "#N7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFoo", flags), "#N8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFoo", flags), "#N9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFoo", flags), "#N10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFoo", flags), "#N11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFoo", flags), "#N12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBar", flags), "#N13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBar", flags), "#N14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBar", flags), "#N15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBar", flags), "#N16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBar", flags), "#N17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBar", flags), "#N18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlue", flags), "#N19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlue", flags), "#N20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlue", flags), "#N21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlue", flags), "#N22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlue", flags), "#N23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlue", flags), "#N24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFoo", flags), "#N25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFoo", flags), "#N26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFoo", flags), "#N27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFoo", flags), "#N28");
		Assert.IsNull (type.GetProperty ("PublicStaticFoo", flags), "#N29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFoo", flags), "#N30");
		Assert.IsNotNull (type.GetProperty ("PrivateStaticBar", flags), "#N31");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticBar", flags), "#N32");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticBar", flags), "#N33");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticBar", flags), "#N34");
		Assert.IsNotNull (type.GetProperty ("PublicStaticBar", flags), "#N35");
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticBar", flags), "#N36");
	}

	static void GetPropertyNestedTest (Type type)
	{
		BindingFlags flags;

		flags = BindingFlags.Instance | BindingFlags.NonPublic;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#A1");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#A2");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#A3");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#A4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#A5");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#A6");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#A6");
#endif
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#A7");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#A8");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#A9");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#A10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#A11");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#A12");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#A12");
#endif
		Assert.IsNotNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#A13");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#A14");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#A15");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#A16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBarChild", flags), "#A17");
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#A18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#A19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#A20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#A21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#A22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#A23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#A24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#A25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#A26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#A27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#A28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#A29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#A30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBarChild", flags), "#A31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBarChild", flags), "#A32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#A33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#A34");
		Assert.IsNull (type.GetProperty ("PublicStaticBarChild", flags), "#A35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#A36");

		flags = BindingFlags.Instance | BindingFlags.Public;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#B1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#B2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#B3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#B4");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#B5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#B6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#B7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#B8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#B9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#B10");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceFooChild", flags), "#B11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#B12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#B13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#B14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#B15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#B16");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBarChild", flags), "#B17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#B18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#B19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#B20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#B21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#B22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#B23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#B24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#B25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#B26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#B27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#B28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#B29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#B30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBarChild", flags), "#B31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBarChild", flags), "#B32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#B33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#B34");
		Assert.IsNull (type.GetProperty ("PublicStaticBarChild", flags), "#B35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#B36");

		flags = BindingFlags.Static | BindingFlags.Public;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#C1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#C2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#C3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#C4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#C5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#C6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#C7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#C8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#C9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#C10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#C11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#C12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#C13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#C14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#C15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#C16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBarChild", flags), "#C17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#C18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#C19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#C20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#C21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#C22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#C23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#C24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#C25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#C26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#C27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#C28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#C29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#C30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBarChild", flags), "#C31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBarChild", flags), "#C32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#C33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#C34");
		Assert.IsNotNull (type.GetProperty ("PublicStaticBarChild", flags), "#C35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#C36");

		flags = BindingFlags.Static | BindingFlags.NonPublic;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#D1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#D2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#D3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#D4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#D5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#D6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#D7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#D8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#D9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#D10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#D11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#D12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#D13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#D14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#D15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#D16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBarChild", flags), "#D17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#D18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#D19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#D20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#D21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#D22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#D23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#D24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#D25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#D26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#D27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#D28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#D29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#D30");
		Assert.IsNotNull (type.GetProperty ("PrivateStaticBarChild", flags), "#D31");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticBarChild", flags), "#D32");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#D33");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#D34");
		Assert.IsNull (type.GetProperty ("PublicStaticBarChild", flags), "#D35");
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#D36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#E1");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#E2");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#E3");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#E4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#E5");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#E6");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#E6");
#endif
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#E7");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#E8");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#E9");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#E10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#E11");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#E12");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#E12");
#endif
		Assert.IsNotNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#E13");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#E14");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#E15");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#E16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBarChild", flags), "#E17");
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#E18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#E19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#E20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#E21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#E22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#E23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#E24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#E25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#E26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#E27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#E28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#E29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#E30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBarChild", flags), "#E31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBarChild", flags), "#E32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#E33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#E34");
		Assert.IsNull (type.GetProperty ("PublicStaticBarChild", flags), "#E35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#E36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#F1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#F2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#F3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#F4");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#F5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#F6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#F7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#F8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#F9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#F10");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceFooChild", flags), "#F11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#F12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#F13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#F14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#F15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#F16");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBarChild", flags), "#F17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#F18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#F19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#F20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#F21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#F22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#F23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#F24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#F25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#F26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#F27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#F28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#F29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#F30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBarChild", flags), "#F31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBarChild", flags), "#F32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#F33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#F34");
		Assert.IsNull (type.GetProperty ("PublicStaticBarChild", flags), "#F35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#F36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#G1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#G2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#G3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#G4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#G5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#G6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#G7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#G8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#G9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#G10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#G11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#G12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#G13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#G14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#G15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#G16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBarChild", flags), "#G17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#G18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#G19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#G20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#G21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#G22");
		Assert.IsNotNull (type.GetProperty ("PublicStaticBlueChild", flags), "#G23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#G24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#G25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#G26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#G27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#G28");
		Assert.IsNotNull (type.GetProperty ("PublicStaticFooChild", flags), "#G29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#G30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBarChild", flags), "#G31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBarChild", flags), "#G32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#G33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#G34");
		Assert.IsNotNull (type.GetProperty ("PublicStaticBarChild", flags), "#G35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#G36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.FlattenHierarchy;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#H1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#H2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#H3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#H4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#H5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#H6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#H7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#H8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#H9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#H10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#H11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#H12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#H13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#H14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#H15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#H16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBarChild", flags), "#H17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#H18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#H19");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#H20");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#H21");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#H22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#H23");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#H24");
#else
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#H24");
#endif
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#H25");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticFooChild", flags), "#H26");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#H27");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#H28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#H29");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#H30");
#else
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#H30");
#endif
		Assert.IsNotNull (type.GetProperty ("PrivateStaticBarChild", flags), "#H31");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticBarChild", flags), "#H32");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#H33");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#H34");
		Assert.IsNull (type.GetProperty ("PublicStaticBarChild", flags), "#H35");
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#H36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#I1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#I2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#I3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#I4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#I5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#I6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#I7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#I8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#I9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#I10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#I11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#I12");
		Assert.IsNotNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#I13");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#I14");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#I15");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#I16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBarChild", flags), "#I17");
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#I18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#I19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#I20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#I21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#I22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#I23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#I24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#I25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#I26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#I27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#I28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#I29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#I30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBarChild", flags), "#I31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBarChild", flags), "#I32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#I33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#I34");
		Assert.IsNull (type.GetProperty ("PublicStaticBarChild", flags), "#I35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#I36");

		flags = BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#J1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#J2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#J3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#J4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#J5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#J6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#J7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#J8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#J9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#J10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#J11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#J12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#J13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#J14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#J15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#J16");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBarChild", flags), "#J17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#J18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#J19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#J20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#J21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#J22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#J23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#J24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#J25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#J26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#J27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#J28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#J29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#J30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBarChild", flags), "#J31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBarChild", flags), "#J32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#J33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#J34");
		Assert.IsNull (type.GetProperty ("PublicStaticBarChild", flags), "#J35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#J36");

		flags = BindingFlags.Static | BindingFlags.Public |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#K1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#K2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#K3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#K4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#K5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#K6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#K7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#K8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#K9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#K10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#K11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#K12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#K13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#K14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#K15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#K16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBarChild", flags), "#K17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#K18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#K19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#K20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#K21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#K22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#K23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#K24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#K25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#K26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#K27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#K28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#K29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#K30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBarChild", flags), "#K31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBarChild", flags), "#K32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#K33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#K34");
		Assert.IsNotNull (type.GetProperty ("PublicStaticBarChild", flags), "#K35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#K36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.DeclaredOnly;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#L1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#L2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#L3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#L4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#L5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#L6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#L7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#L8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#L9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#L10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#L11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#L12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#L13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#L14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#L15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#L16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBarChild", flags), "#L17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#L18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#L19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#L20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#L21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#L22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#L23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#L24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#L25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#L26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#L27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#L28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#L29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#L30");
		Assert.IsNotNull (type.GetProperty ("PrivateStaticBarChild", flags), "#L31");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticBarChild", flags), "#L32");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#L33");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#L34");
		Assert.IsNull (type.GetProperty ("PublicStaticBarChild", flags), "#L35");
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#L36");

		flags = BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#M1");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#M2");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#M3");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#M4");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#M5");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#M6");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#M6");
#endif
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#M7");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#M8");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#M9");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#M10");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceFooChild", flags), "#M11");
#if NET_2_0
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#M12");
#else
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#M12");
#endif
		Assert.IsNotNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#M13");
		Assert.IsNotNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#M14");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#M15");
		Assert.IsNotNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#M16");
		Assert.IsNotNull (type.GetProperty ("PublicInstanceBarChild", flags), "#M17");
		Assert.IsNotNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#M18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#M19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#M20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#M21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#M22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#M23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#M24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#M25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#M26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#M27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#M28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#M29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#M30");
		Assert.IsNull (type.GetProperty ("PrivateStaticBarChild", flags), "#M31");
		Assert.IsNull (type.GetProperty ("FamilyStaticBarChild", flags), "#M32");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#M33");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#M34");
		Assert.IsNull (type.GetProperty ("PublicStaticBarChild", flags), "#M35");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#M36");

		flags = BindingFlags.Static | BindingFlags.NonPublic |
			BindingFlags.Public;

		Assert.IsNull (type.GetProperty ("PrivateInstanceBlueChild", flags), "#N1");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBlueChild", flags), "#N2");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBlueChild", flags), "#N3");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBlueChild", flags), "#N4");
		Assert.IsNull (type.GetProperty ("PublicInstanceBlueChild", flags), "#N5");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBlueChild", flags), "#N6");
		Assert.IsNull (type.GetProperty ("PrivateInstanceFooChild", flags), "#N7");
		Assert.IsNull (type.GetProperty ("FamilyInstanceFooChild", flags), "#N8");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceFooChild", flags), "#N9");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceFooChild", flags), "#N10");
		Assert.IsNull (type.GetProperty ("PublicInstanceFooChild", flags), "#N11");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceFooChild", flags), "#N12");
		Assert.IsNull (type.GetProperty ("PrivateInstanceBarChild", flags), "#N13");
		Assert.IsNull (type.GetProperty ("FamilyInstanceBarChild", flags), "#N14");
		Assert.IsNull (type.GetProperty ("FamANDAssemInstanceBarChild", flags), "#N15");
		Assert.IsNull (type.GetProperty ("FamORAssemInstanceBarChild", flags), "#N16");
		Assert.IsNull (type.GetProperty ("PublicInstanceBarChild", flags), "#N17");
		Assert.IsNull (type.GetProperty ("AssemblyInstanceBarChild", flags), "#N18");
		Assert.IsNull (type.GetProperty ("PrivateStaticBlueChild", flags), "#N19");
		Assert.IsNull (type.GetProperty ("FamilyStaticBlueChild", flags), "#N20");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticBlueChild", flags), "#N21");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticBlueChild", flags), "#N22");
		Assert.IsNull (type.GetProperty ("PublicStaticBlueChild", flags), "#N23");
		Assert.IsNull (type.GetProperty ("AssemblyStaticBlueChild", flags), "#N24");
		Assert.IsNull (type.GetProperty ("PrivateStaticFooChild", flags), "#N25");
		Assert.IsNull (type.GetProperty ("FamilyStaticFooChild", flags), "#N26");
		Assert.IsNull (type.GetProperty ("FamANDAssemStaticFooChild", flags), "#N27");
		Assert.IsNull (type.GetProperty ("FamORAssemStaticFooChild", flags), "#N28");
		Assert.IsNull (type.GetProperty ("PublicStaticFooChild", flags), "#N29");
		Assert.IsNull (type.GetProperty ("AssemblyStaticFooChild", flags), "#N30");
		Assert.IsNotNull (type.GetProperty ("PrivateStaticBarChild", flags), "#N31");
		Assert.IsNotNull (type.GetProperty ("FamilyStaticBarChild", flags), "#N32");
		Assert.IsNotNull (type.GetProperty ("FamANDAssemStaticBarChild", flags), "#N33");
		Assert.IsNotNull (type.GetProperty ("FamORAssemStaticBarChild", flags), "#N34");
		Assert.IsNotNull (type.GetProperty ("PublicStaticBarChild", flags), "#N35");
		Assert.IsNotNull (type.GetProperty ("AssemblyStaticBarChild", flags), "#N36");
	}

	static bool ContainsProperty (PropertyInfo [] props, string name)
	{
		foreach (PropertyInfo p in props)
			if (p.Name == name)
				return true;
		return false;
	}
}

public class Blue
{
	public class Child
	{
		private string PrivateInstanceBlueChild
		{
			get { return null; }
			set { }
		}

		protected string FamilyInstanceBlueChild
		{
			get { return null; }
			set { }
		}

		protected internal string FamANDAssemInstanceBlueChild
		{
			get { return null; }
			set { }
		}

		protected internal string FamORAssemInstanceBlueChild
		{
			get { return null; }
			set { }
		}

		public long PublicInstanceBlueChild
		{
			get
			{
				if (PrivateInstanceBlueChild == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal int AssemblyInstanceBlueChild
		{
			get { return 0; }
			set { }
		}

		private static string PrivateStaticBlueChild
		{
			get { return null; }
			set { }
		}

		protected static string FamilyStaticBlueChild
		{
			get { return null; }
			set { }
		}

		protected static internal string FamANDAssemStaticBlueChild
		{
			get { return null; }
			set { }
		}

		protected static internal string FamORAssemStaticBlueChild
		{
			get { return null; }
			set { }
		}

		public static long PublicStaticBlueChild
		{
			get
			{
				if (PrivateStaticBlueChild == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal static int AssemblyStaticBlueChild
		{
			get { return 0; }
			set { }
		}
	}

	private string PrivateInstanceBlue
	{
		get { return null; }
		set { }
	}

	protected string FamilyInstanceBlue
	{
		get { return null; }
		set { }
	}

	protected internal string FamANDAssemInstanceBlue
	{
		get { return null; }
		set { }
	}

	protected internal string FamORAssemInstanceBlue
	{
		get { return null; }
		set { }
	}

	public long PublicInstanceBlue
	{
		get
		{
			if (PrivateInstanceBlue == null)
				return 0;
			return long.MaxValue;
		}
		set { }
	}

	internal int AssemblyInstanceBlue
	{
		get { return 0; }
		set { }
	}

	private static string PrivateStaticBlue
	{
		get { return null; }
		set { }
	}

	protected static string FamilyStaticBlue
	{
		get { return null; }
		set { }
	}

	protected static internal string FamANDAssemStaticBlue
	{
		get { return null; }
		set { }
	}

	protected static internal string FamORAssemStaticBlue
	{
		get { return null; }
		set { }
	}

	public static long PublicStaticBlue
	{
		get
		{
			if (PrivateStaticBlue == null)
				return 0;
			return long.MaxValue;
		}
		set { }
	}

	internal static int AssemblyStaticBlue
	{
		get { return 0; }
		set { }
	}
}

public class Foo : Blue
{
	public new class Child : Blue.Child
	{
		private string PrivateInstanceFooChild
		{
			get { return null; }
			set { }
		}

		protected string FamilyInstanceFooChild
		{
			get { return null; }
			set { }
		}

		protected internal string FamANDAssemInstanceFooChild
		{
			get { return null; }
			set { }
		}

		protected internal string FamORAssemInstanceFooChild
		{
			get { return null; }
			set { }
		}

		public long PublicInstanceFooChild
		{
			get
			{
				if (PrivateInstanceFooChild == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal int AssemblyInstanceFooChild
		{
			get { return 0; }
			set { }
		}

		private static string PrivateStaticFooChild
		{
			get { return null; }
			set { }
		}

		protected static string FamilyStaticFooChild
		{
			get { return null; }
			set { }
		}

		protected static internal string FamANDAssemStaticFooChild
		{
			get { return null; }
			set { }
		}

		protected static internal string FamORAssemStaticFooChild
		{
			get { return null; }
			set { }
		}

		public static long PublicStaticFooChild
		{
			get
			{
				if (PrivateStaticFooChild == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal static int AssemblyStaticFooChild
		{
			get { return 0; }
			set { }
		}
	}

	private string PrivateInstanceFoo
	{
		get { return null; }
		set { }
	}

	protected string FamilyInstanceFoo
	{
		get { return null; }
		set { }
	}

	protected internal string FamANDAssemInstanceFoo
	{
		get { return null; }
		set { }
	}

	protected internal string FamORAssemInstanceFoo
	{
		get { return null; }
		set { }
	}

	public long PublicInstanceFoo
	{
		get
		{
			if (PrivateInstanceFoo == null)
				return 0;
			return long.MaxValue;
		}
		set { }
	}

	internal int AssemblyInstanceFoo
	{
		get { return 0; }
		set { }
	}

	private static string PrivateStaticFoo
	{
		get { return null; }
		set { }
	}

	protected static string FamilyStaticFoo
	{
		get { return null; }
		set { }
	}

	protected static internal string FamANDAssemStaticFoo
	{
		get { return null; }
		set { }
	}

	protected static internal string FamORAssemStaticFoo
	{
		get { return null; }
		set { }
	}

	public static long PublicStaticFoo
	{
		get
		{
			if (PrivateStaticFoo == null)
				return 0;
			return long.MaxValue;
		}
		set { }
	}

	internal static int AssemblyStaticFoo
	{
		get { return 0; }
		set { }
	}
}

public class Bar : Foo
{
	public new class Child : Foo.Child
	{
		private string PrivateInstanceBarChild
		{
			get { return null; }
			set { }
		}

		protected string FamilyInstanceBarChild
		{
			get { return null; }
			set { }
		}

		protected internal string FamANDAssemInstanceBarChild
		{
			get { return null; }
			set { }
		}

		protected internal string FamORAssemInstanceBarChild
		{
			get { return null; }
			set { }
		}

		public long PublicInstanceBarChild
		{
			get
			{
				if (PrivateInstanceBarChild == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal int AssemblyInstanceBarChild
		{
			get { return 0; }
			set { }
		}

		private static string PrivateStaticBarChild
		{
			get { return null; }
			set { }
		}

		protected static string FamilyStaticBarChild
		{
			get { return null; }
			set { }
		}

		protected static internal string FamANDAssemStaticBarChild
		{
			get { return null; }
			set { }
		}

		protected static internal string FamORAssemStaticBarChild
		{
			get { return null; }
			set { }
		}

		public static long PublicStaticBarChild
		{
			get
			{
				if (PrivateStaticBarChild == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal static int AssemblyStaticBarChild
		{
			get { return 0; }
			set { }
		}
	}

	private string PrivateInstanceBar
	{
		get { return null; }
		set { }
	}

	protected string FamilyInstanceBar
	{
		get { return null; }
		set { }
	}

	protected internal string FamANDAssemInstanceBar
	{
		get { return null; }
		set { }
	}

	protected internal string FamORAssemInstanceBar
	{
		get { return null; }
		set { }
	}

	public long PublicInstanceBar
	{
		get
		{
			if (PrivateInstanceBar == null)
				return 0;
			return long.MaxValue;
		}
		set { }
	}

	internal int AssemblyInstanceBar
	{
		get { return 0; }
		set { }
	}

	private static string PrivateStaticBar
	{
		get { return null; }
		set { }
	}

	protected static string FamilyStaticBar
	{
		get { return null; }
		set { }
	}

	protected static internal string FamANDAssemStaticBar
	{
		get { return null; }
		set { }
	}

	protected static internal string FamORAssemStaticBar
	{
		get { return null; }
		set { }
	}

	public static long PublicStaticBar
	{
		get
		{
			if (PrivateStaticBar == null)
				return 0;
			return long.MaxValue;
		}
		set { }
	}

	internal static int AssemblyStaticBar
	{
		get { return 0; }
		set { }
	}
}

namespace libC
{
	public class Bar : libC.Foo
	{
		public new class Child : libC.Foo.Child
		{
			private string PrivateInstanceBarChild
			{
				get { return null; }
				set { }
			}

			protected string FamilyInstanceBarChild
			{
				get { return null; }
				set { }
			}

			protected internal string FamANDAssemInstanceBarChild
			{
				get { return null; }
				set { }
			}

			protected internal string FamORAssemInstanceBarChild
			{
				get { return null; }
				set { }
			}

			public long PublicInstanceBarChild
			{
				get
				{
					if (PrivateInstanceBarChild == null)
						return 0;
					return long.MaxValue;
				}
				set { }
			}

			internal int AssemblyInstanceBarChild
			{
				get { return 0; }
				set { }
			}

			private static string PrivateStaticBarChild
			{
				get { return null; }
				set { }
			}

			protected static string FamilyStaticBarChild
			{
				get { return null; }
				set { }
			}

			protected static internal string FamANDAssemStaticBarChild
			{
				get { return null; }
				set { }
			}

			protected static internal string FamORAssemStaticBarChild
			{
				get { return null; }
				set { }
			}

			public static long PublicStaticBarChild
			{
				get
				{
					if (PrivateStaticBarChild == null)
						return 0;
					return long.MaxValue;
				}
				set { }
			}

			internal static int AssemblyStaticBarChild
			{
				get { return 0; }
				set { }
			}
		}

		private string PrivateInstanceBar
		{
			get { return null; }
			set { }
		}

		protected string FamilyInstanceBar
		{
			get { return null; }
			set { }
		}

		protected internal string FamANDAssemInstanceBar
		{
			get { return null; }
			set { }
		}

		protected internal string FamORAssemInstanceBar
		{
			get { return null; }
			set { }
		}

		public long PublicInstanceBar
		{
			get
			{
				if (PrivateInstanceBar == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal int AssemblyInstanceBar
		{
			get { return 0; }
			set { }
		}

		private static string PrivateStaticBar
		{
			get { return null; }
			set { }
		}

		protected static string FamilyStaticBar
		{
			get { return null; }
			set { }
		}

		protected static internal string FamANDAssemStaticBar
		{
			get { return null; }
			set { }
		}

		protected static internal string FamORAssemStaticBar
		{
			get { return null; }
			set { }
		}

		public static long PublicStaticBar
		{
			get
			{
				if (PrivateStaticBar == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal static int AssemblyStaticBar
		{
			get { return 0; }
			set { }
		}
	}
}
