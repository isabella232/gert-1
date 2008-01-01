using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyVersion ("1.2")]
#if ONLY_1_1 && !MONO
[assembly: AssemblyKeyFile ("test.snk")]
#endif

public class Bar
{
}
