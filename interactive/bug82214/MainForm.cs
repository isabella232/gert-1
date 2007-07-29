using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _ofd
		// 
		_ofd = new OpenFileDialog ();
		_ofd.Filter = DefaultFilter;
		_ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
		// 
		// _addExtensionLabel
		// 
		_addExtensionLabel = new Label ();
		_addExtensionLabel.Location = new Point (8, 8);
		_addExtensionLabel.Size = new Size (100, 20);
		_addExtensionLabel.Text = "AddExtension:";
		Controls.Add (_addExtensionLabel);
		// 
		// _addExtensionCheckBox
		// 
		_addExtensionCheckBox = new CheckBox ();
		_addExtensionCheckBox.Checked = _ofd.AddExtension;
		_addExtensionCheckBox.Location = new Point (115, 8);
		_addExtensionCheckBox.Size = new Size (100, 20);
		Controls.Add (_addExtensionCheckBox);
		// 
		// _checkFileExistsLabel
		// 
		_checkFileExistsLabel = new Label ();
		_checkFileExistsLabel.Location = new Point (8, 35);
		_checkFileExistsLabel.Size = new Size (100, 20);
		_checkFileExistsLabel.Text = "CheckFileExists:";
		Controls.Add (_checkFileExistsLabel);
		// 
		// _checkFileExistsCheckBox
		// 
		_checkFileExistsCheckBox = new CheckBox ();
		_checkFileExistsCheckBox.Checked = _ofd.CheckFileExists;
		_checkFileExistsCheckBox.Location = new Point (115, 35);
		_checkFileExistsCheckBox.Size = new Size (100, 20);
		Controls.Add (_checkFileExistsCheckBox);
		// 
		// _defaultExtensionLabel
		// 
		_defaultExtensionLabel = new Label ();
		_defaultExtensionLabel.Location = new Point (8, 62);
		_defaultExtensionLabel.Size = new Size (80, 20);
		_defaultExtensionLabel.Text = "DefaultExt:";
		Controls.Add (_defaultExtensionLabel);
		// 
		// _defaultExtensionText
		// 
		_defaultExtensionText = new TextBox ();
		_defaultExtensionText.Location = new Point (115, 62);
		_defaultExtensionText.Size = new Size (100, 20);
		Controls.Add (_defaultExtensionText);
		// 
		// _filterIndexLabel
		// 
		_filterIndexLabel = new Label ();
		_filterIndexLabel.Location = new Point (8, 92);
		_filterIndexLabel.Size = new Size (80, 20);
		_filterIndexLabel.Text = "FilterIndex:";
		Controls.Add (_filterIndexLabel);
		// 
		// _filterIndexValue
		// 
		_filterIndexValue = new NumericUpDown ();
		_filterIndexValue.Location = new Point (115, 92);
		_filterIndexValue.Minimum = -5;
		_filterIndexValue.Maximum = int.MaxValue;
		Controls.Add (_filterIndexValue);
		// 
		// _filterLabel
		// 
		_filterLabel = new Label ();
		_filterLabel.Location = new Point (8, 119);
		_filterLabel.Size = new Size (80, 20);
		_filterLabel.Text = "Filter:";
		Controls.Add (_filterLabel);
		// 
		// _filterText
		// 
		_filterText = new TextBox ();
		_filterText.Location = new Point (115, 119);
		_filterText.Size = new Size (320, 20);
		Controls.Add (_filterText);
		// 
		// _fileNameLabel
		// 
		_fileNameLabel = new Label ();
		_fileNameLabel.Location = new Point (8, 146);
		_fileNameLabel.Size = new Size (80, 20);
		_fileNameLabel.Text = "FileName:";
		Controls.Add (_fileNameLabel);
		// 
		// _fileNameText
		// 
		_fileNameText = new TextBox ();
		_fileNameText.Location = new Point (115, 146);
		_fileNameText.ReadOnly = true;
		_fileNameText.Size = new Size (320, 20);
		_fileNameText.TextAlign = HorizontalAlignment.Right;
		Controls.Add (_fileNameText);
		// 
		// _openFileButton
		// 
		_openFileButton = new Button ();
		_openFileButton.Location = new Point (60, 180);
		_openFileButton.Size = new Size (80, 20);
		_openFileButton.Text = "Open File";
		_openFileButton.Click += new EventHandler (OpenFileButton_Click);
		Controls.Add (_openFileButton);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (295, 180);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (445, 210);
		Location = new Point (150, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82214";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Init ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_addExtensionCheckBox.Checked = true;
		_checkFileExistsCheckBox.Checked = true;
		_defaultExtensionText.Text = string.Empty;
		_filterIndexValue.Value = 1;
		_filterText.Text = DefaultFilter;
		_fileNameText.Text = string.Empty;
		_ofd.FileName = string.Empty;
	}

	void OpenFileButton_Click (object sender, EventArgs e)
	{
		_ofd.AddExtension = _addExtensionCheckBox.Checked;
		_ofd.CheckFileExists = _checkFileExistsCheckBox.Checked;
		_ofd.DefaultExt = _defaultExtensionText.Text;
		_ofd.Filter = _filterText.Text;
		_ofd.FilterIndex = (int) _filterIndexValue.Value;
		_ofd.ShowDialog ();

		Init ();
	}

	void Init ()
	{
		_addExtensionCheckBox.Checked = _ofd.AddExtension;
		_checkFileExistsCheckBox.Checked = _ofd.CheckFileExists;
		_defaultExtensionText.Text = _ofd.DefaultExt;
		_filterIndexValue.Value = _ofd.FilterIndex;
		_filterText.Text = _ofd.Filter;
		_fileNameText.Text = _ofd.FileName;
		_fileNameText.SelectionStart = _fileNameText.Text.Length;
	}

	private OpenFileDialog _ofd;
	private Label _addExtensionLabel;
	private CheckBox _addExtensionCheckBox;
	private Label _checkFileExistsLabel;
	private CheckBox _checkFileExistsCheckBox;
	private Label _defaultExtensionLabel;
	private TextBox _defaultExtensionText;
	private Label _filterIndexLabel;
	private NumericUpDown _filterIndexValue;
	private Label _filterLabel;
	private TextBox _filterText;
	private Label _fileNameLabel;
	private TextBox _fileNameText;
	private Button _resetButton;
	private Button _openFileButton;

	private const string DefaultFilter = "Executables|*.dll;*.exe|Build Scripts|*.cmd;*.build|XML Files|*.xml|All Files|*";
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
			"1. Click the Reset button.{0}{0}" +
			"2. Uncheck the CheckFileExists checkbox.{0}{0}" +
			"3. Change the value of FilterIndex to 6.{0}{0}" +
			"4. Clear the value of Filter textbox.{0}{0}" +
			"5. Click the Open File button.{0}{0}" +
			"6. Enter \"abc\" in the File name combobox.{0}{0}" +
			"7. Click the Cancel button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 6.{0}{0}" +
			"2. The FileName is empty.",
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
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Uncheck the CheckFileExists checkbox.{0}{0}" +
			"3. Change the value of DefaultExt to \"doc\".{0}{0}" +
			"4. Change the value of FilterIndex to 6.{0}{0}" +
			"5. Clear the value of Filter textbox.{0}{0}" +
			"6. Click the Open File button.{0}{0}" +
			"7. Enter \"abc\" in the File name combobox.{0}{0}" +
			"8. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 0.{0}{0}" +
			"2. The file name part of FileName is \"abc.doc\".",
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
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Uncheck the CheckFileExists checkbox.{0}{0}" +
			"3. Change the value of DefaultExt to \"doc\".{0}{0}" +
			"4. Change the value of FilterIndex to 6.{0}{0}" +
			"5. Click the Open File button.{0}{0}" +
			"6. Enter \"abc\" in the File name combobox.{0}{0}" +
			"7. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 1.{0}{0}" +
			"2. The file name part of FileName is \"abc.dll\".",
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
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Uncheck the CheckFileExists checkbox.{0}{0}" +
			"3. Change the value of FilterIndex to 4.{0}{0}" +
			"4. Click the Open File button.{0}{0}" +
			"5. Enter \"abc\" in the File name combobox.{0}{0}" +
			"6. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 4.{0}{0}" +
			"2. The file name part of FileName is \"abc\".",
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
		_bugDescriptionText5.Dock = DockStyle.Fill;
		_bugDescriptionText5.Multiline = true;
		_bugDescriptionText5.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Uncheck the CheckFileExists checkbox.{0}{0}" +
			"3. Change the value of DefaultExt to \"doc\".{0}{0}" +
			"4. Change the value of FilterIndex to 4.{0}{0}" +
			"5. Click the Open File button.{0}{0}" +
			"6. Enter \"abc\" in the File name combobox.{0}{0}" +
			"7. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 4.{0}{0}" +
			"2. The file name part of FileName is \"abc.doc\".",
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
		_bugDescriptionText6.Dock = DockStyle.Fill;
		_bugDescriptionText6.Multiline = true;
		_bugDescriptionText6.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Uncheck the CheckFileExists checkbox.{0}{0}" +
			"3. Change the value of DefaultExt to \"txt\".{0}{0}" +
			"4. Click the Open File button.{0}{0}" +
			"5. Enter \"test\" in the File name combobox.{0}{0}" +
			"6. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 1.{0}{0}" +
			"2. The file name part of FileName is \"test.txt\".",
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
		_bugDescriptionText7.Dock = DockStyle.Fill;
		_bugDescriptionText7.Multiline = true;
		_bugDescriptionText7.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Change the value of DefaultExt to \"doc\".{0}{0}" +
			"3. Click the Open File button.{0}{0}" +
			"4. Enter \"test\" in the File name combobox.{0}{0}" +
			"5. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 1.{0}{0}" +
			"2. The file name part of FileName is \"test.doc\".",
			Environment.NewLine);
		// 
		// _tabPage7
		// 
		_tabPage7 = new TabPage ();
		_tabPage7.Text = "#7";
		_tabPage7.Controls.Add (_bugDescriptionText7);
		_tabControl.Controls.Add (_tabPage7);
		// 
		// _bugDescriptionText8
		// 
		_bugDescriptionText8 = new TextBox ();
		_bugDescriptionText8.Dock = DockStyle.Fill;
		_bugDescriptionText8.Multiline = true;
		_bugDescriptionText8.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Change the value of DefaultExt to \"txt\".{0}{0}" +
			"3. Click the Open File button.{0}{0}" +
			"4. Enter \"test\" in the File name combobox.{0}{0}" +
			"5. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 1.{0}{0}" +
			"2. The file name part of FileName is \"test.exe\".",
			Environment.NewLine);
		// 
		// _tabPage8
		// 
		_tabPage8 = new TabPage ();
		_tabPage8.Text = "#8";
		_tabPage8.Controls.Add (_bugDescriptionText8);
		_tabControl.Controls.Add (_tabPage8);
		// 
		// _bugDescriptionText9
		// 
		_bugDescriptionText9 = new TextBox ();
		_bugDescriptionText9.Dock = DockStyle.Fill;
		_bugDescriptionText9.Multiline = true;
		_bugDescriptionText9.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Uncheck the CheckFileExists checkbox.{0}{0}" +
			"3. Change the value of DefaultExt to \"doc\".{0}{0}" +
			"4. Change the value of FilterIndex to 3.{0}{0}" +
			"5. Click the Open File button.{0}{0}" +
			"6. Enter \"abc.txt\" in the File name combobox.{0}{0}" +
			"7. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 3.{0}{0}" +
			"2. The file name part of FileName is \"abc.txt\".",
			Environment.NewLine);
		// 
		// _tabPage9
		// 
		_tabPage9 = new TabPage ();
		_tabPage9.Text = "#9";
		_tabPage9.Controls.Add (_bugDescriptionText9);
		_tabControl.Controls.Add (_tabPage9);
		// 
		// _bugDescriptionText10
		// 
		_bugDescriptionText10 = new TextBox ();
		_bugDescriptionText10.Dock = DockStyle.Fill;
		_bugDescriptionText10.Multiline = true;
		_bugDescriptionText10.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Uncheck the CheckFileExists checkbox.{0}{0}" +
			"3. Change the value of DefaultExt to \"doc\".{0}{0}" +
			"4. Change the value of FilterIndex to 3.{0}{0}" +
			"5. Click the Open File button.{0}{0}" +
			"6. Enter \"tempfile\" in the File name combobox.{0}{0}" +
			"7. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 3.{0}{0}" +
			"2. The file name part of FileName is \"tempfile.doc\".",
			Environment.NewLine);
		// 
		// _tabPage10
		// 
		_tabPage10 = new TabPage ();
		_tabPage10.Text = "#10";
		_tabPage10.Controls.Add (_bugDescriptionText10);
		_tabControl.Controls.Add (_tabPage10);
		// 
		// _bugDescriptionText11
		// 
		_bugDescriptionText11 = new TextBox ();
		_bugDescriptionText11.Dock = DockStyle.Fill;
		_bugDescriptionText11.Multiline = true;
		_bugDescriptionText11.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Change the value of DefaultExt to \"doc\".{0}{0}" +
			"3. Change the value of FilterIndex to 3.{0}{0}" +
			"4. Click the Open File button.{0}{0}" +
			"5. Enter \"tempfile\" in the File name combobox.{0}{0}" +
			"6. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of FilterIndex is 3.{0}{0}" +
			"2. The file name part of FileName is \"tempfile\".",
			Environment.NewLine);
		// 
		// _tabPage11
		// 
		_tabPage11 = new TabPage ();
		_tabPage11.Text = "#11";
		_tabPage11.Controls.Add (_bugDescriptionText11);
		_tabControl.Controls.Add (_tabPage11);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (360, 345);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82214";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private TextBox _bugDescriptionText6;
	private TextBox _bugDescriptionText7;
	private TextBox _bugDescriptionText8;
	private TextBox _bugDescriptionText9;
	private TextBox _bugDescriptionText10;
	private TextBox _bugDescriptionText11;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
	private TabPage _tabPage6;
	private TabPage _tabPage7;
	private TabPage _tabPage8;
	private TabPage _tabPage9;
	private TabPage _tabPage10;
	private TabPage _tabPage11;
}
