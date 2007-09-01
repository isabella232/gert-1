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
		// MainForm
		// 
		ClientSize = new Size (300, 50);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82657";
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

	private CheckBox _normalCheckBox;
	private CheckBox _buttonCheckBox;
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
			"1. The left checkbox is a \"normal\" checkbox.{0}{0}" +
			"1. The right checkbox is a \"button\" checkbox.",
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
		ClientSize = new Size (300, 110);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82657";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
