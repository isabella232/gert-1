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
		// _fileMenuItem
		// 
		_fileMenuItem = new MenuItem ();
		_fileMenuItem.Text = "&File";
		_mainMenu.MenuItems.Add (_fileMenuItem);
		// 
		// _newMenuItem
		// 
		_newMenuItem = new MenuItem ();
		_newMenuItem.Text = "&New";
		_newMenuItem.Click += new EventHandler (NewMenuItem_Click);
		_fileMenuItem.MenuItems.Add (_newMenuItem);
		// 
		// _windowMenuItem
		// 
		_windowMenuItem = new MenuItem ();
		_windowMenuItem.MdiList = true;
		_windowMenuItem.Text = "&Window";
		_mainMenu.MenuItems.Add (_windowMenuItem);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 200);
		IsMdiContainer = true;
		Location = new Point (250, 100);
		Menu = _mainMenu;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82806";
		Load += new EventHandler (MainForm_Load);
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

	void NewMenuItem_Click (object sender, EventArgs e)
	{
		Form child = new Form ();
		child.ClientSize = new Size (209, 100);
		child.MdiParent = this;
		child.Text = "Child " + (++formCount).ToString (CultureInfo.InvariantCulture);
		child.Show ();
	}

	private int formCount;
	private MainMenu _mainMenu;
	private MenuItem _fileMenuItem;
	private MenuItem _newMenuItem;
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
			"1. Click the File -> New menuitem.{0}{0}" +
			"2. Maximize the child form.{0}{0}" +
			"3. Click the File -> New menuitem.{0}{0}" +
			"4. Close the second child form.{0}{0}" +
			"5. Close the first child form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, the second child form is maximized.{0}{0}" +
			"2. On step 4, the first child form is still maximized.",
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
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the File -> New menuitem.{0}{0}" +
			"2. Click the File -> New menuitem.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1:{0}{0}" +
			"   * A new child form is displayed.{0}" +
			"   * The new child form is activated.{0}{0}" +
			"2. On step 2:{0}{0}" +
			"   * A new child form is displayed.{0}" +
			"   * The second child form is activated.{0}" +
			"   * The first child form has deactivated.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 285);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82806";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
