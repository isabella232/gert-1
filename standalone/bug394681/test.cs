using System;
using System.IO;

class Program
{
	static void Main ()
	{
		string path = string.Format (@"\\{0}\c$", Environment.MachineName);

		Directory.SetCurrentDirectory (path);
		Assert.AreEqual (path, Path.GetFullPath ("."), "#1");
		Assert.AreEqual (path, Directory.GetCurrentDirectory (), "#2");
	}
}
