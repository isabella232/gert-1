using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _statusBar
		// 
		_statusBar = new StatusBar ();
		Controls.Add (_statusBar);
		// 
		// _mainMenu
		// 
		_mainMenu = new MainMenu ();

		// 
		// _fileMenu
		// 
		_fileMenuItem = new MenuItem ();
		_fileMenuItem.Text = "&File";
		_mainMenu.MenuItems.Add (_fileMenuItem);
		// 
		// openToolStripMenuItem
		// 
		_openMenuItem = new MenuItem ();
		_openMenuItem.Text = "&Open";
		_openMenuItem.Click += new EventHandler (OpenMenuItem_Click);
		_fileMenuItem.MenuItems.Add (_openMenuItem);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 300);
		IsMdiContainer = true;
		Location = new Point (200, 100);
		Menu = _mainMenu;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81409";
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

		OutputCounters ();
	}

	void OpenMenuItem_Click (object sender, EventArgs e)
	{
		ChildForm child = new ChildForm ();
		child.MdiParent = this;
		child.Text = "Child " + _childFormNumber++;
		child.Activated += new EventHandler (ChildForm_Activated);
		child.Deactivate += new EventHandler (ChildForm_Deactivate);
		child.Show ();
	}

	void ChildForm_Activated (object sender, EventArgs e)
	{
		_activated++;
		OutputCounters ();
	}

	void ChildForm_Deactivate (object sender, EventArgs e)
	{
		_deactivated++;
		OutputCounters ();
	}

	void OutputCounters ()
	{
		_statusBar.Text = string.Format (CultureInfo.InvariantCulture,
			"Activated: {0}, Deactivated: {1}", _activated,
			_deactivated);
	}

	private int _childFormNumber;
	private int _activated;
	private int _deactivated;
	private StatusBar _statusBar;
	private MainMenu _mainMenu;
	private MenuItem _fileMenuItem;
	private MenuItem _openMenuItem;
}

class ChildForm : Form
{
	public ChildForm ()
	{
		// 
		// ChildForm
		// 
		ClientSize = new Size (150, 150);
	}
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. In the File menu, select Open.{0}{0}" +
			"2. Close the child form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the status bar contains the following text:{0}{0}" +
			"   Activated: 1, Deactivated: 0{0}{0}" +
			"2. On step 2, the status bar contains the following text:{0}{0}" +
			"   Activated: 1, Deactivated: 1",
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
			"1. In the File menu, select Open.{0}{0}" +
			"2. In the File menu, select Open.{0}{0}" +
			"3. Click the Child 1 form.{0}{0}" +
			"4. Click the Child 2 form.{0}{0}" +
			"5. Close the Child 2 form.{0}{0}" +
			"6. Close the Child 1 form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the status bar contains the following text:{0}{0}" +
			"   Activated: 2, Deactivated: 1{0}{0}" +
			"2. On step 2, the status bar contains the following text:{0}{0}" +
			"   Activated: 3, Deactivated: 2{0}{0}" +
			"3. On step 3, the status bar contains the following text:{0}{0}" +
			"   Activated: 4, Deactivated: 3{0}{0}" +
			"4. On step 4, the status bar contains the following text:{0}{0}" +
			"   Activated: 5, Deactivated: 4{0}{0}" +
			"5. On step 4, the status bar contains the following text:{0}{0}" +
			"   Activated: 6, Deactivated: 5{0}{0}" +
			"6. On step 6, the status bar contains the following text:{0}{0}" +
			"   Activated: 6, Deactivated: 6",
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
		ClientSize = new Size (350, 550);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81409";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
