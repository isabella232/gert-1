using System;
using System.Reflection;

class Program
{
	static void Main ()
	{
		Type type = typeof (Foo<>);
		Type [] gargs = type.GetGenericArguments ();
		Assert.IsNotNull (gargs, "#1");
		Assert.AreEqual (1, gargs.Length, "#2");

		Type garg = gargs [0];
		Type [] csts = garg.GetGenericParameterConstraints ();

		Assert.AreEqual ("Z", garg.Name, "#3");
		Assert.AreEqual (GenericParameterAttributes.DefaultConstructorConstraint | GenericParameterAttributes.NotNullableValueTypeConstraint, garg.GenericParameterAttributes, "#4");
		Assert.IsNotNull (csts, "#5");
		Assert.AreEqual (1, csts.Length, "#6");
		Assert.AreEqual (typeof (ValueType), csts [0], "#7");
	}
}

struct Foo<Z> where Z : struct
{
}
