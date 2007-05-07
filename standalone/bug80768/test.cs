using System;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		Paint += new PaintEventHandler (MainForm_Paint);
	}

	void MainForm_Paint (object sender, PaintEventArgs e)
	{
		Close ();
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}
}
