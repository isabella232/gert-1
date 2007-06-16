using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;

namespace SoapFault
{
	[WebService (Namespace = "http://www.mono-project.com/", Name = "FaultService")]
	public class FaultService : System.Web.Services.WebService
	{
		[WebMethod]
		public string Run ()
		{
			XmlDocument doc = new XmlDocument ();
			XmlNode node = doc.CreateNode (XmlNodeType.Element, SoapException.DetailElementName.Name,
				SoapException.DetailElementName.Namespace);

			XmlNode systemError = doc.CreateNode (XmlNodeType.Element, "systemerror",
				"http://www.mono-project/System");
			node.AppendChild (systemError);

			XmlNode code = doc.CreateNode (XmlNodeType.Element, "code",
				"http://www.mono-project/System");
			code.AppendChild (doc.CreateTextNode ("5000"));
			systemError.AppendChild (code);

			XmlNode description = doc.CreateNode (XmlNodeType.Element, "description",
				"http://www.mono-project/System");
			description.AppendChild (doc.CreateTextNode ("Invalid credentials."));
			systemError.AppendChild (description);

			throw new SoapException ("Failure processing request.", SoapException.ServerFaultCode,
				"Mono Web Service", systemError);
		}
	}
}
