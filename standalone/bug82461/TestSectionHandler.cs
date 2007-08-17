using System;
using System.Configuration;
using System.Xml;

namespace ConfigurationSectionTestCase
{
	public class TestSectionHandler : IConfigurationSectionHandler
	{
		public object Create (object parent, object configContext, XmlNode section)
		{
			if (configContext == null)
				throw new ArgumentException ("configContext should not be null when called from ASP.NET!");

			return this;
		}
	}
}
