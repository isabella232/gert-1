using System;
using System.Collections;
using System.IO;
using System.Threading;

class Program
{
	static ArrayList created = new ArrayList ();

	static void Main ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;
		string watchdir = Path.Combine (basedir, "watch");
		string subdir;

		if (!Directory.Exists (watchdir))
			Directory.CreateDirectory (watchdir);

		FileSystemWatcher fsw = new FileSystemWatcher (watchdir);
		fsw.Created += new FileSystemEventHandler (OnCreated);
		fsw.Filter = "a*";
		fsw.IncludeSubdirectories = true;
		fsw.EnableRaisingEvents = true;

		Thread.Sleep (1000);

		Directory.CreateDirectory (Path.Combine (basedir, "temp"));

		Thread.Sleep (1000);
		Assert.AreEqual (0, created.Count, "#1");

		Directory.CreateDirectory (Path.Combine (watchdir, "a"));

		Thread.Sleep (1000);
		Assert.AreEqual (1, created.Count, "#2");
		created.Clear ();

		Directory.CreateDirectory (Path.Combine (watchdir, "b"));

		Thread.Sleep (1000);
		Assert.AreEqual (0, created.Count, "#3");

		Directory.CreateDirectory (Path.Combine (Path.Combine (watchdir, "c"), "d"));

		Thread.Sleep (1000);
		Assert.AreEqual (0, created.Count, "#4");

		Directory.CreateDirectory (Path.Combine (Path.Combine (watchdir, "d"), "a"));

		Thread.Sleep (1000);
		Assert.AreEqual (1, created.Count, "#5");

		subdir = Path.Combine (Path.Combine (watchdir, "e"), "a");
		Directory.CreateDirectory (subdir);
		File.Create (Path.Combine (subdir, "xa"));

		Thread.Sleep (1000);
		Assert.AreEqual (1, created.Count, "#6");
		created.Clear ();

		subdir = Path.Combine (Path.Combine (watchdir, "f"), "a");
		Directory.CreateDirectory (subdir);
		File.Create (Path.Combine (subdir, "ax"));

		Thread.Sleep (1000);
		Assert.AreEqual (2, created.Count, "#7");
		created.Clear ();

		subdir = Path.Combine (Path.Combine (watchdir, "g"), "b");
		Directory.CreateDirectory (subdir);
		File.Create (Path.Combine (subdir, "ax"));

		Thread.Sleep (1000);
		Assert.AreEqual (1, created.Count, "#8");
	}

	static void OnCreated (object sender, FileSystemEventArgs e)
	{
		created.Add (e);
	}
}
