using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _showImageMarginCheckBox
		// 
		_showImageMarginCheckBox = new CheckBox ();
		_showImageMarginCheckBox.Checked = true;
		_showImageMarginCheckBox.Location = new Point (8, 80);
		_showImageMarginCheckBox.Size = new Size (130, 20);
		_showImageMarginCheckBox.Text = "ShowImageMargin";
		_showImageMarginCheckBox.CheckedChanged += new EventHandler (ShowImageMarginCheckBox_CheckedChanged);
		Controls.Add (_showImageMarginCheckBox);
		// 
		// _menu
		// 
		_menu = new ContextMenuStrip ();
		_menu.Dock = DockStyle.Top;
		_menu.Size = new Size (170, 70);
		// 
		// _label
		// 
		_label = new ToolStripLabel ();
		_label.Text = "Mono";
		_menu.Items.Add (_label);
		// 
		// _menuItem
		// 
		_menuItem = new ToolStripMenuItem ();
		_menuItem.Size = new Size (169, 22);
		_menuItem.Text = "Insert date...";
		_menu.Items.Add (_menuItem);
		// 
		// MainForm
		// 
		ClientSize = new Size (285, 105);
		ContextMenuStrip = _menu;
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81903";
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

	void ShowImageMarginCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		_menu.ShowImageMargin = _showImageMarginCheckBox.Checked;
	}

	private CheckBox _showImageMarginCheckBox;
	private ContextMenuStrip _menu;
	private ToolStripLabel _label;
	private ToolStripMenuItem _menuItem;
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
			"1. Check the ShowImageMargin checkbox.{0}{0}" +
			"2. Right-click on the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Mono label is left-aligned.{0}{0}" +
			"2. The contextmenu has a bar on the left to display images.",
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
			"1. Uncheck the ShowImageMargin checkbox.{0}{0}" +
			"2. Right-click on the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Mono label is left-aligned.{0}{0}" +
			"2. The contextmenu does not have a bar on the left to display images.",
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
		ClientSize = new Size (360, 195);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81903";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
