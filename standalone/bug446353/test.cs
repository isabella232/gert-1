using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

class Program
{
	static void Main ()
	{
		string base_dir = AppDomain.CurrentDomain.BaseDirectory;
		string build_dir = Path.Combine (base_dir, "build");
		string cache_dir = Path.Combine (base_dir, "cache");

		AppDomainSetup setup;
		AppDomain domain;

		if (!Directory.Exists (build_dir))
			Directory.CreateDirectory (build_dir);

		setup = new AppDomainSetup ();
		setup.ApplicationBase = build_dir;
		setup.ApplicationName = "ShadowCopyTest1";
		setup.CachePath = cache_dir;
		setup.ShadowCopyFiles = "true";

		domain = AppDomain.CreateDomain ("mydomain", null,
			setup);
		domain.ExecuteAssembly (Path.Combine (base_dir, "appdomain.exe"));
		AppDomain.Unload (domain);

		string resultFile = Path.Combine (build_dir, "result");
		Assert.IsTrue (File.Exists (resultFile), "#A1");

		using (StreamReader sr = new StreamReader (resultFile, Encoding.UTF8, true)) {
			string appdomain = Path.Combine (base_dir, "appdomain.exe");

			string configurationFile = sr.ReadLine ();
			Assert.AreEqual (Path.Combine (build_dir, "test.exe.config"), configurationFile, "#A2");

			string cachePath = sr.ReadLine ();
			Assert.IsTrue (StartsWith (cachePath, cache_dir), "#A3:" + cachePath);

			string shadowCopyFiles = sr.ReadLine ();
			Assert.AreEqual ("true", shadowCopyFiles, "#A4");

			string dynamicBase = sr.ReadLine ();
			Assert.AreEqual (string.Empty, dynamicBase, "#A5");

			string dynamicDir = sr.ReadLine ();
			Assert.AreEqual (string.Empty, dynamicDir, "#A6");

			string codeBase = sr.ReadLine ();
			Assert.AreEqual (new Uri (appdomain).ToString (), codeBase, "#A7");

			string location = sr.ReadToEnd ();
			Assert.IsTrue (StartsWith (location, Path.Combine (cache_dir, setup.ApplicationName)), "#A8:" + location);
			Assert.IsTrue (location.EndsWith ("appdomain.exe"), "#A9:" + location);
		}

		File.Delete (resultFile);

		setup = new AppDomainSetup ();

		domain = AppDomain.CreateDomain ("mydomain", null, setup);
		domain.ExecuteAssembly (Path.Combine (base_dir, "appdomain.exe"));
		AppDomain.Unload (domain);

		resultFile = Path.Combine (base_dir, "result");
		Assert.IsTrue (File.Exists (resultFile), "#B1");

		using (StreamReader sr = new StreamReader (resultFile, Encoding.UTF8, true)) {
			string appdomain = Path.Combine (base_dir, "appdomain.exe");

			string configurationFile = sr.ReadLine ();
			Assert.AreEqual (Path.Combine (base_dir, "test.exe.config"), configurationFile, "#B2");

			string cachePath = sr.ReadLine ();
			Assert.AreEqual (string.Empty, cachePath, "#B3");

			string shadowCopyFiles = sr.ReadLine ();
			Assert.AreEqual (string.Empty, shadowCopyFiles, "#B4");

			string dynamicBase = sr.ReadLine ();
			Assert.AreEqual (string.Empty, dynamicBase, "#B5");

			string dynamicDir = sr.ReadLine ();
			Assert.AreEqual (string.Empty, dynamicDir, "#B6");

			string codeBase = sr.ReadLine ();
			Assert.IsTrue (string.Compare (new Uri (appdomain).ToString (), codeBase, IgnoreCase) == 0, "#B7:" + codeBase);

			string location = sr.ReadToEnd ();
			Assert.IsTrue (string.Compare (appdomain, location, IgnoreCase) == 0, "#B8:" + location);
		}

		File.Delete (resultFile);

		setup = new AppDomainSetup ();
		setup.ApplicationName = "ShadowCopyTest3";
		setup.CachePath = cache_dir;
		setup.ConfigurationFile = "domain.config";
		setup.DynamicBase = Path.Combine (base_dir, "dynamic");

		domain = AppDomain.CreateDomain ("mydomain", null, setup);
		domain.ExecuteAssembly (Path.Combine (base_dir, "appdomain.exe"));
		AppDomain.Unload (domain);

		resultFile = Path.Combine (base_dir, "result");
		Assert.IsTrue (File.Exists (resultFile), "#C1");

		using (StreamReader sr = new StreamReader (resultFile, Encoding.UTF8, true)) {
			string appdomain = Path.Combine (base_dir, "appdomain.exe");

			string configurationFile = sr.ReadLine ();
			Assert.AreEqual (Path.Combine (base_dir, "domain.config"), configurationFile, "#C2");

			string cachePath = sr.ReadLine ();
			Assert.AreEqual (cache_dir, cachePath, "#C3");

			string shadowCopyFiles = sr.ReadLine ();
			Assert.AreEqual (string.Empty, shadowCopyFiles, "#C4");

			string dynamicBase = sr.ReadLine ();
			Assert.IsTrue (StartsWith (dynamicBase, setup.DynamicBase), "#C5");

			string dynamicDir = sr.ReadLine ();
			Assert.AreEqual (Path.Combine (dynamicBase, setup.ApplicationName), dynamicDir, "#C6");

			string codeBase = sr.ReadLine ();
			Assert.IsTrue (string.Compare (new Uri (appdomain).ToString (), codeBase, IgnoreCase) == 0, "#C7:" + codeBase);

			string location = sr.ReadToEnd ();
			Assert.IsTrue (string.Compare (appdomain, location, IgnoreCase) == 0, "#C8:" + location);
		}

		File.Delete (resultFile);

		setup.ShadowCopyFiles = "true";

		domain = AppDomain.CreateDomain ("mydomain", null, setup);
		domain.ExecuteAssembly (Path.Combine (base_dir, "appdomain.exe"));
		AppDomain.Unload (domain);

		resultFile = Path.Combine (base_dir, "result");
		Assert.IsTrue (File.Exists (resultFile), "#D1");

		using (StreamReader sr = new StreamReader (resultFile, Encoding.UTF8, true)) {
			string appdomain = Path.Combine (base_dir, "appdomain.exe");

			string configurationFile = sr.ReadLine ();
			Assert.AreEqual (Path.Combine (base_dir, "domain.config"), configurationFile, "#D2");

			string cachePath = sr.ReadLine ();
			Assert.AreEqual (cache_dir, cachePath, "#D3");

			string shadowCopyFiles = sr.ReadLine ();
			Assert.AreEqual ("true", shadowCopyFiles, "#D4");

			string dynamicBase = sr.ReadLine ();
			Assert.IsTrue (StartsWith (dynamicBase, setup.DynamicBase), "#D5");

			string dynamicDir = sr.ReadLine ();
			Assert.AreEqual (Path.Combine (dynamicBase, setup.ApplicationName), dynamicDir, "#D6");

			string codeBase = sr.ReadLine ();
			Assert.IsTrue (string.Compare (new Uri (appdomain).ToString (), codeBase, IgnoreCase) == 0, "#D7:" + codeBase);

			string location = sr.ReadToEnd ();
			Assert.IsTrue (StartsWith (location, Path.Combine (cache_dir, setup.ApplicationName)), "#D8:" + location);
			Assert.IsTrue (location.EndsWith ("appdomain.exe"), "#D9:" + location);
		}

		File.Delete (resultFile);

		setup = new AppDomainSetup ();
		setup.ShadowCopyFiles = "true";

		domain = AppDomain.CreateDomain ("mydomain", null, setup);
		domain.ExecuteAssembly (Path.Combine (base_dir, "appdomain.exe"));
		AppDomain.Unload (domain);

		resultFile = Path.Combine (base_dir, "result");
		Assert.IsTrue (File.Exists (resultFile), "#E1");

		using (StreamReader sr = new StreamReader (resultFile, Encoding.UTF8, true)) {
			string appdomain = Path.Combine (base_dir, "appdomain.exe");

			string configurationFile = sr.ReadLine ();
			Assert.AreEqual (Path.Combine (base_dir, "test.exe.config"), configurationFile, "#E2");

			string cachePath = sr.ReadLine ();
			Assert.AreEqual (string.Empty, cachePath, "#E3");

			string shadowCopyFiles = sr.ReadLine ();
			Assert.AreEqual ("true", shadowCopyFiles, "#E4");

			string dynamicBase = sr.ReadLine ();
			Assert.AreEqual (string.Empty, dynamicBase, "#E5");

			string dynamicDir = sr.ReadLine ();
			Assert.AreEqual (string.Empty, dynamicDir, "#E6");

			string codeBase = sr.ReadLine ();
			Assert.IsTrue (string.Compare (new Uri (appdomain).ToString (), codeBase, IgnoreCase) == 0, "#E7:" + codeBase);

			string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

			string location = sr.ReadToEnd ();
			if (RunningOnWindows)
				Assert.IsTrue (StartsWith (location, localAppData), "#E8:" + location);
			Assert.IsTrue (location.EndsWith ("appdomain.exe"), "#E9:" + location);
		}

		File.Delete (resultFile);

		setup = new AppDomainSetup ();
		setup.ApplicationName = "ShadowCopyTest6";
		setup.ShadowCopyFiles = "true";

		domain = AppDomain.CreateDomain ("mydomain", null, setup);
		domain.ExecuteAssembly (Path.Combine (base_dir, "appdomain.exe"));
		AppDomain.Unload (domain);

		resultFile = Path.Combine (base_dir, "result");
		Assert.IsTrue (File.Exists (resultFile), "#F1");

		using (StreamReader sr = new StreamReader (resultFile, Encoding.UTF8, true)) {
			string appdomain = Path.Combine (base_dir, "appdomain.exe");

			string configurationFile = sr.ReadLine ();
			Assert.AreEqual (Path.Combine (base_dir, "test.exe.config"), configurationFile, "#F2");

			string cachePath = sr.ReadLine ();
			Assert.AreEqual (string.Empty, cachePath, "#F3");

			string shadowCopyFiles = sr.ReadLine ();
			Assert.AreEqual ("true", shadowCopyFiles, "#F4");

			string dynamicBase = sr.ReadLine ();
			Assert.AreEqual (string.Empty, dynamicBase, "#F5");

			string dynamicDir = sr.ReadLine ();
			Assert.AreEqual (string.Empty, dynamicDir, "#F6");

			string codeBase = sr.ReadLine ();
			Assert.IsTrue (string.Compare (new Uri (appdomain).ToString (), codeBase, IgnoreCase) == 0, "#F7:" + codeBase);

			string localAppData = Environment.GetFolderPath (Environment.SpecialFolder.LocalApplicationData);

			string location = sr.ReadToEnd ();
			if (RunningOnWindows)
				Assert.IsTrue (StartsWith (location, localAppData), "#F8:" + location);
			Assert.IsTrue (location.EndsWith ("appdomain.exe"), "#F9:" + location);
			Assert.IsTrue (IndexOf (location, setup.ApplicationName) == -1, "#F10:" + location);
		}
	}

	static bool StartsWith (string source, string prefix)
	{
		CompareOptions options = CompareOptions.None;

		if (IgnoreCase)
			options = CompareOptions.IgnoreCase;

		CultureInfo culture = CultureInfo.InvariantCulture;
		return culture.CompareInfo.IsPrefix (source, prefix, options);
	}

	static int IndexOf (string source, string prefix)
	{
		CompareOptions options = CompareOptions.None;

		if (IgnoreCase)
			options = CompareOptions.IgnoreCase;

		CultureInfo culture = CultureInfo.InvariantCulture;
		return culture.CompareInfo.IndexOf (source, prefix, options);
	}

	static bool RunningOnWindows {
		get {
			return (Path.DirectorySeparatorChar == '\\');
		}
	}

	static bool IgnoreCase {
		get { return RunningOnWindows; }
	}
}
