using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

class Program
{
	static int Main ()
	{
		XmlDocument xml = DoLoad ();
		if (xml.FirstChild.Attributes ["name"].Value != "Bob")
			return 1;
		if (xml.FirstChild.Attributes ["address"].Value != "-")
			return 2;
		return 0;
	}

	static XmlDocument DoLoad ()
	{
		string schemaFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"customer.xsd");
		Stream stream = File.OpenRead (schemaFile);
		XmlSchema schema = XmlSchema.Read (stream, Program.DoValidationEvent);

		XmlReaderSettings settings = new XmlReaderSettings ();
		settings.Schemas.Add (schema);
		settings.ValidationEventHandler += Program.DoValidationEvent;
		settings.ValidationType = ValidationType.Schema;

		string xmlFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"test.xml");
		stream = File.OpenRead (xmlFile);
		XmlReader reader = XmlReader.Create (stream, settings);

		XmlDocument xml = new XmlDocument ();
		xml.Load (reader);

		return xml;
	}

	static void DoValidationEvent (object sender, ValidationEventArgs e)
	{
		Console.WriteLine ("{0}", e.Message);
	}
}
