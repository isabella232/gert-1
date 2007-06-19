using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _components
		// 
		_components = new System.ComponentModel.Container ();
		// 
		// _menu
		// 
		_menu = new ContextMenuStrip (_components);
		_menu.Dock = DockStyle.Top;
		_menu.Size = new Size (170, 70);
		// 
		// _menuItem
		// 
		_menuItem = new ToolStripMenuItem ();
		_menuItem.Size = new Size (169, 22);
		_menuItem.Text = "Insert date...";
		_menu.Items.Add (_menuItem);
		// 
		// _dateTimePicker
		// 
		_dateTimePicker = new DateTimePicker ();
		_dateTimePicker.Value = DateTime.Now;
		_dateTimePicker.Format = DateTimePickerFormat.Custom;
		_dateTimePicker.CustomFormat = "yyyy-MM-dd";
		_menuItem.DropDownItems.Add (new ToolStripControlHost (_dateTimePicker));
		// 
		// MainForm
		// 
		ClientSize = new Size (285, 105);
		ContextMenuStrip = _menu;
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81909";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	protected override void Dispose (bool disposing)
	{
		if (disposing) {
			if (_components != null) {
				_components.Dispose ();
			}
		}
		base.Dispose (disposing);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private DateTimePicker _dateTimePicker;
	private IContainer _components;
	private ContextMenuStrip _menu;
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Close the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The application exits cleanly.{0}{0}" +
			"2. No stacktrace is printed to the console.",
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
		ClientSize = new Size (360, 160);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81909";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
