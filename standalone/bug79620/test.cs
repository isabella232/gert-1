using System;
using System.IO;
using System.Xml;

public class test_t {
	static int Main() {
		using (StreamReader sr = new StreamReader ("test.xml")) {
#if NET_2_0
			try {
				new XmlDocument ().LoadXml (sr.ReadToEnd ());
				return 1;
			} catch (XmlException ex) {
				return ex.Message.Contains ("undeclared entity 'nbsp'") ? 0 : 2;
			}
#else
			new XmlDocument ().LoadXml (sr.ReadToEnd ());
			return 0;
#endif
		}
	}
}
