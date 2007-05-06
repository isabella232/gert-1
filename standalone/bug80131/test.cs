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
		using (SocketResponder sr = new SocketResponder (localEP, new SocketRequestHandler (Response_Bug80131))) {
			sr.Start ();

			FooService service = new FooService ();
			service.Url = "http://" + sr.LocalEndPoint.Address.ToString () + ":5000/";

			int a;
			bool b;
			Elem [] e = service.Req ("x", out a, out b);
			Assert.IsNotNull (e, "#B1");
			Assert.AreEqual (1, e.Length, "#B2");
			Assert.AreEqual ("whatever", e [0].attr, "#B2");
			Assert.AreEqual (5, a, "#B3");
			Assert.IsTrue (b, "#B4");
		}
	}

	static string Response_Bug80131 ()
	{
		return "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
			"<soap:Body>" +
			"<ReqResponse xmlns=\"urn:foo\" status=\"5\" statusSpecified=\"true\">" +
			"<Hits attr=\"whatever\">ERERE</Hits>" +
			"</ReqResponse>" +
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
