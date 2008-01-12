using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

class Program
{
	[STAThread]
	static int Main ()
	{
		AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler (CurrentDomain_AssemblyResolve);

		try {
			Assembly a = Assembly.GetExecutingAssembly ();
			a.GetSatelliteAssembly (new CultureInfo ("ja-JP"), new Version ("3.0"));
			return 1;
		} catch (FileNotFoundException) {
			if (_AssemblyResolves.Count != 1)
				return 2;
		}

		_AssemblyResolves.Clear ();

		try {
			ResourceManager rm = new ResourceManager ("foo", Assembly.GetExecutingAssembly ());
			rm.GetObject ("bar", new CultureInfo ("fr-FR"));

			return 3;
		} catch (MissingManifestResourceException) {
#if NET_2_0
			if (_AssemblyResolves.Count != 0)
				return 4;
#else
			if (_AssemblyResolves.Count != 2)
				return 4;
#endif
			return 0;
		}
	}

	static Assembly CurrentDomain_AssemblyResolve (object sender, ResolveEventArgs args)
	{
		lock (_syncLock) {
			_AssemblyResolves.Add (args.Name);
		}
		return null;
	}

	static readonly object _syncLock = new object ();
	static readonly ArrayList _AssemblyResolves = new ArrayList ();
}
