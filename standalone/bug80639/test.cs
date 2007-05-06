using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		Controls.Add (new MyTextBox ());
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

	class MyTextBox : TextBox
	{
		protected override void OnPaint (PaintEventArgs e)
		{
			Environment.Exit (1);
		}
	}
}
