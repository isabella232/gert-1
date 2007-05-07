using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		Control c = new Control ();
		c.Anchor |= AnchorStyles.Bottom;
		c.Size = new Size (100, 100);
		Controls.Add (c);
		if (c.Height != 100)
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

	public override Rectangle DisplayRectangle {
		get {
			return Rectangle.Empty;
		}
	}
}
