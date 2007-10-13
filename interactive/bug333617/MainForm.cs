using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _saveFileButton
		// 
		_saveFileButton = new Button ();
		_saveFileButton.Location = new Point (110, 25);
		_saveFileButton.Size = new Size (80, 20);
		_saveFileButton.Text = "Save";
		_saveFileButton.Click += new EventHandler (SaveFileButton_Click);
		Controls.Add (_saveFileButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 80);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #333617";
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
		_sfd.Filter = "NAnt build files|*.build|C# sources|*.cs";
		_sfd.ShowDialog ();
	}

	private Button _saveFileButton;
	private SaveFileDialog _sfd = new SaveFileDialog ();
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
			"2. Click the dropdown array of the \"Save as type\" " +
			"combobox.{0}{0}" +
			"3. Click the Save button.{0}{0}" +
			"4. Click the dropdown array of the \"Save as type\" " +
			"combobox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A listbox is dropped down (as in step 2).",
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
		ClientSize = new Size (300, 260);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #333617";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
