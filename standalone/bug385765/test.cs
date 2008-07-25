using System;
using System.IO;

class Program
{
	static void Main ()
	{
		DirectoryInfo di;
		DirectoryInfo [] dirs;
		FileInfo [] files;

		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		di = new DirectoryInfo (basedir);
		dirs = di.GetDirectories ();
		files = di.GetFiles ();

		Assert.AreEqual (2, dirs.Length, "#A1");
		Assert.AreEqual ("dirB", dirs [0].Name, "#A2");
		Assert.AreEqual ("test", dirs [1].Name, "#A3");

		Assert.AreEqual (4, files.Length, "#B1");
		Assert.AreEqual ("default.build", files [0].Name, "#B2");
		Assert.AreEqual ("fileB.txt", files [1].Name, "#B3");
		Assert.AreEqual ("test.cs", files [2].Name, "#B4");
		Assert.AreEqual ("test.exe", files [3].Name, "#B5");

		di = new DirectoryInfo (Path.Combine (basedir, "dirB"));
		dirs = di.GetDirectories ();
		files = di.GetFiles ();

		Assert.AreEqual (0, dirs.Length, "#C1");

		Assert.AreEqual (1, files.Length, "#D1");
		Assert.AreEqual ("fileA.tmp", files [0].Name, "#D2");
	}
}
