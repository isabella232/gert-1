using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main (string [] args)
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;

		Assembly a = Assembly.LoadFile (Path.Combine (dir, "mscorlib.dll"));
		Assert.AreEqual ("mscorlib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", a.FullName, "#1");

		Type t = a.GetType ("System.Exception");
		FieldInfo f = t.GetField ("Unknown");
		object value = f.GetValue (f);
		Assert.AreEqual ("1", value.ToString (), "#2");
	}
}
