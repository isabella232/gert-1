using System;
using System.Web;

namespace OfflinePages
{
	public class ViewSource : IHttpHandler
	{
		public virtual void ProcessRequest (HttpContext context)
		{
			context.Response.Clear ();
			context.Response.Write ("Source");
			context.Response.End ();
		}

		public bool IsReusable {
			get { return false; }
		}
	}
}
