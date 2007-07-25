using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _sfd
		// 
		_sfd = new SaveFileDialog ();
		_sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
		// 
		// _saveFileButton
		// 
		_saveFileButton = new Button ();
		_saveFileButton.Location = new Point (60, 25);
		_saveFileButton.Size = new Size (80, 20);
		_saveFileButton.Text = "Save File";
		_saveFileButton.Click += new EventHandler (SaveFileButton_Click);
		Controls.Add (_saveFileButton);
		// 
		// MainForm
		// 
		Location = new Point (350, 100);
		Size = new Size (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82187";
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

	void SaveFileButton_Click (object sender, EventArgs e)
	{
		_sfd.ShowDialog ();
	}

	private SaveFileDialog _sfd;
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
			"1. Click the Save File button.{0}{0}" +
			"2. Click the Cancel button.{0}{0}" +
			"3. Click the Save File button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Save dialog box is displayed ok in the center of the " +
			"screen.",
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
		ClientSize = new Size (300, 200);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82187";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
