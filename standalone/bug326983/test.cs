using System;
using System.IO;

class Program
{
	static void Main ()
	{
		string src;
		string dest;

		if (RunningOnWindows) {
			src = @"c:\\monotemp";
			dest = @"d:\\monotemp";
		} else {
			src = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Desktop),
				"monotemp");
			dest = "/boot/monotemp";
		}

		Directory.CreateDirectory (src);
		DirectoryInfo di = new DirectoryInfo (src);
		try {
			di.MoveTo (dest);
			Assert.Fail ("#A1");
		} catch (IOException ex) {
			//  Source and destination path must have identical
			// roots. Move will not work across volumes
			Assert.AreEqual (typeof (IOException), ex.GetType (), "#A2");
			Assert.IsNull (ex.InnerException, "#A3");
			Assert.IsNotNull (ex.Message, "#A4");
		}

		Assert.IsFalse (File.Exists (dest), "#B1");
		Assert.IsFalse (Directory.Exists (dest), "#B2");
	}

	static bool RunningOnWindows {
		get { return Path.DirectorySeparatorChar == '\\'; }
	}
}
