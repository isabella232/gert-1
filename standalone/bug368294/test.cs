using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main (string [] args)
	{
		Type type;
		Assembly a;
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		
		a = Assembly.LoadFile (Path.Combine (dir, "mylib.dll"));
		Assert.AreEqual ("mylib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", a.FullName, "#A");

		type = a.GetType ("System.Attribute");
		Assert.AreEqual ("System.Attribute", type.FullName, "#B1");
		Assert.AreEqual (a.FullName, type.Assembly.FullName, "#B2");
		Assert.AreEqual ("System.Attribute, " + a.FullName, type.AssemblyQualifiedName, "#B3");

		type = a.GetType ("System.Int32");
		Assert.AreEqual ("System.Int32", type.FullName, "#C1");
		Assert.AreEqual (a.FullName, type.Assembly.FullName, "#C2");
		Assert.AreEqual ("System.Int32, " + a.FullName, type.AssemblyQualifiedName, "#C3");

		type = a.GetType ("System.Int64");
		Assert.AreEqual ("System.Int64", type.FullName, "#D1");
		Assert.AreEqual (a.FullName, type.Assembly.FullName, "#D2");
		Assert.AreEqual ("System.Int64, " + a.FullName, type.AssemblyQualifiedName, "#D3");

		a = Assembly.LoadFile (Path.Combine (dir, "mscorlib.dll"));
		Assert.AreEqual ("mscorlib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", a.FullName, "#E");

		type = a.GetType ("System.Attribute");
		Assert.AreEqual ("System.Attribute", type.FullName, "#E1");
		Assert.AreEqual (a.FullName, type.Assembly.FullName, "#E2");
		Assert.AreEqual ("System.Attribute, " + a.FullName, type.AssemblyQualifiedName, "#E3");

		type = a.GetType ("System.Int32");
		Assert.AreEqual ("System.Int32", type.FullName, "#F1");
		Assert.AreEqual (a.FullName, type.Assembly.FullName, "#F2");
		Assert.AreEqual ("System.Int32, " + a.FullName, type.AssemblyQualifiedName, "#F3");

		type = a.GetType ("System.Int64");
		Assert.AreEqual ("System.Int64", type.FullName, "#G1");
		Assert.AreEqual (a.FullName, type.Assembly.FullName, "#G2");
		Assert.AreEqual ("System.Int64, " + a.FullName, type.AssemblyQualifiedName, "#G3");
	}
}
