using System;
using System.Web;

namespace Mono.Web
{
	public class TestHandler : IHttpHandler
	{
		public void ProcessRequest (HttpContext context)
		{
			context.Response.Write("TestHandler executed!");
		}
		
		public bool IsReusable {
			get {
				return true;
			}
		}
		
	}
}
