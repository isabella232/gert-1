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
		settings.ValidationType = ValidationType.None;

		XmlSchemaSet schemaSet = new XmlSchemaSet();
		schemaSet.Add(schema);

		XmlReader reader = XmlReader.Create (new StringReader (xml), settings);

		XmlNamespaceManager manager = new XmlNamespaceManager (reader.NameTable);
		XmlSchemaValidator validator = new XmlSchemaValidator (reader.NameTable,
			schemaSet, manager, XmlSchemaValidationFlags.None);
		validator.Initialize ();
		validator.ValidateElement ("test", string.Empty, null);
		try {
			validator.ValidateAttribute ("mode", string.Empty, "NOT A ENUMERATION VALUE", null);
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
