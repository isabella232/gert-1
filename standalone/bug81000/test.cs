using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

public class Program
{
	static int Main ()
	{
		XmlReaderSettings xmlReaderSettings = new XmlReaderSettings ();
		xmlReaderSettings.ProhibitDtd = false;
		xmlReaderSettings.XmlResolver = new Resolver ();

		string xml = "<!DOCTYPE xsl:stylesheet SYSTEM \"foo.dtd\"><root>&alpha;</root>";

		XmlReader reader = XmlReader.Create (new StringReader (xml), xmlReaderSettings);
		reader.Read ();
		reader.Read ();
		reader.Read ();
		if (reader.Value != "bravo")
			return 1;
		if (!reader.Read ())
			return 1;
		if (reader.Read ())
			return 1;
		return 0;
	}
}

public class Resolver : XmlResolver
{
	public override ICredentials Credentials {
		set {
		}
	}

	public override object GetEntity (Uri absoluteUri, string role, Type type)
	{
		return new MemoryStream (Encoding.UTF8.GetBytes ("<!ENTITY alpha \"bravo\">"));
	}
}
