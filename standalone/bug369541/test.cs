using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		const string name = "Lang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=8dcf90ebde298dcd";

		Assembly a = Assembly.Load (name.ToUpper ());
		Assert.AreEqual (name, a.FullName, "#1");

		Type t = Type.GetType ("Lang, " + name.ToUpper ());
		Assert.IsNotNull (t, "#2");
		Assert.AreEqual ("Lang, " + name, t.AssemblyQualifiedName, "#3");
	}
}
