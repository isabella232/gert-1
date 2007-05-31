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
		_textBox.Dock = DockStyle.Fill;
		_textBox.Multiline = true;
		_textBox.ScrollBars = ScrollBars.Vertical;
		_textBox.Text = string.Format (CultureInfo.InvariantCulture,
			"Line #1.{0}" +
			"Line #2.{0}" +
			"Line #3.{0}" +
			"Line #4.{0}" +
			"Line #5.{0}" +
			"Line #6.{0}" +
			"Line #7.{0}" +
			"Line #8.{0}" +
			"Line #9.{0}" +
			"Line #10.{0}" +
			"Line #11.{0}" +
			"Line #12.{0}" +
			"Line #13.{0}" +
			"Line #14.{0}" +
			"Line #15.{0}" +
			"Line #16.{0}" +
			"Line #17.{0}" +
			"Line #18.{0}" +
			"Line #19.{0}" +
			"Line #20.{0}" +
			"Line #21.{0}" +
			"Line #22.{0}" +
			"Line #23.{0}" +
			"Line #24.{0}" +
			"Line #25.{0}" +
			"Line #26.{0}" +
			"Line #27.{0}" +
			"Line #28.{0}" +
			"Line #29.{0}" +
			"Line #30.",
			Environment.NewLine);
		Controls.Add (_textBox);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (300, 300);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81311";
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

	private TextBox _textBox;
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
			"1. Click inside the TextBox at the end of line 5.{0}{0}" +
			"2. Press PageDown key.{0}{0}" +
			"3. Press PageUp key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The cursor caret is positioned at the end of line 5.",
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
		ClientSize = new Size (320, 220);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81311";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
