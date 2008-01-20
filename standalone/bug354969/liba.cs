using System;
using System.Reflection;

[assembly: AssemblyVersion ("9.7.5.3")]
[assembly: AssemblyFileVersion ("3.2.3.2")]
[assembly: AssemblyProduct ("libA")]
[assembly: AssemblyTitle ("libA title")]
[assembly: AssemblyInformationalVersion ("0.2.4.0")]
[assembly: AssemblyDescription ("libA description")]
[assembly: AssemblyCopyright ("libA copyright")]
[assembly: AssemblyCompany ("libA company")]
[assembly: AssemblyTrademark ("libA trademark")]
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
