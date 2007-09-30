using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dropDownStyleBox
		// 
		_dropDownStyleBox = new GroupBox ();
		_dropDownStyleBox.Location = new Point (220, 8);
		_dropDownStyleBox.Size = new Size (135, 100);
		_dropDownStyleBox.Text = "Dropdown style";
		Controls.Add (_dropDownStyleBox);
		// 
		// _dropDownRadioButton
		// 
		_dropDownRadioButton = new RadioButton ();
		_dropDownRadioButton.Location = new Point (8, 20);
		_dropDownRadioButton.Size = new Size (100, 20);
		_dropDownRadioButton.Text = "DropDown";
		_dropDownRadioButton.CheckedChanged += new EventHandler (DropDownRadioButton_CheckedChanged);
		_dropDownStyleBox.Controls.Add (_dropDownRadioButton);
		// 
		// _dropDownListRadioButton
		// 
		_dropDownListRadioButton = new RadioButton ();
		_dropDownListRadioButton.Location = new Point (8, 45);
		_dropDownListRadioButton.Size = new Size (100, 20);
		_dropDownListRadioButton.Text = "DropDownList";
		_dropDownListRadioButton.CheckedChanged += new EventHandler (DropDownListRadioButton_CheckedChanged);
		_dropDownStyleBox.Controls.Add (_dropDownListRadioButton);
		// 
		// _simpleRadioButton
		// 
		_simpleRadioButton = new RadioButton ();
		_simpleRadioButton.Location = new Point (8, 70);
		_simpleRadioButton.Size = new Size (100, 20);
		_simpleRadioButton.Text = "Simple";
		_simpleRadioButton.CheckedChanged += new EventHandler (SimpleRadioButton_CheckedChanged);
		_dropDownStyleBox.Controls.Add (_simpleRadioButton);
		// 
		// _fillButton
		// 
		_fillButton = new Button ();
		_fillButton.Location = new Point (135, 35);
		_fillButton.Size = new Size (70, 20);
		_fillButton.Text = "Fill";
		_fillButton.Click += new EventHandler (FillButton_Click);
		Controls.Add (_fillButton);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (135, 8);
		_resetButton.Size = new Size (70, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _comboBox
		// 
		_comboBox = new ComboBox ();
		_comboBox.Location = new Point (8, 8);
		_comboBox.Size = new Size (100, 110);
		_comboBox.DropDown += new EventHandler (ComboBox_DropDown);
		_comboBox.DropDownStyleChanged += new EventHandler (ComboBox_DropDownStyleChanged);
		_comboBox.SelectedIndexChanged += new EventHandler (ComboBox_SelectedIndexChanged);
		Controls.Add (_comboBox);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 80;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (365, 200);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #79970";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_dropDownRadioButton.Checked = _comboBox.DropDownStyle == ComboBoxStyle.DropDown;
		_dropDownListRadioButton.Checked = _comboBox.DropDownStyle == ComboBoxStyle.DropDownList;
		_simpleRadioButton.Checked = _comboBox.DropDownStyle == ComboBoxStyle.Simple;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void DropDownRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_dropDownRadioButton.Checked)
			_comboBox.DropDownStyle = ComboBoxStyle.DropDown;
	}

	void DropDownListRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_dropDownListRadioButton.Checked)
			_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
	}

	void SimpleRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_simpleRadioButton.Checked)
			_comboBox.DropDownStyle = ComboBoxStyle.Simple;
	}

	void ComboBox_DropDown (object sender, EventArgs e)
	{
		_eventsText.AppendText ("ComboBox => DropDown" + Environment.NewLine);
	}

	void ComboBox_DropDownStyleChanged (object sender, EventArgs e)
	{
		_dropDownRadioButton.Checked = _comboBox.DropDownStyle == ComboBoxStyle.DropDown;
		_dropDownListRadioButton.Checked = _comboBox.DropDownStyle == ComboBoxStyle.DropDownList;
		_simpleRadioButton.Checked = _comboBox.DropDownStyle == ComboBoxStyle.Simple;
	}

	void ComboBox_SelectedIndexChanged (object sender, EventArgs e)
	{
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_comboBox.DropDownStyle = ComboBoxStyle.DropDown;
		_comboBox.Items.Clear ();
		_eventsText.Text = string.Empty;
	}

	void FillButton_Click (object sender, EventArgs e)
	{
		if (_comboBox.Items.Count > 0)
			return;

		CultureInfo [] cultures = CultureInfo.GetCultures (CultureTypes.SpecificCultures);
		foreach (CultureInfo culture in cultures) {
			int index = _comboBox.Items.Add (culture.Name);
			if (culture.Name == CultureInfo.CurrentCulture.Name)
				_comboBox.SelectedIndex = index;
		}
	}

	private GroupBox _dropDownStyleBox;
	private RadioButton _dropDownRadioButton;
	private RadioButton _dropDownListRadioButton;
	private RadioButton _simpleRadioButton;
	private Button _resetButton;
	private Button _fillButton;
	private ComboBox _comboBox;
	private TextBox _eventsText;
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
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Click the dropdown arrow of the ComboBox control.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The ComboBox does not display a dropdown list.{0}{0}" +
			"2. The following event is fired:{0}{0}" +
			"   * ComboBox => DropDown{0}{0}" +
			"3. A cursor caret is blinking in the ComboBox.",
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
			"1. Click the Reset button.{0}{0}" +
			"2. Select the DropDownList style.{0}{0}" +
			"3. Click the dropdown arrow of the ComboBox control.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The ComboBox does not display a dropdown list.{0}{0}" +
			"2. The following event is fired:{0}{0}" +
			"   * ComboBox => DropDown",
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
			"1. Click the Reset button.{0}{0}" +
			"2. Select the Simple style.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The ComboBox is split into two parts: one ressembling a " +
			"textbox, and one empty listbox.{0}{0}" +
			"2. No events are fired.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 250);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #79970";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
