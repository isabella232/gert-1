using System.Reflection;

#if NET_2_0
#pragma warning disable 1699
#endif
[assembly: AssemblyKeyFile ("test.snk")]
#if NET_2_0
#pragma warning restore 1699
#endif

class Foo
{
}
