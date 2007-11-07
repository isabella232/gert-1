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
		_openFileButton.Location = new Point (110, 20);
		_openFileButton.Text = "Open File";
		_openFileButton.Click += new EventHandler (OpenFileButton_Click);
		Controls.Add (_openFileButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 65);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #338399";
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
		OpenFileDialog ofd = new OpenFileDialog();
		ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
		ofd.ShowDialog ();
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
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Open File button.{0}{0}" +
			"2. Double-click the \"test\" directory.{0}{0}" +
			"3. Click the Up button.{0}{0}" +
			"4. Click in the empty area of the listview.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No crash.",
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
		ClientSize = new Size (300, 220);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #338399";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
