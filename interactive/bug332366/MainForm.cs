using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _comboBox
		// 
		_comboBox = new ComboBox ();
		_comboBox.Location = new Point (75, 12);
		_comboBox.Size = new Size (140, 20);
		Controls.Add (_comboBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 50);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #332366";
		Load += new EventHandler (MainForm_Load);
	}
	
	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		for (int i = 1; i <= 40; i++)
			_comboBox.Items.Add (i.ToString (CultureInfo.InvariantCulture));
		_comboBox.SelectedIndex = 0;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private ComboBox _comboBox;
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
			"1. Click the dropdown arrow.{0}{0}" +
			"2. Scroll down.{0}{0}" +
			"2. Select item \"40\".{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The dropdown list is closed.{0}{0}" +
			"2. The text \"40\" is displayed in the combobox.",
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
		Text = "Instructions - bug #332366";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
