using System;
using System.Web;

namespace Main.Handlers
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
