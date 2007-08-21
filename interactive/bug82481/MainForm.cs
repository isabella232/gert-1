using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _statusStrip
		// 
		_statusStrip = new StatusStrip ();
		Controls.Add (_statusStrip);
		// 
		// _progressBar
		// 
		_progressBar = new ToolStripProgressBar ();
		_statusStrip.Items.Add (_progressBar);
		// 
		// _statusLabel
		// 
		_statusLabel = new ToolStripStatusLabel ("Begin");
		_statusStrip.Items.Add (_statusLabel);
		// 
		// _startButton
		// 
		_startButton = new ToolStripButton ();
		_startButton.Text = "Start";
		_startButton.Click += new EventHandler (StartButton_Click);
		_statusStrip.Items.Insert (0, _startButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 60);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82481";
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

	void StartButton_Click (object sender, EventArgs e)
	{
		_progressBar.Value = 0;
		_statusLabel.Text = "Running";
		Application.DoEvents ();
		for (int i = 0; i < 100; i++) {
			_progressBar.Value += 1;
			Thread.Sleep (20);
		}
		_statusLabel.Text = "End";
	}

	private StatusStrip _statusStrip;
	private ToolStripProgressBar _progressBar;
	private ToolStripStatusLabel _statusLabel;
	private ToolStripButton _startButton;
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
			"1. Click the Start button in the status bar.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The text of the label changes to \"Running\".{0}{0}" +
			"2. The progress bar fills.{0}{0}" +
			"3. The text of the label changes to \"End\" when " +
			"progress bar is filled.",
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
		ClientSize = new Size (300, 200);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82481";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
