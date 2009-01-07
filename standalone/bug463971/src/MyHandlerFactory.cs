using System.Web;

namespace MyWebApp
{
	internal class MyHandlerFactory : IHttpHandlerFactory
	{
		private class MyFactoryHandler : IHttpHandler
		{
			internal MyFactoryHandler ()
			{
			}

			void IHttpHandler.ProcessRequest (HttpContext context)
			{
				context.Response.Write ("MyHandlerFactory|");
			}

			bool IHttpHandler.IsReusable
			{
				get
				{
					return true;
				}
			}
		}

		private MyHandlerFactory ()
		{
		}

		IHttpHandler IHttpHandlerFactory.GetHandler (HttpContext context, string requestType, string url, string pathTranslated)
		{
			return new MyFactoryHandler ();
		}

		void IHttpHandlerFactory.ReleaseHandler (IHttpHandler handler)
		{
		}
	}
}
