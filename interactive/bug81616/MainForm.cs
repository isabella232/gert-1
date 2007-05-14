using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Location = new Point (12, 97);
		_textBox.Size = new Size (140, 20);
		_textBox.TabIndex = 0;
		Controls.Add (_textBox);
		// 
		// _checkBox1
		// 
		_checkBox1 = new CheckBox ();
		_checkBox1.Location = new Point (20, 12);
		_checkBox1.Size = new Size (67, 17);
		_checkBox1.TabIndex = 1;
		_checkBox1.Text = "&Enable it";
		Controls.Add (_checkBox1);
		// 
		// _checkBox2
		// 
		_checkBox2 = new CheckBox ();
		_checkBox2.Location = new Point (20, 35);
		_checkBox2.Size = new Size (61, 17);
		_checkBox2.TabIndex = 2;
		_checkBox2.Text = "&Invert it";
		Controls.Add (_checkBox2);
		// 
		// _checkBox3
		// 
		_checkBox3 = new CheckBox ();
		_checkBox3.Location = new Point (20, 58);
		_checkBox3.Size = new Size (68, 17);
		_checkBox3.TabIndex = 3;
		_checkBox3.Text = "&Search it";
		Controls.Add (_checkBox3);
		// 
		// MainForm
		// 
		ClientSize = new Size (170, 130);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81616";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private TextBox _textBox;
	private CheckBox _checkBox1;
	private CheckBox _checkBox2;
	private CheckBox _checkBox3;
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
			"Steps to execute:{0}{0}" +
			"1. Click in the textbox.{0}{0}" +
			"2. Press the keys E, I and S.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The pressed keys are displayed in the textbox.{0}{0}" +
			"2. Focus stays in the textbox.{0}{0}" +
			"3. The checked state of the checkboxes does not change.",
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
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click in the textbox.{0}{0}" +
			"2. Press the Alt-I key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The text in the textbox does not change.{0}{0}" +
			"2. The checked state of the \"Invert it\" checkbox changes.",
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
		ClientSize = new Size (300, 215);
		Location = new Point (500, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81616";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
