using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// MainForm
		// 
		ClientSize = new Size (350, 350);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82202";
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
		Graphics g = e.Graphics;
		GraphicsPath path = new GraphicsPath ();

		Rectangle borderect = new Rectangle (49, 49, 252, 252);
		g.FillRectangle (new SolidBrush (Color.White), borderect);

		int Diameter = 16;
		Rectangle baserect = new Rectangle (50, 50, 249, 249);

		Rectangle arcrect = new Rectangle (baserect.Location, new Size (Diameter, Diameter));

		// handle top left corner
		path.AddArc (arcrect, 180, 90);

		// handle top right corner
		arcrect.X = baserect.Right - Diameter;
		path.AddArc (arcrect, 270, 90);

		// handle baserect right corner
		arcrect.Y = baserect.Bottom - Diameter;
		path.AddArc (arcrect, 0, 90);

		// handle bottom left corner
		arcrect.X = baserect.Left;
		path.AddArc (arcrect, 90, 90);

		path.CloseFigure ();

		g.DrawPath (Pens.SteelBlue, path);
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
			"1. A white square with a blue rectangle is drawn in the center " +
			"of the form.{0}{0}" +
			"2. The rectange has rounded corners.{0}{0}" +
			"3. A one pixel wide \"border\" is drawn around the square.",
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
		ClientSize = new Size (330, 150);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82202";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
