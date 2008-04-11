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

		XmlReader vr = XmlReader.Create (xtr, settings);
#else
		XmlValidatingReader vr = new XmlValidatingReader (xtr);
		vr.ValidationType = ValidationType.Schema;
		vr.Schemas.Add ("http://schemas.xmlsoap.org/wsdl/", "http://schemas.xmlsoap.org/wsdl/");
#endif

		while (vr.Read ()) {
		}
	}
}
