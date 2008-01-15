using System;
using System.Reflection;

class Program
{
	static void Main ()
	{
		ConstructorInfo ctor;

		Type type = typeof (Foo);
		ctor = type.GetConstructor (Type.EmptyTypes);
		Assert.IsNotNull (ctor, "#A1");
		Assert.AreEqual (0, ctor.GetParameters ().Length, "#A2");
		Assert.IsFalse (ctor.IsStatic, "#A3");
		Assert.IsTrue (ctor.IsPublic, "#A4");
		Assert.AreEqual (".ctor", ctor.Name, "#A5");

		type = typeof (Bar);
		ctor = type.GetConstructor (Type.EmptyTypes);
		Assert.IsNull (ctor, "#B");
	}
}
