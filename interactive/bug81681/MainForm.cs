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
		_richTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		_richTextBox.Height = 140;
		_richTextBox.Width = 295;
		_richTextBox.WordWrap = false;
		Controls.Add (_richTextBox);
		// 
		// _scrollBarsGroupBox
		// 
		_scrollBarsGroupBox = new GroupBox ();
		_scrollBarsGroupBox.Dock = DockStyle.Bottom;
		_scrollBarsGroupBox.Height = 120;
		_scrollBarsGroupBox.Text = "ScrollBars";
		Controls.Add (_scrollBarsGroupBox);
		// 
		// _bothRadioButton
		// 
		_bothRadioButton = new RadioButton ();
		_bothRadioButton.Checked = (_richTextBox.ScrollBars == RichTextBoxScrollBars.Both);
		_bothRadioButton.Location = new Point (8, 15);
		_bothRadioButton.Size = new Size (80, 20);
		_bothRadioButton.Text = "Both";
		_bothRadioButton.CheckedChanged += new EventHandler (BothRadioButton_CheckedChanged);
		_scrollBarsGroupBox.Controls.Add (_bothRadioButton);
		// 
		// _forcedBothRadioButton
		// 
		_forcedBothRadioButton = new RadioButton ();
		_forcedBothRadioButton.Checked = (_richTextBox.ScrollBars == RichTextBoxScrollBars.ForcedBoth);
		_forcedBothRadioButton.Location = new Point (8, 35);
		_forcedBothRadioButton.Size = new Size (120, 20);
		_forcedBothRadioButton.Text = "ForcedBoth";
		_forcedBothRadioButton.CheckedChanged += new EventHandler (ForcedBothRadioButton_CheckedChanged);
		_scrollBarsGroupBox.Controls.Add (_forcedBothRadioButton);
		// 
		// _forcedHorizontalRadioButton
		// 
		_forcedHorizontalRadioButton = new RadioButton ();
		_forcedHorizontalRadioButton.Checked = (_richTextBox.ScrollBars == RichTextBoxScrollBars.ForcedHorizontal);
		_forcedHorizontalRadioButton.Location = new Point (8, 55);
		_forcedHorizontalRadioButton.Size = new Size (120, 20);
		_forcedHorizontalRadioButton.Text = "ForcedHorizontal";
		_forcedHorizontalRadioButton.CheckedChanged += new EventHandler (ForcedHorizontalRadioButton_CheckedChanged);
		_scrollBarsGroupBox.Controls.Add (_forcedHorizontalRadioButton);
		// 
		// _forcedVerticalRadioButton
		// 
		_forcedVerticalRadioButton = new RadioButton ();
		_forcedVerticalRadioButton.Checked = (_richTextBox.ScrollBars == RichTextBoxScrollBars.ForcedVertical);
		_forcedVerticalRadioButton.Location = new Point (8, 75);
		_forcedVerticalRadioButton.Size = new Size (120, 20);
		_forcedVerticalRadioButton.Text = "ForcedVertical";
		_forcedVerticalRadioButton.CheckedChanged += new EventHandler (ForcedVerticalRadioButton_CheckedChanged);
		_scrollBarsGroupBox.Controls.Add (_forcedVerticalRadioButton);
		// 
		// _horizontalRadioButton
		// 
		_horizontalRadioButton = new RadioButton ();
		_horizontalRadioButton.Checked = (_richTextBox.ScrollBars == RichTextBoxScrollBars.Horizontal);
		_horizontalRadioButton.Location = new Point (170, 15);
		_horizontalRadioButton.Size = new Size (120, 20);
		_horizontalRadioButton.Text = "Horizontal";
		_horizontalRadioButton.CheckedChanged += new EventHandler (HorizontalRadioButton_CheckedChanged);
		_scrollBarsGroupBox.Controls.Add (_horizontalRadioButton);
		// 
		// _noneRadioButton
		// 
		_noneRadioButton = new RadioButton ();
		_noneRadioButton.Checked = (_richTextBox.ScrollBars == RichTextBoxScrollBars.None);
		_noneRadioButton.Location = new Point (170, 35);
		_noneRadioButton.Size = new Size (80, 20);
		_noneRadioButton.Text = "None";
		_noneRadioButton.CheckedChanged += new EventHandler (NoneRadioButton_CheckedChanged);
		_scrollBarsGroupBox.Controls.Add (_noneRadioButton);
		// 
		// _verticalRadioButton
		// 
		_verticalRadioButton = new RadioButton ();
		_verticalRadioButton.Checked = (_richTextBox.ScrollBars == RichTextBoxScrollBars.Vertical);
		_verticalRadioButton.Location = new Point (170, 55);
		_verticalRadioButton.Size = new Size (80, 20);
		_verticalRadioButton.Text = "Vertical";
		_verticalRadioButton.CheckedChanged += new EventHandler (VerticalRadioButton_CheckedChanged);
		_scrollBarsGroupBox.Controls.Add (_verticalRadioButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81681";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_richTextBox.Text = string.Format (CultureInfo.InvariantCulture,
			"Some Text That Should Allow Us To Test Both Vertical And " +
			"Horizontal Scrollbars, And The Effect Of WordWrap.{0}{0}" +
			"Line #1{0}{0}" +
			"Line #2{0}{0}" +
			"Line #3{0}{0}" +
			"Line #4{0}{0}" +
			"Line #5{0}{0}" +
			"Line #6{0}{0}" +
			"Line #7{0}{0}" +
			"Line #8{0}{0}" +
			"Line #9{0}{0}",
			Environment.NewLine);

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void BothRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_bothRadioButton.Checked)
			_richTextBox.ScrollBars = RichTextBoxScrollBars.Both;
	}

	void ForcedBothRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_forcedBothRadioButton.Checked)
			_richTextBox.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
	}

	void ForcedHorizontalRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_forcedHorizontalRadioButton.Checked)
			_richTextBox.ScrollBars = RichTextBoxScrollBars.ForcedHorizontal;
	}

	void ForcedVerticalRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_forcedVerticalRadioButton.Checked)
			_richTextBox.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
	}

	void HorizontalRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_horizontalRadioButton.Checked)
			_richTextBox.ScrollBars = RichTextBoxScrollBars.Horizontal;
	}

	void NoneRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_noneRadioButton.Checked)
			_richTextBox.ScrollBars = RichTextBoxScrollBars.None;
	}

	void VerticalRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_verticalRadioButton.Checked)
			_richTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
	}

	private RichTextBox _richTextBox;
	private GroupBox _scrollBarsGroupBox;
	private RadioButton _bothRadioButton;
	private RadioButton _forcedBothRadioButton;
	private RadioButton _forcedHorizontalRadioButton;
	private RadioButton _forcedVerticalRadioButton;
	private RadioButton _horizontalRadioButton;
	private RadioButton _noneRadioButton;
	private RadioButton _verticalRadioButton;
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
			"1. Both horizontal and vertical scrollbars are displayed.",
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
			"1. Select the ForcedBoth radiobutton.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Both horizontal and vertical scrollbars are displayed, and " +
			"enabled.",
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
			"1. Select the ForcedHorizontal radiobutton.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Only a horizontal scrollbar is displayed, and enabled.",
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
			"1. Select the ForcedVertical radiobutton.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Only a vertical scrollbar is displayed, and enabled.",
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
			"1. Select the Horizontal radiobutton.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Only a horizontal scrollbar is displayed, and enabled.",
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
			"1. Select the None radiobutton.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Neither horizontal nor vertical scrollbars are displayed.",
			Environment.NewLine);
		// 
		// _tabPage6
		// 
		_tabPage6 = new TabPage ();
		_tabPage6.Text = "#6";
		_tabPage6.Controls.Add (_bugDescriptionText6);
		_tabControl.Controls.Add (_tabPage6);
		// 
		// _bugDescriptionText7
		// 
		_bugDescriptionText7 = new TextBox ();
		_bugDescriptionText7.Multiline = true;
		_bugDescriptionText7.Dock = DockStyle.Fill;
		_bugDescriptionText7.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Select the Vertical radiobutton.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Only a vertical scrollbar is displayed, and enabled.",
			Environment.NewLine);
		// 
		// _tabPage7
		// 
		_tabPage7 = new TabPage ();
		_tabPage7.Text = "#7";
		_tabPage7.Controls.Add (_bugDescriptionText7);
		_tabControl.Controls.Add (_tabPage7);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (360, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81681";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private TextBox _bugDescriptionText6;
	private TextBox _bugDescriptionText7;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
	private TabPage _tabPage6;
	private TabPage _tabPage7;
}
