using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _richTextBox
		// 
		_richTextBox = new RichTextBox ();
		_richTextBox.Dock = DockStyle.Top;
		_richTextBox.Height = 120;
		Controls.Add (_richTextBox);
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Dock = DockStyle.Bottom;
		_textBox.Height = 120;
		_textBox.Multiline = true;
		Controls.Add (_textBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 250);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81682";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_richTextBox.SelectionColor = Color.Black;
		_richTextBox.AppendText ("should be colored black");
		_richTextBox.SelectionColor = Color.Red;
		_richTextBox.AppendText (Environment.NewLine + "should have a red color");
		_richTextBox.SelectionColor = Color.Empty;
		_richTextBox.AppendText (Environment.NewLine + "should be default color");
		_richTextBox.SelectionColor = Color.Black;
		_richTextBox.AppendText (Environment.NewLine + "should be colored black");
		_richTextBox.SelectionFont = new Font (_richTextBox.SelectionFont, FontStyle.Bold);
		_richTextBox.AppendText (" and now bold");
		_richTextBox.SelectionColor = Color.Red;
		_richTextBox.AppendText (Environment.NewLine + "should have a red color and bold");
		_richTextBox.SelectionColor = Color.Empty;
		_richTextBox.AppendText (Environment.NewLine + "should be default color and bold");

		_textBox.AppendText ("should be colored black");
		_textBox.AppendText (Environment.NewLine + "should have a red color");
		_textBox.AppendText (Environment.NewLine + "should be default color");
		_textBox.AppendText (Environment.NewLine + "should be colored black");
		_textBox.AppendText (" and now bold");
		_textBox.AppendText (Environment.NewLine + "should have a red color and bold");
		_textBox.AppendText (Environment.NewLine + "should be default color and bold");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private RichTextBox _richTextBox;
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
			"Expected result on start-up:{0}{0}" +
			"1. The RichTextBox (top) and the TextBox (bottom) contain 6 " +
			"lines of text.{0}{0}" +
			"2. The cursor caret is positioned at the end of line 6 in the " +
			"RichTextBox.",
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
			"1. Click inside the RichTextBox.{0}{0}" +
			"2. Press the Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"2. The cursor caret is positioned at the end of line 6 in the " +
			"TextBox.",
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
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click inside the RichTextBox.{0}{0}" +
			"2. Press the Ctrl-A key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. All text in the RichTextBox is selected.{0}{0}" +
			"2. The text on each line is fully visible.",
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
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click inside the TextBox.{0}{0}" +
			"2. Press the Ctrl-Home key.{0}{0}" +
			"3. Press the Ctrl-Shift-End key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. All text in the TextBox is selected.{0}{0}" +
			"2. The text on each line is fully visible.",
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
		ClientSize = new Size (360, 210);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81682";
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
