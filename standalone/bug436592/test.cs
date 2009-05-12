using System;

namespace SettingsTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Settings.Default.Reload ();
			Assert.AreEqual (5, Settings.Default.ConnectionLimit, "#A1");
			Assert.AreEqual ("Local", Settings.Default.SteamGamePage, "#A2");
			Assert.IsNull (Settings.Default.UserName, "#A3");
			Settings.Default.ConnectionLimit = 7;
			Settings.Default.SteamGamePage = "Mono";
			Settings.Default.UserName = "drieseng";
			Assert.AreEqual (7, Settings.Default.ConnectionLimit, "#B1");
			Assert.AreEqual ("Mono", Settings.Default.SteamGamePage, "#B2");
			Assert.AreEqual ("drieseng", Settings.Default.UserName, "#B3");
			Settings.Default.Reload();
			Assert.AreEqual (5, Settings.Default.ConnectionLimit, "#C1");
			Assert.AreEqual ("Local", Settings.Default.SteamGamePage, "#C2");
			Assert.IsNull (Settings.Default.UserName, "#C3");
		}
	}

	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute ()]
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute ("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
	internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
	{
		private static Settings defaultInstance = ((Settings) (global::System.Configuration.ApplicationSettingsBase.Synchronized (new Settings ())));

		public static Settings Default {
			get {
				return defaultInstance;
			}
		}

		[global::System.Configuration.ApplicationScopedSettingAttribute ()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute ()]
		[global::System.Configuration.DefaultSettingValueAttribute ("Test")]
		public string SteamGamePage {
			get {
				return ((string) (this ["SteamGamePage"]));
			}
			set {
				this ["SteamGamePage"] = value;
			}
		}

		[global::System.Configuration.ApplicationScopedSettingAttribute ()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute ()]
		[global::System.Configuration.DefaultSettingValueAttribute ("5")]
		public int ConnectionLimit {
			get {
				return ((int) (this ["ConnectionLimit"]));
			}
			set {
				this ["ConnectionLimit"] = value;
			}
		}

		[global::System.Configuration.ApplicationScopedSettingAttribute ()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute ()]
		public string UserName {
			get {
				return ((string) (this ["UserName"]));
			}
			set {
				this ["UserName"] = value;
			}
		}
	}
}
