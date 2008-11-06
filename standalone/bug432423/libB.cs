using System.Reflection;

[assembly: AssemblyKeyFile ("test.snk")]
#if ONLY_1_0
[assembly: AssemblyFlags ((uint) AssemblyNameFlags.None)]
#elif NET_2_0
[assembly: AssemblyFlags ((uint) AssemblyNameFlags.EnableJITcompileOptimizer)]
#else
[assembly: AssemblyFlags ((uint) AssemblyNameFlags.Retargetable)]
#endif

class Foo
{
}
