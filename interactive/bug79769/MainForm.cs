using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// MainForm
		// 
		ClientSize = new Size (350, 350);
		IsMdiContainer = true;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79769";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		ChildForm f = new ChildForm ();
		f.MdiParent = this;
		f.Show ();
	}
}

class ChildForm : Form
{
	public ChildForm ()
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Maximize the MDI parent window.{0}{0}" +
			"2. Maximize the MDI child window.{0}{0}" +
			"3. Unmaximize the MDI parent window.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The control box is visible on the MDI child window.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// ChildForm
		// 
		Text = "Child";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
