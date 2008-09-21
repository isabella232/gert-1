using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		Assembly a = Assembly.LoadFile (Path.Combine (basedir, "B/libB.dll"));
		Assert.AreEqual ("libB, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", a.FullName, "#1");
	}
}
