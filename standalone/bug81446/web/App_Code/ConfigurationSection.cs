using System;
using System.Configuration;
using System.Xml;

namespace MonoTest
{
	public sealed class ConfigurationSection : System.Configuration.ConfigurationSection
	{
		static ConfigurationProperty nameProp;
		static ConfigurationPropertyCollection properties;

		private ConfigurationSection ()
		{
		}

		static ConfigurationSection ()
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
}
