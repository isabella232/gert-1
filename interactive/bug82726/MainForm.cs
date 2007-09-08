using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
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
		_statusScript.Items.Add (_statusLabel);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 100);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82726";
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
			"1. An animated icon is displayed in the statusstrip.",
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
		ClientSize = new Size (300, 100);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82726";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
