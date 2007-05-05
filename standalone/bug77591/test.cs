using System;
using System.Xml.Serialization;

public class EntryPoint
{
	static int Main ()
	{
		XmlReflectionImporter importer = new XmlReflectionImporter ();
		try {
			importer.ImportTypeMapping (typeof (SimpleClass));
			return 1;
		} catch (InvalidOperationException) {
            return 0;
		}
	}
}

public class SimpleClass
{
	[XmlTextAttribute (typeof (byte[]))]
	public string something = null;
}
