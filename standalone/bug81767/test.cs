using System;
using System.IO;
using System.Threading;
using System.Text;

class Program
{
	static int Main ()
	{
		locker = 0;
		Thread t = new Thread (DeleteThread);
		t.Start ();

		using (FileStream fs = File.Open (path, FileMode.Create, FileAccess.Write, FileShare.Delete)) {
			Byte [] info = new UTF8Encoding (true).GetBytes ("This is some text in the file.\r\n");
			fs.Write (info, 0, info.Length);
			fs.Write (info, 0, info.Length);
			fs.Write (info, 0, info.Length);
			fs.Write (info, 0, info.Length);
			fs.Write (info, 0, info.Length);
		}
		locker = 1;

		using (FileStream fs = File.Open (path, FileMode.Open, FileAccess.ReadWrite, FileShare.Delete)) {
			byte [] b = new byte [10];
			UTF8Encoding temp = new UTF8Encoding (true);

			while (fs.Read (b, 0, b.Length) > 0) {
				temp.GetString (b);
				Thread.Sleep (1000);
			}
		}
		t.Join ();

		if (File.Exists (path))
			return 1;
		return 0;
	}

	static void DeleteThread ()
	{
		while (locker == 0) {
			Thread.Sleep (100);
		}
		File.Delete (path);
	}

	static byte locker;
	static string path = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
		"file.txt");
}
