using System;
using System.Reflection;

class Program
{
	static void Main (string [] args)
	{
		AssemblyName aname = AssemblyName.GetAssemblyName (args [0]);
		Assert.AreEqual ("mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", aname.FullName, "#1");
	}
}
