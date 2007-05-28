using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 200;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the arrow on the dropdown button.{0}{0}" +
			"2. Click the arrow on the dropdown button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, a menu is dropped down.{0}{0}" +
			"2. On step 2, the menu is closed.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _toolBar
		// 
		_toolBar = new ToolBar ();
		_toolBar.AutoSize = true;
		_toolBar.Appearance = ToolBarAppearance.Flat;
		Controls.Add (_toolBar);
		// 
		// _dropDownButton
		// 
		_dropDownButton = new ToolBarButton ();
		_dropDownButton.DropDownMenu = new ContextMenu (new MenuItem [] {
			new MenuItem ("Send") });
		_dropDownButton.Style = ToolBarButtonStyle.DropDownButton;
		_dropDownButton.ToolTipText = "Drop Down";
		_dropDownButton.Text = "&Drop Down";
		_toolBar.Buttons.Add (_dropDownButton);
		// 
		// MainForm
		// 
		StartPosition = FormStartPosition.CenterScreen;
		ClientSize = new Size (300, 260);
		Text = "bug #81675";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private ToolBar _toolBar;
	private ToolBarButton _dropDownButton;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
