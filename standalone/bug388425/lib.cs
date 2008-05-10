using System.Reflection;

#if V1
[assembly: AssemblyVersion ("1.0.0.0")]
#else
[assembly: AssemblyVersion ("2.0.0.0")]
#endif

#if !NET_2_0 && !MONO
[assembly: AssemblyKeyFile ("test.snk")]
#endif

namespace Mono.Web.Test
{
#if V1
	public class HelperV1
	{
		public static string Company {
			get {
				return "Mono_V1";
			}
		}
	}
#else
	public class HelperV2
	{
		public static string Company {
			get {
				return "Mono_V2";
			}
		}
	}
#endif
}
