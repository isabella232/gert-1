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
		// 
		// _timer
		// 
		_timer = new Timer ();
		_timer.Interval = 1000 * 5; // update every 5 seconds
		_timer.Tick += new EventHandler (Timer_Tick);
		_timer.Start ();
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
			"Expected result:{0}{0}" +
			"1. A notify icon is displayed in the taskbar.{0}{0}" +
			"2. The icon is a number which increments every 5 seconds.{0}{0}" +
			"3. The color of the text alternates between black and green.",
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
		ClientSize = new Size (300, 150);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81559";
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
		_notifyIcon.Icon = CreateIcon ();
		_notifyIcon.Visible = true;
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		if (_notifyIcon.Icon != null)
			_notifyIcon.Icon.Dispose ();
		_notifyIcon.Icon = CreateIcon ();
	}

	Icon CreateIcon ()
	{
		_counter++;

		Bitmap bmp = new Bitmap (16, 16);
		Brush brush;
		using (Graphics g = Graphics.FromImage (bmp)) {
			if ((_counter % 2) == 0) {
				brush = new SolidBrush (Color.Black);
			} else {
				brush = new SolidBrush (Color.Green);
			}
			g.DrawString ("#" + _counter.ToString (CultureInfo.InvariantCulture),
				 new Font (FontFamily.GenericSansSerif, 9), brush, 0, 0);
		}
		brush.Dispose ();
		return Icon.FromHandle (bmp.GetHicon ());
	}

	private NotifyIcon _notifyIcon;
	private Timer _timer;
	private int _counter = 0;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
