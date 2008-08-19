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
		string bar_dir = Path.Combine (watch_dir, "bar");
		string foo_dir = Path.Combine (watch_dir, "foo");

		Directory.CreateDirectory (watch_dir);
		Directory.CreateDirectory (bar_dir);
		Directory.CreateDirectory (foo_dir);
		File.Create (Path.Combine (bar_dir, "hiWorld")).Close ();

		FileSystemWatcher watcher = new FileSystemWatcher ();
		watcher.Path = watch_dir;
		watcher.NotifyFilter |= NotifyFilters.Size;
		watcher.Renamed += new RenamedEventHandler (Renamed);
		watcher.IncludeSubdirectories = true;
		watcher.EnableRaisingEvents = true;

		Thread.Sleep (200);

		File.Move (Path.Combine (bar_dir, "hiWorld"), Path.Combine (bar_dir, "helloWorld"));

		Thread.Sleep (200);

		Assert.AreEqual (1, _events.Count, "#1");
		RenamedEventArgs renamedArgs = _events [0] as RenamedEventArgs;
		Assert.IsNotNull (renamedArgs, "#2");
		Assert.AreEqual (WatcherChangeTypes.Renamed, renamedArgs.ChangeType, "#3");
		AssertPaths (Path.Combine (bar_dir, "helloWorld"), renamedArgs.FullPath, "#4");
		AssertPaths (Path.Combine ("bar", "helloWorld"), renamedArgs.Name, "#5");
		AssertPaths (Path.Combine (bar_dir, "hiWorld"), renamedArgs.OldFullPath, "#6");
		AssertPaths (Path.Combine ("bar", "hiWorld"), renamedArgs.OldName, "#7");
	}

	static void AssertPaths (string x, string y, string msg)
	{
		// the MS fileSystemWatcher returns some path in lower-case
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

	static void Renamed (object sender, RenamedEventArgs args)
	{
		if (args.ChangeType != WatcherChangeTypes.Renamed)
			throw new Exception (string.Format ("Wrong ChangeType: {0} instead of {1}.",
				args.ChangeType, WatcherChangeTypes.Renamed));

		_events.Add (args);
	}
}
