using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

class Program
{
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		string base_dir = Path.Combine (dir, "build");
		string cache_dir = Path.Combine (dir, "cache");

		if (!Directory.Exists (base_dir))
			Directory.CreateDirectory (base_dir);

		AppDomainSetup setup = new AppDomainSetup ();
		setup.ApplicationBase = base_dir;
		setup.CachePath = cache_dir;
		setup.ShadowCopyFiles = "true";
		setup.ApplicationName = "ShadowCopyTest";

		AppDomain domain = AppDomain.CreateDomain ("mydomain", null,
			setup);
		domain.ExecuteAssembly (Path.Combine (dir, "appdomain.exe"));
		AppDomain.Unload (domain);

		string resultFile = Path.Combine (base_dir, "result");
		Assert.IsTrue (File.Exists (resultFile), "#1");

		using (StreamReader sr = new StreamReader (resultFile, Encoding.UTF8, true)) {
			string appdomain = Path.Combine (dir, "appdomain.exe");

			Assert.AreEqual (new Uri (appdomain).ToString (), sr.ReadLine (), "#2");
			Assert.IsTrue (StartsWith (sr.ReadToEnd (), cache_dir), "#3");
		}
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
