using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

class Program
{
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		Assembly asm = Assembly.LoadFrom (Path.Combine (dir, "../localized/localized.dll"));
		ResourceManager rm = new ResourceManager ("MyClass", asm);

		Assert.AreEqual ("System information", rm.GetObject ("SystemInformation", new CultureInfo ("en-US")), "#1");
		Assert.AreEqual ("Informació del sistema", rm.GetObject ("SystemInformation", new CultureInfo ("ca-ES")), "#2");
		Assert.AreEqual ("Systeeminformatie", rm.GetObject ("SystemInformation", new CultureInfo ("nl-BE")), "#3");
	}
}
