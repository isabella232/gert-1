using System;
using System.IO;

class Program
{
	static void Main ()
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;
		Assert.IsNotNull (basedir, "#1");
		int len = basedir.Length;
		Assert.IsTrue (len > 0, "#2");
		Assert.AreEqual (Path.DirectorySeparatorChar, basedir [len -1], "#3");

		string subdir = Path.Combine (basedir, "sub");
		File.Copy (Path.Combine (basedir, "remote.dll"),
			Path.Combine (subdir, "remote.dll"), true);

		AppDomainSetup setup = new AppDomainSetup ();
		setup.ApplicationBase = subdir;

		AppDomain domain;

		domain = AppDomain.CreateDomain ("test", AppDomain.CurrentDomain.Evidence, setup);
		try {
			RemoteTester remote = (RemoteTester) domain.CreateInstanceAndUnwrap (
				typeof (RemoteTester).Assembly.FullName,
				typeof (RemoteTester).FullName);
			Assert.AreEqual (subdir, remote.GetBaseDirectory (), "#4");
		} finally {
			AppDomain.Unload (domain);
		}

		domain = AppDomain.CreateDomain ("test", AppDomain.CurrentDomain.Evidence, null);
		try {
			RemoteTester remote = (RemoteTester) domain.CreateInstanceAndUnwrap (
				typeof (RemoteTester).Assembly.FullName,
				typeof (RemoteTester).FullName);
			Assert.AreEqual (basedir, remote.GetBaseDirectory (), "#5");
		} finally {
			AppDomain.Unload (domain);
		}

	}
}
