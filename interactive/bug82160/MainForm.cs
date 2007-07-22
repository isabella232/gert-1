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
			"1. Right-click the notificy icon.{0}{0}" +
			"2. Click on another part of the notification area.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The context menu is closed.{0}{0}" +
			"2. The notify icon is redrawn.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Right-click the notificy icon.{0}{0}" +
			"2. Right-click the notificy icon.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the first context menu is closed and a new " +
			"context menu is displayed.{0}{0}" +
			"Applies to:{0}" +
			"Microsoft Windows",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 220);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #82160";
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
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
