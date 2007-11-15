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
		_textBox.Height = 130;
		_textBox.Multiline = true;
		Controls.Add (_textBox);
		// 
		// _largeFontCheckBox
		// 
		_largeFontCheckBox = new CheckBox ();
		_largeFontCheckBox.Location = new Point (10, 140);
		_largeFontCheckBox.Text = "Large Font";
		_largeFontCheckBox.CheckedChanged += new EventHandler (LargeFontCheckBox_CheckedChanged);
		Controls.Add (_largeFontCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 165);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #341534";
		Load += new EventHandler (MainForm_Load);
	}
	
	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_textBox.Text = string.Format (CultureInfo.InvariantCulture,
			"Some Text{0}" +
			"That Spans Multiple Lines{0}" +
			"And Allows Us To Test Changes in Font Size...",
			Environment.NewLine);

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void LargeFontCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		if (_largeFontCheckBox.Checked)
			_textBox.Font = new Font (_textBox.Font.FontFamily, 15);
		else
			_textBox.Font = new Font (_textBox.Font.FontFamily, 9);
	}

	private TextBox _textBox;
	private CheckBox _largeFontCheckBox;
}

public class NonSelectableButon : Button
{
	public NonSelectableButon ()
	{
		SetStyle (ControlStyles.Selectable, false);
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
			"Steps to execute:{0}{0}" +
			"1. Check the Large Font checkbox.{0}{0}" +
			"2. Uncheck the Large Font checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1:{0}{0}" +
			"   * the font size increases.{0}" +
			"   * the lines do not overlap.{0}" +
			"   * line 3 is automatically wrapped.{0}{0}" +
			"2. On step 2:{0}{0}" +
			"   * the font size decreases.{0}" +
			"   * the lines do not overlap.{0}" +
			"   * line 3 is no longer wrapped.",
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
		ClientSize = new Size (300, 300);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #341534";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
