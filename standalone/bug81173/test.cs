using System;
using System.Collections;
using System.Windows.Forms;

class Program
{
	static int Main (string [] args)
	{
		ArrayList list = new ArrayList ();
		Application.Run (new HandleMockForm (list));
		if (list.Count != 3)
			return 1;

		if (((string) list [0]) != "HandleCreated:True")
			return 2;

		if (((string) list [1]) != "FormDisposed:True")
			return 3;

		if (((string) list [2]) != "HandleDestroyed:True")
			return 4;

		return 0;
	}
}

class HandleMockForm : Form
{
	public HandleMockForm (ArrayList list)
	{
		_list = list;
		Load += new EventHandler (HandleMockForm_Load);
	}

	protected override void OnHandleCreated (EventArgs e)
	{
		_list.Add ("HandleCreated:" + this.IsHandleCreated);
		base.OnHandleCreated (e);
	}
	protected override void OnHandleDestroyed (EventArgs e)
	{
		_list.Add ("HandleDestroyed:" + this.IsHandleCreated);
		base.OnHandleDestroyed (e);
	}

	protected override void Dispose (bool disposing)
	{
		_list.Add ("FormDisposed:" + this.IsHandleCreated);
		base.Dispose (disposing);
	}

	void HandleMockForm_Load (object sender, EventArgs e)
	{
		Close ();
	}

	private readonly ArrayList _list;
}