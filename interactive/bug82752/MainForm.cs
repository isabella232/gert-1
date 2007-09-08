using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _checkBox1
		// 
		_checkBox1 = new CheckBox ();
		_checkBox1.Location = new Point (8, 8);
		_checkBox1.Size = new Size (100, 50);
		_checkBox1.Text = "CheckBox";
		Controls.Add (_checkBox1);
		// 
		// _checkBox2
		// 
		_checkBox2 = new CheckBox ();
		_checkBox2.Location = new Point (8, 60);
		_checkBox2.Size = new Size (100, 50);
		Controls.Add (_checkBox2);
		// 
		// _radioButton1
		// 
		_radioButton1 = new RadioButton ();
		_radioButton1.Location = new Point (8, 112);
		_radioButton1.Size = new Size (100, 50);
		_radioButton1.TabStop = true;
		_radioButton1.Text = "RadioButton";
		Controls.Add (_radioButton1);
		// 
		// _radioButton2
		// 
		_radioButton2 = new RadioButton ();
		_radioButton2.Location = new Point (8, 164);
		_radioButton2.Size = new Size (100, 50);
		_radioButton2.TabStop = true;
		Controls.Add (_radioButton2);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 220);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82752";
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

	private CheckBox _checkBox1;
	private CheckBox _checkBox2;
	private RadioButton _radioButton1;
	private RadioButton _radioButton2;
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
			"1. Press the Tab key.{0}{0}" +
			"2. Press the Alt-Tab key.{0}{0}" +
			"3. Press the Tab key.{0}{0}" +
			"4. Press the Tab key.{0}{0}" +
			"5. Press the Down-Arrow key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, a focus rectangle is drawn around the " +
			"text of the first checkbox.{0}{0}" +
			"2. On step 3, no focus rectangle is drawn around " +
			"the second checkbox.{0}{0}" +
			"3. On step 4, a focus rectangle is drawn around " +
			"the text of the first radiobutton.{0}{0}" +
			"3. On step 5, no focus rectangle is drawn around " +
			"the second radiobutton.",
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
		ClientSize = new Size (300, 380);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82752";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
