using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _openFileButton
		// 
		_openFileButton = new Button ();
		_openFileButton.Location = new Point (40, 30);
		_openFileButton.Size = new Size (80, 20);
		_openFileButton.Text = "Open File";
		_openFileButton.Click += new EventHandler (OpenFileButton_Click);
		Controls.Add (_openFileButton);
		// 
		// _saveFileButton
		// 
		_saveFileButton = new Button ();
		_saveFileButton.Location = new Point (175, 30);
		_saveFileButton.Size = new Size (80, 20);
		_saveFileButton.Text = "Save File";
		_saveFileButton.Click += new EventHandler (SaveFileButton_Click);
		Controls.Add (_saveFileButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 70);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82539";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void OpenFileButton_Click (object sender, EventArgs e)
	{
		OpenFileDialog ofd = new OpenFileDialog ();
		ofd.ShowDialog ();
	}

	void SaveFileButton_Click (object sender, EventArgs e)
	{
		SaveFileDialog sfd = new SaveFileDialog ();
		sfd.ShowDialog ();
	}

	private Button _openFileButton;
	private Button _saveFileButton;
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
			"1. Click the Open File button.{0}{0}" +
			"2. Clear the text in the Filename combobox.{0}{0}" +
			"3. Click the Open button.{0}{0}" +
			"4. Click the Cancel button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, the dialog box does not close.{0}{0}" +
			"2. On step 4, the dialog box closes.",
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
			"1. Click the Open File button.{0}{0}" +
			"2. Clear the text in the Filename combobox.{0}{0}" +
			"3. Click the Save button.{0}{0}" +
			"4. Click the Cancel button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, the dialog box does not close.{0}{0}" +
			"2. On step 4, the dialog box closes.",
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
		ClientSize = new Size (300, 250);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82539";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}

