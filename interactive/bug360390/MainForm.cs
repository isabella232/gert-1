using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _textBox1
		// 
		_textBox1 = new MaskedTextBox ();
		_textBox1.Location = new Point (8, 8);
		_textBox1.Mask = "LL/LLL";
		_textBox1.Size = new Size (280, 20);
		_textBox1.UseSystemPasswordChar = true;
		Controls.Add (_textBox1);
		// 
		// _textBox2
		// 
		_textBox2 = new MaskedTextBox ();
		_textBox2.Location = new Point (8, 40);
		_textBox2.PasswordChar = '%';
		_textBox2.Size = new Size (280, 20);
		Controls.Add (_textBox2);
		// 
		// _maskedTextProvider
		// 
		_maskedTextProvider = new MaskedTextProvider ("LL/LL/LLLL");
		_maskedTextProvider.PasswordChar = '@';
		_maskedTextProvider.PromptChar = '?';
		// 
		// _textBox3
		// 
		_textBox3 = new MaskedTextBox (_maskedTextProvider);
		_textBox3.Location = new Point (8, 72);
		_textBox3.Size = new Size (280, 20);
		Controls.Add (_textBox3);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 110);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #360390";
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

	private MaskedTextBox _textBox1;
	private MaskedTextBox _textBox2;
	private MaskedTextBox _textBox3;
	private MaskedTextProvider _maskedTextProvider;
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
			"1. The following text is displayed in the textboxes:{0}{0}" +
			"   1: __/____{0}" +
			"   2:{0}" +
			"   3:??/??/????",
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
			"Expected result on start-up:{0}{0}" +
			"1. Click inside the first textbox.{0}{0}" +
			"2. Enter a few alphabetic characters.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. An asterisk or bullet is displayed for each " +
			"entered character.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. Click inside the second textbox.{0}{0}" +
			"2. Enter a few characters and digits.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A percentage sign is displayed for each entered " +
			"character.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// _bugDescriptionText4
		// 
		_bugDescriptionText4 = new TextBox ();
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. Click inside the third textbox.{0}{0}" +
			"2. Enter a few alphabetic characters.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. An @ sign is displayed for each entered character.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (320, 170);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #360390";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
}
