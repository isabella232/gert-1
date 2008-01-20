using System;
using System.Reflection;

[assembly: AssemblyVersion ("9.7.5.3")]
[assembly: AssemblyFileVersion ("3.2.3.2")]
[assembly: AssemblyProduct ("libC")]
[assembly: AssemblyTitle ("libC title")]
[assembly: AssemblyInformationalVersion ("0.2.4.0")]
[assembly: AssemblyDescription ("libC description")]
[assembly: AssemblyCopyright ("libC copyright")]
[assembly: AssemblyCompany ("libC company")]
[assembly: AssemblyTrademark ("libC trademark")]
#if NET_2_0
[assembly: AssemblyFlags (AssemblyNameFlags.Retargetable)]
#else
[assembly: AssemblyFlags ((int) AssemblyNameFlags.Retargetable)]
#endif

#if ONLY_1_1 && !MONO
[assembly: AssemblyKeyFile ("test.snk")]
#endif

public class Foo
{
}
