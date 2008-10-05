using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using bug432366.Properties;

namespace bug432366
{
	class Program
	{
		static void Main (string [] args)
		{
			SettingsContext s = Settings.Default.Context;

			Assert.AreEqual (3, s.Count, "#A1");
			Assert.IsNotNull (s ["GroupName"], "#A2");
			Assert.AreEqual ("bug432366.Properties.Settings", s ["GroupName"], "#A3");
			Assert.IsNotNull (s ["SettingsKey"], "#A4");
			Assert.AreEqual ("", s ["SettingsKey"], "#A5");
			Assert.IsNotNull (s ["SettingsClassType"], "#A6");
			Assert.AreEqual (typeof (Settings), s ["SettingsClassType"], "#A7");

			Assert.AreEqual (1, Settings.Default.Providers.Count, "#B1");
			SettingsProvider provider = Settings.Default.Providers ["LocalFileSettingsProvider"];
			Assert.IsNotNull (provider, "#B2");
#if MONO
			Assert.AreEqual ("", provider.ApplicationName, "#B3");
#else
			Assert.AreEqual ("bug432366", provider.ApplicationName, "#B3");
#endif
			Assert.AreEqual ("LocalFileSettingsProvider", provider.Description, "#B4");
			Assert.AreEqual ("LocalFileSettingsProvider", provider.Name, "#B5");

			SettingsPropertyValueCollection values = provider.GetPropertyValues (
				Settings.Default.Context, Settings.Default.Properties);
			Assert.IsNotNull (values, "#C1");
			Assert.AreEqual (1, values.Count, "#C2");

			SettingsPropertyValue value = values ["BugReport_Service"];
			Assert.IsNotNull (value, "#D1");
			Assert.AreEqual ("BugReport_Service", value.Name, "#D2");
			Assert.AreEqual ("http://localhost:8080/index.asmx", value.PropertyValue, "#D3");
		}
	}
}

namespace bug432366.Properties
{
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute ()]
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute ("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
	internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
	{
		private static Settings defaultInstance = ((Settings) (global::System.Configuration.ApplicationSettingsBase.Synchronized (new Settings ())));

		public static Settings Default
		{
			get
			{
				return defaultInstance;
			}
		}

		[global::System.Configuration.ApplicationScopedSettingAttribute ()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute ()]
		[global::System.Configuration.SpecialSettingAttribute (global::System.Configuration.SpecialSetting.WebServiceUrl)]
		[global::System.Configuration.DefaultSettingValueAttribute ("http://172.20.107.70:8080/index.asmx")]
		public string BugReport_Service
		{
			get
			{
				return ((string) (this ["BugReport_Service"]));
			}
		}
	}
}
