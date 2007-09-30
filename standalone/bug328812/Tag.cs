using System.Xml;

namespace xmpp.common
{
	public class Tag : XmlElement
	{
		public Tag (string prefix, XmlQualifiedName qname, XmlDocument doc)
			: base (prefix, qname.Name, qname.Namespace, doc)
		{
		}
	}
}
