using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
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
		_rootFolderGroupBox.Size = new Size (382, 110);
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
		// _recentFolderRadioButton
		// 
		_recentFolderRadioButton = new RadioButton ();
		_recentFolderRadioButton.Location = new Point (8, 82);
		_recentFolderRadioButton.Tag = Environment.SpecialFolder.Recent;
		_recentFolderRadioButton.Text = "Recent";
		_rootFolderGroupBox.Controls.Add (_recentFolderRadioButton);
		// 
		// _selectFolderButton
		// 
		_selectFolderButton = new Button ();
		_selectFolderButton.Location = new Point (180, 225);
		_selectFolderButton.Size = new Size (60, 20);
		_selectFolderButton.Text = "Select";
		_selectFolderButton.Click += new EventHandler (SelectFolderButton_Click);
		Controls.Add (_selectFolderButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 255);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82580";
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
		_fbd.SelectedPath = _selectedPathText.Text;

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
	private RadioButton _recentFolderRadioButton;
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
			"2. Enter the absolute path of an existing directory " +
			"in the SelectedPath textbox.{0}{0}" +
			"3. Click the Select button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Part of the TreeView up to the node for the entered " +
			"path is expanded.{0}" +
			"2. The node for the entered path is highlighted.{0}" +
			"3. The TreeView has focus.",
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
			"1. Check the My Computer radiobutton.{0}{0}" +
			"2. Enter the absolute path of a non-existing directory " +
			"in the SelectedPath textbox, where part of the part " +
			"matches an existing directory.{0}{0}" +
			"3. Click the Select button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Only the My Computer node itself is expanded.{0}{0}" +
			"2. The My Computer node is highlighted.",
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
			"1. Check the Desktop radiobutton.{0}{0}" +
			"2. Enter a relative path to a subdirectory of the " +
			"Desktop.{0}{0}" +
			"3. Click the Select button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Part of the TreeView up to the node for the entered " +
			"path is expanded.{0}{0}" +
			"2. The node for the entered path is highlighted.{0}{0}" +
			"3. The TreeView has focus.",
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
			"1. Check the Personal radiobutton.{0}{0}" +
			"2. Enter an absolute path of a subdirectory of the " +
			"Personal shell namespace.{0}{0}" +
			"3. Click the Select button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Part of the TreeView up to the node for the entered " +
			"path is expanded.{0}{0}" +
			"2. The node for the entered path is highlighted.{0}{0}" +
			"3. The TreeView has focus.",
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
		if (!RunningOnUnix) {
			_bugDescriptionText5.Text = string.Format (CultureInfo.InvariantCulture,
				"Steps to execute:{0}{0}" +
				"1. Check the My Computer radiobutton.{0}{0}" +
				"2. Enter the absolute path of an existing directory " +
				"in the SelectedPath textbox, with casing that " +
				"differs from the actual path.{0}{0}" +
				"3. Click the Select button.{0}{0}" +
				"Expected result:{0}{0}" +
				"1. Part of the TreeView up to the node for the entered " +
				"path is expanded.{0}" +
				"2. The node for the entered path is highlighted.{0}" +
				"3. The TreeView has focus.",
				Environment.NewLine);
		} else {
			_bugDescriptionText5.Text = string.Format (CultureInfo.InvariantCulture,
				"Steps to execute:{0}{0}" +
				"1. Check the My Computer radiobutton.{0}{0}" +
				"2. Enter the absolute path of an existing directory " +
				"in the SelectedPath textbox, with casing that " +
				"differs from the actual path.{0}{0}" +
				"3. Click the Select button.{0}{0}" +
				"Expected result:{0}{0}" +
				"1. Only the My Computer node itself is expanded.{0}{0}" +
				"2. The My Computer node is highlighted.",
				Environment.NewLine);
		}
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
		ClientSize = new Size (390, 350);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82580";
	}

	static bool RunningOnUnix
	{
		get
		{
#if NET_2_0
			return (Environment.OSVersion.Platform == PlatformID.Unix);
#else
			int platform = (int) Environment.OSVersion.Platform;
			return (platform == 128);
#endif
		}
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
