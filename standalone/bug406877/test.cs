using System;
using System.Globalization;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		string base_dir = Path.Combine (dir, "build");
		string cache_dir = Path.Combine (dir, "cache");

		ShadowCopyTester tester = ShadowCopyTester.GetRemote (base_dir, cache_dir);

		string location;

		location = tester.Location1 ();
		Assert.IsTrue (StartsWith (location, cache_dir), "#1:" + location);
		location = tester.Location2 (dir);
		Assert.IsTrue (StartsWith (location, cache_dir), "#2:" + location);

		File.Delete (Path.Combine (dir, "lib.dll"));
	}

	static bool StartsWith (string source, string prefix)
	{
		CompareOptions options = CompareOptions.None;
		
		if (RunningOnWindows)
			options = CompareOptions.IgnoreCase;

		CultureInfo culture = CultureInfo.InvariantCulture;
		return culture.CompareInfo.IsPrefix (source, prefix, options);
	}

	static bool RunningOnWindows {
		get {
			return (Path.DirectorySeparatorChar == '\\');
		}
	}
}

class ShadowCopyTester : MarshalByRefObject
{
	public string Location1 ()
	{
		return Assembly.GetExecutingAssembly ().Location;
	}

	public string Location2 (string base_dir)
	{
		Assembly a = Assembly.LoadFrom (Path.Combine (base_dir, "lib.dll"));
		return a.Location;
	}

	public static ShadowCopyTester GetRemote (string base_dir, string cache_dir)
	{
		AppDomainSetup setup = new AppDomainSetup ();
		setup.ApplicationBase = base_dir;
		setup.CachePath = cache_dir;
		setup.ShadowCopyFiles = "true";
		setup.ApplicationName = "ShadowCopyTest";

		AppDomain domain = AppDomain.CreateDomain ("shadow", null, setup);
		return (ShadowCopyTester) domain.CreateInstanceFromAndUnwrap (
			typeof (ShadowCopyTester).Assembly.Location,
			typeof (ShadowCopyTester).FullName);
	}
}
