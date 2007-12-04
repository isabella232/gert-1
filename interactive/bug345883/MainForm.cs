using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _windowStyleListBox
		// 
		_windowStyleListBox = new ListBox ();
		_windowStyleListBox.Dock = DockStyle.Top;
		_windowStyleListBox.Height = 80;
		_windowStyleListBox.Location = new Point (8, 8);
		Controls.Add (_windowStyleListBox);
		// 
		// _useShellExecuteCheckBox
		// 
		_useShellExecuteCheckBox = new CheckBox ();
		_useShellExecuteCheckBox.Checked = true;
		_useShellExecuteCheckBox.Location = new Point (8, 90);
		_useShellExecuteCheckBox.Size = new Size (120, 20);
		_useShellExecuteCheckBox.Text = "UseShellExecute";
		Controls.Add (_useShellExecuteCheckBox);
		// 
		// _launchProcessButton
		// 
		_launchProcessButton = new Button ();
		_launchProcessButton.Location = new Point (90, 120);
		_launchProcessButton.Size = new Size (120, 20);
		_launchProcessButton.Text = "Launch Process";
		_launchProcessButton.Click += new EventHandler (LaunchProcessButton_Click);
		Controls.Add (_launchProcessButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 160);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #345883";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Array values = Enum.GetValues (typeof (ProcessWindowStyle));
		_windowStyleListBox.DataSource = values;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void LaunchProcessButton_Click (object sender, EventArgs e)
	{
		string systemDir = Environment.GetFolderPath (Environment.SpecialFolder.System);
		string exe = Path.Combine (systemDir, "notepad.exe");

		Process p = new Process ();
		p.StartInfo = new ProcessStartInfo ();
		p.StartInfo.FileName = exe;
		p.StartInfo.UseShellExecute = _useShellExecuteCheckBox.Checked;
		p.StartInfo.WindowStyle = (ProcessWindowStyle)
			_windowStyleListBox.SelectedValue;
		p.Start ();
		if (p.WaitForExit (1000))
			throw new Exception ("Process has exited!");
		p.Kill ();
		Thread.Sleep (200);
		if (!p.HasExited)
			throw new Exception ("Process could not be stopped!");
	}

	private ListBox _windowStyleListBox;
	private CheckBox _useShellExecuteCheckBox;
	private Button _launchProcessButton;
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
			"1. Check the UseShellExecute checkbox.{0}{0}" +
			"2. Launch the process with each of the window styles.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Notepad is launched with the selected window style, " +
			"and closes automatically after a second.",
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
			"1. Uncheck the UseShellExecute checkbox.{0}{0}" +
			"2. Launch the process with each of the window styles.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Notepad is always launched with the \"normal\" window " +
			"style, and closes automatically after a second.",
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
		ClientSize = new Size (300, 180);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #345883";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
