using System;
using System.Web;

namespace OfflinePages
{
	public class GetPages : IHttpHandler
	{
		public virtual void ProcessRequest (HttpContext context)
		{
			context.Response.Clear ();
			context.Response.Write ("Test");
			context.Response.End ();
		}

		public bool IsReusable {
			get { return false; }
		}
	}
}
