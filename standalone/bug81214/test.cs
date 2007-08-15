using System;
using System.Configuration;
using System.Xml;

public class Program
{
	static int Main ()
	{
#if NET_2_0
		CustomConfigSection config = (CustomConfigSection) ConfigurationManager.
			GetSection ("CustomConfig");
#else
		CustomConfig config = (CustomConfig) ConfigurationSettings.GetConfig (
			"CustomConfig");
#endif
		if (config == null)
			return 1;
		if (config.Mode != "Whatever")
			return 2;
		return 0;
	}
}

#if NET_2_0
public sealed class CustomConfigSection : ConfigurationSection
{
	static ConfigurationProperty modeProp;
	static ConfigurationPropertyCollection properties;

	private CustomConfigSection ()
	{
	}

	static CustomConfigSection ()
	{
		modeProp = new ConfigurationProperty ("mode", typeof (string), "RemoteOnly");
		properties = new ConfigurationPropertyCollection ();
		properties.Add (modeProp);
	}

	protected override void DeserializeSection (XmlReader reader)
	{
		base.DeserializeSection (reader);
	}

	protected override void Reset (ConfigurationElement parentElement)
	{
	}

	[ConfigurationProperty ("mode", DefaultValue = "RemoteOnly")]
	public string Mode
	{
		get { return (string) base [modeProp]; }
		set { base [modeProp] = value; }
	}

	protected override ConfigurationPropertyCollection Properties
	{
		get { return properties; }
	}
}
#else
public sealed class CustomConfigSection : IConfigurationSectionHandler
{
	private CustomConfigSection ()
	{
	}

	object IConfigurationSectionHandler.Create (object parent, object configContext, XmlNode section)
	{
		string mode = "RemoteOnly";

		if (section.Attributes ["mode"] != null) {
			mode = section.Attributes ["mode"].Value;
		}

		return new CustomConfig (mode);
	}
}

public sealed class CustomConfig
{
	public CustomConfig (string mode)
	{
		_mode = mode;
	}

	public string Mode {
		get { return _mode; }
	}

	private readonly string _mode;
}
#endif
