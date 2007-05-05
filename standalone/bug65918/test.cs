using System.IO;
using System.Text;
using System.Xml;

public class EntryPoint {
	public static void Main() {
		XmlTextWriter writer = new XmlTextWriter("test.xml", Encoding.UTF8);
		writer.Close();
		writer.Close();
	}
}
