using System;
using System.IO;

public class Program
{
	static void Main ()
	{
		string file = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "temp.txt");

		using (FileStream fs = new FileStream (file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete | FileShare.Read)) {
			fs.WriteByte (0x05);
		}

		using (FileStream fs = new FileStream (file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete | FileShare.Write)) {
			fs.WriteByte (0x05);
		}

		using (FileStream fs = new FileStream (file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete | FileShare.ReadWrite)) {
			fs.WriteByte (0x05);
		}

		using (FileStream fs = new FileStream (file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete | FileShare.Inheritable)) {
			fs.WriteByte (0x05);
		}
	}
}
