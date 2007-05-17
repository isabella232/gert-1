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
		_richTextBox.Height = 160;
		Controls.Add (_richTextBox);
		// 
		// _wordWrapCheckBox
		// 
		_wordWrapCheckBox = new CheckBox ();
		_wordWrapCheckBox.Checked = _richTextBox.WordWrap;
		_wordWrapCheckBox.Location = new Point (8, 170);
		_wordWrapCheckBox.Text = "WordWrap";
		_wordWrapCheckBox.CheckedChanged += new EventHandler (WordWrapCheckBox_CheckedChanged);
		Controls.Add (_wordWrapCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 200);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81488";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_richTextBox.Text = "Some Text That Should Allow Us To Test The " +
			"Visual Effect Of The WordWrap property.";

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void WordWrapCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		_richTextBox.WordWrap = _wordWrapCheckBox.Checked;
	}

	private RichTextBox _richTextBox;
	private CheckBox _wordWrapCheckBox;
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
			"1. The line of text in the RichTextBox is wrapped over multiple " +
			"lines.",
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
			"1. Uncheck the WordWrap checkbox.{0}{0}" +
			"1. Check the WordWrap checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the line of text in the RichTextBox is no longer " +
			"wrapped causing a horizontal scrollbar to be displayed.{0}{0}" +
			"2. On step 2, the line of text is wrapped over multiple lines " +
			"and the horizontal scrollbar is no longer displayed.",
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
		ClientSize = new Size (360, 210);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81488";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
