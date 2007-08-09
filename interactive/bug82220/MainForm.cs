using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dataGridView
		// 
		_dataGridView = new DataGridView ();
		_dataGridView.Dock = DockStyle.Top;
		_dataGridView.Height = 150;
		Controls.Add (_dataGridView);
		// 
		// _nameTextBoxColumn
		// 
		_nameTextBoxColumn = new DataGridViewTextBoxColumn ();
		_nameTextBoxColumn.HeaderText = "Name";
		_dataGridView.Columns.Add (_nameTextBoxColumn);
		// 
		// _firstNameTextBoxColumn
		// 
		_firstNameTextBoxColumn = new DataGridViewTextBoxColumn ();
		_firstNameTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		_firstNameTextBoxColumn.HeaderText = "First Name";
		_dataGridView.Columns.Add (_firstNameTextBoxColumn);
		// 
		// _clipboardCopyMode
		// 
		_clipboardCopyMode = new GroupBox ();
		_clipboardCopyMode.Location = new Point (8, 160);
		_clipboardCopyMode.Size = new Size (282, 100);
		_clipboardCopyMode.Text = "ClipboardCopyMode";
		Controls.Add (_clipboardCopyMode);
		// 
		// _disableClipboardCopyMode
		// 
		_disableClipboardCopyMode = new RadioButton ();
		_disableClipboardCopyMode.Location = new Point (8, 16);
		_disableClipboardCopyMode.Size = new Size (80, 20);
		_disableClipboardCopyMode.Text = "Disable";
		_disableClipboardCopyMode.CheckedChanged += new EventHandler (DisableClipboardCopyMode_CheckedChanged);
		_clipboardCopyMode.Controls.Add (_disableClipboardCopyMode);
		// 
		// _enableAlwaysIncludeHeaderTextClipboardCopyMode
		// 
		_enableAlwaysIncludeHeaderTextClipboardCopyMode = new RadioButton ();
		_enableAlwaysIncludeHeaderTextClipboardCopyMode.Location = new Point (8, 35);
		_enableAlwaysIncludeHeaderTextClipboardCopyMode.Size = new Size (200, 20);
		_enableAlwaysIncludeHeaderTextClipboardCopyMode.Text = "EnableAlwaysIncludeHeaderText";
		_enableAlwaysIncludeHeaderTextClipboardCopyMode.CheckedChanged += new EventHandler (EnableAlwaysIncludeHeaderTextClipboardCopyMode_CheckedChanged);
		_clipboardCopyMode.Controls.Add (_enableAlwaysIncludeHeaderTextClipboardCopyMode);
		// 
		// _enableWithAutoHeaderTextClipboardCopyMode
		// 
		_enableWithAutoHeaderTextClipboardCopyMode = new RadioButton ();
		_enableWithAutoHeaderTextClipboardCopyMode.Checked = true;
		_enableWithAutoHeaderTextClipboardCopyMode.Location = new Point (8, 54);
		_enableWithAutoHeaderTextClipboardCopyMode.Size = new Size (200, 20);
		_enableWithAutoHeaderTextClipboardCopyMode.Text = "EnableWithAutoHeaderText";
		_enableWithAutoHeaderTextClipboardCopyMode.CheckedChanged += new EventHandler (EnableWithAutoHeaderTextClipboardCopyMode_CheckedChanged);
		_clipboardCopyMode.Controls.Add (_enableWithAutoHeaderTextClipboardCopyMode);
		// 
		// _enableWithoutHeaderTextClipboardCopyMode
		// 
		_enableWithoutHeaderTextClipboardCopyMode = new RadioButton ();
		_enableWithoutHeaderTextClipboardCopyMode.Location = new Point (8, 73);
		_enableWithoutHeaderTextClipboardCopyMode.Size = new Size (200, 20);
		_enableWithoutHeaderTextClipboardCopyMode.Text = "EnableWithoutHeaderText";
		_enableWithoutHeaderTextClipboardCopyMode.CheckedChanged += new EventHandler (EnableWithoutHeaderTextClipboardCopyMode_CheckedChanged);
		_clipboardCopyMode.Controls.Add (_enableWithoutHeaderTextClipboardCopyMode);
		// 
		// _copyButton
		// 
		_copyButton = new Button ();
		_copyButton.Location = new Point (8, 270);
		_copyButton.Size = new Size (60, 20);
		_copyButton.Text = "Copy";
		_copyButton.Click += new EventHandler (CopyButton_Click);
		Controls.Add (_copyButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82220";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_dataGridView.Rows.Add ("de Icaza", "Miguel");
		_dataGridView.Rows.Add ("Toshok", "Chris");
		_dataGridView.Rows.Add ("Harper", "Jackson");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void DisableClipboardCopyMode_CheckedChanged (object sender, EventArgs e)
	{
		if (_disableClipboardCopyMode.Checked)
			_dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
	}

	void EnableAlwaysIncludeHeaderTextClipboardCopyMode_CheckedChanged (object sender, EventArgs e)
	{
		if (_enableAlwaysIncludeHeaderTextClipboardCopyMode.Checked)
			_dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
	}

	void EnableWithAutoHeaderTextClipboardCopyMode_CheckedChanged (object sender, EventArgs e)
	{
		if (_enableWithAutoHeaderTextClipboardCopyMode.Checked)
			_dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
	}

	void EnableWithoutHeaderTextClipboardCopyMode_CheckedChanged (object sender, EventArgs e)
	{
		if (_enableWithoutHeaderTextClipboardCopyMode.Checked)
			_dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
	}

	void CopyButton_Click (object sender, EventArgs e)
	{
		DataObject data = _dataGridView.GetClipboardContent ();
		if (data != null)
			Clipboard.SetDataObject(data);
		MessageBox.Show (Clipboard.GetText ());
	}

	private DataGridView _dataGridView;
	private DataGridViewTextBoxColumn _nameTextBoxColumn;
	private DataGridViewTextBoxColumn _firstNameTextBoxColumn;
	private GroupBox _clipboardCopyMode;
	private RadioButton _disableClipboardCopyMode;
	private RadioButton _enableAlwaysIncludeHeaderTextClipboardCopyMode;
	private RadioButton _enableWithAutoHeaderTextClipboardCopyMode;
	private RadioButton _enableWithoutHeaderTextClipboardCopyMode;
	private Button _copyButton;
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
			"1. Click on the Name cell of the second row.{0}{0}" +
			"2. Click the Copy button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A message box stating \"Toshok\" is displayed.",
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
			"1. Select the third row of the DataGridView.{0}{0}" +
			"2. Click the Copy button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A message box stating the following text is displayed:{0}{0}" +
			"   (empty)  Harper  Jackson",
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
			"1. Select the Name and First Name cells of the third row.{0}{0}" +
			"2. Click the Copy button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A message box stating \"Harper Jackson\" is displayed.",
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
			"1. Select the first and third row.{0}{0}" +
			"2. Click the Copy button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A message box stating the following text is displayed:{0}{0}" +
			"   (empty)  de Icaza Miguel{0}" +
			"   (empty)  Harper   Jackson",
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
		ClientSize = new Size (320, 200);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82220";
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
