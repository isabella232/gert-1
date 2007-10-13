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
		// _fileMenu
		// 
		_fileMenu = new MenuItem ("&File");
		_fileMenu.MenuItems.Add (new MenuItem ("New"));
		_fileMenu.MenuItems.Add (new MenuItem ("Open"));
		_fileMenu.MenuItems.Add (new MenuItem ("Save"));
		_mainMenu.MenuItems.Add (_fileMenu);
		// 
		// _editMenu
		// 
		_editMenu = new MenuItem ("&Edit");
		_editMenu.MenuItems.Add (new MenuItem ("Copy"));
		_editMenu.MenuItems.Add (new MenuItem ("Cut"));
		_editMenu.MenuItems.Add (new MenuItem ("Paste"));
		_mainMenu.MenuItems.Add (_editMenu);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 50);
		Location = new Point (250, 100);
		Menu = _mainMenu;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #333668";
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

	private MainMenu _mainMenu;
	private MenuItem _fileMenu;
	private MenuItem _editMenu;
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
			"1. Click the File menu.{0}{0}" +
			"2. Use the arrow keys to navigate up and down.{0}{0}" +
			"3. Press the Right arrow key.{0}{0}" +
			"4. Press the Left arrow key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the arrow keys can used to move between " +
			"the items of the File menu.{0}{0}" +
			"2. On step 3, the Edit menu is opened and the Copy " +
			"menuitem is selected.{0}{0}" +
			"2. On step 4, the File menu is opened and the New " +
			"menuitem is selected.",
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
			"1. Click on the form.{0}{0}" +
			"2. Press and hold the Alt key..{0}{0}" +
			"3. Press the F4 key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The form is closed.",
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
		ClientSize = new Size (310, 310);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #333668";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
