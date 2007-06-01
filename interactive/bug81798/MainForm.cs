using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _statusBar
		// 
		_statusBar = new StatusBar ();
		Controls.Add (_statusBar);
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Attempt to make this form larger in size.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The form can be resized to 500 by 400 pixels.",
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
		ClientSize = new Size (350, 180);
		MaximumSize = new Size (500, 400);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81798";
		Load += new EventHandler (MainForm_Load);
		Resize += new EventHandler (MainForm_Resize);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_statusBar.Text = this.Size.ToString ();
	}

	void MainForm_Resize (object sender, EventArgs e)
	{
		_statusBar.Text = this.Size.ToString ();
	}

	private StatusBar _statusBar;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
