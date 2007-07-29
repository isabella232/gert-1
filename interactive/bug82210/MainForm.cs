using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _contextMenuStrip
		// 
		_contextMenuStrip = new ContextMenuStrip ();
		// 
		// _toolStripMenuItem1
		// 
		_toolStripMenuItem1 = new ToolStripMenuItem ();
		_toolStripMenuItem1.Text = "Menu Item 1";
		_contextMenuStrip.Items.Add (_toolStripMenuItem1);
		// 
		// _toolStripMenuItem2
		// 
		_toolStripMenuItem2 = new ToolStripMenuItem ();
		_toolStripMenuItem2.Text = "Menu Item 2";
		_contextMenuStrip.Items.Add (_toolStripMenuItem2);
		// 
		// _toolStripMenuItem3
		// 
		_toolStripMenuItem3 = new ToolStripMenuItem ();
		_toolStripMenuItem3.Text = "Menu Item 3";
		_contextMenuStrip.Items.Add (_toolStripMenuItem3);
		// 
		// _toolStripMenuItem4
		// 
		_toolStripMenuItem4 = new ToolStripMenuItem ();
		_toolStripMenuItem4.Text = "Menu Item 4";
		_contextMenuStrip.Items.Add (_toolStripMenuItem4);
		// 
		// _notifyIcon
		// 
		_notifyIcon = new NotifyIcon ();
		_notifyIcon.ContextMenuStrip = _contextMenuStrip;
		_notifyIcon.Icon = Icon;
		_notifyIcon.Visible = true;
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
			"1. Ensure the taskbar is positioned at the top of the screen.{0}{0}" +
			"2. Right-click the notify icon.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The context menu pops up below the cursor.",
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
		ClientSize = new Size (300, 170);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #82210";
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

	private NotifyIcon _notifyIcon;
	private ContextMenuStrip _contextMenuStrip;
	private ToolStripMenuItem _toolStripMenuItem1;
	private ToolStripMenuItem _toolStripMenuItem2;
	private ToolStripMenuItem _toolStripMenuItem3;
	private ToolStripMenuItem _toolStripMenuItem4;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
