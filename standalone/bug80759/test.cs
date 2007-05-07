using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

class Program
{
	static int Main ()
	{
		Foo foo = new Foo ();
		foo.Test = "BAR";
		foo.NullableInt = 10;

		XmlSerializer serializer = new XmlSerializer (typeof (Foo));

		MemoryStream stream = new MemoryStream ();

		serializer.Serialize (stream, foo);
		stream.Position = 0;
		foo = (Foo) serializer.Deserialize (stream);

		if (foo.Test != "BAR")
			return 1;
		if (foo.NullableInt != 10)
			return 2;

		foo.NullableInt = null;
		stream = new MemoryStream ();
		serializer.Serialize (stream, foo);
		stream.Position = 0;
		foo = (Foo) serializer.Deserialize (stream);

		if (foo.Test != "BAR")
			return 3;
		if (foo.NullableInt != null)
			return 4;

		return 0;
	}
}

public class Foo
{
	public string Test;
	public int? NullableInt;

	[XmlIgnore]
	public bool NullableIntSpecified
	{
		get { return NullableInt.HasValue; }
	}
}
