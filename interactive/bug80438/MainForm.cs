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
		_propertyGrid.SelectedObject = new Config ();
		_propertyGrid.Size = new Size (405, 200);
		Controls.Add (_propertyGrid);
		// 
		// _resetButton
		//
		_resetButton = new Button ();
		_resetButton.Location = new Point (8, 210);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
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
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The PropertyGrid is cleared.",
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
		ClientSize = new Size (405, 380);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80438";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_propertyGrid.SelectedObject = null;
	}

	private PropertyGrid _propertyGrid;
	private Button _resetButton;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}

public class Config
{
	private string _FeedbackEmailAddress = "something";

	[Category ("Documentation")]
	[Description ("Whatever.")]
	[DefaultValue ("")]
	public string FeedbackEmailAddress
	{
		get { return _FeedbackEmailAddress; }
		set
		{
			_FeedbackEmailAddress = value;
		}
	}
}

