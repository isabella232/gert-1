using System;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		MainForm form = new MainForm ();
		form.StartPosition = FormStartPosition.CenterParent;
		Application.Run (form);

		form = new MainForm ();
		form.StartPosition = FormStartPosition.CenterScreen;
		Application.Run (form);

		form = new MainForm ();
		form.StartPosition = FormStartPosition.Manual;
		Application.Run (form);

		form = new MainForm ();
		form.StartPosition = FormStartPosition.WindowsDefaultBounds;
		Application.Run (form);

		form = new MainForm ();
		form.StartPosition = FormStartPosition.WindowsDefaultLocation;
		Application.Run (form);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Close ();
	}
}
