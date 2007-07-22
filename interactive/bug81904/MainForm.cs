using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _contextMenu
		// 
		_contextMenu = new ContextMenu ();
		// 
		// _notifyIcon
		// 
		_notifyIcon = new NotifyIcon ();
		_notifyIcon.ContextMenu = _contextMenu;
		// 
		// _bringToFrontMenuItem
		// 
		_bringToFrontMenuItem = new MenuItem ();
		_bringToFrontMenuItem.Text = "Bring to front...";
		_bringToFrontMenuItem.Click += new EventHandler (BringToFrontMenuItem_Click);
		_contextMenu.MenuItems.Add (_bringToFrontMenuItem);
		// 
		// _activateMenuItem
		// 
		_activateMenuItem = new MenuItem ();
		_activateMenuItem.Text = "Activate...";
		_activateMenuItem.Click += new EventHandler (ActivateMenuItem_Click);
		_contextMenu.MenuItems.Add (_activateMenuItem);
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
			"1. Ensure another form is displayed on top of this one.{0}{0}" +
			"2. Right-click the notify icon.{0}{0}" +
			"3. Click the \"Bring to front...\" menu item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The form is moved to the top of the z-order.{0}{0}" +
			"2. The form is activated.",
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
			"1. Ensure another form is displayed on top of this one.{0}{0}" +
			"2. Right-click the notify icon.{0}{0}" +
			"3. Click the \"Activate...\" menu item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The form is moved to the top of the z-order.{0}{0}" +
			"2. The form is activated.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Ensure another form is displayed on top of this one.{0}{0}" +
			"2. Left-click the notify icon.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The form is moved to the top of the z-order.{0}{0}" +
			"2. The form is activated.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 220);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81904";
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
			if (_notifyIcon != null) {
				_notifyIcon.Dispose ();
			}
		}
		base.Dispose (disposing);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_notifyIcon.Icon = Icon;
		_notifyIcon.Visible = true;
	}

	void BringToFrontMenuItem_Click (object sender, EventArgs e)
	{
		BringToFront ();
	}

	void ActivateMenuItem_Click (object sender, EventArgs e)
	{
		Activate ();
	}

	private NotifyIcon _notifyIcon;
	private ContextMenu _contextMenu;
	private MenuItem _bringToFrontMenuItem;
	private MenuItem _activateMenuItem;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
