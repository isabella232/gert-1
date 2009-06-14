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
		pinfo = type.GetProperty ("Name");
		Assert.IsNotNull (pinfo, "#A3");

		type = assembly.GetType ("Foo+Bar");
#if MONO
		Assert.IsNotNull (type, "#B1");
		Assert.AreEqual (aname, type.Assembly.FullName, "#B2");
		pinfo = type.GetProperty ("Town");
		Assert.IsNotNull (pinfo, "#B3");
#else
		Assert.IsNull (type, "#B1");
#endif
	}
}
