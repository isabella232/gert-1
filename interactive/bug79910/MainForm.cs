using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _allowFullOpenCheck
		// 
		_allowFullOpenCheck = new CheckBox ();
		_allowFullOpenCheck.Location = new Point (190, 8);
		_allowFullOpenCheck.Size = new Size (110, 20);
		_allowFullOpenCheck.Text = "Allow Full Open";
		_allowFullOpenCheck.CheckedChanged += new EventHandler (AllowFullOpenCheck_CheckedChanged);
		Controls.Add (_allowFullOpenCheck);
		// 
		// _fullOpenCheck
		// 
		_fullOpenCheck = new CheckBox ();
		_fullOpenCheck.Location = new Point (190, 30);
		_fullOpenCheck.Size = new Size (110, 20);
		_fullOpenCheck.Text = "Full Open";
		_fullOpenCheck.CheckedChanged += new EventHandler (FullOpenCheck_CheckedChanged);
		Controls.Add (_fullOpenCheck);
		// 
		// _selectColorButton
		// 
		_selectColorButton = new Button ();
		_selectColorButton.Location = new Point (8, 8);
		_selectColorButton.Size = new Size (90, 20);
		_selectColorButton.Text = "Select Color";
		_selectColorButton.Click += new EventHandler (SelectColorButton_Click);
		Controls.Add (_selectColorButton);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (110, 8);
		_resetButton.Size = new Size (70, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 440;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the \"Select Color\" button.{0}{0}" +
			"3. In the \"Color\" dialog box, click \"Define Custom Colors\".{0}{0}" +
			"4. Click \"Cancel\".{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The AllowFullOpen checkbox is checked.{0}{0}" +
			"2. The Full Open checkbox is not checked.{0}{0}" +
			"======={0}{0}" +
			"Steps to execute:{0}{0}" +
			"1. Click the \"Select Color\" button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"Color\" dialog box is not fully open.{0}{0}" +
			"2. The \"Define Custom Colors\" button is enabled.{0}{0}" +
			"3. Clicking the \"Define Custom Colors\" button changed the " +
			"\"Color\" dialog box to \"Full Open\" state.",
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
		_bugDescriptionText2.Location = new Point (8, 8);
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click \"Reset\" button.{0}{0}" +
			"2. Uncheck the \"Allow Full Open\" checkbox.{0}{0}" +
			"3. Click the \"Select Color\" button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"Color\" dialog box is not fully open.{0}{0}" +
			"2. The \"Define Custom Colors\" button is disabled.{0}{0}" +
			"======={0}{0}" +
			"Steps to execute:{0}{0}" +
			"1. Click \"OK\" button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The AllowFullOpen checkbox is not checked.{0}{0}" +
			"2. The Full Open checkbox is not checked.",
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
		_bugDescriptionText3.Location = new Point (8, 8);
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click \"Reset\" button.{0}{0}" +
			"2. Uncheck the \"Allow Full Open\" checkbox.{0}{0}" +
			"2. Check the \"Full Open\" checkbox.{0}{0}" +
			"3. Click the \"Select Color\" button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"Color\" dialog box is not fully open.{0}{0}" +
			"2. The \"Define Custom Colors\" button is disabled.{0}{0}" +
			"======={0}{0}" +
			"Steps to execute:{0}{0}" +
			"1. Click \"Cancel\" button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The AllowFullOpen checkbox is not checked.{0}{0}" +
			"2. The Full Open checkbox is checked.",
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
		_bugDescriptionText4.Location = new Point (8, 8);
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click \"Reset\" button.{0}{0}" +
			"2. Check the \"Full Open\" checkbox.{0}{0}" +
			"3. Click the \"Select Color\" button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"Color\" dialog box is fully open.{0}{0}" +
			"2. The \"Define Custom Colors\" button is disabled.{0}{0}" +
			"======={0}{0}" +
			"Steps to execute:{0}{0}" +
			"1. Click \"OK\" button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The AllowFullOpen checkbox is checked.{0}{0}" +
			"2. The Full Open checkbox is checked.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (300, 480);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79910";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_allowFullOpenCheck.Checked = _colorDialog.AllowFullOpen;
		_fullOpenCheck.Checked = _colorDialog.FullOpen;
	}

	void AllowFullOpenCheck_CheckedChanged (object sender, EventArgs e)
	{
		_colorDialog.AllowFullOpen = _allowFullOpenCheck.Checked;
	}

	void FullOpenCheck_CheckedChanged (object sender, EventArgs e)
	{
		_colorDialog.FullOpen = _fullOpenCheck.Checked;
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_colorDialog = new ColorDialog ();
		_allowFullOpenCheck.Checked = _colorDialog.AllowFullOpen;
		_fullOpenCheck.Checked = _colorDialog.FullOpen;
	}

	void SelectColorButton_Click (object sender, EventArgs e)
	{
		_colorDialog.ShowDialog ();
		_allowFullOpenCheck.Checked = _colorDialog.AllowFullOpen;
		_fullOpenCheck.Checked = _colorDialog.FullOpen;
	}

	private CheckBox _allowFullOpenCheck;
	private CheckBox _fullOpenCheck;
	private Button _selectColorButton;
	private Button _resetButton;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private ColorDialog _colorDialog = new ColorDialog ();
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
}
