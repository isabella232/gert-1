using System;
using System.Net;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;

class Program
{
	[STAThread]
	static int Main ()
	{
		try {
			FaultService svc = new FaultService ();
			svc.Url = "http://" + IPAddress.Loopback.ToString () + ":8081/FaultService.asmx";
			svc.Run ();
			return 1;
		} catch (SoapException ex) {
			if (ex.Actor != "Mono Web Service")
				return 2;
			if (ex.Code != SoapException.ServerFaultCode)
				return 3;
			if (ex.Detail == null)
				return 4;
			if (ex.Detail.LocalName != "detail")
				return 5;
			if (ex.Detail.NamespaceURI != string.Empty)
				return 6;

			XmlNamespaceManager nsMgr = new XmlNamespaceManager (ex.Detail.OwnerDocument.NameTable);
			nsMgr.AddNamespace ("se", "http://www.mono-project/System");

			XmlElement systemError = (XmlElement) ex.Detail.SelectSingleNode (
				"se:systemerror", nsMgr);
			if (systemError == null)
				return 7;
			if (ex.InnerException != null)
				return 8;
			if (ex.Message != "Failure processing request.")
				return 9;
			return 0;
		}
	}
}

[System.Web.Services.WebServiceBindingAttribute (Name = "FaultServiceSoap", Namespace = "http://www.mono-project.com/")]
public class FaultService : System.Web.Services.Protocols.SoapHttpClientProtocol
{
	public FaultService ()
	{
		this.Url = "http://localhost/SoapFault/FaultService.asmx";
	}

	[System.Web.Services.Protocols.SoapDocumentMethodAttribute ("http://www.mono-project.com/Run", RequestNamespace = "http://www.mono-project.com/", ResponseNamespace = "http://www.mono-project.com/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
	public string Run ()
	{
		object [] results = this.Invoke ("Run", new object [0]);
		return ((string) (results [0]));
	}

	public System.IAsyncResult BeginRun (System.AsyncCallback callback, object asyncState)
	{
		return this.BeginInvoke ("Run", new object [0], callback, asyncState);
	}

	public string EndRun (System.IAsyncResult asyncResult)
	{
		object [] results = this.EndInvoke (asyncResult);
		return ((string) (results [0]));
	}
}
