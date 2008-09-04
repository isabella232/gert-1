using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

class Program
{
	static void Main (string [] args)
	{
		string xsd = @"
			<xs:schema xmlns:xs='http://www.w3.org/2001/XMLSchema'>
				<xs:element name='TestClass'>
					<xs:complexType>
						<xs:sequence>
							<xs:element name='UnknownItemSerializer'
								type='UnknownItemSerializerType' />
						</xs:sequence>
					</xs:complexType>
				</xs:element>
				<xs:complexType name='UnknownItemSerializerType'>
					<xs:sequence>
						<xs:element name='DerivedClass_1'>
							<xs:complexType>
								<xs:sequence>
									<xs:element name='value' type='xs:integer' />
								</xs:sequence>
							</xs:complexType>
						</xs:element>
					</xs:sequence>
					<xs:attribute name='type' type='xs:string' use='required' />
				</xs:complexType>
			</xs:schema>
			";

		TestClass a = new TestClass ();
		DerivedClass_1 d1 = new DerivedClass_1 ();

		a.Item = d1;
		String s = a.ToString ();

		XmlTextReader xtr = new XmlTextReader (new StringReader (s));

		XmlValidatingReader vr = new XmlValidatingReader (xtr);
		vr.Schemas.Add (XmlSchema.Read (new StringReader (xsd), null));
		vr.ValidationType = ValidationType.Schema;

		while (vr.Read ()) {
		}

	}
}

public class UnknownItemSerializer : IXmlSerializable
{
	public BaseClass Item;

	public UnknownItemSerializer ()
	{
	}

	public UnknownItemSerializer (BaseClass item)
	{
		this.Item = item;
	}

	public static implicit operator UnknownItemSerializer (BaseClass p)
	{
		return p == null ? null : new UnknownItemSerializer (p);
	}

	public static implicit operator BaseClass (UnknownItemSerializer p)
	{
		return p == null ? null : p.Item;
	}

	public XmlSchema GetSchema ()
	{
		return null;
	}

	public void ReadXml (XmlReader reader)
	{
		return;
	}

	public void WriteXml (XmlWriter writer)
	{
		writer.WriteAttributeString ("type", String.Format ("{0}, {1}",
			Item.GetType ().ToString (),
			Item.GetType ().Assembly.ToString ()));
		new XmlSerializer (Item.GetType ()).Serialize (writer, Item);
	}
}

public class TestClass
{
	public BaseClass Item;

	public override string ToString ()
	{
		string result = string.Empty;

		using (MemoryStream stream = new MemoryStream ()) {
			using (StreamReader sr = new StreamReader (stream)) {
				XmlTextWriter writer = null;

				try {
					writer = new XmlTextWriter (stream, System.Text.Encoding.UTF8);
					XmlAttributes attrs = new XmlAttributes ();
					XmlElementAttribute attr = new XmlElementAttribute ();
					attr.ElementName = "UnknownItemSerializer";
					attr.Type = typeof (UnknownItemSerializer);
					attrs.XmlElements.Add (attr);
					XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides ();
					attrOverrides.Add (typeof (TestClass), "Item", attrs);

					XmlSerializer serializer = new XmlSerializer (this.GetType (), attrOverrides);
					serializer.Serialize (writer, this);

					stream.Position = 0;
					result = sr.ReadToEnd ();
				} finally {
					if (writer != null)
						writer.Close ();
				}
			}
		}

		return result;
	}
}

public class BaseClass
{
}

public class DerivedClass_1 : BaseClass
{
	public int value = 10;
}

public class DerivedClass_2 : BaseClass
{
	public string strValue = "testString";
}
