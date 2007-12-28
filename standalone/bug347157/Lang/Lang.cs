using System;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyVersion ("1.0.0.0")]
[assembly: AssemblyFileVersion ("1.0.0.0")]
[assembly: NeutralResourcesLanguageAttribute ("")]

#if ONLY_1_1 && !MONO
[assembly: AssemblyKeyFile ("../test.snk")]
#endif

namespace TestLocale
{
	public class Lang
	{
		public static ResourceManager GetDataManager ()
		{
			return new ResourceManager ("Lang.Data", Assembly.GetExecutingAssembly ());
		}

		public static string GetData (string keyName)
		{
			return GetDataManager ().GetString (keyName, System.Threading.Thread.CurrentThread.CurrentCulture);
		}
	}
}
