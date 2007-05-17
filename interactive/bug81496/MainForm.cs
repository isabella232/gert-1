using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm (string runtimeEngine)
	{
		_runtimeEngine = runtimeEngine;
		// 
		// _launchButton
		// 
		_launchButton = new Button ();
		_launchButton.Location = new Point (115, 15);
		_launchButton.Text = "Launch";
		_launchButton.Click += new EventHandler (LaunchButton_Click);
		Controls.Add (_launchButton);
		// 
		// Form1
		// 
		ClientSize = new Size (292, 60);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81496";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main (string [] args)
	{
		if (args.Length != 0)
			Application.Run (new MainForm (args [0]));
		else
			Application.Run (new MainForm ((string) null));
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void LaunchButton_Click (object sender, EventArgs e)
	{
		string consoleApp = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"console.exe");

		Process p = new Process ();
		p.StartInfo.CreateNoWindow = true;
		p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		if (_runtimeEngine != null) {
			p.StartInfo.FileName = _runtimeEngine;
			p.StartInfo.Arguments = "\"" + consoleApp + "\"";
		} else {
			p.StartInfo.FileName = consoleApp;
		}
		p.StartInfo.UseShellExecute = false;
		p.StartInfo.RedirectStandardInput = true;
		p.StartInfo.RedirectStandardOutput = true;
		p.StartInfo.RedirectStandardError = true;
		p.Start ();

		MessageBox.Show ("Launched");

		p.Kill ();
	}

	private Button _launchButton;
	private string _runtimeEngine;
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
			"1. Click the Launch button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A message box stating \"Launched\" is displayed.{0}{0}" +
			"2. No command-prompt window is displayed.",
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
		ClientSize = new Size (360, 170);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81496";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
