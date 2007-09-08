using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _visibleCheckBox
		// 
		_visibleCheckBox = new CheckBox ();
		_visibleCheckBox.Location = new Point (5, 5);
		_visibleCheckBox.Text = "&Visible";
		_visibleCheckBox.CheckedChanged += VisibleCheckBox_CheckedChanged;
		Controls.Add (_visibleCheckBox);
		// 
		// _statusScript
		// 
		_statusScript = new StatusStrip ();
		_statusScript.Dock = DockStyle.Bottom;
		Controls.Add (_statusScript);
		// 
		// _statusLabel
		// 
		_statusLabel = new ToolStripStatusLabel ();
		_statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		_statusLabel.Image = Image.FromFile ("AnimatedCompile.gif");
		_statusLabel.ImageScaling = ToolStripItemImageScaling.None;
		_statusLabel.Margin = new Padding (2, 0, 2, 1);
		_statusLabel.Size = new Size (15, 21);
		_statusLabel.Visible = false;
		_statusScript.Items.Add (_statusLabel);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 100);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82727";
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

	void VisibleCheckBox_CheckedChanged (object sender, EventArgs ea)
	{
		_statusLabel.Visible = _visibleCheckBox.Checked;
	}

	private CheckBox _visibleCheckBox;
	private StatusStrip _statusScript;
	private ToolStripStatusLabel _statusLabel;
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
			"1. No icon is displayed close to the left border of " +
			"the statusstrip.",
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
			"1. Check the Visible checkbox.{0}{0}" +
			"2. Uncheck the Visible checkbox.{0}{0}" +
			"3. Check the Visible checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1 and 3, an icon is displayed close to " +
			"the left border of the statusstrip.{0}{0}" +
			"1. On step 2, no icon is displayed close to the " +
			"left border of the statusstrip.",
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
		ClientSize = new Size (330, 245);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82727";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
