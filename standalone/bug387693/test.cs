using System;
using System.Threading;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
		Application.Run (new SplashForm ());
	}

	static void Run ()
	{
		Application.Run (new SplashForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Thread t = new Thread (new ThreadStart (Run));
		t.IsBackground = true;
		t.Start ();
		t.Join ();
		Close ();
	}
}

class SplashForm : Form
{
	public SplashForm ()
	{
		Button b = new Button ();
		b.Click += new EventHandler (Button_Click);
		Controls.Add (b);

		Load += new EventHandler (MainForm_Load);
	}

	void Button_Click (object sender, EventArgs e)
	{
		Close ();
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Close ();
	}
}
