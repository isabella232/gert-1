using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		ComponentResourceManager resources = new ComponentResourceManager (typeof (MainForm));
		SuspendLayout ();
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
		// _separatorBar
		// 
		_separatorBar = new ToolStripSeparator ();
		// 
		// _newButton
		// 
		_newButton = new ToolStripButton ();
		_newButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_newButton.Image = ((Image) (resources.GetObject ("_newButton.Image")));
		_newButton.ImageTransparentColor = Color.Black;
		_newButton.Text = "New";
		_toolStrip.Items.Add (_newButton);
		// 
		// _openButton
		// 
		_openButton = new ToolStripButton ();
		_openButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		_openButton.Image = ((Image) (resources.GetObject ("_openButton.Image")));
		_openButton.ImageTransparentColor = Color.Black;
		_openButton.Text = "Open";
		_toolStrip.Items.Add (_openButton);
		_toolStrip.Items.Add (_separatorBar);
		// 
		// _textBox
		// 
		_textBox = new ToolStripTextBox ();
		_toolStrip.Items.Add (_textBox);
		_toolStrip.Items.Add (new ToolStripSeparator ());
		// 
		// _comboBox
		// 
		_comboBox = new ToolStripComboBox ();
		_toolStrip.Items.Add (_comboBox);
		// 
		// _toolStripEnabledCheckBox
		// 
		_toolStripEnabledCheckBox = new CheckBox ();
		_toolStripEnabledCheckBox.Checked = true;
		_toolStripEnabledCheckBox.Location = new Point (8, 75);
		_toolStripEnabledCheckBox.Size = new Size (70, 20);
		_toolStripEnabledCheckBox.Text = "Enabled";
		_toolStripEnabledCheckBox.CheckedChanged += new EventHandler (ToolStripEnabledCheckBox_CheckedChanged);
		Controls.Add (_toolStripEnabledCheckBox);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (300, 100);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82651";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
		PerformLayout ();
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.SetCompatibleTextRenderingDefault (false);
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ToolStripEnabledCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		_toolStrip.Enabled = _toolStripEnabledCheckBox.Checked;
	}

	private ToolStrip _toolStrip;
	private ToolStripSeparator _separatorBar;
	private ToolStripButton _newButton;
	private ToolStripButton _openButton;
	private ToolStripTextBox _textBox;
	private ToolStripComboBox _comboBox;
	private CheckBox _toolStripEnabledCheckBox;
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
			"Expected result:{0}{0}" +
			"1. The buttons in the ToolStrip are grayed out.",
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
		ClientSize = new Size (330, 140);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82651";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
