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
		string base_dir = AppDomain.CurrentDomain.BaseDirectory;
		string watch_dir = Path.Combine (base_dir, "watch");

		FileSystemWatcher watcher = new FileSystemWatcher ();
		watcher.Path = watch_dir;
		watcher.NotifyFilter |= NotifyFilters.Size;
		watcher.Created += new FileSystemEventHandler (Created);
		watcher.Deleted += new FileSystemEventHandler (Deleted);
		watcher.Changed += new FileSystemEventHandler (Changed);
		watcher.Renamed += new RenamedEventHandler (Renamed);

		FileSystemEventArgs fileArgs;
		RenamedEventArgs renamedArgs;

		Thread.Sleep (200);

		File.Create (Path.Combine (watch_dir, "helloWorld")).Close ();

		watcher.IncludeSubdirectories = true;
		watcher.EnableRaisingEvents = true;

		string foo_dir = Path.Combine (watch_dir, "foo");
		string bar_dir = Path.Combine (watch_dir, "bar");

		Directory.CreateDirectory (foo_dir);

		Thread.Sleep (200);

		Assert.AreEqual (1, _events.Count, "#A1");
		fileArgs = _events [0] as FileSystemEventArgs;
		Assert.IsNotNull (fileArgs, "#A2");
		Assert.AreEqual (WatcherChangeTypes.Created, fileArgs.ChangeType, "#A3");
		Assert.AreEqual (foo_dir, fileArgs.FullPath, "#A4");
		Assert.AreEqual ("foo", fileArgs.Name, "#A5");

		Directory.Move (foo_dir, bar_dir);

		Thread.Sleep (200);

		Assert.AreEqual (2, _events.Count, "#B1");
		renamedArgs = _events [1] as RenamedEventArgs;
		Assert.IsNotNull (renamedArgs, "#B2");
		Assert.AreEqual (WatcherChangeTypes.Renamed, renamedArgs.ChangeType, "#B3");
		Assert.AreEqual (bar_dir, renamedArgs.FullPath, "#B4");
		Assert.AreEqual ("bar", renamedArgs.Name, "#B5");
		Assert.AreEqual (foo_dir, renamedArgs.OldFullPath, "#B6");
		Assert.AreEqual ("foo", renamedArgs.OldName, "#B7");

		File.Create (Path.Combine (bar_dir, "hiWorld")).Close ();

		Thread.Sleep (200);

		Assert.IsTrue (_events.Count >= 3, "#C1");
		fileArgs = _events [2] as FileSystemEventArgs;
		Assert.IsNotNull (fileArgs, "#C2");
		Assert.AreEqual (WatcherChangeTypes.Created, fileArgs.ChangeType, "#C3");
		AssertPaths (Path.Combine (bar_dir, "hiWorld"), fileArgs.FullPath, "#C4");
		AssertPaths (Path.Combine ("bar", "hiWorld"), fileArgs.Name, "#C5");

		File.Move (Path.Combine (bar_dir, "hiWorld"), Path.Combine (bar_dir, "helloWorld"));

		Thread.Sleep (200);

		renamedArgs = _events [_events.Count - 1] as RenamedEventArgs;
		Assert.IsNotNull (renamedArgs, "#D1");
		Assert.AreEqual (WatcherChangeTypes.Renamed, renamedArgs.ChangeType, "#D2");
		AssertPaths (Path.Combine (bar_dir, "helloWorld"), renamedArgs.FullPath, "#D3");
		// FIXME: bug #418241 
		//AssertPaths (Path.Combine ("bar", "helloWorld"), renamedArgs.Name, "#D4");
		AssertPaths ("helloWorld", renamedArgs.Name, "#D4");
		AssertPaths (Path.Combine (bar_dir, "hiWorld"), renamedArgs.OldFullPath, "#D5");
		// FIXME: bug #418241 
		//AssertPaths (Path.Combine ("bar", "hiWorld"), renamedArgs.OldName, "#D6");
		AssertPaths ("hiWorld", renamedArgs.OldName, "#D6");
	}

	static void AssertPaths (string x, string y, string msg)
	{
		// the MS fileSystemWatcher returns some path in lower-case
		if (string.Compare (x, y, !RunningOnUnix) != 0)
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected: {0}, but was: {1}. {2}",
				x == null ? "<null>" : x, y == null ? "<null>" : y, msg));
	}

	static bool RunningOnUnix {
		get {
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
