using System;
using System.Web;

namespace Mono.Web
{
	public class TestModule : System.Web.IHttpModule
	{
		public void Init (HttpApplication application)
		{
			application.BeginRequest += new EventHandler (Application_BeginRequest);
			application.EndRequest += new EventHandler (Application_EndRequest);
		}

		public void Dispose ()
		{
		}

		void Application_BeginRequest(Object source, EventArgs e)
		{
			HttpApplication application = (HttpApplication)source;
			HttpContext context = application.Context;
			context.Response.Write("<h1>Begin TestModule</h1>");
		}

		void Application_EndRequest (Object source, EventArgs e)
		{
			HttpApplication application = (HttpApplication) source;
			HttpContext context = application.Context;
			context.Response.Write ("<h1>End TestModule</h1>");
		}
	}
}
