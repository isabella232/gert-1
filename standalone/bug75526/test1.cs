using System;
using System.IO;

public class Test
{
	static int Main ()
	{
		string tempFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"tmp.txt");
		using (FileStream fs = File.OpenWrite (tempFile)) {
			for (int i = 0; i < 50000; i++) {
				fs.WriteByte (5);
			}
		}

		using (FileStream fs = File.OpenRead (tempFile)) {
			StreamReader sr = new StreamReader (fs);
			char [] buf = new char [8192];
			int len = sr.Read (buf, 0, buf.Length);
			if (len != 8192)
				return 1;
		}
		return 0;
	}
}
