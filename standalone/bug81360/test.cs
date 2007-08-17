using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

class Program
{
	static void Main (string [] args)
	{
		string schemaFile = "bug.xsd";
		XmlTextReader treader = new XmlTextReader (schemaFile);

		XmlSchema sc = XmlSchema.Read (treader, null);
		sc.Compile (null);

		string page =
			"<body xmlns=\"" + sc.TargetNamespace + "\">"
			+ "<div>"
			+ "</div>"
			+ "</body>";

		System.Xml.XmlTextReader reader = new XmlTextReader (new StringReader (page));
		try {
			XmlValidatingReader validator = new System.Xml.XmlValidatingReader (reader);
			validator.Schemas.Add (sc);
			validator.ValidationType = ValidationType.Schema;
			validator.EntityHandling = EntityHandling.ExpandCharEntities;
			while (validator.Read ()) {
			}
		} finally {
			reader.Close ();
		}
	}
}
