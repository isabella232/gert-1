using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

class MainTestCase
{
	static int Main ()
	{
		XmlSchema schema = XmlSchema.Read (new XmlTextReader ("schema.xsd"), null);

#if NET_2_0
		XmlReaderSettings settings = new XmlReaderSettings ();
		settings.ValidationType = ValidationType.Schema;
		settings.Schemas.Add (schema);

		XmlReader reader = XmlReader.Create (new StringReader (xml), settings);
		try {
			while (reader.Read ()) ;
			return 1;
		} catch (XmlSchemaValidationException) {
		} finally {
			reader.Close ();
		}
#else
		XmlValidatingReader validator = new XmlValidatingReader (xml, XmlNodeType.Document, null);
		validator.ValidationType = ValidationType.Schema;
		validator.Schemas.Add (schema);
		try {
			while (validator.Read ()) ;
			return 1;
		} catch (XmlSchemaException) {
		} finally {
			validator.Close ();
		}
#endif

		return 0;
	}

	static string xml = @"<test mode=""NOT A ENUMERATION VALUE""></test>";
}
