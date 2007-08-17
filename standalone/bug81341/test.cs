using System;
using System.Collections.Generic;
using System.Xml.Serialization;

class Program
{
	static int Main (string [] args)
	{
		try {
			new XmlSerializer (typeof (IList<string>));
			return 1;
		} catch (NotSupportedException) {
			return 0;
		}
	}
}
