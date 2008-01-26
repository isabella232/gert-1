using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
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
		_propertyGrid.SelectedObject = new Config ();
		Controls.Add (_propertyGrid);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 240);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #354991";
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
	private string _text = "Some random text" + Environment.NewLine + "with line feeds";

	[Category ("Style")]
	[Description ("The backcolor of the text.")]
	[DefaultValue ("Nothing much")]
	[Editor (typeof (MultilineStringEditor), typeof (UITypeEditor))]
	public string Text {
		get { return _text; }
		set { _text = value; }
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
			"1. Drop down the editor for the Text item.{0}{0}" +
			"2. Modify the text in the editor.{0}{0}" +
			"3. Click on the label of the Text item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The new text is displayed as value for the Text item.",
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
		ClientSize = new Size (320, 200);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #354991";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
