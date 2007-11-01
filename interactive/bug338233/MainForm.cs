using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// MainForm
		// 
		ClientSize = new Size (270, 270);
		Location = new Point (275, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #338233";
		Load += new EventHandler (MainForm_Load);
		Paint += new PaintEventHandler (MainForm_Paint);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void MainForm_Paint (object sender, PaintEventArgs e)
	{
		Pen p = new Pen (Color.Red, 5);
		p.ScaleTransform (1, 0);
		e.Graphics.DrawLine (p, 10, 10, 250, 250);

		p.ResetTransform ();
		p.ScaleTransform (0, 1);
		e.Graphics.DrawLine (p, 250, 10, 10, 250);

		p.ResetTransform ();
		p.ScaleTransform (0, 0);
		e.Graphics.DrawLine (p, 130, 10, 130, 250);

		p.ResetTransform ();
		p.ScaleTransform (0, 1);
		e.Graphics.DrawLine (p, 10, 130, 250, 130);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}
}

public class InstructionsForm : Form
{
	public InstructionsForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on startup:{0}{0}" +
			"1. A star-like shape is drawn.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (310, 100);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #338233";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
