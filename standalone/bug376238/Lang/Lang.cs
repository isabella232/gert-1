using System;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if V1
[assembly: AssemblyVersion ("1.0.0.0")]
#if ONLY_1_1 && !MONO
#endif
#elif V2
[assembly: AssemblyVersion ("1.0.2.0")]
#if ONLY_1_1 && !MONO
[assembly: AssemblyKeyFile ("../locale.snk")]
#endif
#endif
[assembly: AssemblyFileVersion ("1.0.0.0")]
[assembly: NeutralResourcesLanguageAttribute ("")]

namespace TestLocale
{
#if V1
	public class Lang
#elif V2
	public class Lang2
#endif
	{
	}
}
