using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Threading;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1)
			return 1;

		switch (args [0]) {
		case "write1":
			Thread.CurrentThread.CurrentCulture = new CultureInfo ("de-DE");
			Settings.Default.MaxIncome = 75665.43;
			Settings.Default.Location = new Rectangle (544, 20, 332, 50);
			Settings.Default.Save ();
			break;
		case "read1":
			Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US");
			Assert.AreEqual (75665.43, Settings.Default.MaxIncome, "#A1");
			Assert.AreEqual (new Rectangle (544, 20, 332, 50), Settings.Default.Location, "#A2");
			Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");
			Assert.AreEqual (75665.43, Settings.Default.MaxIncome, "#B1");
			Assert.AreEqual (new Rectangle (544, 20, 332, 50), Settings.Default.Location, "#B2");
			Thread.CurrentThread.CurrentCulture = new CultureInfo ("de-DE");
			Assert.AreEqual (75665.43, Settings.Default.MaxIncome, "#C1");
			Assert.AreEqual (new Rectangle (544, 20, 332, 50), Settings.Default.Location, "#C2");
			break;
		case "write2":
			Thread.CurrentThread.CurrentCulture = new CultureInfo ("de-DE");
			Settings.Default.MaxIncome = 4553.76;
			Settings.Default.Location = new Rectangle (214, 10, 42, 20);
			Settings.Default.Save ();
			break;
		case "read2":
			Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US");
			Assert.AreEqual (4553.76, Settings.Default.MaxIncome, "#A1");
			Assert.AreEqual (new Rectangle (214, 10, 42, 20), Settings.Default.Location, "#A2");
			Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");
			Assert.AreEqual (4553.76, Settings.Default.MaxIncome, "#B1");
			Assert.AreEqual (new Rectangle (214, 10, 42, 20), Settings.Default.Location, "#B2");
			Thread.CurrentThread.CurrentCulture = new CultureInfo ("de-DE");
			Assert.AreEqual (4553.76, Settings.Default.MaxIncome, "#C1");
			Assert.AreEqual (new Rectangle (214, 10, 42, 20), Settings.Default.Location, "#C2");
			break;
		default:
			Console.WriteLine ("Unsupported action: {0}", args [0]);
			return 2;
		}

		return 0;
	}
}

internal sealed partial class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = ((Settings) (ApplicationSettingsBase.Synchronized (new Settings ())));

	public static Settings Default {
		get {
			return defaultInstance;
		}
	}

	[UserScopedSettingAttribute ()]
	[DefaultSettingValueAttribute ("-8")]
	public double MaxIncome {
		get {
			return ((double) (this ["MaxIncome"]));
		}
		set {
			this ["MaxIncome"] = value;
		}
	}

	[UserScopedSettingAttribute ()]
	[DefaultSettingValueAttribute ("3599, 20, 30, 2")]
	public Rectangle Location {
		get {
			return ((Rectangle) (this ["Location"]));
		}
		set {
			this ["Location"] = value;
		}
	}
}
