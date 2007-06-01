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
		_propertyGrid.HelpVisible = false;
		_propertyGrid.SelectedObject = new Config ();
		_propertyGrid.Size = new Size (405, 150);
		Controls.Add (_propertyGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Size = new Size (405, 190);
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. Click in the textbox for the FeedbackEmailAddress field.{0}{0}" +
			"2. Click in the textbox for the Name field.{0}{0}" +
			"3. Enter some text.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The entered text is immediately displayed.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// MainForm
		// 
		ClientSize = new Size (405, 350);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81791";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private PropertyGrid _propertyGrid;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}

public class Config
{
	private string _feedbackEmailAddress = "something";
	private string _name = null;

	[Category ("Documentation")]
	[Description ("Whatever.")]
	[DefaultValue ("")]
	public string FeedbackEmailAddress {
		get { return _feedbackEmailAddress; }
		set { _feedbackEmailAddress = value; }
	}

	[Category ("Documentation")]
	[DefaultValue ("XXX")]
	public string Name {
		get { return _name; }
		set { _name = value; }
	}
}
