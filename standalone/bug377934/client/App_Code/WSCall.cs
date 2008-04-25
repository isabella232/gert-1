using System;

namespace TestMDWS
{
	public class WSCall
	{
		public WSCall()
		{
		}
		
		public static string GetResult()
		{
			Mono.Web.Services.MyTestService svc = new Mono.Web.Services.MyTestService ();
			return svc.SayHello ("Mono").ToString ("dd/MM/yyyy");
		}
	}
}
