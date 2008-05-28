using System;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

class MainForm : Form
{
	delegate void UpdateHandler ();

	public MainForm ()
	{
		// 
		// _button
		// 
		_button = new Button ();
		Controls.Add (_button);
		// 
		// MainForm
		// 
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
#if NET_2_0
		Control.CheckForIllegalCrossThreadCalls = true;
#endif
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_timer = new Timer ();
		_timer.Interval = 200;
		_timer.Enabled = true;
		_timer.Tick += new EventHandler (Timer_Tick);
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		_timer.Enabled = false;

		Thread t = new Thread (new ThreadStart (RunThread));
		t.Start ();
	}

	void RunThread ()
	{
#if NET_2_0
		try {
			UpdateText ();
			throw new Exception ("unsafe assignment to Text should result in exception");
		} catch (InvalidOperationException) {
		}
#else
		UpdateText ();
#endif

		Invoke (new UpdateHandler (UpdateText));
		Invoke (new UpdateHandler (CloseForm));
	}

	void UpdateText ()
	{
		_button.Text = "OK OK";
	}

	void CloseForm ()
	{
		Close ();
	}

	private Button _button;
	private Timer _timer;
}
