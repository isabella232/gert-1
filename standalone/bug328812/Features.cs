using System.Xml;
using xmpp.common;

namespace xmpp.core
{
	public class Features : Tag
	{
		public Features (string prefix, XmlQualifiedName qname, XmlDocument doc)
			: base (prefix, qname, doc)
		{
		}
	}
}
