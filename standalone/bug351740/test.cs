using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		try {
			Assembly.LoadFrom (Path.Combine (dir, "Lang.dll"));
			Assert.Fail ("#1");
		} catch (FileLoadException ex) {
			// .NET 1.x:
			// Strong name validation failed for assembly "Lang.dll"
			// 
			// .NET 2.0:
			// Could not load file or assembly '...Lang.dll' or one
			// of its dependencies. Invalid assembly public key
			Assert.AreEqual (typeof (FileLoadException), ex.GetType (), "#2");
			Assert.IsNull (ex.InnerException, "#3");
			Assert.IsNotNull (ex.FileName, "#4");
			Assert.IsTrue (ex.FileName.IndexOf ("Lang.dll") != -1, "#5");
		}
	}
}
