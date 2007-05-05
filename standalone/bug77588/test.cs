using System;
using System.Collections;
using System.Xml.Serialization;

public class EntryPoint
{
	static void Main ()
	{
		XmlReflectionImporter importer = new XmlReflectionImporter ();
		XmlTypeMapping map = importer.ImportTypeMapping (typeof (MyList));
		XmlSerializer xs = new XmlSerializer (map);
		xs.Serialize (Console.Out, new MyList (null));
	}
}

public class MyList : ArrayList
{
	object container;

	// NOTE: MyList has no public constructor
	public MyList (object container) {
		this.container = container;
	}

	public object Container {
		get { return container; }
	}
}
