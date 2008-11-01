using System;
using System.IO;

class Program
{
	static void Main ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;
		Assert.IsNotNull (basedir, "#1");
		int len = basedir.Length;
		Assert.IsTrue (len > 0, "#2");
		Assert.AreEqual (Path.DirectorySeparatorChar, basedir [len -1], "#3");
	}
}
