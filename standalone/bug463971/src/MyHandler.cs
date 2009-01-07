using System.Web;

namespace MyWebApp
{
	internal class MyHandler : IHttpHandler
	{
		private MyHandler ()
		{
		}

		void IHttpHandler.ProcessRequest (HttpContext context)
		{
			context.Response.Write ("MyHandler|");
		}

		bool IHttpHandler.IsReusable
		{
			get
			{
				return true;
			}
		}
	}
}
