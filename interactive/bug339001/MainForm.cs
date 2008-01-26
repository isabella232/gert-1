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
		_propertyGrid.Dock = DockStyle.Top;
		_propertyGrid.Height = 200;
		Controls.Add (_propertyGrid);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (120, 210);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 240);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #339001";
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

	void ResetButton_Click (object sender, EventArgs e)
	{
		_propertyGrid.ResetSelectedProperty ();
	}

	private PropertyGrid _propertyGrid;
	private Button _resetButton;
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
			"1. Enter the value \"Bad\" for the FontSize item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. An error dialog is displayed.{0}{0}" +
			"2. After closing the error dialog, the focus remains " +
			"on the FontSize item until the invalid value is corrected.",
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
			"1. Enter the value \"Bad\" for the Style item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. An error dialog is displayed.{0}{0}" +
			"2. After closing the error dialog, the focus remains " +
			"on the Style item until the invalid value is corrected.",
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
			"1. Enter the value \"Bad\" for the UseStyle item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. An error dialog is displayed.{0}{0}" +
			"2. After closing the error dialog, the focus remains " +
			"on the Style item until the invalid value is corrected.",
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
		ClientSize = new Size (320, 200);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #339001";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
