using System.Web;

namespace Mono.Web
{
	public class TestHandlerFactory : IHttpHandlerFactory
	{
		IHttpHandler IHttpHandlerFactory.GetHandler (HttpContext context, string requestType, string url, string pathTranslated)
		{
			return new TestHandler ();
		}

		void IHttpHandlerFactory.ReleaseHandler (IHttpHandler handler)
		{
		}
	}
}
