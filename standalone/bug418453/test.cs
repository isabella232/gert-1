using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Threading;

class Program
{
	static readonly ArrayList _events = new ArrayList ();

	static void Main (string [] args)
	{
		RenamedEventArgs renamedArgs;
		FileSystemEventArgs fileSysArgs;

		string base_dir = AppDomain.CurrentDomain.BaseDirectory;
		string watch_dir = Path.Combine (base_dir, "watch");

		Directory.CreateDirectory (watch_dir);
		File.Create (Path.Combine (watch_dir, "hiWorld")).Close ();

		FileSystemWatcher watcher = new FileSystemWatcher ();
		watcher.Path = watch_dir;
		watcher.Filter = "helloWorld";
		watcher.NotifyFilter |= NotifyFilters.Size;
		watcher.Created += new FileSystemEventHandler (Created);
		watcher.Deleted += new FileSystemEventHandler (Deleted);
		watcher.Changed += new FileSystemEventHandler (Changed);
		watcher.Renamed += new RenamedEventHandler (Renamed);

		watcher.IncludeSubdirectories = true;
		watcher.EnableRaisingEvents = true;

		Thread.Sleep (200);

		File.Move (Path.Combine (watch_dir, "hiWorld"), Path.Combine (watch_dir, "helloWorld"));

		Thread.Sleep (200);

		Assert.AreEqual (1, _events.Count, "#A1");
		renamedArgs = _events [0] as RenamedEventArgs;
		Assert.IsNotNull (renamedArgs, "#A2");
		Assert.AreEqual (WatcherChangeTypes.Renamed, renamedArgs.ChangeType, "#A3");
		AssertPaths (Path.Combine (watch_dir, "helloWorld"), renamedArgs.FullPath, "#A4");
		AssertPaths ("helloWorld", renamedArgs.Name, "#A5");
		AssertPaths (Path.Combine (watch_dir, "hiWorld"), renamedArgs.OldFullPath, "#A6");
		AssertPaths ("hiWorld", renamedArgs.OldName, "#A7");

		Thread.Sleep (200);
		_events.Clear ();

		File.Create (Path.Combine (watch_dir, "helloWorld")).Close ();

		Thread.Sleep (200);

		Assert.IsTrue (_events.Count > 0, "#B1");
		for (int i = 0; i < _events.Count; i++) {
			fileSysArgs = _events [i] as FileSystemEventArgs;
			Assert.IsNotNull (fileSysArgs, "#B2:" + i);
			Assert.AreEqual (WatcherChangeTypes.Changed, fileSysArgs.ChangeType, "#B3:" + i);
			AssertPaths (Path.Combine (watch_dir, "helloWorld"), fileSysArgs.FullPath, "#B4:" + i);
			AssertPaths ("helloWorld", fileSysArgs.Name, "#B5:" + i);
		}

		Thread.Sleep (200);
		_events.Clear ();

		File.Delete (Path.Combine (watch_dir, "helloWorld"));

		Thread.Sleep (200);

		Assert.AreEqual (1, _events.Count, "#C1");
		fileSysArgs = _events [0] as FileSystemEventArgs;
		Assert.IsNotNull (fileSysArgs, "#C2");
		Assert.AreEqual (WatcherChangeTypes.Deleted, fileSysArgs.ChangeType, "#C3");
		AssertPaths (Path.Combine (watch_dir, "helloWorld"), fileSysArgs.FullPath, "#C4");
		AssertPaths ("helloWorld", fileSysArgs.Name, "#C5");

		Thread.Sleep (200);
		_events.Clear ();

		File.Create (Path.Combine (watch_dir, "hiWorld")).Close ();
		Thread.Sleep (200);
		File.Create (Path.Combine (watch_dir, "hiWorld")).Close ();
		Thread.Sleep (200);
		File.Delete (Path.Combine (watch_dir, "hiWorld"));
		Thread.Sleep (200);

		Assert.AreEqual (0, _events.Count, "#D");
	}

	static void AssertPaths (string x, string y, string msg)
	{
		// the MS fileSystemWatcher returns some paths in lower-case
		if (string.Compare (x, y, !RunningOnUnix) != 0)
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected: {0}, but was: {1}. {2}",
				x == null ? "<null>" : x, y == null ? "<null>" : y, msg));
	}

	static bool RunningOnUnix
	{
		get
		{
#if NET_2_0
			return Environment.OSVersion.Platform == PlatformID.Unix;
#else
			return (int) Environment.OSVersion.Platform == 128;
#endif
		}
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
