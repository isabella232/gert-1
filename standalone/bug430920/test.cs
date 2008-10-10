using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		Assembly a = Assembly.GetExecutingAssembly ();

		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		Assert.AreEqual (Path.Combine (basedir, "test.exe"), a.Location, "#1:" + a.Location);
		Assert.IsTrue (a.CodeBase.StartsWith ("file:///"), "#2:" + a.CodeBase);

		Uri uri = new Uri (a.Location);
		Assert.AreEqual (uri.ToString (), a.CodeBase, "#3");
	}
}
