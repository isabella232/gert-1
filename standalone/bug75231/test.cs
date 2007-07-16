using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

using Mono.Test;

class Program
{
	static void Main ()
	{
		AppDomainSetup setup = new AppDomainSetup ();
		setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
		setup.ApplicationName = "test";

		AppDomain newDomain = AppDomain.CreateDomain ("test",
			AppDomain.CurrentDomain.Evidence, setup);

		StringCollection probePaths = new StringCollection ();
		probePaths.Add (Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "lib"));

		// create an instance of our custom Assembly Resolver in the target domain.
		newDomain.CreateInstanceFrom (Assembly.GetExecutingAssembly ().CodeBase,
			typeof (AssemblyResolveHandler).FullName,
			false,
			BindingFlags.Public | BindingFlags.Instance,
			null,
			new object[] { probePaths },
			CultureInfo.InvariantCulture,
			null,
			AppDomain.CurrentDomain.Evidence);

		Helper helper = new Helper ();
		newDomain.DoCallBack (new CrossAppDomainDelegate (helper.Test));
	}

	[Serializable ()]
	private class Helper
	{
		public void Test ()
		{
			Runner.Execute ();
		}
	}

	[Serializable]
	private class AssemblyResolveHandler
	{
		public AssemblyResolveHandler (StringCollection probePaths)
		{
			_probePaths = probePaths;

			// attach handlers for the current domain.
			AppDomain.CurrentDomain.AssemblyResolve +=
				new ResolveEventHandler (ResolveAssembly);
		}

		public Assembly ResolveAssembly (Object sender, ResolveEventArgs args)
		{
			// find assembly in probe paths
			foreach (string path in _probePaths) {
				string[] assemblies = Directory.GetFiles (path, "*.dll");
				foreach (string assemblyFile in assemblies) {
					try {
						AssemblyName assemblyName = AssemblyName.GetAssemblyName (assemblyFile);
						if (assemblyName.FullName == args.Name) {
							return Assembly.LoadFrom (assemblyFile);
						}
					} catch { }
				}
			}

			// assembly reference could not be resolved
			return null;
		}

		private StringCollection _probePaths;
	}
}
