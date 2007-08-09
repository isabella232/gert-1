using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _fileNameLabel
		// 
		_fileNameLabel = new Label ();
		_fileNameLabel.AutoSize = true;
		_fileNameLabel.Location = new Point (8, 8);
		_fileNameLabel.Text = "FileName:";
		Controls.Add (_fileNameLabel);
		// 
		// _fileNameText
		// 
		_fileNameText = new TextBox ();
		_fileNameText.Location = new Point (120, 8);
		_fileNameText.Size = new Size (450, 25);
		Controls.Add (_fileNameText);
		// 
		// _filterLabel
		// 
		_filterLabel = new Label ();
		_filterLabel.AutoSize = true;
		_filterLabel.Location = new Point (8, 35);
		_filterLabel.Text = "Filter:";
		Controls.Add (_filterLabel);
		// 
		// _filterText
		// 
		_filterText = new TextBox ();
		_filterText.Location = new Point (120, 35);
		_filterText.Size = new Size (450, 25);
		Controls.Add (_filterText);
		// 
		// _filterIndexLabel
		// 
		_filterIndexLabel = new Label ();
		_filterIndexLabel.AutoSize = true;
		_filterIndexLabel.Location = new Point (8, 62);
		_filterIndexLabel.Text = "FilterIndex:";
		Controls.Add (_filterIndexLabel);
		// 
		// _filterIndexText
		// 
		_filterIndexText = new TextBox ();
		_filterIndexText.Location = new Point (120, 62);
		_filterIndexText.Size = new Size (100, 25);
		Controls.Add (_filterIndexText);
		// 
		// _initialDirectoryLabel
		// 
		_initialDirectoryLabel = new Label ();
		_initialDirectoryLabel.AutoSize = true;
		_initialDirectoryLabel.Location = new Point (8, 89);
		_initialDirectoryLabel.Text = "InitialDirectory:";
		Controls.Add (_initialDirectoryLabel);
		// 
		// _initialDirectoryText
		// 
		_initialDirectoryText = new TextBox ();
		_initialDirectoryText.Location = new Point (120, 89);
		_initialDirectoryText.Size = new Size (450, 25);
		Controls.Add (_initialDirectoryText);
		// 
		// _titleLabel
		// 
		_titleLabel = new Label ();
		_titleLabel.AutoSize = true;
		_titleLabel.Location = new Point (8, 116);
		_titleLabel.Text = "Title:";
		Controls.Add (_titleLabel);
		// 
		// _titleText
		// 
		_titleText = new TextBox ();
		_titleText.Location = new Point (120, 116);
		_titleText.Size = new Size (450, 25);
		Controls.Add (_titleText);
		// 
		// _openFileButton
		// 
		_openFileButton = new Button ();
		_openFileButton.Location = new Point (200, 150);
		_openFileButton.Size = new Size (80, 20);
		_openFileButton.Text = "Open";
		_openFileButton.Click += new EventHandler (OpenFileButton_Click);
		Controls.Add (_openFileButton);
		// 
		// _saveFileButton
		// 
		_saveFileButton = new Button ();
		_saveFileButton.Location = new Point (300, 150);
		_saveFileButton.Size = new Size (80, 20);
		_saveFileButton.Text = "Save";
		_saveFileButton.Click += new EventHandler (SaveFileButton_Click);
		Controls.Add (_saveFileButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (600, 180);
		Location = new Point (100, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80887";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	static string ConvertToNull (string text)
	{
		if (text.Length == 0)
			return null;
		return text;
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		ResetValues ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void OpenFileButton_Click (object sender, EventArgs e)
	{
		_ofd.FileName = ConvertToNull (_fileNameText.Text);
		_ofd.Filter = ConvertToNull (_filterText.Text);
		_ofd.FilterIndex = int.Parse (_filterIndexText.Text, CultureInfo.InvariantCulture);
		_ofd.InitialDirectory = ConvertToNull (_initialDirectoryText.Text);
		_ofd.Title = ConvertToNull (_titleText.Text);
		_ofd.Multiselect = true;
		_ofd.ValidateNames = false;
		_ofd.ShowDialog ();
		RefreshValuesOpen ();
	}

	void SaveFileButton_Click (object sender, EventArgs e)
	{
		_sfd.FileName = ConvertToNull(_fileNameText.Text);
		_sfd.Filter = ConvertToNull(_filterText.Text);
		_sfd.FilterIndex = int.Parse (_filterIndexText.Text, CultureInfo.InvariantCulture);
		_sfd.InitialDirectory = ConvertToNull(_initialDirectoryText.Text);
		_sfd.Title = ConvertToNull(_titleText.Text);
		_sfd.ValidateNames = false;
		_sfd.ShowDialog ();
		RefreshValuesSave ();
	}

	void RefreshValuesOpen ()
	{
		_fileNameText.Text = _ofd.FileName;
		_filterText.Text = _ofd.Filter;
		_filterIndexText.Text = _ofd.FilterIndex.ToString (CultureInfo.InvariantCulture);
		_initialDirectoryText.Text = _ofd.InitialDirectory;
		_titleText.Text = _ofd.Title;
	}

	void RefreshValuesSave ()
	{
		_fileNameText.Text = _sfd.FileName;
		_filterText.Text = _sfd.Filter;
		_filterIndexText.Text = _sfd.FilterIndex.ToString (CultureInfo.InvariantCulture);
		_initialDirectoryText.Text = _sfd.InitialDirectory;
		_titleText.Text = _sfd.Title;
	}

	void ResetValues ()
	{
		_fileNameText.Text = "whatever";
		_filterText.Text = "NAnt build files|*.build|C# sources|*.cs";
		_filterIndexText.Text = "1";
		_initialDirectoryText.Text = AppDomain.CurrentDomain.BaseDirectory;
		_titleText.Text = "Saving";
	}

	private Button _openFileButton;
	private Button _saveFileButton;
	private Label _fileNameLabel;
	private TextBox _fileNameText;
	private Label _filterLabel;
	private TextBox _filterText;
	private Label _filterIndexLabel;
	private TextBox _filterIndexText;
	private Label _initialDirectoryLabel;
	private TextBox _initialDirectoryText;
	private Label _titleLabel;
	private TextBox _titleText;
	private SaveFileDialog _sfd = new SaveFileDialog ();
	private OpenFileDialog _ofd = new OpenFileDialog ();
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
			"1. Click the Save button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A \"Save As\" dialog is displayed.{0}{0}" +
			"2. The \"bug80887\" directory is displayed in the \"Save in\" " +
			"combobox.{0}{0}" +
			"3. The \"File name\" combobox displays \"whatever\" and is " +
			"highlighted.{0}{0}" +
			"4. The \"NAnt build files\" item is selected in the \"Save as type\"" +
			"combobox.{0}{0}" +
			"5. The listview contains two items:{0}{0}" +
			"   * The \"test\" directory.{0}" +
			"   * The \"default.build\" file.",
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
			"1. Click the Save button.{0}{0}" +
			"2. Click the dropdown arrow of the \"File name\" combobox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The dropped down combobox only contains files with extension " +
			"\".build\" that were recently saved.{0}{0}" +
			"2. The \"bug80887\" directory is displayed in the \"Save in\" " +
			"combobox.{0}{0}" +
			"3. The listview contains two items:{0}{0}" +
			"   * The \"test\" directory.{0}" +
			"   * The \"default.build\" file.{0}{0}" +
			"4. The \"File name\" combobox displays \"whatever\".{0}{0}" +
			"5. The \"NAnt build files\" item is selected in the \"Save as type\"" +
			"combobox.",
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
			"1. Click the Save button.{0}{0}" +
			"2. Click the dropdown arrow of the \"Save as type\" combobox.{0}{0}" +
			"3. Select the \"C# sources\" item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The listview contains two items:{0}{0}" +
			"   * The \"test\" directory.{0}" +
			"   * The \"MainForm.cs\" file.",
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
			"1. Click the Save button.{0}{0}" +
			"2. Click the dropdown arrow of the \"Save as type\" combobox.{0}{0}" +
			"3. Select the \"C# sources\" item.{0}{0}" +
			"4. Click the dropdown arrow of the \"Save as type\" combobox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The dropped down combobox only contains files with extension " +
			"\".cs\" that were recently saved.",
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
			"1. Click the Save button.{0}{0}" +
			"2. Click the \"test\" directory.{0}{0}" +
			"3. Click the \"default.build\" file.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the text of the \"File name\" combobox does not " +
			"change.{0}{0}" +
			"2. On step 3, the text of the \"File name\" combobox changes to " +
			"\"default.build\".",
			Environment.NewLine);
		// 
		// _tabPage5
		// 
		_tabPage5 = new TabPage ();
		_tabPage5.Text = "#5";
		_tabPage5.Controls.Add (_bugDescriptionText5);
		_tabControl.Controls.Add (_tabPage5);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (450, 320);
		Location = new Point (720, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80887";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
}
