using System;
using System.Collections;
using System.Xml.Serialization;

public class EntryPoint
{
	static void Main ()
	{
		XmlReflectionImporter importer = new XmlReflectionImporter ();
		XmlTypeMapping map = importer.ImportTypeMapping (typeof (ArrayType));
		XmlSerializer xs = new XmlSerializer (map);
		xs.Serialize (Console.Out, new ArrayType ());
	}
}

public class ArrayType
{
	[XmlAttribute (DataType = "base64Binary")]
	public byte[][] bin1 = new byte[][] { new byte[] { 1, 2 }, new byte[] { 1, 2 } };
}
