using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;

class Program
{
	static int Main ()
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

		if (n.OuterXml != expected) {
			Console.WriteLine ("Expected result:");
			Console.WriteLine (expected);
			Console.WriteLine ();
			Console.WriteLine ("Actual result:");
			Console.WriteLine (n.OuterXml);
			return 1;
		}
		return 0;
	}
}
