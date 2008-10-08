using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

public class MyTraceListener : TraceListener
{
	public override void Write (string o)
	{
	}

	public override void WriteLine (string message)
	{
	}

	public override void Fail (string message)
	{
		Invoke.FailExecuted = true;
		MessageBox.Show ("Fail()\nleave me standing a while");
	}

	public override void Fail (string message, string detailMessage)
	{
		Fail (null);
	}
}

public class Invoke : Form
{
	static void Main ()
	{
		UiTag = "ui thread";
		Application.Run (new Invoke ());

		Assert.AreEqual (5, TickCount, "TickCount");
		Assert.IsTrue (FailExecuted, "FailExecuted");
		Environment.Exit (0);
	}

	public Invoke ()
	{
		_timer = new System.Windows.Forms.Timer ();
		_timer.Interval = 1000;
		_timer.Tick += new EventHandler (t_Tick);
		_timer.Start ();

		Debug.Listeners.Clear ();
		Debug.Listeners.Add (new MyTraceListener ());

		new Thread (new ThreadStart (foo)).Start ();
	}

	public void foo ()
	{
		Debug.Assert (false, "Yo!");
	}

	void t_Tick (object sender, EventArgs e)
		{
			if (UiTag == null)
				Environment.Exit (1);

			TickCount++;
			if (TickCount == 5) {
				_timer.Stop ();
				Close ();
			}
			MessageBox.Show ("tick");
		}

	[ThreadStatic]
	static object UiTag;
	static int TickCount;
	internal static bool FailExecuted;
	System.Windows.Forms.Timer _timer;
}
