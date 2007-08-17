using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

class Program
{
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;

		using (Stream input = File.OpenRead (Path.Combine (dir, "test.xml"))) {
#if NET_2_0
			XmlSchemaSet schemas = new XmlSchemaSet ();
#else
			XmlSchemaCollection schemas = new XmlSchemaCollection ();
#endif
			schemas.Add (XmlSchema.Read (File.OpenRead (Path.Combine (dir, "spring-objects.xsd")), null));

			XmlReader reader = CreateValidatingReader (input, schemas, null);
			XmlDocument doc = new XmlDocument ();
			doc.Load (reader);
		}
	}

#if NET_2_0
	static XmlReader CreateValidatingReader(Stream stream, XmlSchemaSet schemas, ValidationEventHandler eventHandler)
	{
		XmlReaderSettings settings = new XmlReaderSettings();
		settings.Schemas.Add(schemas);
		settings.ValidationType = ValidationType.Schema;
		if (eventHandler != null)
			settings.ValidationEventHandler += eventHandler;
		return XmlReader.Create(stream, settings);
	}
#else
	static XmlReader CreateValidatingReader (Stream stream, XmlSchemaCollection schemas, ValidationEventHandler eventHandler)
	{
		XmlValidatingReader reader = new XmlValidatingReader (new XmlTextReader (stream));
		reader.Schemas.Add (schemas);
		reader.ValidationType = ValidationType.Schema;
		if (eventHandler != null)
			reader.ValidationEventHandler += eventHandler;
		return reader;
	}
#endif
}
