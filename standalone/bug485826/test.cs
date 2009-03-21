using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
	Timer _timer;

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	public MainForm ()
	{
		Load += new EventHandler (MainForm_Load);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_timer = new Timer ();
		_timer.Tick += new EventHandler (Timer_Tick);
		_timer.Interval = 500;
		_timer.Enabled = true;
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		Close ();
	}

	protected override void OnPaint (PaintEventArgs e)
	{
		IntPtr hdc = e.Graphics.GetHdc ();
		Graphics g1 = Graphics.FromHdc (hdc);
		Graphics g2 = Graphics.FromHdc (g1.GetHdc ());
		g2.Dispose ();
		g1.Dispose ();
	}
}
