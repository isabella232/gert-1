using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

class Program
{
	static int Main ()
	{
		XmlReflectionImporter ri = new XmlReflectionImporter ("NSPrimitive");
		XmlSchemas schemas = new XmlSchemas ();
		XmlSchemaExporter sx = new XmlSchemaExporter (schemas);
		XmlTypeMapping tm = ri.ImportTypeMapping (typeof (int));
		sx.ExportTypeMapping (tm);

		StringWriter sw = new StringWriter ();
		schemas[0].Write (sw);

		int exitCode = 0;

		exitCode += Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
			"<?xml version=\"1.0\" encoding=\"utf-16\"?>{0}" +
			"<xs:schema xmlns:tns=\"NSPrimitive\" elementFormDefault=\"qualified\" targetNamespace=\"NSPrimitive\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">{0}" +
			"  <xs:element name=\"int\" type=\"xs:int\" />{0}" +
			"</xs:schema>", Environment.NewLine), sw.ToString (), "#1");

		ri = new XmlReflectionImporter ("NSString");
		schemas = new XmlSchemas ();
		sx = new XmlSchemaExporter (schemas);
		tm = ri.ImportTypeMapping (typeof (string));
		sx.ExportTypeMapping (tm);

		sw = new StringWriter ();
		schemas[0].Write (sw);

		exitCode += Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
			"<?xml version=\"1.0\" encoding=\"utf-16\"?>{0}" +
			"<xs:schema xmlns:tns=\"NSString\" elementFormDefault=\"qualified\" targetNamespace=\"NSString\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">{0}" +
			"  <xs:element name=\"string\" nillable=\"true\" type=\"xs:string\" />{0}" +
			"</xs:schema>", Environment.NewLine), sw.ToString (), "#2");

		ri = new XmlReflectionImporter ("NSQName");
		schemas = new XmlSchemas ();
		sx = new XmlSchemaExporter (schemas);
		tm = ri.ImportTypeMapping (typeof (XmlQualifiedName));
		sx.ExportTypeMapping (tm);

		sw = new StringWriter ();
		schemas[0].Write (sw);

		exitCode += Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
			"<?xml version=\"1.0\" encoding=\"utf-16\"?>{0}" +
			"<xs:schema xmlns:tns=\"NSQName\" elementFormDefault=\"qualified\" targetNamespace=\"NSQName\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">{0}" +
#if NET_2_0
			"  <xs:element name=\"QName\" nillable=\"true\" type=\"xs:QName\" />{0}" +
#else
			"  <xs:element name=\"QName\" type=\"xs:QName\" />{0}" +
#endif
			"</xs:schema>", Environment.NewLine), sw.ToString (), "#3");

		ri = new XmlReflectionImporter ("NSDateTime");
		schemas = new XmlSchemas ();
		sx = new XmlSchemaExporter (schemas);
		tm = ri.ImportTypeMapping (typeof (DateTime));
		sx.ExportTypeMapping (tm);

		sw = new StringWriter ();
		schemas[0].Write (sw);

		exitCode += Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
			"<?xml version=\"1.0\" encoding=\"utf-16\"?>{0}" +
			"<xs:schema xmlns:tns=\"NSDateTime\" elementFormDefault=\"qualified\" targetNamespace=\"NSDateTime\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">{0}" +
			"  <xs:element name=\"dateTime\" type=\"xs:dateTime\" />{0}" +
			"</xs:schema>", Environment.NewLine), sw.ToString (), "#4");

		ri = new XmlReflectionImporter ("NSByteArray");
		schemas = new XmlSchemas ();
		sx = new XmlSchemaExporter (schemas);
		tm = ri.ImportTypeMapping (typeof (byte[]));
		sx.ExportTypeMapping (tm);

		sw = new StringWriter ();
		schemas[0].Write (sw);

		exitCode += Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
			"<?xml version=\"1.0\" encoding=\"utf-16\"?>{0}" +
			"<xs:schema xmlns:tns=\"NSByteArray\" elementFormDefault=\"qualified\" targetNamespace=\"NSByteArray\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">{0}" +
			"  <xs:element name=\"base64Binary\" nillable=\"true\" type=\"xs:base64Binary\" />{0}" +
			"</xs:schema>", Environment.NewLine), sw.ToString (), "#5");

		ri = new XmlReflectionImporter ("NSInt32Array");
		schemas = new XmlSchemas ();
		sx = new XmlSchemaExporter (schemas);
		tm = ri.ImportTypeMapping (typeof (int[]));
		sx.ExportTypeMapping (tm);

		sw = new StringWriter ();
		schemas[0].Write (sw);

		exitCode += Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
			"<?xml version=\"1.0\" encoding=\"utf-16\"?>{0}" +
			"<xs:schema xmlns:tns=\"NSInt32Array\" elementFormDefault=\"qualified\" targetNamespace=\"NSInt32Array\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">{0}" +
			"  <xs:element name=\"ArrayOfInt\" nillable=\"true\" type=\"tns:ArrayOfInt\" />{0}" +
			"  <xs:complexType name=\"ArrayOfInt\">{0}" +
			"    <xs:sequence>{0}" +
			"      <xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"int\" type=\"xs:int\" />{0}" +
			"    </xs:sequence>{0}" +
			"  </xs:complexType>{0}" +
			"</xs:schema>", Environment.NewLine), sw.ToString (), "#6");

		ri = new XmlReflectionImporter ("NSSimpleClassArray");
		schemas = new XmlSchemas ();
		sx = new XmlSchemaExporter (schemas);
		tm = ri.ImportTypeMapping (typeof (SimpleClass[]));
		sx.ExportTypeMapping (tm);

		sw = new StringWriter ();
		schemas[0].Write (sw);

		exitCode += Assert.AreEqual (string.Format (CultureInfo.InvariantCulture,
			"<?xml version=\"1.0\" encoding=\"utf-16\"?>{0}" +
			"<xs:schema xmlns:tns=\"NSSimpleClassArray\" elementFormDefault=\"qualified\" targetNamespace=\"NSSimpleClassArray\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">{0}" +
			"  <xs:element name=\"ArrayOfSimpleClass\" nillable=\"true\" type=\"tns:ArrayOfSimpleClass\" />{0}" +
			"  <xs:complexType name=\"ArrayOfSimpleClass\">{0}" +
			"    <xs:sequence>{0}" +
			"      <xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"SimpleClass\" nillable=\"true\" type=\"tns:SimpleClass\" />{0}" +
			"    </xs:sequence>{0}" +
			"  </xs:complexType>{0}" +
			"  <xs:complexType name=\"SimpleClass\" />{0}" +
			"</xs:schema>", Environment.NewLine), sw.ToString (), "#7");

		return exitCode;
	}

	public class Assert
	{
		public static int AreEqual (string a, string b, string comment)
		{
			if (a != b) {
				Console.WriteLine ("[{3}]{0}Expected: {0}{1}{0}Actual: {0}{2}",
					Environment.NewLine, a, b, comment);
				return 1;
			}
			return 0;
		}
	}
}

public class SimpleClass
{
}
