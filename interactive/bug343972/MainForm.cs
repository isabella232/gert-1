using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		_menuStrip = new MenuStrip ();
		_fileToolStripMenuItem = new ToolStripMenuItem ();
		_openToolStripMenuItem = new ToolStripMenuItem ();
		_userToolStripMenuItem = new ToolStripMenuItem ();
		_loginToolStripMenuItem = new ToolStripMenuItem ();
		_menuStrip.Items.AddRange (new ToolStripItem [] {
			_fileToolStripMenuItem,
			_userToolStripMenuItem});
		_menuStrip.TabIndex = 0;
		_fileToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
			_openToolStripMenuItem});
		_fileToolStripMenuItem.Text = "File";
		_openToolStripMenuItem.Text = "Open";
		_userToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
			_loginToolStripMenuItem
		});
		_userToolStripMenuItem.Text = "&User";
		_loginToolStripMenuItem.Text = "Login";
		Controls.Add (_menuStrip);
		MainMenuStrip = _menuStrip;
		_menuStrip.PerformLayout ();
		// 
		// MainForm
		// 
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #343972";
		Load += new EventHandler (MainForm_Load);
		PerformLayout ();
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

	private MenuStrip _menuStrip;
	private ToolStripMenuItem _fileToolStripMenuItem;
	private ToolStripMenuItem _openToolStripMenuItem;
	private ToolStripMenuItem _userToolStripMenuItem;
	private ToolStripMenuItem _loginToolStripMenuItem;
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
			"1. Press the Alt+U key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The User menu drops down.",
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
		ClientSize = new Size (300, 140);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #343972";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
