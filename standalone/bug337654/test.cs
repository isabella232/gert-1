using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

class Program
{
	[STAThread]
	static void Main ()
	{
		AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler (CurrentDomain_AssemblyResolve);

		try {
			Assembly a = Assembly.GetExecutingAssembly ();
			a.GetSatelliteAssembly (new CultureInfo ("ja-JP"), new Version ("3.0"));
			Assert.Fail ("#A1");
		} catch (FileNotFoundException) {
			Assert.AreEqual (1, _AssemblyResolves.Count, "#A2");
			Assert.AreEqual ("test.resources, Version=3.0, Culture=ja-JP, PublicKeyToken=null", _AssemblyResolves [0], "#A3");
		}

		_AssemblyResolves.Clear ();

		try {
			ResourceManager rm = new ResourceManager ("foo", Assembly.GetExecutingAssembly ());
			rm.GetObject ("bar", new CultureInfo ("fr-FR"));
			Assert.Fail ("#B1");
		} catch (MissingManifestResourceException) {
			Assert.AreEqual (2, _AssemblyResolves.Count, "#B2");
			Assert.AreEqual ("test.resources, Version=0.0.0.0, Culture=fr-FR, PublicKeyToken=null", _AssemblyResolves [0], "#B3");
			Assert.AreEqual ("test.resources, Version=0.0.0.0, Culture=fr, PublicKeyToken=null", _AssemblyResolves [1], "#B4");
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
