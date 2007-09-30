using System;
using System.IO;

class Program
{
	static int Main ()
	{
		string tempFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
						"file.tmp");
		if (!File.Exists (tempFile))
			File.Create (tempFile).Close ();

		try {
			File.SetAttributes (tempFile, FileAttributes.Archive |
				FileAttributes.ReadOnly);
			if ((File.GetAttributes (tempFile) & FileAttributes.Archive) == 0)
				return 1;
			return 0;
		} finally {
			File.SetAttributes (tempFile, FileAttributes.Normal);
			File.Delete (tempFile);
		}
	}
}
