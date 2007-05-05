using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

class Test
{
	static void Main ()
	{
		IPEndPoint localEP = new IPEndPoint (IPAddress.Loopback, 5000);
		using (SocketResponder sr = new SocketResponder (localEP, new SocketRequestHandler (Response_Bug79988))) {
			sr.Start ();

			FooService service = new FooService ();
			service.Url = "http://" + IPAddress.Loopback.ToString () + ":5000/";

			int a;
			bool b;
			Elem [] e = service.Req ("x", out a, out b);
			Assert.IsNull (e, "#A1");
			Assert.AreEqual (0, a, "#A2");
			Assert.IsFalse (b, "#A3");
		}
	}

	static string Response_Bug79988 ()
	{
		return "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
			"<soap:Body>" +
			"<ReqResponse2 xmlns=\"urn:foo\">" +
			"<Hits>ERERE</Hits>" +
			"</ReqResponse2>" +
			"</soap:Body>" +
			"</soap:Envelope>";
	}
}

[WebServiceBindingAttribute (Name = "Foo", Namespace = "urn:foo")]
public class FooService : SoapHttpClientProtocol
{
	[SoapDocumentMethodAttribute ("", RequestElementName = "Req", RequestNamespace = "urn:foo", ResponseNamespace = "urn:foo", Use = SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
	[return: XmlElementAttribute ("Hits")]
	public Elem [] Req ([XmlAttributeAttribute ()] string arg, [XmlAttributeAttribute ()] out int status, [XmlAttributeAttribute ()] [XmlIgnoreAttribute ()] out bool statusSpecified)
	{
		object [] results = this.Invoke ("Req", new object [] { arg });
		status = ((int) (results [1]));
		statusSpecified = ((bool) (results [2]));
		return ((Elem []) (results [0]));
	}
}

[SerializableAttribute ()]
public class Elem
{
	private string attrField;

	[XmlAttributeAttribute ()]
	public string attr
	{
		get
		{
			return this.attrField;
		}
		set
		{
			this.attrField = value;
		}
	}
}
