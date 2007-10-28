using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Dock = DockStyle.Bottom;
		_textBox.Multiline = true;
		_textBox.Height = 30;
		Controls.Add (_textBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 270);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #325502";
		Load += new EventHandler (MainForm_Load);
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

	protected override void OnPaint (PaintEventArgs e)
	{
		base.OnPaint (e);

		using (GraphicsPath path = CreatePath ())
			e.Graphics.FillPath (Brushes.Red, path);
	}

	protected override void OnMouseMove (MouseEventArgs e)
	{
		base.OnMouseMove (e);
		bool hit = false;
		using (GraphicsPath path = CreatePath ())
			hit = path.IsVisible (e.X, e.Y);

		_textBox.Text = hit ? "HIT" : "MISS";
	}

	GraphicsPath CreatePath ()
	{
		GraphicsPath path = new GraphicsPath ();
		path.AddEllipse (new Rectangle (50, 20, 200, 200));
		return path;
	}

	private TextBox _textBox;
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
			"Steps to execute:{0}{0}" +
			"1. Move the mouse pointer in the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Whenever the mouse pointer is over the red ellipse, " +
			"the text in the textbox changes from MISS to HIT.",
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
		ClientSize = new Size (310, 160);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #325502";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
