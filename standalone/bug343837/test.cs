using System;
using System.Configuration;

namespace A.B.Properties
{
	class Program
	{
		static void Main ()
		{
			Settings settings = new Settings ();
			Assert.IsNull (settings.CallUpgrade, "#1");
			Assert.IsNotNull (settings.IncludeModel, "#2");
			Assert.AreEqual ("OK", settings.IncludeModel, "#3");
			Assert.AreEqual (2, settings.Properties.Count, "#4");
		}
	}

	class Settings : ApplicationSettingsBase
	{
		[UserScopedSettingAttribute ()]
		public string CallUpgrade {
			get {
				return (string) this ["CallUpgrade"];
			}
			set {
				this ["CallUpgrade"] = value;
			}
		}

		[UserScopedSettingAttribute ()]
		public string IncludeModel {
			get {
				return (string) this ["IncludeModel"];
			}
			set {
				this ["IncludeModel"] = value;
			}
		}
	}
}
