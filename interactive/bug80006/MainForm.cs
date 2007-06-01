using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// mainMenu1
		// 
		_mainMenu = new MainMenu ();
		// 
		// _menuItem
		// 
		_menuItem = new MenuItem ();
		_menuItem.Index = 0;
		_menuItem.MergeType = MenuMerge.MergeItems;
		_menuItem.Text = "&File";
		_mainMenu.MenuItems.Add (_menuItem);
		// 
		// MainForm
		// 
		ClientSize = new Size (350, 400);
		IsMdiContainer = true;
		Menu = _mainMenu;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80006";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	[STAThread]
	void MainForm_Load (object sender, EventArgs e)
	{
		Form child = new ChildForm ();
		child.MdiParent = this;
		child.Show ();
	}

	private MainMenu _mainMenu;
	private MenuItem _menuItem;
}

public class ChildForm : Form
{
	public ChildForm ()
	{
		SuspendLayout ();
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
			"1. Click the File menu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A Close menu item is displayed.",
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
			"1. Maximize the child form.{0}{0}" +
			"2. Click the File menu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A Close menu item is displayed.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// mainMenu1
		// 
		_mainMenu = new MainMenu ();
		// 
		// _menuItem1
		// 
		_menuItem1 = new MenuItem ();
		_menuItem1.Index = 0;
		_menuItem1.MergeType = MenuMerge.MergeItems;
		_menuItem1.Text = "&File";
		_mainMenu.MenuItems.Add (_menuItem1);
		// 
		// _menuItem2
		// 
		_menuItem2 = new MenuItem ();
		_menuItem2.Index = 0;
		_menuItem2.MergeType = MenuMerge.MergeItems;
		_menuItem2.Text = "&Close";
		_menuItem1.MenuItems.Add (_menuItem2);
		// 
		// ChildForm
		// 
		ClientSize = new Size (292, 273);
		Menu = _mainMenu;
		Text = "Child";
		ResumeLayout (false);
	}

	private MainMenu _mainMenu;
	private MenuItem _menuItem1;
	private MenuItem _menuItem2;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
