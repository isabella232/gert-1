using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

class Program
{
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;

		XmlTextReader xtr = new XmlTextReader (Path.Combine (dir, "MyTestService.wsdl"));

#if NET_2_0
		XmlReaderSettings settings = new XmlReaderSettings ();
		settings.ValidationType = ValidationType.Schema;
		settings.Schemas.Add ("http://schemas.xmlsoap.org/wsdl/", "http://schemas.xmlsoap.org/wsdl/");
		settings.Schemas.Add ("http://schemas.xmlsoap.org/wsdl/http/", "http://schemas.xmlsoap.org/wsdl/http/");
		settings.Schemas.Add ("http://schemas.xmlsoap.org/wsdl/soap/", "http://schemas.xmlsoap.org/wsdl/soap/");
		settings.Schemas.Add ("http://schemas.xmlsoap.org/wsdl/soap12/", "http://schemas.xmlsoap.org/wsdl/soap12/wsdl11soap12.xsd");

		XmlReader vr = XmlReader.Create (xtr, settings);
#else
		XmlValidatingReader vr = new XmlValidatingReader (xtr);
		vr.ValidationType = ValidationType.Schema;
		vr.Schemas.Add ("http://schemas.xmlsoap.org/wsdl/", "http://schemas.xmlsoap.org/wsdl/");
		vr.Schemas.Add ("http://schemas.xmlsoap.org/wsdl/http/", "http://schemas.xmlsoap.org/wsdl/http/");
		vr.Schemas.Add ("http://schemas.xmlsoap.org/wsdl/soap/", "http://schemas.xmlsoap.org/wsdl/soap/");
#endif

		while (vr.Read ()) {
		}
		
	}
}
