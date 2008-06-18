using System;
using System.Collections;
using System.IO;
using System.Threading;

class Program
{
	static readonly ArrayList _events = new ArrayList ();

	static void Main (string [] args)
	{
		string base_dir = AppDomain.CurrentDomain.BaseDirectory;
		string watch_dir = Path.Combine (base_dir, "watch");

		FileSystemWatcher watcher = new FileSystemWatcher ();
		watcher.Path = watch_dir;
		watcher.NotifyFilter |= NotifyFilters.Size;
		watcher.Created += new FileSystemEventHandler (Created);
		watcher.Deleted += new FileSystemEventHandler (Deleted);
		watcher.Changed += new FileSystemEventHandler (Changed);
		watcher.Renamed += new RenamedEventHandler (Renamed);
		watcher.EnableRaisingEvents = true;

		FileSystemEventArgs fileArgs;
		RenamedEventArgs renamedArgs;

		File.Create (Path.Combine (watch_dir, "tmp")).Close ();
		File.Move (Path.Combine (watch_dir, "tmp"), Path.Combine (watch_dir, "tmp2"));
		File.Delete (Path.Combine (watch_dir, "tmp2"));

		Assert.AreEqual (3, _events.Count, "#A1");

		fileArgs = _events [0] as FileSystemEventArgs;
		Assert.IsNotNull (fileArgs, "#B1");
		Assert.AreEqual (WatcherChangeTypes.Created, fileArgs.ChangeType, "#B2");
		Assert.AreEqual (Path.Combine (watch_dir, "tmp"), fileArgs.FullPath, "#B3");
		Assert.AreEqual ("tmp", fileArgs.Name, "#B4");

		renamedArgs = _events [1] as RenamedEventArgs;
		Assert.IsNotNull (fileArgs, "#C1");
		Assert.AreEqual (WatcherChangeTypes.Renamed, renamedArgs.ChangeType, "#C2");
		Assert.AreEqual (Path.Combine (watch_dir, "tmp2"), renamedArgs.FullPath, "#C3");
		Assert.AreEqual ("tmp2", renamedArgs.Name, "#C4");
		Assert.AreEqual (Path.Combine (watch_dir, "tmp"), renamedArgs.OldFullPath, "#C5");
		Assert.AreEqual ("tmp", renamedArgs.OldName, "#C6");

		fileArgs = _events [2] as FileSystemEventArgs;
		Assert.IsNotNull (fileArgs, "#D1");
		Assert.AreEqual (WatcherChangeTypes.Deleted, fileArgs.ChangeType, "#D2");
		Assert.AreEqual (Path.Combine (watch_dir, "tmp2"), fileArgs.FullPath, "#D3");
		Assert.AreEqual ("tmp2", fileArgs.Name, "#D4");
	}

	static void Created (object sender, FileSystemEventArgs args)
	{
		if (args.ChangeType != WatcherChangeTypes.Created)
			throw new Exception (string.Format ("Wrong ChangeType: {0} instead of {1}.",
				args.ChangeType, WatcherChangeTypes.Created));

		_events.Add (args);
	}

	static void Renamed (object sender, RenamedEventArgs args)
	{
		if (args.ChangeType != WatcherChangeTypes.Renamed)
			throw new Exception (string.Format ("Wrong ChangeType: {0} instead of {1}.",
				args.ChangeType, WatcherChangeTypes.Renamed));

		_events.Add (args);
	}

	static void Changed (object sender, FileSystemEventArgs args)
	{
		if (args.ChangeType != WatcherChangeTypes.Changed)
			throw new Exception (string.Format ("Wrong ChangeType: {0} instead of {1}.",
				args.ChangeType, WatcherChangeTypes.Changed));

		_events.Add (args);
	}

	static void Deleted (object sender, FileSystemEventArgs args)
	{
		if (args.ChangeType != WatcherChangeTypes.Deleted)
			throw new Exception (string.Format ("Wrong ChangeType: {0} instead of {1}.",
				args.ChangeType, WatcherChangeTypes.Deleted));

		_events.Add (args);
	}
}
