using System;
using System.Xml;

public delegate void XmlWriterClosedEventHandler (XmlWriter writer);

public class Test {
	public XmlWriterClosedEventHandler Closed;

	public void Whatever ()
	{
        Console.WriteLine ("This should not execute!");
	}

	static void Main () {
		Test t = new Test ();
		t.Closed += delegate (XmlWriter t) {
			t.Whatever ();
		};
		t.Closed(null);
	}
}
