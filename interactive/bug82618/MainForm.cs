using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dialogResultLabel
		// 
		_dialogResultLabel = new Label ();
		_dialogResultLabel.AutoSize = true;
		_dialogResultLabel.Location = new Point (8, 8);
		_dialogResultLabel.Text = "DialogResult:";
		Controls.Add (_dialogResultLabel);
		// 
		// _dialogResultText
		// 
		_dialogResultText = new TextBox ();
		_dialogResultText.Location = new Point (90, 8);
		_dialogResultText.ReadOnly = true;
		_dialogResultText.Size = new Size (80, 20);
		_dialogResultText.TabStop = false;
		Controls.Add (_dialogResultText);
		// 
		// _selectedPathLabel
		// 
		_selectedPathLabel = new Label ();
		_selectedPathLabel.AutoSize = true;
		_selectedPathLabel.Location = new Point (8, 40);
		_selectedPathLabel.Text = "SelectedPath:";
		Controls.Add (_selectedPathLabel);
		// 
		// _selectedPathText
		// 
		_selectedPathText = new TextBox ();
		_selectedPathText.Location = new Point (90, 40);
		_selectedPathText.ReadOnly = true;
		_selectedPathText.Size = new Size (300, 20);
		_selectedPathText.TabStop = false;
		Controls.Add (_selectedPathText);
		// 
		// _existsLabel
		// 
		_existsLabel = new Label ();
		_existsLabel.AutoSize = true;
		_existsLabel.Location = new Point (8, 72);
		_existsLabel.Text = "Exists:";
		Controls.Add (_existsLabel);
		// 
		// _folderExistsCheckBox
		// 
		_folderExistsCheckBox = new CheckBox ();
		_folderExistsCheckBox.Checked = false;
		_folderExistsCheckBox.Enabled = false;
		_folderExistsCheckBox.Location = new Point (90, 72);
		_folderExistsCheckBox.TabStop = false;
		Controls.Add (_folderExistsCheckBox);
		// 
		// _selectFolderButton
		// 
		_selectFolderButton = new Button ();
		_selectFolderButton.Location = new Point (180, 104);
		_selectFolderButton.Size = new Size (60, 20);
		_selectFolderButton.Text = "Select";
		_selectFolderButton.Click += new EventHandler (SelectFolderButton_Click);
		Controls.Add (_selectFolderButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 140);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82618";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_fbd = new FolderBrowserDialog ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void SelectFolderButton_Click (object sender, EventArgs e)
	{
		_fbd.SelectedPath = null;
		DialogResult result = _fbd.ShowDialog (this);
		_dialogResultText.Text = result.ToString ();

		_selectedPathText.Text = _fbd.SelectedPath;
		if (_selectedPathText.Text.Length > 0)
			_folderExistsCheckBox.Checked = Directory.Exists (_fbd.SelectedPath);
		else
			_folderExistsCheckBox.Checked = false;

	}

	private Label _dialogResultLabel;
	private TextBox _dialogResultText;
	private Label _selectedPathLabel;
	private TextBox _selectedPathText;
	private Label _existsLabel;
	private CheckBox _folderExistsCheckBox;
	private Button _selectFolderButton;
	private FolderBrowserDialog _fbd;
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
			"1. Click the Select button.{0}{0}" +
			"2. Select the Desktop node.{0}{0}" +
			"3. Click the Make New Folder button.{0}{0}" +
			"4. Enter the name of a non-existing folder.{0}{0}" +
			"5. Press the Enter key..{0}{0}" +
			"6. Click the Make New Folder button.{0}{0}" +
			"7. Enter Mono as label.{0}{0}" +
			"8. Press the Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. DialogResult is OK.{0}{0}" +
			"2. SelectedPath is the full path of the Mono folder.{0}{0}" +
			"3. The Exists checkbox is checked.",
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
			"1. Click the Select button.{0}{0}" +
			"2. Select the Desktop node.{0}{0}" +
			"3. Click the Make New Folder button.{0}{0}" +
			"4. Press the Esc key.{0}{0}" +
			"5. Click the Make New Folder button.{0}{0}" +
			"6. Enter Mono as label.{0}{0}" +
			"7. Press the Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. DialogResult is OK.{0}{0}" +
			"2. SelectedPath is the full path of the Mono folder.{0}{0}" +
			"3. The Exists checkbox is checked.",
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
		ClientSize = new Size (360, 375);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82618";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
