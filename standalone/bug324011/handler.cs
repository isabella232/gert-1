using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Text;
using System.Xml;

namespace Test
{
	public class RootHandler : IHttpHandler
	{
		public void ProcessRequest (HttpContext context)
		{
			HttpResponse Response = context.Response;
			Response.Write ("<html>");
			Response.Write ("<body>");
			Response.Write ("<h1> Hello from ROOT handler. </h1>");
			Response.Write ("</body>");
			Response.Write ("</html>");
		}
		public bool IsReusable
		{
			get { return false; }
		}
	}
	public class SubdirHandler : IHttpHandler
	{
		public void ProcessRequest (HttpContext context)
		{
			HttpResponse Response = context.Response;
			Response.Write ("<html>");
			Response.Write ("<body>");
			Response.Write ("<h1> Hello from Subdir handler. </h1>");
			Response.Write ("</body>");
			Response.Write ("</html>");
		}
		public bool IsReusable
		{
			get { return false; }
		}
	}
}
