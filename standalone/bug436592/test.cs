using System;

namespace SettingsTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Settings.Default.Reload ();
			Assert.AreEqual ("Local", Settings.Default.SteamGamePage, "#1");
			Settings.Default.SteamGamePage = "Mono";
			Assert.AreEqual ("Mono", Settings.Default.SteamGamePage, "#2");
			Settings.Default.Reload();
			Assert.AreEqual ("Local", Settings.Default.SteamGamePage, "#3");
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
	}
}
