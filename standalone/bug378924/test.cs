using System;
using System.Reflection;

class Program
{
	static void Main (string [] args)
	{
		AssemblyName an = AssemblyName.GetAssemblyName (args [0]);
		Assert.AreEqual ("mscorlib, Version=2.1.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", an.FullName, "#1");
	}
}
