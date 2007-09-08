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
		_toolStrip.AllowItemReorder = true;
		_toolStrip.Dock = DockStyle.Top;
		_toolStrip.Height = 100;
		_toolStrip.Margin = new Padding (5);
		_toolStrip.Stretch = true;
		_toolStrip.TabStop = true;
		Controls.Add (_toolStrip);
		// 
		// _textBox1
		// 
		_textBox1 = new ToolStripTextBox ();
		_textBox1.Margin = new Padding (5);
		_textBox1.Size = new Size(130, 60);
		_textBox1.Text = "1";
		_textBox1.ToolTipText = "Mono";
		_toolStrip.Items.Add (_textBox1);
		// 
		// _textBox2
		// 
		_textBox2 = new ToolStripTextBox ();
		_textBox2.Margin = new Padding (5);
		_textBox2.Size = new Size(130, 60);
		_textBox2.Text = "2";
		_toolStrip.Items.Add (_textBox2);
		// 
		// _autoToolTipCheckBox
		// 
		_autoToolTipCheckBox = new CheckBox ();
		_autoToolTipCheckBox.Checked = false;
		_autoToolTipCheckBox.Location = new Point (8, 35);
		_autoToolTipCheckBox.Size = new Size (100, 20);
		_autoToolTipCheckBox.Text = "AutoToolTip";
		_autoToolTipCheckBox.CheckedChanged += new EventHandler (AutoToolTipCheckBox_CheckedChanged);
		Controls.Add (_autoToolTipCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 60);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82750";
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

	void AutoToolTipCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		_textBox1.AutoToolTip = _autoToolTipCheckBox.Checked;
		_textBox2.AutoToolTip = _autoToolTipCheckBox.Checked;
	}

	private ToolStrip _toolStrip;
	private ToolStripTextBox _textBox1;
	private ToolStripTextBox _textBox2;
	private CheckBox _autoToolTipCheckBox;
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
			"1. Uncheck the AutoToolTip checkbox.{0}{0}" +
			"2. Hover over textbox 1.{0}{0}" +
			"3. Hover over textbox 2.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, a \"Mono\" tooltip is displayed.{0}{0}" +
			"2. On step 3, no tooltip is displayed.",
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
			"1. Check the AutoToolTip checkbox.{0}{0}" +
			"2. Hover over textbox 1.{0}{0}" +
			"3. Hover over textbox 2.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, a \"Mono\" tooltip is displayed.{0}{0}" +
			"2. On step 3, a \"2\" tooltip is displayed.",
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
		ClientSize = new Size (300, 220);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82750";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
