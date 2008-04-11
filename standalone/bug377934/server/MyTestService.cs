using System;
using System.Web.Services;

namespace Mono.Web.Services
{
	[WebServiceBinding (ConformsTo = WsiProfiles.BasicProfile1_1, EmitConformanceClaims = true)]
	public class MyTestService : WebService
	{
		[WebMethod]
		public DateTime SayHello (string name)
		{
			return new DateTime (2008, 08, 13);
		}
	}
}
