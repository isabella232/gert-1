
using System;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if V1
[assembly: AssemblyVersion ("1.0.0.0")]
#if ONLY_1_1 && !MONO
[assembly: AssemblyDelaySign (true)]
[assembly: AssemblyKeyFile ("../lang.snk")]
#endif
#elif V2
[assembly: AssemblyVersion ("1.0.2.0")]
#if ONLY_1_1 && !MONO
[assembly: AssemblyDelaySign (true)]
[assembly: AssemblyKeyFile ("../locale.snk")]
#endif
#endif
[assembly: AssemblyFileVersion ("1.0.0.0")]
[assembly: NeutralResourcesLanguageAttribute ("")]

namespace TestLocale
{
#if V1
	public class Locale
#elif V2
	public class Locale2
#endif
	{
	}
}
