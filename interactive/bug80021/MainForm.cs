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
			"1. The form cannot be resized to more than 500 by 600 pixels.",
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
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Reduce the size of the window to less than its maximum size.{0}{0}" +
			"2. Click the Maximize Window icon in the title bar.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The form is moved to the top-left corner of the screen.{0}{0}" +
			"2. The size of the form changed to its maximum size.{0}{0}" +
			"3. The left and right borders of the form are not removed.",
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
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Move the window to a specific position on the screen.{0}{0}" +
			"2. Reduce the size of the window to less than its maximum size.{0}{0}" +
			"3. Click the Maximize Window icon in the title bar.{0}{0}" +
			"4. Click the Unmaximize Window icon in the title bar.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The form is moved back to the position it had in step 2.{0}{0}" +
			"2. The size of the form is restored back to the size it had in " +
			"step 2.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// MainForm
		//
		ClientSize = new Size (350, 320);
		MaximumSize = new Size (500, 600);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80021";
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
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
