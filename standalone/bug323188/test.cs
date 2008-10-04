using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

class Program
{
	static readonly ArrayList _events = new ArrayList ();

	static void Main (string [] args)
	{
		string base_dir = AppDomain.CurrentDomain.BaseDirectory;
		string watch_dir = Path.Combine (base_dir, "watch");

		string temp_file = Path.Combine (watch_dir, "Log.tmp");
		using (StreamWriter sw = new StreamWriter (temp_file, false)) {
			sw.Write ("remove me");
		}

		FileSystemWatcher watcher = new FileSystemWatcher ();
		watcher.Path = watch_dir;
		watcher.NotifyFilter |= NotifyFilters.Size;
		watcher.Created += new FileSystemEventHandler (Created);
		watcher.Deleted += new FileSystemEventHandler (Deleted);
		watcher.Changed += new FileSystemEventHandler (Changed);
		watcher.Renamed += new RenamedEventHandler (Renamed);
		watcher.EnableRaisingEvents = true;

		Thread.Sleep (200);

		using (StreamReader sr = new StreamReader (temp_file, Encoding.UTF8, true)) {
			sr.ReadToEnd ();
		}

		// on Windows, Mono's FSW only checks for changes every 750 ms
		Thread.Sleep (1000);

		Assert.AreEqual (0, _events.Count, "#A");

		StreamWriter writer = new StreamWriter (temp_file, false);
		writer.Write ("delete me");
		writer.Flush ();

		// on Windows, Mono's FSW only checks for changes every 750 ms
		Thread.Sleep (1000);

		Assert.AreEqual (1, _events.Count, "#B1");
		FileSystemEventArgs fileArgs = _events [0] as FileSystemEventArgs;
		Assert.IsNotNull (fileArgs, "#B2");
		Assert.AreEqual (WatcherChangeTypes.Changed, fileArgs.ChangeType, "#B3");
		AssertPaths (temp_file, fileArgs.FullPath, "#B4");
		AssertPaths ("Log.tmp", fileArgs.Name, "#B5");

		writer.Close ();

		// on Windows, Mono's FSW only checks for changes every 750 ms
		Thread.Sleep (1000);

		Assert.AreEqual (2, _events.Count, "#C1");
		fileArgs = _events [1] as FileSystemEventArgs;
		Assert.IsNotNull (fileArgs, "#C2");
		Assert.AreEqual (WatcherChangeTypes.Changed, fileArgs.ChangeType, "#C3");
		AssertPaths (temp_file, fileArgs.FullPath, "#C4");
		AssertPaths ("Log.tmp", fileArgs.Name, "#C5");
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
