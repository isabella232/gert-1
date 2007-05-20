using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _trackBar
		// 
		_trackBar = new TrackBar ();
		_trackBar.AutoSize = false;
		_trackBar.Left = 0;
		_trackBar.Top = 0;
		_trackBar.Orientation = Orientation.Vertical;
		_trackBar.Height = 100;
		_trackBar.Width = 100;
		_trackBar.Maximum = 100;
		Controls.Add (_trackBar);
		// 
		// _checkBox
		// 
		_checkBox = new CheckBox ();
		_checkBox.Location = new Point (110, 8);
		_checkBox.Text = "Check";
		_checkBox.Width = 80;
		_checkBox.Checked = true;
		Controls.Add (_checkBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (200, 110);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #79816";
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

	private TrackBar _trackBar;
	private CheckBox _checkBox;
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
			"Steps to reproduce:{0}{0}" +
			"1. Click and drag the handle of the TrackBar.{0}{0}" +
			"2. Click the CheckBox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. In both cases, no focus rectangle should have shown around " +
			"the control.{0}{0}" +
			"Note:{0}" +
			"The focus rectangle around the TrackBar is not easily " +
			"reproducable.",
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
		ClientSize = new Size (300, 220);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #79816";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
