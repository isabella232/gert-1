using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _label
		// 
		_label = new Label ();
		_label.Dock = DockStyle.Top;
		_label.Font = new Font (FontFamily.GenericSansSerif, 25, FontStyle.Bold);
		_label.Height = 349;
		_label.Image = Image.FromFile ("LunaticsInc.png");
		_label.Text = "Global warming";
		_label.TextAlign = ContentAlignment.MiddleCenter;
		Controls.Add (_label);
		// 
		// _backgroundImageCheckBox
		// 
		_backgroundImageCheckBox = new CheckBox ();
		_backgroundImageCheckBox.Location = new Point (8, 350);
		_backgroundImageCheckBox.Text = "Background Image";
		_backgroundImageCheckBox.Size = new Size (140, 20);
		_backgroundImageCheckBox.CheckedChanged += new EventHandler (BackgroundImageCheckBox_CheckedChanged);
		Controls.Add (_backgroundImageCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (326, 370);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #339565";
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

	void BackgroundImageCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		if (_backgroundImageCheckBox.Checked) {
			_label.BackgroundImage = _label.Image;
			_label.Image = null;
		} else {
			_label.Image = _label.BackgroundImage;
			_label.BackgroundImage = null;
		}
	}

	private Label _label;
	private CheckBox _backgroundImageCheckBox;
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
			"1. The text \"Global warming\" is drawn on top of " +
			"image.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Check the Background Image checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The text \"Global warming\" remains drawn on top " +
			"of the image.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #339565";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
