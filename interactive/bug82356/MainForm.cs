using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _propertyGrid
		// 
		_propertyGrid = new PropertyGrid ();
		_propertyGrid.Dock = DockStyle.Fill;
		_propertyGrid.HelpVisible = false;
		_propertyGrid.SelectedObject = new Config ();
		Controls.Add (_propertyGrid);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 200);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82356";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private PropertyGrid _propertyGrid;
}

public class Config
{
	private SdkLanguage _language = SdkLanguage.ja;

	[DefaultValue (SdkLanguage.en)]
	[System.ComponentModel.TypeConverter (typeof (EnumDescriptionConverter))]
	public SdkLanguage Language {
		get { return _language; }
		set { _language = value;
		}
	}
}

public enum SdkLanguage
{
	[Description ("French")]
	fr,
	[Description ("English")]
	en,
	[Description ("German")]
	de,
	[Description ("Italian")]
	it,
	[Description ("Japanese")]
	ja,
	[Description ("Korean")]
	ko,
	[Description ("Spanish")]
	es
}

public class EnumDescriptionConverter : System.ComponentModel.EnumConverter
{
	private System.Type enumType;

	public static string GetEnumDescription (Enum value)
	{
		FieldInfo fi = value.GetType ().GetField (value.ToString ());
		DescriptionAttribute [] attributes =
			(DescriptionAttribute []) fi.GetCustomAttributes (typeof (DescriptionAttribute), false);
		if (attributes.Length > 0) {
			return attributes [0].Description;
		} else {
			return value.ToString ();
		}
	}

	public static string GetEnumDescription (System.Type value, string name)
	{
		FieldInfo fi = value.GetField (name);
		DescriptionAttribute [] attributes =
			(DescriptionAttribute []) fi.GetCustomAttributes (typeof (DescriptionAttribute), false);
		if (attributes.Length > 0) {
			return attributes [0].Description;
		} else {
			return name;
		}
	}

	public static object GetEnumValue (System.Type value, string description)
	{
		FieldInfo [] fis = value.GetFields ();
		foreach (FieldInfo fi in fis) {
			DescriptionAttribute [] attributes =
				(DescriptionAttribute []) fi.GetCustomAttributes (typeof (DescriptionAttribute), false);
			if (attributes.Length > 0) {
				if (attributes [0].Description == description) {
					return fi.GetValue (fi.Name);
				}
			}
			if (fi.Name == description) {
				return fi.GetValue (fi.Name);
			}
		}
		return description;
	}

	public EnumDescriptionConverter (System.Type type)
		: base (type)
	{
		enumType = type;
	}

	public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof (string)) {
			if (value is Enum)
				return GetEnumDescription ((Enum) value);

			if (value is string)
				return GetEnumDescription (enumType, (string) value);
		}

		return base.ConvertTo (context, culture, value, destinationType);
	}

	public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string)
			return GetEnumValue (enumType, (string) value);

		if (value is Enum)
			return GetEnumDescription ((Enum) value);

		return base.ConvertFrom (context, culture, value);
	}
}

public class InstructionsForm : Form
{
	public InstructionsForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The value of Language property is \"Japanese\".{0}{0}" +
			"2. The color of the text of the Language combobox is black.{0}{0}" +
			"3. The text of the Language combobox is bold.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the dropdown arrow of the Language combobox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The items of the combobox are names of a few languages " +
			"(eg. French, English, ...).{0}{0}" +
			"2. The Japanese item is highlighted.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Select the English language in the combobox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of Language property is \"English\".{0}{0}" +
			"2. The color of the text of the Language combobox is black.{0}{0}" +
			"3. The text of the Language combobox is not bold.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (360, 200);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82356";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
