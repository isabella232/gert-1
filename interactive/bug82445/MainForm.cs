using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _pictureBox
		// 
		_pictureBox = new PictureBox ();
		_pictureBox.Dock = DockStyle.Top;
		_pictureBox.Height = 352;
		Controls.Add (_pictureBox);
		// 
		// MainForm
		// 
		Location = new Point (250, 100);
		ClientSize = new Size (360, 352);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82445";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_pictureBox.Image = Image.FromFile ("the_sign-animated.gif");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private PictureBox _pictureBox;
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
			"1. The animation is played without pauzes between " +
			"each frame.",
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
		ClientSize = new Size (300, 100);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82445";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
