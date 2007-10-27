using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

class MainForm : Form
{
	public MainForm ()
	{
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
		Application.Run (new SplashForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Thread t = new Thread (new ThreadStart (Run));
		t.IsBackground = true;
		t.Start ();
		t.Join ();

		Close ();
	}

	static void Run ()
	{
		Application.Run (new SplashForm ());
	}
}

class SplashForm : Form
{
	public SplashForm ()
	{
		// 
		// _label
		// 
		_label = new Label ();
		_label.AutoSize = true;
		_label.Dock = DockStyle.Fill;
		_label.Text = "This form should close automatically.";
		Controls.Add (_label);
		// 
		// _timer
		// 
		_timer = new Timer ();
		_timer.Tick += new EventHandler (Timer_Tick);
		_timer.Interval = 100;
		_timer.Start ();
		// 
		// SplashForm
		// 
		ClientSize = new Size (200, 50);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #325033";
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		_timer.Stop ();
		Close ();
	}

	private Label _label;
	private Timer _timer;
}
