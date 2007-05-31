using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _openFileButton
		// 
		_openFileButton = new Button ();
		_openFileButton.Location = new System.Drawing.Point (60, 28);
		_openFileButton.Text = "Open File";
		_openFileButton.Click += new System.EventHandler (OpenFileButton_Click);
		Controls.Add (_openFileButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (200, 80);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81784";
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
	}

	void OpenFileButton_Click (object sender, EventArgs e)
	{
		OpenFileDialog ofd = new OpenFileDialog ();
		ofd.Filter = "Text files (*.txt)|*.txt|Source files (*.cs)|*.cs|Application files (*.exe)|*.exe|All files (*.*)|*.*";
		ofd.FilterIndex = 2;
		ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
		ofd.ShowDialog ();

		MessageBox.Show (string.Format (CultureInfo.InvariantCulture,
			"FilterIndex: {0}", ofd.FilterIndex));

		ofd.Dispose ();
	}

	private Button _openFileButton;
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
			"1. Click the Open File button.{0}{0}" +
			"2. Select the \"Application files (*.exe)\" entry in the " +
			"\"Files of type\" ComboBox.{0}{0}" +
			"3. Select the \"test.exe\" file in the ListView.{0}{0}" +
			"4. Click the Open button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A message box stating \"FilterIndex: 3\" is displayed.",
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
			"1. Click the Open File button.{0}{0}" +
			"2. Select the \"Application files (*.exe)\" entry in the " +
			"\"Files of type\" ComboBox.{0}{0}" +
			"3. Select the \"test.exe\" file in the ListView.{0}{0}" +
			"4. Click the Cancel button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A message box stating \"FilterIndex: 2\" is displayed.",
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
		ClientSize = new Size (340, 230);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81784";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
