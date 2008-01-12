using System;
using System.IO;

namespace MyAssembly
{
	class MainClass
	{
		static void Main (string [] args)
		{
			string tempFile;

			if (args.Length != 1) {
				string dir = AppDomain.CurrentDomain.BaseDirectory;
				tempFile = Path.Combine (dir, "temp");
			} else {
				tempFile = args [0];
			}

			File.Create (tempFile).Close ();
		}
	}
}
