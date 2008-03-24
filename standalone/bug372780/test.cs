using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

using Mono.GeneratedSerializers.Literal;

class Program
{
	static void Main ()
	{
		A a = new A ();
		a.b = new B ();
		a.b.c = new C ();
		a.b.c.d = 5;
		a.b.c.e = "whatever";

		MemoryStream ms = new MemoryStream ();

		StreamWriter sw = new StreamWriter (ms, Encoding.UTF8);

		XmlSerializerContract contract = new XmlSerializerContract ();
		XmlSerializer xs = contract.GetSerializer (typeof (A));
		xs.Serialize (sw, a);

		ms.Position = 0;

		using (StreamReader sr = new StreamReader (ms, Encoding.UTF8, true)) {
			A ades = (A) xs.Deserialize (sr);
			Assert.IsNotNull (ades, "#1");
			Assert.IsNotNull (ades.b, "#2");
			Assert.IsNotNull (ades.b.c, "#3");
			Assert.AreEqual (5, ades.b.c.d, "#4");
			Assert.AreEqual ("whatever", ades.b.c.e, "#5");
		}
	}
}
