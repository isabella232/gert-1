using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MONO_HttpHandler_Test
{
	public class CustomHandlerFactory : IHttpHandlerFactory
	{
		public IHttpHandler GetHandler (HttpContext context, string requestType, string url, string pathTranslated)
		{
			context.Response.Write ("<handler>" + url + "</handler>");
			object o = System.Web.Compilation.BuildManager.CreateInstanceFromVirtualPath (url, typeof (IHttpHandler));
			return o as IHttpHandler;
		}

		public void ReleaseHandler (IHttpHandler handler)
		{
		}
	}
}
