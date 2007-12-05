using System;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace WebServices
{
	[WebService (Namespace = "http://tempuri.org/")]
	[WebServiceBindingAttribute (Name = "AnotherBinding", Namespace = "http://tempuri.org/")]
	public class TestWebService : System.Web.Services.WebService
	{
		[WebMethod]
		public string HelloWorld ()
		{
			return "Hello World";
		}
	}
}
