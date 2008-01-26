using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
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
		Controls.Add (_propertyGrid);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 240);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #322446";
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

		Config conf = new Config ();
		conf.BackColor = Color.Blue;
		conf.Style = FontStyle.Strikeout;
		conf.UseStyle = false;
		_propertyGrid.SelectedObject = conf;
	}

	private PropertyGrid _propertyGrid;
}

public class Config
{
	private bool _useStyle = true;
	private FontStyle _style = FontStyle.Underline;
	private Color _backColor = Color.Red;

	[Category ("Style")]
	[Description ("The style to apply to text.")]
	[DefaultValue (FontStyle.Underline)]
	public FontStyle Style {
		get { return _style; }
		set { _style = value; }
	}

	[Category ("Behavior")]
	[Description ("Controls whether to apply style to an element.")]
	[DefaultValue (true)]
	public bool UseStyle {
		get { return _useStyle; }
		set { _useStyle = value; }
	}

	[Category ("Style")]
	[Description ("The size of the font.")]
	public Color BackColor
	{
		get { return _backColor; }
		set { _backColor = value; }
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
			"Steps to execute:{0}{0}" +
			"1. Drop down the colorpicker for the BackColor item.{0}{0}" +
			"2. Click the UseStyle item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The colorpicker closes.",
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
			"1. Drop down the colorpicker for the BackColor item.{0}{0}" +
			"2. Move focus to another window.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The colorpicker closes.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (320, 180);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #322446";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
