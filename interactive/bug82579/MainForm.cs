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
		// _rootFolderGroupBox
		// 
		_rootFolderGroupBox = new GroupBox ();
		_rootFolderGroupBox.Location = new Point (8, 104);
		_rootFolderGroupBox.Size = new Size (382, 90);
		_rootFolderGroupBox.Text = "RootFolder";
		Controls.Add (_rootFolderGroupBox);
		// 
		// _desktopFolderRadioButton
		// 
		_desktopFolderRadioButton = new RadioButton ();
		_desktopFolderRadioButton.Location = new Point (8, 16);
		_desktopFolderRadioButton.Tag = Environment.SpecialFolder.Desktop;
		_desktopFolderRadioButton.Text = "Desktop";
		_rootFolderGroupBox.Controls.Add (_desktopFolderRadioButton);
		// 
		// _myComputerFolderRadioButton
		// 
		_myComputerFolderRadioButton = new RadioButton ();
		_myComputerFolderRadioButton.Location = new Point (8, 38);
		_myComputerFolderRadioButton.Tag = Environment.SpecialFolder.MyComputer;
		_myComputerFolderRadioButton.Text = "My Computer";
		_rootFolderGroupBox.Controls.Add (_myComputerFolderRadioButton);
		// 
		// _personalFolderRadioButton
		// 
		_personalFolderRadioButton = new RadioButton ();
		_personalFolderRadioButton.Location = new Point (8, 60);
		_personalFolderRadioButton.Tag = Environment.SpecialFolder.Personal;
		_personalFolderRadioButton.Text = "Personal";
		_rootFolderGroupBox.Controls.Add (_personalFolderRadioButton);
		// 
		// _selectFolderButton
		// 
		_selectFolderButton = new Button ();
		_selectFolderButton.Location = new Point (180, 210);
		_selectFolderButton.Size = new Size (60, 20);
		_selectFolderButton.Text = "Select";
		_selectFolderButton.Click += new EventHandler (SelectFolderButton_Click);
		Controls.Add (_selectFolderButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 245);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82579";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_fbd = new FolderBrowserDialog ();
		SyncForm ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void SelectFolderButton_Click (object sender, EventArgs e)
	{
		SyncDialog ();
		DialogResult result = _fbd.ShowDialog (this);
		_dialogResultText.Text = result.ToString ();
		SyncForm ();
	}

	void SyncDialog ()
	{
		foreach (RadioButton rb in _rootFolderGroupBox.Controls) {
			if (rb.Checked) {
				if ((Environment.SpecialFolder) rb.Tag != _fbd.RootFolder)
					_fbd.RootFolder = (Environment.SpecialFolder) rb.Tag;
				break;
			}
		}
	}

	void SyncForm ()
	{
		foreach (RadioButton rb in _rootFolderGroupBox.Controls) {
			if (_fbd.RootFolder == (Environment.SpecialFolder) rb.Tag) {
				rb.Checked = true;
				break;
			}
		}

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
	private GroupBox _rootFolderGroupBox;
	private RadioButton _desktopFolderRadioButton;
	private RadioButton _myComputerFolderRadioButton;
	private RadioButton _personalFolderRadioButton;
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
			"1. Check the My Computer radiobutton.{0}{0}" +
			"2. Click the Select button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Only the My Computer node and its volumes are " +
			"displayed.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (330, 165);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82579";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
