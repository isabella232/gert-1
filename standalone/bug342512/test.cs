using System;

public class PlotMenuItem
{
	private EventHandler callback_;

	public PlotMenuItem ()
	{
	}

	public PlotMenuItem (EventHandler callback)
	{
		callback_ = callback;

		PlotMenuItem child = new PlotMenuItem ();
		child.Callback += new EventHandler (callback);
	}

	static void Main ()
	{
		new PlotMenuItem (new EventHandler (MenuItem_Click));
	}

	static void MenuItem_Click (object sender, EventArgs e)
	{
	}

	public EventHandler Callback {
		get { return callback_; }
		set { callback_ = value; }
	}
}
