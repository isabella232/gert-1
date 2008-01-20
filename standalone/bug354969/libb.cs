using System;
using System.Reflection;

[assembly: AssemblyVersion ("5.2.1.4")]
[assembly: AssemblyCulture ("nl-BE")]
[assembly: AssemblyFileVersion ("3.2.3.2")]
[assembly: AssemblyProduct ("libB")]
[assembly: AssemblyTitle ("libB title")]
[assembly: AssemblyInformationalVersion ("0.2.4.0")]
[assembly: AssemblyDescription ("libB description")]
[assembly: AssemblyCopyright ("libB copyright")]
[assembly: AssemblyCompany ("libB company")]
[assembly: AssemblyTrademark ("libB trademark")]
#if NET_2_0
[assembly: AssemblyFlags (AssemblyNameFlags.Retargetable)]
#else
[assembly: AssemblyFlags ((int) AssemblyNameFlags.Retargetable)]
#endif

public class Foo
{
}
