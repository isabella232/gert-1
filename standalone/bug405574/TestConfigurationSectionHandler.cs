using System;
using System.Configuration;
using System.Xml;

public class TestConfigurationSectionHandler : IConfigurationSectionHandler
{
	public object Create (object parent, object configContext, XmlNode section)
	{
		return ConfigurationManager.OpenExeConfiguration ("").FilePath;
	}
}
