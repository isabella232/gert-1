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
		Menu = _mainMenu;
		// 
		// _menuFile
		// 
		_menuFile = new MenuItem ();
		_menuFile.Text = "&File";
		_mainMenu.MenuItems.Add (_menuFile);
		// 
		// _menuItemTab
		// 
		_menuItemTab = new MenuItem ();
		_menuItemTab.Text = "Two\tWords";
		_menuFile.MenuItems.Add (_menuItemTab);
		// 
		// _menuItemLong
		// 
		_menuItemLong = new MenuItem ();
		_menuItemLong.Text = "It's a long long road that leads us to nowhere";
		_menuFile.MenuItems.Add (_menuItemLong);
		// 
		// MainForm
		// 
		ClientSize = new Size (292, 100);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #355196";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private MainMenu _mainMenu;
	private MenuItem _menuFile;
	private MenuItem _menuItemTab;
	private MenuItem _menuItemLong;
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
			"Steps to execute{0}{0}" +
			"1. Click the File menu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Two menu items are displayed:{0}{0}" +
			"  * one with a large space between the two words{0}" +
			"  * one with a long text that does not wrap",
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
		ClientSize = new Size (300, 180);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #355196";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
