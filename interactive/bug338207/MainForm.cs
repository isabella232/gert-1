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
		ClientSize = new Size (465, 260);
		Location = new Point (180, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #338207";
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
		using (Font f = new Font (FontFamily.GenericSansSerif, 20f, FontStyle.Italic)) {
			e.Graphics.DrawString ("This is a Italic test string", f,
				new SolidBrush (Color.Black), 10, 10);
		}

		using (Font f = new Font (FontFamily.GenericSansSerif, 20f, FontStyle.Bold)) {
			e.Graphics.DrawString ("This is a Bold test string", f,
				new SolidBrush (Color.Black), 10, 50);
		}

		using (Font f = new Font (FontFamily.GenericSansSerif, 20f, FontStyle.Bold | FontStyle.Italic)) {
			e.Graphics.DrawString ("This is a Bold + Italic test string", f,
				new SolidBrush (Color.Black), 10, 90);
		}

		using (Font f = new Font (FontFamily.GenericSansSerif, 20f, FontStyle.Strikeout)) {
			e.Graphics.DrawString ("This is a Strikeout test string", f,
				new SolidBrush (Color.Black), 10, 130);
		}

		using (Font f = new Font (FontFamily.GenericSansSerif, 20f, FontStyle.Underline)) {
			e.Graphics.DrawString ("This is a Underline test string", f,
				new SolidBrush (Color.Black), 10, 170);
		}

		using (Font f = new Font (FontFamily.GenericSansSerif, 20f)) {
			e.Graphics.DrawString ("This is a regular test string", f,
				new SolidBrush (Color.Black), 10, 210);
		}
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
			"1. The different lines of text are displayed with " +
			"the font style they describe.",
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
		Location = new Point (690, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #338207";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
