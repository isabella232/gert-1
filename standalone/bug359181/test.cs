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

		File.Create (Path.Combine (watch_dir, "tmp")).Close ();

		watcher.EnableRaisingEvents = true;
		Thread.Sleep (200);

		File.Move (Path.Combine (watch_dir, "tmp"), Path.Combine (watch_dir, "tmp2"));
		Thread.Sleep (200);

		Assert.AreEqual (1, _events.Count, "#A");

		RenamedEventArgs renamedArgs = _events [0] as RenamedEventArgs;
		Assert.IsNotNull (renamedArgs, "#B1");
		Assert.AreEqual (WatcherChangeTypes.Renamed, renamedArgs.ChangeType, "#B2");
		Assert.AreEqual (Path.Combine (watch_dir, "tmp2"), renamedArgs.FullPath, "#B3");
		Assert.AreEqual ("tmp2", renamedArgs.Name, "#B4");
		Assert.AreEqual (Path.Combine (watch_dir, "tmp"), renamedArgs.OldFullPath, "#B5");
		Assert.AreEqual ("tmp", renamedArgs.OldName, "#B6");
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
