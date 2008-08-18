using System;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _timer
		// 
		_timer = new Timer ();
		_timer.Interval = 1000 * 2; // update every 2 seconds
		_timer.Tick += new EventHandler (Timer_Tick);
		_timer.Start ();
		// 
		// MainForm
		// 
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
		Assert.AreEqual (6, tick_count, "#1");
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		start = DateTime.Now;
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		tick_count++;
		TimeSpan elapsed = DateTime.Now - start;
		if (elapsed.TotalMilliseconds >= 12000)
			Close ();

	}

	private static int tick_count;

	private DateTime start;
	private Timer _timer;
}
