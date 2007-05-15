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
		ClientSize = new Size (200, 90);
		Location = new Point (350, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #79594";
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

	void MainForm_Paint (object o, PaintEventArgs args)
	{
		StringFormat format = new StringFormat ();
		format.Alignment = StringAlignment.Center;
		string text = "this is really long text........................................... with a lot o periods.";
		SizeF sz = args.Graphics.MeasureString (text, Font, 80, format);
		Rectangle bounds = new Rectangle (60, 8, 80, 80);
		args.Graphics.DrawString (text, Font, SystemBrushes.ControlText, bounds, format);

		bounds.Height = (int) sz.Height;
		args.Graphics.DrawRectangle (new Pen (Color.Black), bounds);
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The text in the rectangle is spread over 6 lines.{0}{0}" +
			"2. The text on each line is centered horizontally.",
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
		ClientSize = new Size (330, 110);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #79594";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
