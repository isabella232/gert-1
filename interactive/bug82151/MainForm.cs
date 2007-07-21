using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _toolStrip
		// 
		_toolStrip = new ToolStrip ();
		_toolStrip.Renderer = new ToolStripSystemRenderer ();
		Controls.Add (_toolStrip);
		// 
		// _toolStripButton1
		// 
		_toolStripButton1 = new ToolStripButton ();
		_toolStripButton1.Text = "1";
		_toolStrip.Items.Add (_toolStripButton1);
		// 
		// _toolStripButton2
		// 
		_toolStripButton2 = new ToolStripButton ();
		_toolStripButton2.Checked = true;
		_toolStripButton2.Text = "2";
		_toolStrip.Items.Add (_toolStripButton2);
		// 
		// _toolStripButton3
		// 
		_toolStripButton3 = new ToolStripButton ();
		_toolStripButton3.Text = "3";
		_toolStrip.Items.Add (_toolStripButton3);
		// 
		// _checkedGroupBox
		// 
		_checkedGroupBox = new GroupBox ();
		_checkedGroupBox.Location = new Point (20, 35);
		_checkedGroupBox.Size = new Size (260, 85);
		_checkedGroupBox.Text = "Checked";
		Controls.Add (_checkedGroupBox);
		// 
		// _button1CheckBox
		// 
		_button1CheckBox = new CheckBox ();
		_button1CheckBox.Checked = _toolStripButton1.Checked;
		_button1CheckBox.Location = new Point (8, 16);
		_button1CheckBox.Text = "1";
		_checkedGroupBox.Controls.Add (_button1CheckBox);
		_button1CheckBox.CheckedChanged += delegate (object sender, EventArgs e) {
			_toolStripButton1.Checked = _button1CheckBox.Checked;
		};
		// 
		// _button2CheckBox
		// 
		_button2CheckBox = new CheckBox ();
		_button2CheckBox.Checked = _toolStripButton2.Checked;
		_button2CheckBox.Location = new Point (8, 35);
		_button2CheckBox.Text = "2";
		_checkedGroupBox.Controls.Add (_button2CheckBox);
		_button2CheckBox.CheckedChanged += delegate (object sender, EventArgs e) {
			_toolStripButton2.Checked = _button2CheckBox.Checked;
		};
		// 
		// _button3CheckBox
		// 
		_button3CheckBox = new CheckBox ();
		_button3CheckBox.Checked = _toolStripButton3.Checked;
		_button3CheckBox.Location = new Point (8, 55);
		_button3CheckBox.Text = "3";
		_checkedGroupBox.Controls.Add (_button3CheckBox);
		_button3CheckBox.CheckedChanged += delegate (object sender, EventArgs e) {
			_toolStripButton3.Checked = _button3CheckBox.Checked;
		};
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 140);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82151";
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

	private ToolStrip _toolStrip;
	private ToolStripButton _toolStripButton1;
	private ToolStripButton _toolStripButton2;
	private ToolStripButton _toolStripButton3;
	private GroupBox _checkedGroupBox;
	private CheckBox _button1CheckBox;
	private CheckBox _button2CheckBox;
	private CheckBox _button3CheckBox;
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
			"1. Button 2 is checked.{0}{0}" +
			"2. Checking/unchecking one of the checkboxes modifies the checked " +
			" state of the corresponding button.",
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
		ClientSize = new Size (360, 135);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82151";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
