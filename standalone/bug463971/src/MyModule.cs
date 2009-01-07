using System;
using System.Web;

namespace MyWebApp
{
	internal class MyModule : IHttpModule
	{
		private MyModule ()
		{
		}

		void IHttpModule.Init (HttpApplication application)
		{
			application.BeginRequest += new EventHandler (this.OnBeginRequest);
		}

		void IHttpModule.Dispose ()
		{
		}

		private void OnBeginRequest (Object source, EventArgs e)
		{
			HttpApplication application = (HttpApplication) source;
			application.Response.Write ("MyModule|");
		}
	}
}
