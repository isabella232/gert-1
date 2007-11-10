using System;
using System.Diagnostics;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _control
		// 
		_control.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		Controls.Add (_control);
		if (_control.Width != 0)
			throw new Exception ();
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Close ();
	}

	private Control _control = new Control ();
}
