using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _formCaptionLabel
		// 
		_formCaptionLabel = new Label ();
		_formCaptionLabel.Location = new Point (8, 8);
		_formCaptionLabel.Size = new Size (100, 20);
		_formCaptionLabel.Text = "Form Caption:";
		Controls.Add (_formCaptionLabel);
		// 
		// _formCaptionText
		// 
		_formCaptionText = new TextBox ();
		_formCaptionText.Location = new Point (110, 8);
		_formCaptionText.Size = new Size (100, 20);
		Controls.Add (_formCaptionText);
		// 
		// _changeCaptionButton
		//
		_changeCaptionButton = new Button ();
		_changeCaptionButton.Location = new Point (220, 8);
		_changeCaptionButton.Size = new Size (60, 20);
		_changeCaptionButton.Text = "Change";
		_changeCaptionButton.Click += new EventHandler (ChangeCaptionButton_Click);
		Controls.Add (_changeCaptionButton);
		// 
		// _resetButton
		//
		_resetButton = new Button ();
		_resetButton.Location = new Point (300, 8);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _minimizeBoxCheck
		// 
		_minimizeBoxCheck = new CheckBox ();
		_minimizeBoxCheck.Checked = true;
		_minimizeBoxCheck.Location = new Point (8, 35);
		_minimizeBoxCheck.Size = new Size (100, 20);
		_minimizeBoxCheck.Text = "MinimizeBox";
		_minimizeBoxCheck.CheckedChanged += new EventHandler (MinimizeBox_CheckedChanged);
		Controls.Add (_minimizeBoxCheck);
		// 
		// _maximizeBoxCheck
		// 
		_maximizeBoxCheck = new CheckBox ();
		_maximizeBoxCheck.Checked = true;
		_maximizeBoxCheck.Location = new Point (118, 35);
		_maximizeBoxCheck.Size = new Size (100, 20);
		_maximizeBoxCheck.Text = "MaximizeBox";
		_maximizeBoxCheck.CheckedChanged += new EventHandler (MaximizeBox_CheckedChanged);
		Controls.Add (_maximizeBoxCheck);
		// 
		// _controlBoxCheck
		// 
		_controlBoxCheck = new CheckBox ();
		_controlBoxCheck.Checked = true;
		_controlBoxCheck.Location = new Point (228, 35);
		_controlBoxCheck.Size = new Size (100, 20);
		_controlBoxCheck.Text = "ControlBox";
		_controlBoxCheck.CheckedChanged += new EventHandler (ControlBox_CheckedChanged);
		Controls.Add (_controlBoxCheck);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (408, 200);
		Location = new Point (100, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80640";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main (string [] args)
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_formCaptionText.Text = Text;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ChangeCaptionButton_Click (object sender, EventArgs e)
	{
		Text = _formCaptionText.Text;
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_formCaptionText.Text = "bug #80640";
		Text = _formCaptionText.Text;
		_minimizeBoxCheck.Checked = true;
		_maximizeBoxCheck.Checked = true;
		_controlBoxCheck.Checked = true;
	}

	void MinimizeBox_CheckedChanged (object sender, EventArgs e)
	{
		MinimizeBox = _minimizeBoxCheck.Checked;
	}

	void MaximizeBox_CheckedChanged (object sender, EventArgs e)
	{
		MaximizeBox = _maximizeBoxCheck.Checked;
	}

	void ControlBox_CheckedChanged (object sender, EventArgs e)
	{
		ControlBox = _controlBoxCheck.Checked;
	}

	private Label _formCaptionLabel;
	private TextBox _formCaptionText;
	private Button _changeCaptionButton;
	private Button _resetButton;
	private CheckBox _minimizeBoxCheck;
	private CheckBox _maximizeBoxCheck;
	private CheckBox _controlBoxCheck;
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
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Uncheck the \"MinimizeBox\" checkbox.{0}{0}" +
			"3. Check the \"MinimizeBox\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. At step 2:{0}{0}" +
			"   * The Minimize box is visible and disabled.{0}" +
			"   * The Maximize box is visible and enabled.{0}" +
			"   * The Close box is visible and enabled.{0}{0}" +
			"2. At step 3:{0}{0}" +
			"   * The Minimize box is visible and enabled.{0}" +
			"   * The Maximize box is visible and enabled.{0}" +
			"   * The Close box is visible and enabled.{0}{0}" +
			"3. The title of the Form is \"bug #80640\".",
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
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Uncheck the \"MaximizeBox\" checkbox.{0}{0}" +
			"3. Check the \"MaximizeBox\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. At step 2:{0}{0}" +
			"   * The Minimize box is visible and enabled.{0}" +
			"   * The Maximize box is visible and disabled.{0}" +
			"   * The Close box is visible and enabled.{0}{0}" +
			"2. At step 3:{0}{0}" +
			"   * The Minimize box is visible and enabled.{0}" +
			"   * The Maximize box is visible and enabled.{0}" +
			"   * The Close box is visible and enabled.{0}{0}" +
			"3. The title of the Form is \"bug #80640\".",
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
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Uncheck the \"ControlBox\" checkbox.{0}{0}" +
			"3. Check the \"ControlBox\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. At step 2:{0}{0}" +
			"   * The Minimize box is not visible.{0}" +
			"   * The Maximize box is not visible.{0}" +
			"   * The Close box is not visible.{0}{0}" +
			"2. At step 3:{0}{0}" +
			"   * The Minimize box is visible.{0}" +
			"   * The Maximize box is visible.{0}" +
			"   * The Close box is visible.{0}{0}" +
			"3. The title of the Form is \"bug #80640\".",
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
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Clear the text from the \"Form Caption\" textbox.{0}{0}" +
			"3. Click the \"Change\" button.{0}{0}" +
			"4. Uncheck the \"ControlBox\" checkbox.{0}{0}" +
			"5. Check the \"ControlBox\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. At step 3:{0}{0}" +
			"   * The title bar of the form is visible.{0}" +
			"   * The form has no title.{0}{0}" +
			"2. At step 4:{0}{0}" +
			"   * The title bar of the form is not visible.{0}{0}" +
			"3. At step 5:{0}{0}" +
			"   * The title bar of the form is visible.{0}" +
			"   * The form has no title.",
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
		ClientSize = new Size (400, 420);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80640";
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
