using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Dock = DockStyle.Top;
		_textBox.Height = 100;
		_textBox.Multiline = true;
		Controls.Add (_textBox);
		// 
		// _multilineCheckBox
		// 
		_multilineCheckBox = new CheckBox ();
		_multilineCheckBox.Checked = true;
		_multilineCheckBox.Location = new Point (8, 110);
		_multilineCheckBox.Size = new Size (100, 20);
		_multilineCheckBox.Text = "Multiline";
		_multilineCheckBox.CheckedChanged += new EventHandler (MultilineCheckBox_CheckedChanged);
		Controls.Add (_multilineCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 135);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82749";
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

	void MultilineCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		_textBox.Multiline = _multilineCheckBox.Checked;
	}

	private TextBox _textBox;
	private CheckBox _multilineCheckBox;
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
			"1. Uncheck the Multiline checkbox.{0}{0}" +
			"2. Check the Multiline checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the height is the textbox is reduced.{0}{0}" +
			"1. On step 2, the original height is restored.",
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
		ClientSize = new Size (330, 195);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82749";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
