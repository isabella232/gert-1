using System;
using System.IO;
using System.Threading;

class Program
{
	static FileSystemEventArgs created;

	static void Main ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;
		string watchdir = Path.Combine (basedir, "watch");

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
		Assert.IsNull (created, "#1");

		Directory.CreateDirectory (Path.Combine (watchdir, "a"));

		Thread.Sleep (1000);
		Assert.IsNotNull (created, "#2");
		created = null;

		Directory.CreateDirectory (Path.Combine (watchdir, "b"));

		Thread.Sleep (1000);
		Assert.IsNull (created, "#3");

		Directory.CreateDirectory (Path.Combine (Path.Combine (watchdir, "c"), "d"));

		Thread.Sleep (1000);
		Assert.IsNull (created, "#4");

		Directory.CreateDirectory (Path.Combine (Path.Combine (watchdir, "d"), "a"));

		Thread.Sleep (1000);
		Assert.IsNotNull (created, "#5");
	}

	static void OnCreated (object sender, FileSystemEventArgs e)
	{
		created = e;
	}
}
