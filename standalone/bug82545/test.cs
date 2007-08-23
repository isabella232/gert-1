using System;
using System.IO;

class Program
{
	static int Main ()
	{
		string [] files = Directory.GetFiles ("c:\\");
		bool foundPageFile = false;
		foreach (string file in files) {
			if (file == @"c:\pagefile.sys") {
				foundPageFile = true;
				break;
			}
		}

		if (!foundPageFile)
			return 1;

		FileInfo fi = new FileInfo (@"c:\pagefile.sys");
		if (!fi.Exists)
			return 2;
		if (fi.Attributes != (FileAttributes.Archive | FileAttributes.System | FileAttributes.Hidden))
			return 3;
		if (fi.FullName != @"c:\pagefile.sys")
			return 4;
		if (fi.Name != "pagefile.sys")
			return 5;
		if (fi.Length <= 0)
			return 6;
		if (fi.LastAccessTime == DateTime.MinValue)
			return 7;

		return 0;
	}
}
