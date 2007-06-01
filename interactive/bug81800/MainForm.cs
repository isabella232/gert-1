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
		_tabControl.Size = new Size (405, 140);
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The value of the FeedbackEmailAddress is \"something\".{0}{0}" +
			"2. The Name field has no value.",
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
		ClientSize = new Size (405, 300);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81800";
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
