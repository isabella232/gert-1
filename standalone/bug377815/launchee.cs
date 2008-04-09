using System;
using System.IO;

class Launchee
{
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		File.Create (Path.Combine (dir, "started")).Close ();
	}
}
