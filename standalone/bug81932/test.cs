using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

class Program
{
	static void Main ()
	{
		Test1 ();
		Test2 ();
	}

	static void Test1 ()
	{
		string xml = "<root><child1><nest1><nest2>hello!</nest2></nest1></child1><child2/><child3/></root>";
		XmlReader r = new XmlTextReader (new StringReader (xml));

		while (r.Read ()) {
			if (r.Name == "child1")
				break;
		}

		XPathDocument d = new XPathDocument (r);
		XPathNavigator n = d.CreateNavigator ();
		string expected = string.Format ("<child1>{0}  <nest1>{0}    <nest2>hello!</nest2>{0}  </nest1>{0}</child1>{0}<child2 />{0}<child3 />",
			Environment.NewLine);

		Assert.AreEqual (expected, n.OuterXml, "#1");
	}

	static void Test2 ()
	{
		XmlSchemaSet schemaSet = new XmlSchemaSet ();
		schemaSet.Add (null, "test.xsd");

		XmlReaderSettings settings = new XmlReaderSettings ();
		settings.ValidationType = ValidationType.Schema;
		settings.CloseInput = true;
		settings.Schemas.Add (schemaSet);

		XmlReader r = XmlReader.Create ("test.xml", settings);
		XPathDocument d = new XPathDocument (r);
		d.CreateNavigator ();
	}
}
