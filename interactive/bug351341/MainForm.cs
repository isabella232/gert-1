using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _staStatus
		// 
		_staStatus = new StatusStrip ();
		_staStatus.Dock = DockStyle.Bottom;
		_staStatus.Name = "Status Bar";
		_staStatus.TabIndex = 0;
		Controls.Add (this._staStatus);
		// 
		// _labelA
		// 
		_labelA = new ToolStripStatusLabel ();
		_labelA.Text = "a";
		_staStatus.Items.Add (_labelA);
		// 
		// _labelB
		// 
		_labelB = new ToolStripStatusLabel ();
		_labelB.Text = "b";
		_staStatus.Items.Add (_labelB);
		// 
		// _labelC
		// 
		_labelC = new ToolStripStatusLabel ();
		_labelC.Text = "c";
		_staStatus.Items.Add (_labelC);
		// 
		// _largeTextCheckBox
		// 
		_largeTextCheckBox = new CheckBox ();
		_largeTextCheckBox.Dock = DockStyle.Top;
		_largeTextCheckBox.Size = new Size (168, 32);
		_largeTextCheckBox.Text = "Large Text";
		_largeTextCheckBox.CheckedChanged += new EventHandler (LargeTextCheckBox_CheckedChanged);
		Controls.Add (_largeTextCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 150);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #351341";
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

	void LargeTextCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		if (_largeTextCheckBox.Checked)
			_labelB.Text = "Much Longer";
		else
			_labelB.Text = "b";
	}

	private StatusStrip _staStatus;
	private ToolStripStatusLabel _labelA;
	private ToolStripStatusLabel _labelB;
	private ToolStripStatusLabel _labelC;
	private CheckBox _largeTextCheckBox;
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
			"1. Check the Large Text checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The text of the second label changes to \"Much Longer\".{0}{0}" +
			"2. The third label shifts along, and remains visible.",
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
		ClientSize = new Size (300, 175);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #351341";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
