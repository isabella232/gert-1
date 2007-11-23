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
		// _notifyIcon
		// 
		_notifyIcon = new NotifyIcon ();
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Move the mouse pointer over the notify icon in " +
			"the task bar.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A tooltip containing the following text is displayed:{0}{0}" +
			"   Rank: 10{0}" +
			"   Downs: 55{0}" +
			"   Pages: 994{0}" +
			"   Tracker: 4{0}" +
			"   Msgs: 7988{0}{0}" +
			"2. All text is left aligned and fully visible.",
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
		ClientSize = new Size (300, 250);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81550";
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
		StringBuilder sb = new StringBuilder ();
		sb.Append ("Rank: 10");
		sb.Append (Environment.NewLine);
		sb.Append ("Downs: 55");
		sb.Append (Environment.NewLine);
		sb.Append ("Pages: 994");
		sb.Append (Environment.NewLine);
		sb.Append ("Tracker: 4");
		sb.Append (Environment.NewLine);
		sb.Append ("Msgs: 7988");
		_notifyIcon.Text = sb.ToString ();
	}

	private NotifyIcon _notifyIcon;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
