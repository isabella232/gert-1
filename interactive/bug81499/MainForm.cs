using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _fileListBox
		// 
		_fileListBox = new ListBox ();
		_fileListBox.Dock = DockStyle.Top;
		_fileListBox.Height = 100;
		Controls.Add (_fileListBox);
		// 
		// _supportMultiDottedCheckBox
		// 
		_supportMultiDottedCheckBox = new CheckBox ();
		_supportMultiDottedCheckBox.Checked = false;
		_supportMultiDottedCheckBox.Location = new Point (8, 110);
		_supportMultiDottedCheckBox.Size = new Size (200, 20);
		_supportMultiDottedCheckBox.Text = "Support Multidotted Extension";
		Controls.Add (_supportMultiDottedCheckBox);
		// 
		// _saveFileButton
		// 
		_saveFileButton = new Button ();
		_saveFileButton.Location = new Point (240, 110);
		_saveFileButton.Size = new Size (100, 20);
		_saveFileButton.Text = "Save File";
		_saveFileButton.Click += new EventHandler (SaveFileButton_Click);
		Controls.Add (_saveFileButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (350, 140);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81499";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();

#if ONLY_1_1
		_supportMultiDottedCheckBox.Checked = false;
		_supportMultiDottedCheckBox.Enabled = false;
#endif
	}

	void SaveFileButton_Click (object sender, EventArgs e)
	{
		_fileListBox.Items.Clear ();

		_saveFileDialog = new SaveFileDialog ();
#if NET_2_0
		_saveFileDialog.SupportMultiDottedExtensions = _supportMultiDottedCheckBox.Checked;
#endif
		_saveFileDialog.Filter = "Doc files (*.doc)|*.foo.doc|All files|*.*";
		_saveFileDialog.ShowDialog ();

		foreach (string file in _saveFileDialog.FileNames) {
			_fileListBox.Items.Add (file);
		}
	}

	private ListBox _fileListBox;
	private CheckBox _supportMultiDottedCheckBox;
	private Button _saveFileButton;
	private SaveFileDialog _saveFileDialog;
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
#if NET_2_0
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck the Support Multidotted Extension checkbox.{0}{0}" +
			"2. Click the Save File button.{0}{0}" +
			"3. Enter \"abc\" in the \"File name\" combobox.{0}{0}" +
			"4. Click the Save button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The listbox contains an entry with file name \"...{1}abc.doc\".",
			Environment.NewLine, Path.DirectorySeparatorChar);
#else
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Save File button.{0}{0}" +
			"2. Enter \"abc\" in the \"File name\" combobox.{0}{0}" +
			"3. Click the Save button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The listbox contains an entry with file name \"...{1}abc.doc\".",
			Environment.NewLine, Path.DirectorySeparatorChar);
#endif
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
#if NET_2_0
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Check the Support Multidotted Extension checkbox.{0}{0}" +
			"2. Click the Save File button.{0}{0}" +
			"3. Enter \"abc\" in the \"File name\" combobox.{0}{0}" +
			"4. Click the Save button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The listbox contains an entry with file name \"...{1}abc.doc.foo\".",
			Environment.NewLine, Path.DirectorySeparatorChar);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
#endif
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (330, 230);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81499";
	}

	private TextBox _bugDescriptionText1;
#if NET_2_0
	private TextBox _bugDescriptionText2;
#endif
	private TabControl _tabControl;
	private TabPage _tabPage1;
#if NET_2_0
	private TabPage _tabPage2;
#endif
}
