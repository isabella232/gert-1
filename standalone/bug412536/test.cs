using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

class MainForm : Form
{
	public static ArrayList _events;
	private bool _doEvents;

	public MainForm (bool doEvents)
	{
		_doEvents = doEvents;
		_components = new Container ();
		// 
		// _timer
		// 
		_timer = new Timer (_components);
		_timer.Interval = 50;
		_timer.Tick += new EventHandler (Timer_Tick);
		_timer.Enabled = true;
		// 
		// MainForm
		// 
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		for (int i = 0; i < 5; i++) {
			_events = new ArrayList ();
			Application.Run (new MainForm (false));
			Assert.AreEqual (2, _events.Count, "#A1:" + i);
			Assert.AreEqual ("Load", _events [0], "#A2:" + i);
			Assert.AreEqual ("Tick", _events [1], "#A3:" + i);
		}

		for (int i = 0; i < 5; i++) {
			_events = new ArrayList ();
			Application.Run (new MainForm (true));
			Assert.AreEqual (2, _events.Count, "#B1:" + i);
			Assert.AreEqual ("Tick", _events [0], "#B2:" + i);
			Assert.AreEqual ("Load", _events [1], "#B3:" + i);
		}
	}

	protected override void OnLoad (EventArgs e)
	{
		base.OnLoad (e);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		if (_doEvents) {
			Application.DoEvents ();
			for (int i = 0; i < 5; i++) {
				System.Threading.Thread.Sleep (50);
				Application.DoEvents ();
			}
		}
		_events.Add ("Load");
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		_events.Add ("Tick");
		Close ();
	}

	protected override void Dispose (bool disposing)
	{
		if (disposing) {
			if (_timer != null) {
				_timer.Dispose ();
				_timer = null;
			}
			if (_components != null) {
				_components.Dispose ();
				_components = null;
			}
		}
		base.Dispose (disposing);
	}

	private Container _components;
	private Timer _timer;
}
