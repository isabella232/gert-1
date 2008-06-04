using System;
using System.Net;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml;

class Client
{
	static void Main ()
	{
		Soap soap = new Soap ();
		XmlDocument req = new XmlDocument ();
		req.LoadXml ("<returnval><obj type='Folder'>group-d1</obj><propSet><name>childEntity</name><val><ManagedObjectReference type='Folder'>group-d33</ManagedObjectReference><ManagedObjectReference type='Folder'>group-d36</ManagedObjectReference><ManagedObjectReference type='Folder' >group-d2</ManagedObjectReference><ManagedObjectReference type='Datacenter' >datacenter-3</ManagedObjectReference></val></propSet></returnval>");
		
		XmlDocument resp = soap.RetrievePropertiesResponse (req);
		Assert.AreEqual ("RetrievePropertiesResponse", resp.DocumentElement.LocalName, "#1");
		Assert.IsTrue (resp.OuterXml.IndexOf ("group-d33") != -1, "#2");
		Assert.IsTrue (resp.OuterXml.IndexOf ("group-d36") != -1, "#3");
		Assert.IsTrue (resp.OuterXml.IndexOf ("group-d2") != -1, "#4");
		Assert.IsTrue (resp.OuterXml.IndexOf ("datacenter-3") != -1, "#5");
	}
}

[WebServiceBindingAttribute (Name = "Soap", Namespace = "urn:internalvim25")]
public class Soap : SoapHttpClientProtocol
{
	public Soap ()
	{
		this.Url = "http://" + IPAddress.Loopback.ToString () + ":8001";
	}

	[SoapDocumentMethodAttribute ("urn:internalvim25/RetrievePropertiesResponse", RequestNamespace = "urn:internalvim25", ResponseNamespace = "urn:internalvim25", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
	public XmlDocument RetrievePropertiesResponse (XmlDocument doc)
	{
		object [] results = this.Invoke ("RetrievePropertiesResponse", new object [] { doc });
		return ((XmlDocument) (results [0]));
	}
}
