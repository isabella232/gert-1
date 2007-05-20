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
		_richTextBox.Height = 200;
		_richTextBox.Multiline = true;
		_richTextBox.ReadOnly = true;
		_richTextBox.Text = "Jackson";
		Controls.Add (_richTextBox);
		// 
		// _readOnlyCheckBox
		// 
		_readOnlyCheckBox = new CheckBox ();
		_readOnlyCheckBox.Checked = true;
		_readOnlyCheckBox.Location = new Point (8, 210);
		_readOnlyCheckBox.Size = new Size (80, 20);
		_readOnlyCheckBox.Text = "ReadOnly";
		_readOnlyCheckBox.CheckedChanged += new EventHandler (ReadOnlyCheckBox_CheckedChanged);
		Controls.Add (_readOnlyCheckBox);
		// 
		// _blueCheckBox
		// 
		_blueCheckBox = new CheckBox ();
		_blueCheckBox.Location = new Point (250, 210);
		_blueCheckBox.Size = new Size (80, 20);
		_blueCheckBox.Text = "Blue";
		_blueCheckBox.CheckedChanged += new EventHandler (BlueCheckBox_CheckedChanged);
		Controls.Add (_blueCheckBox);
		// 
		// _backColorLabel
		// 
		_backColorLabel = new Label ();
		_backColorLabel.Location = new Point (8, 240);
		_backColorLabel.Size = new Size (80, 20);
		_backColorLabel.Text = "BackColor:";
		Controls.Add (_backColorLabel);
		// 
		// _backColorValue
		// 
		_backColorValue = new Label ();
		_backColorValue.Location = new Point (100, 240);
		_backColorValue.Size = new Size (150, 20);
		Controls.Add (_backColorValue);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 270);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #79949";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
#if NET_2_0
		Color expectedColor = SystemColors.Control;
#else
		Color expectedColor = SystemColors.Window;
#endif
		if (_richTextBox.BackColor != expectedColor) {
			Environment.ExitCode = 1;
			Close ();
		}

		_backColorValue.Text = _richTextBox.BackColor.ToString ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ReadOnlyCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		_richTextBox.ReadOnly = _readOnlyCheckBox.Checked;
		_backColorValue.Text = _richTextBox.BackColor.ToString ();
	}

	void BlueCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		if (_blueCheckBox.Checked) {
			_originalBackColor = _richTextBox.BackColor;
			_richTextBox.BackColor = Color.Blue;
		} else {
			_richTextBox.BackColor = _originalBackColor;
		}
		_backColorValue.Text = _richTextBox.BackColor.ToString ();
	}

	private RichTextBox _richTextBox;
	private CheckBox _readOnlyCheckBox;
	private CheckBox _blueCheckBox;
	private Label _backColorLabel;
	private Label _backColorValue;
	private Color _originalBackColor;
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
#if NET_2_0
			"1. The background color of the RichTextBox is gray.{0}{0}" +
			"2. The value of BackColor is \"Color [Control]\".{0}{0}" +
#else
			"1. The background color of the RichTextBox is white.{0}{0}" +
			"2. The value of BackColor is \"Color [Window]\".{0}{0}" +
#endif
			"3. The foreground color of the RichTextBox is black.",
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
			"1. Uncheck the \"ReadOnly\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
#if NET_2_0
			"1. The background color of the RichTextBox is white.{0}{0}" +
			"2. The value of BackColor is \"Color [Window]\".{0}{0}" +
			"3. The foreground color of the RichTextBox is black.{0}{0}" +
			"Note:{0}" +
			"On MS, the background color is gray. This has been reported as a" +
			" bug (see bug report).",
#else
			"1. The background color of the RichTextBox is white.{0}{0}" +
			"2. The value of BackColor is \"Color [Window]\".{0}{0}" +
			"3. The foreground color of the RichTextBox is black.",
#endif
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
			"1. Check the \"ReadOnly\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
#if NET_2_0
			"1. The background color of the RichTextBox is gray.{0}{0}" +
			"2. The value of BackColor is \"Color [Control]\".{0}{0}" +
#else
			"1. The background color of the RichTextBox is white.{0}{0}" +
			"2. The value of BackColor is \"Color [Window]\".{0}{0}" +
#endif
			"3. The foreground color of the RichTextBox is black.",
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
			"1. Check the \"ReadOnly\" checkbox.{0}{0}" +
			"2. Check the \"Blue\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The background color of the RichTextBox is blue.{0}{0}" +
			"2. The value of BackColor is \"Color [Blue]\".{0}{0}" +
			"3. The foreground color of the RichTextBox is black.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// _bugDescriptionText5
		// 
		_bugDescriptionText5 = new TextBox ();
		_bugDescriptionText5.Multiline = true;
		_bugDescriptionText5.Dock = DockStyle.Fill;
		_bugDescriptionText5.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck the \"ReadOnly\" checkbox.{0}{0}" +
			"2. Uncheck the \"Blue\" checkbox.{0}{0}" +
			"3. Check the \"Blue\" checkbox.{0}{0}" +
			"4. Check the \"ReadOnly\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The background color of the RichTextBox is blue.{0}{0}" +
			"2. The value of BackColor is \"Color [Blue]\".{0}{0}" +
			"3. The foreground color of the RichTextBox is black.",
			Environment.NewLine);
		// 
		// _tabPage5
		// 
		_tabPage5 = new TabPage ();
		_tabPage5.Text = "#5";
		_tabPage5.Controls.Add (_bugDescriptionText5);
		_tabControl.Controls.Add (_tabPage5);
		// 
		// _bugDescriptionText6
		// 
		_bugDescriptionText6 = new TextBox ();
		_bugDescriptionText6.Multiline = true;
		_bugDescriptionText6.Dock = DockStyle.Fill;
		_bugDescriptionText6.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck the \"ReadOnly\" checkbox.{0}{0}" +
			"2. Uncheck the \"Blue\" checkbox.{0}{0}" +
			"3. Check the \"ReadOnly\" checkbox.{0}{0}" +
			"4. Check the \"Blue\" checkbox.{0}{0}" +
			"5. Uncheck the \"ReadOnly\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The background color of the RichTextBox is blue.{0}{0}" +
			"2. The value of BackColor is \"Color [Blue]\".{0}{0}" +
			"3. The foreground color of the RichTextBox is black.",
			Environment.NewLine);
		// 
		// _tabPage5
		// 
		_tabPage6 = new TabPage ();
		_tabPage6.Text = "#6";
		_tabPage6.Controls.Add (_bugDescriptionText6);
		_tabControl.Controls.Add (_tabPage6);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 330);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #79949";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private TextBox _bugDescriptionText6;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
	private TabPage _tabPage6;
}
