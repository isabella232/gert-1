using System;
using System.Configuration;

using MyApp.Windows.Forms.Properties;

class Program
{
	static void Main ()
	{
		Settings settings = Settings.Default;
		Assert.IsNotNull (settings.Server, "#1");
		Assert.AreEqual ("home", settings.Server, "#2");
		Assert.IsNull (settings.Properties ["User"], "#3");
		Assert.IsNull (settings.Properties ["ConfigureOnRun"], "#4");
		Assert.IsNull (settings.Properties ["AutoLogin"], "#5");
		Assert.AreEqual (1, settings.Properties.Count, "#6");
	}
}

namespace MyApp.Windows.Forms.Properties
{
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = ((Settings)
			(ApplicationSettingsBase.Synchronized (new Settings ())));

		public static Settings Default {
			get {
				return defaultInstance;
			}
		}

		[UserScopedSettingAttribute]
		[DefaultSettingValueAttribute ("localhost")]
		public string Server {
			get {
				return ((string) (this ["Server"]));
			}
			set {
				this ["Server"] = value;
			}
		}
	}
}
