using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
#if NET_2_0
		// 
		// _toolStrip
		// 
		_toolStrip = new ToolStrip ();
		_toolStrip.Location = new Point (0, 24);
		_toolStrip.Size = new Size (632, 25);
		_toolStrip.TabIndex = 1;
		_toolStrip.Text = "ToolStrip";
		Controls.Add (_toolStrip);
		// 
		// _toolStripComboBox
		// 
		_toolStripComboBox = new ToolStripComboBox ();
		_toolStripComboBox.Text = "ComboBox";
		_toolStrip.Items.Add (_toolStripComboBox);
#endif
		// 
		// _comboBox
		// 
		_comboBox = new ComboBox ();
		_comboBox.Location = new Point (8, 40);
		_comboBox.Size = new Size (100, 20);
		_comboBox.Text = "ComboBox";
		Controls.Add (_comboBox);
		// 
		// _enabledCheckBox
		// 
		_enabledCheckBox = new CheckBox ();
		_enabledCheckBox.Checked = true;
		_enabledCheckBox.Location = new Point (8, 75);
		_enabledCheckBox.Size = new Size (70, 20);
		_enabledCheckBox.Text = "Enabled";
		_enabledCheckBox.CheckedChanged += new EventHandler (EnabledCheckBox_CheckedChanged);
		Controls.Add (_enabledCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 100);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82654";
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
		_comboBox.Enabled = _enabledCheckBox.Checked;
#if NET_2_0
		_toolStripComboBox.Enabled = _enabledCheckBox.Checked;
#endif
	}

#if NET_2_0
	private ToolStrip _toolStrip;
	private ToolStripComboBox _toolStripComboBox;
#endif
	private ComboBox _comboBox;
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
			"Steps to execute:{0}{0}" +
			"1. Uncheck the Enabled checkbox.{0}{0}" +
			"2. Check the Enabled checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1:{0}{0}" +
			"   * The dropdown button of the combox is disabled.{0}" +
			"   * The background and text are grayed out.{0}" +
			"   * Clicking inside the combobox has no effect.{0}{0}" +
			"2. On step 2:{0}{0}" +
			"   * The dropdown button of the combox is enabled.{0}" +
			"   * The background is white and text is black.{0}" +
			"   * Text cursor is visible after clicking inside the combobox.",
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
		ClientSize = new Size (330, 300);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82654";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
