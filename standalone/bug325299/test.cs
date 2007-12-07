using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

using Mono.Unix;

class Program
{
	static void Main ()
	{
		Process p = new Process ();
		p.StartInfo = new ProcessStartInfo ();
		p.StartInfo.FileName = "/bin/sh";
		p.StartInfo.Arguments = "-c umask";
		p.StartInfo.RedirectStandardOutput = true;
		p.StartInfo.UseShellExecute = false;
		p.Start ();
		Assert.IsTrue (p.WaitForExit (1000), "#1");
		Assert.AreEqual (0, p.ExitCode, "#2");

		string output = p.StandardOutput.ReadLine ();
		Assert.IsNotNull (output, "#3");

		int umask = int.Parse (output, CultureInfo.InvariantCulture);
		int expected = 666 & ~umask;

		string fileName = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"file.tmp");

		File.Create (fileName).Close ();

		UnixFileInfo file = new UnixFileInfo (fileName);
		FileAccessPermissions perm = file.FileAccessPermissions;

		int actual = 0;
		actual += (perm & FileAccessPermissions.UserRead) != 0 ? 400 : 0;
		actual += (perm & FileAccessPermissions.UserWrite) != 0 ? 200 : 0;
		actual += (perm & FileAccessPermissions.UserExecute) != 0 ? 100 : 0;
		actual += (perm & FileAccessPermissions.GroupRead) != 0 ? 40 : 0;
		actual += (perm & FileAccessPermissions.GroupWrite) != 0 ? 20 : 0;
		actual += (perm & FileAccessPermissions.GroupExecute) != 0 ? 10 : 0;
		actual += (perm & FileAccessPermissions.OtherRead) != 0 ? 4 : 0;
		actual += (perm & FileAccessPermissions.OtherWrite) != 0 ? 2 : 0;
		actual += (perm & FileAccessPermissions.OtherExecute) != 0 ? 1 : 0;
		Assert.AreEqual (expected, actual, "#4");
	}
}
