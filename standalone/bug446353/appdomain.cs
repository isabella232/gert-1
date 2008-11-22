using System;
using System.IO;
using System.Reflection;
using System.Text;

class Program
{
	static void Main ()
	{
		string resultFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"result");

		Assembly a = Assembly.GetEntryAssembly ();

		using (StreamWriter sw = new StreamWriter (resultFile, false, Encoding.UTF8)) {
			sw.WriteLine (AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
			sw.WriteLine (AppDomain.CurrentDomain.SetupInformation.CachePath);
			sw.WriteLine (AppDomain.CurrentDomain.SetupInformation.ShadowCopyFiles);
			sw.WriteLine (AppDomain.CurrentDomain.SetupInformation.DynamicBase);
			sw.WriteLine (AppDomain.CurrentDomain.DynamicDirectory);
			sw.WriteLine (a.CodeBase);
			sw.Write (a.Location);
		}
	}
}
