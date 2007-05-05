using System;
using System.Configuration;
using System.Xml;

namespace MonoTest
{
#if NET_2_0
	public sealed class TestConfigurationSection : ConfigurationSection
	{
		static ConfigurationProperty nameProp;
		static ConfigurationPropertyCollection properties;

		private TestConfigurationSection ()
		{
		}

		static TestConfigurationSection ()
		{
			nameProp = new ConfigurationProperty ("name", typeof (string), "Empty");
			properties = new ConfigurationPropertyCollection ();
			properties.Add (nameProp);
		}

		protected override void DeserializeSection (XmlReader reader)
		{
			base.DeserializeSection (reader);
		}

		[ConfigurationProperty ("name", DefaultValue = "Empty")]
		public string Name
		{
			get { return (string) base [nameProp]; }
			set { base [nameProp] = value; }
		}

		protected override ConfigurationPropertyCollection Properties
		{
			get { return properties; }
		}
	}
#else
	public sealed class TestConfigurationSection : IConfigurationSectionHandler
	{
		private TestConfigurationSection ()
		{
		}

		object IConfigurationSectionHandler.Create (object parent, object configContext, XmlNode section)
		{
			string name = "Empty";

			if (section.Attributes ["name"] != null) {
				name = section.Attributes ["name"].Value;
			}

			return new TestConfiguration (name);
		}
	}
#endif

	public sealed class TestConfigurationSectionHandler : IConfigurationSectionHandler
	{
		private TestConfigurationSectionHandler ()
		{
		}

		object IConfigurationSectionHandler.Create (object parent, object configContext, XmlNode section)
		{
			string name = "Empty";

			if (section.Attributes ["name"] != null) {
				name = section.Attributes ["name"].Value;
			}

			return new TestConfiguration (name);
		}
	}

	public sealed class TestConfiguration
	{
		public TestConfiguration (string name)
		{
			_name = name;
		}

		public string Name
		{
			get { return _name; }
		}

		private readonly string _name;
	}
}
