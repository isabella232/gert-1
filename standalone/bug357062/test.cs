using System;
using System.Diagnostics;
using System.IO;

class Program
{
	[STAThread]
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;

		ProcessModule main = Process.GetCurrentProcess ().MainModule;
		Assert.AreEqual (Path.Combine (dir, "test.exe"), main.FileName, "#1");
	}
}
