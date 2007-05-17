using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _mainMenu
		// 
		_mainMenu = new MainMenu ();
		// 
		// _windowMenuItem
		// 
		_windowMenuItem = new MenuItem ();
		_windowMenuItem.MdiList = true;
		_windowMenuItem.Text = "Windows";
		_mainMenu.MenuItems.Add (_windowMenuItem);
		// 
		// MainForm
		// 
		ClientSize = new Size (450, 500);
		IsMdiContainer = true;
		Menu = _mainMenu;
		Location = new Point (100, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80135";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_oneForm = new Form ();
		_oneForm.MdiParent = this;
		_oneForm.Text = "One";
		_oneForm.Show ();

		_twoForm = new Form ();
		_twoForm.MdiParent = this;
		_twoForm.Text = "Two";
		_twoForm.Show ();

		_threeForm = new Form ();
		_threeForm.MdiParent = this;
		_threeForm.Text = "Three";
		_threeForm.Show ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private Form _oneForm;
	private Form _twoForm;
	private Form _threeForm;
	private MainMenu _mainMenu;
	private MenuItem _windowMenuItem;
}

public class InstructionsForm : Form
{
	public InstructionsForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Location = new Point (8, 40);
		_tabControl.Dock = DockStyle.Fill;
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. MDI child forms One, Two and Three are visible.{0}{0}" +
			"2. MDI child form Three is the active MDI child.{0}{0}" +
			"3. MDI child form Three is displayed on top.",
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
		ClientSize = new Size (350, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80135";
		Controls.Add (_tabControl);
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
