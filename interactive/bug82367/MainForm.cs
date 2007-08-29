using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

public class MainForm : Form
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
		// _creditsCheckBox
		// 
		_creditsCheckBox = new CheckBox ();
		_creditsCheckBox.Location = new Point (125, 110);
		_creditsCheckBox.Size = new Size (60, 20);
		_creditsCheckBox.Text = "Credits";
		_creditsCheckBox.CheckedChanged += new EventHandler (CreditsCheckBox_CheckedChanged);
		Controls.Add (_creditsCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 140);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82367";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_textBox.Lines = new string [] { "Mono's", "Managed Windows Forms", "ROCKS!" };

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void CreditsCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		if (_creditsCheckBox.Checked)
			_textBox.Lines = new string [] { "Rolf", "Chris", "Everalo", "Jonathan", "..." };
		else
			_textBox.Lines = new string [] { "Mono's", "Managed Windows Forms", "ROCKS!" };
	}

	private TextBox _textBox;
	private CheckBox _creditsCheckBox;
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
			"1. The following lines are displayed in the textbox:{0}{0}" +
			"   Mono's{0}" +
			"   Managed Windows Forms{0}" +
			"   ROCKS!",
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
			"1. Check the Credits checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following lines are displayed in the TextBox:{0}{0}" +
			"   Rolf{0}" +
			"   Chris{0}" +
			"   Everaldo{0}" +
			"   Jonathan{0}" +
			"   ...",
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
		ClientSize = new Size (360, 215);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82367";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
