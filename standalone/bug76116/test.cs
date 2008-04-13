using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

public class Program
{
	static void Main ()
	{
		XmlDocument doc = new XmlDocument ();
		doc.Load (new FileStream ("test.xsl", FileMode.Open));

		XslTransform t = new XslTransform ();
		t.Load (doc);
	}
}
