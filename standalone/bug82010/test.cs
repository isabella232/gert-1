using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

class Program
{
	static void Main (string [] args)
	{
		string file = args [0];

		using (FileStream stream = new FileStream (file, FileMode.Open)) {
			XmlValidatingReader vr = new XmlValidatingReader (stream, XmlNodeType.Document, null);
			vr.Schemas.Add (null, "xml.xsd");
			vr.Schemas.Add (null, "CodeList.xsd");
			vr.ValidationType = ValidationType.Schema;
			vr.ValidationEventHandler += new ValidationEventHandler (ValidationHandler);
			while (vr.Read ()) ;
		}

#if NET_2_0
		XmlReaderSettings settings = new XmlReaderSettings ();
		settings.ValidationType = ValidationType.Schema;
		settings.Schemas.Add (null, "xml.xsd");
		settings.Schemas.Add (null, "CodeList.xsd");
		settings.ValidationEventHandler += new ValidationEventHandler (ValidationHandler);
		XmlReader reader = XmlReader.Create (file, settings);
		while (reader.Read ()) ;
#endif
	}

	static void ValidationHandler (object sender, ValidationEventArgs args)
	{
		Console.WriteLine ("***Validation error");
		Console.WriteLine ("\tSeverity:{0}", args.Severity);
		Console.WriteLine ("\tMessage:{0}", args.Message);
	}
}
