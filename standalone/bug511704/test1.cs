using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		string aname = "A, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";

		Type type;
		PropertyInfo pinfo;
		Assembly assembly;

		assembly = typeof (Orange).Assembly;
		type = assembly.GetType ("Foo");
		Assert.IsNotNull (type, "#A1");
		Assert.AreEqual (aname, type.Assembly.FullName, "#A2");
		type = assembly.GetType ("Foo+Bar");
		Assert.IsNotNull (type, "#A3");
		Assert.AreEqual (aname, type.Assembly.FullName, "#A4");

		type = typeof (Foo);
		Assert.AreEqual (aname, type.Assembly.FullName, "#B1");
		type = type.Assembly.GetType ("Foo");
		Assert.IsNotNull (type, "#B2");
		Assert.AreEqual (aname, type.Assembly.FullName, "#B3");

		type = typeof (Foo.Bar);
		Assert.AreEqual (aname, type.Assembly.FullName, "#C1");
		type = type.Assembly.GetType ("Foo+Bar");
		Assert.IsNotNull (type, "#C2");
		Assert.AreEqual (aname, type.Assembly.FullName, "#C3");

		type = Type.GetType ("Foo, A, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
		Assert.IsNotNull (type, "#D1");
		Assert.AreEqual (aname, type.Assembly.FullName, "#D2");
		pinfo = type.GetProperty ("Name");
		Assert.IsNotNull (pinfo, "#D3");

		type = Type.GetType ("Foo, B, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
		Assert.IsNotNull (type, "#E1");
		Assert.AreEqual (aname, type.Assembly.FullName, "#E2");
		pinfo = type.GetProperty ("Name");
		Assert.IsNotNull (pinfo, "#E3");

		type = Type.GetType ("Foo+Bar, A, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
		Assert.IsNotNull (type, "#F1");
		Assert.AreEqual (aname, type.Assembly.FullName, "#F2");
		pinfo = type.GetProperty ("Town");
		Assert.IsNotNull (pinfo, "#F3");

		type = Type.GetType ("Foo+Bar, B, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
		Assert.IsNotNull (type, "#G1");
		Assert.AreEqual (aname, type.Assembly.FullName, "#G2");
		pinfo = type.GetProperty ("Town");
		Assert.IsNotNull (pinfo, "#G3");

		assembly = Assembly.LoadFrom (Path.Combine (
			AppDomain.CurrentDomain.BaseDirectory, "B.dll"));
		type = assembly.GetType ("Foo");
		Assert.IsNotNull (type, "#H1");
		Assert.AreEqual (aname, type.Assembly.FullName, "#H2");
		type = assembly.GetType ("Foo+Bar");
		Assert.IsNotNull (type, "#H3");

		Foo foo = new Foo ();
		Assert.IsNotNull (foo, "#I1");
		Foo.Bar foobar = new Foo.Bar ();
		Assert.IsNotNull (foobar, "#I2");
	}
}
