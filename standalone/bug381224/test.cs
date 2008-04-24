using System;
using System.IO;
using System.Threading;
using System.Text;

class Program
{
	static int Main ()
	{
		if (!RunTest (DeleteThread, true))
			return 1;
		if (!RunTest (MoveThread, false))
			return 2;
		if (!File.Exists (path_backup))
			return 3;
		return 0;
	}


	static bool RunTest (ThreadStart tstart, bool delete)
	{
		locker = 0;
		Thread t = new Thread (tstart);
		t.Start ();

		using (FileStream fs = File.Open (path, FileMode.Create, FileAccess.Write, FileShare.Delete)) {
			Byte [] info = new UTF8Encoding (true).GetBytes ("This is some text in the file.\r\n");
			fs.Write (info, 0, info.Length);
			fs.Write (info, 0, info.Length);
			fs.Write (info, 0, info.Length);
			fs.Write (info, 0, info.Length);
			fs.Write (info, 0, info.Length);
		}

		using (FileStream fs = File.Open (path, FileMode.Open, FileAccess.ReadWrite, FileShare.Delete)) {
			locker = 1;
			byte [] b = new byte [10];
			UTF8Encoding temp = new UTF8Encoding (true);

			while (fs.Read (b, 0, b.Length) > 0) {
				temp.GetString (b);
				Thread.Sleep (1000);
			}

			if (delete && !File.Exists (path))
				throw new Exception ("File should continue to exist until FileStream is closed.");
		}
		t.Join ();

		return (!File.Exists (path));
	}

	static void DeleteThread ()
	{
		while (locker == 0)
			Thread.Sleep (100);
		File.Delete (path);
		if (!File.Exists (path))
			throw new Exception ("File should continue to exist until FileStream is closed.");
	}

	static void MoveThread ()
	{
		while (locker == 0)
			Thread.Sleep (100);
		File.Move (path, path_backup);
		if (File.Exists (path))
			throw new Exception ("File should immediately be moved.");
		if (!File.Exists (path_backup))
			throw new Exception ("File should have immediately been created.");
	}

	static byte locker;
	static string path = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
		"file.txt");
	static string path_backup = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
		"file.backup");
}
