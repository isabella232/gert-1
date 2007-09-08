using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _updateButton
		// 
		_updateButton = new Button ();
		_updateButton.Location = new Point (100, 25);
		_updateButton.Text = "&Update";
		_updateButton.Click += UpdateButton_Click;
		Controls.Add (_updateButton);
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
		_statusLabel.Size = new Size (0, 17);
		_statusScript.Items.Add (_statusLabel);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 100);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82723";
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

	void UpdateButton_Click (object sender, EventArgs ea)
	{
		int cur = _buttonPhase;
		_buttonPhase = (_buttonPhase + 1) % ButtonPhaseCount;

		switch (cur) {
		case 0:
			_statusLabel.Text = new string ('c', 30);
			break;
		case 1:
			_statusLabel.Text = new string ('b', 20);
			break;
		case 2:
			_statusLabel.Text = new string ('a', 10);
			break;
		}
	}

	private Button _updateButton;
	private StatusStrip _statusScript;
	private ToolStripStatusLabel _statusLabel;
	private int _buttonPhase;
	private const int ButtonPhaseCount = 3;
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
			"1. Click the Update button.{0}{0}" +
			"2. Click the Update button.{0}{0}" +
			"3. Click the Update button.{0}{0}" +
			"4. Click the Update button.{0}{0}" +
			"5. Click the Update button.{0}{0}" +
			"6. Click the Update button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, 30 c's are displayed in the label on " +
			"statusstrip.{0}{0}" +
			"2. On step 2, 20 b's are displayed in the label on " +
			"statusstrip.{0}{0}" +
			"3. On step 3, 10 a's are displayed in the label on " +
			"statusstrip.{0}{0}" +
			"4. On step 4, 30 c's are displayed in the label on " +
			"statusstrip.{0}{0}" +
			"5. On step 5, 20 b's are displayed in the label on " +
			"statusstrip.{0}{0}" +
			"6. On step 6, 10 a's are displayed in the label on " +
			"statusstrip.",
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
		ClientSize = new Size (330, 410);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82723";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
