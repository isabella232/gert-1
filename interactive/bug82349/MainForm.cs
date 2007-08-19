using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// ContextMenu
		// 
		ContextMenu = new ContextMenu ();
		ContextMenu.MenuItems.Add (new MenuItem ("Format1"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format2"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format3"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format4"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format5"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format6"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format7"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format8"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format9"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format10"));
		ContextMenu.MenuItems.Add (new MenuItem ("-"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format11"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format12"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format13"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format14"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format15"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format15"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format16"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format17"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format18"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format19"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format20"));
		ContextMenu.MenuItems.Add (new MenuItem ("-"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format21"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format22"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format23"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format24"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format25"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format26"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format27"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format28"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format29"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format30"));
		ContextMenu.MenuItems.Add (new MenuItem ("-"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format31"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format32"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format33"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format34"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format35"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format36"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format37"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format38"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format39"));
		ContextMenu.MenuItems.Add (new MenuItem ("Format40"));

		// 
		// MainForm
		// 
		Location = new Point (250, 100);
		Size = new Size (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82349";
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
			"1. Move the form to a location in the center of the screen.{0}{0}" +
			"2. Right-click the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A context menu pops up.{0}{0}" +
			"2. The start position of the menu is repositioned to " +
			"allow all menu items (from 1 tot 40) to be displayed.",
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
		ClientSize = new Size (300, 205);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82349";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
