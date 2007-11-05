using System.Web.Services;

namespace Mono.Web.Services
{
#if NET_2_0
	[WebServiceBinding (ConformsTo = WsiProfiles.BasicProfile1_1, EmitConformanceClaims = true)]
#else
	[WebServiceBinding]
#endif
	public class MyTestService : WebService
	{
		[WebMethod]
		public string SayHello (string name)
		{
			return "Hello " + name;
		}
	}
}
