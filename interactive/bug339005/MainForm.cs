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
		Text = "bug #339005";
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
		conf.FontSize = 12;
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
	private int _fontSize  = 9;

	[Category ("Style")]
	[Description ("The size of the font.")]
	[DefaultValue (9)]
	public int FontSize {
		get { return _fontSize; }
		set { _fontSize = value; }
	}

	[Category ("Style")]
	[Description ("The style to apply to text.")]
	[DefaultValue (FontStyle.Underline)]
	public FontStyle Style {
		get { return _style; }
		set { _style = value; }
	}

	[Category ("Style")]
	[Description ("Controls whether to apply style to an element.")]
	[DefaultValue (true)]
	public bool UseStyle {
		get { return _useStyle; }
		set { _useStyle = value; }
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
			"1. Double-click the label of the Style item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value cycles on each double-click.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (320, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #339005";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
