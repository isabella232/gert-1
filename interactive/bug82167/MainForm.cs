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
		Location = new Point (125, 100);
		Size = new Size (550, 270);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82167";
		Load += new EventHandler (MainForm_Load);
		Paint += new PaintEventHandler (MainForm_Paint);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void MainForm_Paint (object sender, PaintEventArgs e)
	{
		DrawTestString (e.Graphics, GraphicsUnit.Pixel);
		DrawTestString (e.Graphics, GraphicsUnit.Point);
		DrawTestString (e.Graphics, GraphicsUnit.Millimeter);
		DrawTestString (e.Graphics, GraphicsUnit.Document);
	}

	static void DrawTestString (Graphics g, GraphicsUnit unit)
	{
		g.PageUnit = unit;
		float left = 50;
		float top = 50;
		float height = 10;

		g.DrawLine (Pens.Black, left, top, left, top + height);
		g.DrawLine (Pens.Black, left, top + height, left + height, top + height);

		Font font = new Font ("Arial", height, unit);
		g.DrawString ("Xyz| unit: " + unit.ToString (), font, Brushes.Black, left, top);
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
			"Expected result on start-up:{0}{0}" +
			"1. Four different lines of text are drawn from small to large:{0}{0}" +
			"   * Document{0}" +
			"   * Pixel{0}" +
			"   * Point{0}" +
			"   * Millimeter{0}{0}" +
			"2. Each line of the text starts at the point where the two lines " +
			"intersect.",
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
		ClientSize = new Size (360, 180);
		Location = new Point (700, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82167";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
