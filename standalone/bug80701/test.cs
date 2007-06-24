using System;
using System.IO;
using System.Net;

class Program
{
	[STAThread]
	static int Main (string [] args)
	{
		using (FileStream fs = new FileStream ("tmp.txt", FileMode.Create, FileAccess.Write, FileShare.Read)) {
			fs.WriteByte (5);
			fs.Close ();
		}

		FileStream fs2 = new FileStream ("tmp.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
		try {
			File.Delete ("tmp.txt");
			return 1;
		} catch (IOException) {
			fs2.Close ();
			File.Delete ("tmp.txt");
			return 0;
		}
	}
}
