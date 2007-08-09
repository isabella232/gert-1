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
		// _startButton
		// 
		_startButton = new Button ();
		_startButton.Anchor = AnchorStyles.Bottom;
		_startButton.Location = new Point (110, 88);
		_startButton.TabIndex = 0;
		_startButton.Text = "Start";
		_startButton.Click += new EventHandler (StartButton_Click);
		// 
		// _progressBar
		// 
		_progressBar = new ProgressBar ();
		_progressBar.Anchor = ((AnchorStyles.Bottom | AnchorStyles.Left) | AnchorStyles.Right);
		_progressBar.Location = new Point (8, 32);
		_progressBar.Size = new Size (280, 23);
		_progressBar.TabIndex = 1;
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 125);
		Controls.Add (_startButton);
		Controls.Add (_progressBar);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81142";
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
		Thread myThread = new Thread (new ThreadStart (UpdateProgressBar));
		myThread.Start ();
	}

	public void UpdateProgressBar ()
	{
		int valeur = 0;
		_progressBar.Visible = true;
		_progressBar.Value = 0;
		for (int i = 0; i < 100000000; i++) {
			valeur = Convert.ToInt32 (i / 1000000);
			_progressBar.Value = valeur;
		}
	}

	private Button _startButton;
	private ProgressBar _progressBar;
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Start button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The ProgressBar gruadually fills within a few seconds.",
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
		ClientSize = new Size (300, 140);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81142";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
