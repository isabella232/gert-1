using System;
using System.Web.Services;

namespace Mono.Web.Services
{
	/// <summary>
	/// ZERERE
	/// </summary>
#if NET_2_0
	[WebServiceBinding (ConformsTo = WsiProfiles.BasicProfile1_1, EmitConformanceClaims = true)]
#else
	[WebServiceBinding]
#endif
	public class MyTestService : WebService
	{
		/// <summary>
		/// erer
		/// </summary>
		/// <param name="name">A</param>
		/// <returns>B</returns>
		[WebMethod]
		public DateTime SayHello (string name)
		{
			return new DateTime (2008, 08, 13);
		}
	}
}
