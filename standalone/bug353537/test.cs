using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;

		File.Create (Path.Combine (dir, "Lang.dll")).Close ();
		try {
			Assembly.Load ("Lang, Version=1.0.0.0");
			Assert.Fail ("#1");
#if NET_2_0
		} catch (BadImageFormatException ex) {
			Assert.AreEqual (typeof (BadImageFormatException), ex.GetType (), "#2");
			Assert.AreEqual ("Lang, Version=1.0.0.0", ex.FileName, "#3");
			Assert.IsNull (ex.InnerException, "#4");
			Assert.IsNotNull (ex.Message, "#5");
		}
#else
		} catch (FileLoadException ex) {
			Assert.AreEqual (typeof (FileLoadException), ex.GetType (), "#2");
			Assert.AreEqual ("Lang", ex.FileName, "#3");
			Assert.IsNull (ex.InnerException, "#4");
			Assert.IsNotNull (ex.Message, "#5");
		}
#endif
	}
}
