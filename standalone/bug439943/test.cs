using System;
using System.Collections.Specialized;
using System.Configuration;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Please specify action.");
			return 1;
		}

		switch (args [0]) {
		case "clear":
			Settings.Default.Name = null;
			Settings.Default.FirstNames = null;
			Settings.Default.Address = null;
			Settings.Default.Save ();
			break;
		case "write":
			StringCollection firstNames = new StringCollection ();
			firstNames.Add ("Miguel");
			firstNames.Add ("Atsushi");
			firstNames.Add ("Gonzalo");

			Settings.Default.Address = new Address ("Whatever", 50);
			Settings.Default.FirstNames = firstNames;
			Settings.Default.Name = "Mono";
			Settings.Default.Save ();
			break;
		case "read1":
			Assert.IsNotNull (Settings.Default.Address, "#1");
			Assert.AreEqual (50, Settings.Default.Address.HouseNumber, "#2");
			Assert.AreEqual ("Whatever", Settings.Default.Address.Street, "#3");
			Assert.IsNotNull (Settings.Default.FirstNames, "#4");
			Assert.AreEqual (3, Settings.Default.FirstNames.Count, "#5");
			Assert.AreEqual ("Miguel", Settings.Default.FirstNames [0], "#6");
			Assert.AreEqual ("Atsushi", Settings.Default.FirstNames [1], "#7");
			Assert.AreEqual ("Gonzalo", Settings.Default.FirstNames [2], "#8");
			Assert.AreEqual ("Mono", Settings.Default.Name, "#9");
			break;
		case "read2":
			Assert.AreEqual (string.Empty, Settings.Default.Name, "#1");
			Assert.IsNull (Settings.Default.FirstNames, "#2");
			Assert.IsNull (Settings.Default.Address, "#3");
			break;
		default:
			Console.WriteLine ("Unsupported action '{0}'.", args [0]);
			return 2;
		}

		return 0;
	}
}

internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = new Settings ();

	public static Settings Default
	{
		get { return defaultInstance; }
	}

	[UserScopedSettingAttribute]
	[SettingsSerializeAs (SettingsSerializeAs.String)]
	public string Name
	{
		get { return ((string) (this ["Name"])); }
		set { this ["Name"] = value; }
	}

	[UserScopedSettingAttribute]
	[SettingsSerializeAs (SettingsSerializeAs.Xml)]
	public StringCollection FirstNames
	{
		get { return ((StringCollection) (this ["FirstNames"])); }
		set { this ["FirstNames"] = value; }
	}

	[UserScopedSettingAttribute]
	[SettingsSerializeAs (SettingsSerializeAs.Binary)]
	public Address Address
	{
		get { return ((Address) (this ["Address"])); }
		set { this ["Address"] = value; }
	}
}

[Serializable]
class Address
{
	public Address ()
	{
	}

	public Address (string street, int houseNumber)
	{
		this.Street = street;
		this.HouseNumber = houseNumber;
	}

	public string Street;
	public int HouseNumber;
}
