using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main (string [] args)
	{
		Assembly a;

		string dir = AppDomain.CurrentDomain.BaseDirectory;

		a = Assembly.LoadFile (Path.Combine (dir, "mscorlib.dll"));
		Assert.AreEqual ("mscorlib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", a.FullName, "#1");
		a = typeof (int).Assembly;
#if NET_2_0
		Assert.AreEqual ("mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", a.FullName, "#2");
#else
		Assert.AreEqual ("mscorlib, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", a.FullName, "#2");
#endif
	}
}
