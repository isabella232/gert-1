using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _normalCheckBox
		// 
		_normalCheckBox = new CheckBox ();
		_normalCheckBox.Checked = true;
		_normalCheckBox.Location = new Point (55, 8);
		_normalCheckBox.Size = new Size (60, 20);
		_normalCheckBox.Text = "Normal";
		Controls.Add (_normalCheckBox);
		// 
		// _buttonCheckBox
		// 
		_buttonCheckBox = new CheckBox ();
		_buttonCheckBox.Appearance = Appearance.Button;
		_buttonCheckBox.Checked = true;
		_buttonCheckBox.Location = new Point (170, 8);
		_buttonCheckBox.Size = new Size (60, 20);
		_buttonCheckBox.Text = "Button";
		Controls.Add (_buttonCheckBox);
		// 
		// _enabledCheckBox
		// 
		_enabledCheckBox = new CheckBox ();
		_enabledCheckBox.Checked = true;
		_enabledCheckBox.Location = new Point (8, 55);
		_enabledCheckBox.Size = new Size (70, 20);
		_enabledCheckBox.Text = "Enabled";
		_enabledCheckBox.CheckedChanged += new EventHandler (EnabledCheckBox_CheckedChanged);
		Controls.Add (_enabledCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 80);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82656";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void EnabledCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		_normalCheckBox.Enabled = _enabledCheckBox.Checked;
		_buttonCheckBox.Enabled = _enabledCheckBox.Checked;
	}

	private CheckBox _normalCheckBox;
	private CheckBox _buttonCheckBox;
	private CheckBox _enabledCheckBox;
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
			"Expected result on start-up:{0}{0}" +
			"1. The Normal checkbox has a sunken border.",
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
			"1. Uncheck the Enabled checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The checkbox is grayed out.{0}{0}" +
			"2. All borders of the checkbox remain visible.",
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
		ClientSize = new Size (330, 170);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82656";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
