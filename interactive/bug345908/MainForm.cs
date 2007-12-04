using System;
using System.ComponentModel;
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
		// _errorDialogCheckBox
		// 
		_errorDialogCheckBox = new CheckBox ();
		_errorDialogCheckBox.Checked = false;
		_errorDialogCheckBox.Location = new Point (8, 8);
		_errorDialogCheckBox.Size = new Size (120, 20);
		_errorDialogCheckBox.Text = "ErrorDialog";
		Controls.Add (_errorDialogCheckBox);
		// 
		// _useShellExecuteCheckBox
		// 
		_useShellExecuteCheckBox = new CheckBox ();
		_useShellExecuteCheckBox.Checked = true;
		_useShellExecuteCheckBox.Location = new Point (8, 30);
		_useShellExecuteCheckBox.Size = new Size (120, 20);
		_useShellExecuteCheckBox.Text = "UseShellExecute";
		Controls.Add (_useShellExecuteCheckBox);
		// 
		// _launchProcessButton
		// 
		_launchProcessButton = new Button ();
		_launchProcessButton.Location = new Point (90, 60);
		_launchProcessButton.Size = new Size (120, 20);
		_launchProcessButton.Text = "Launch Process";
		_launchProcessButton.Click += new EventHandler (LaunchProcessButton_Click);
		Controls.Add (_launchProcessButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 90);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #345908";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	static bool RunningOnUnix {
		get {
			PlatformID platform = Environment.OSVersion.Platform;
#if NET_2_0
			return platform == PlatformID.Unix;
#else
			return ((int) platform) == 128;
#endif
		}
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		if (RunningOnUnix) {
			MessageBox.Show ("This test only applies to Windows.",
				"bug #345883");
			Close ();
		}

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void LaunchProcessButton_Click (object sender, EventArgs e)
	{
		string exe = RunningOnUnix ? "/usr/bin/shouldnoteverexist.exe"
			: @"C:\shouldnoteverexist.exe";

		Process p = new Process ();
		p.StartInfo = new ProcessStartInfo ();
		p.StartInfo.ErrorDialog = _errorDialogCheckBox.Checked;
		p.StartInfo.FileName = exe;
		p.StartInfo.UseShellExecute = _useShellExecuteCheckBox.Checked;
		try {
			p.Start ();
			throw new Exception ("Process should not have started successfully.");
		} catch (Win32Exception) {
		}
	}

	private CheckBox _errorDialogCheckBox;
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
			"1. Uncheck the ErrorDialog checkbox.{0}{0}" +
			"2. Check the UseShellExecute checkbox.{0}{0}" +
			"3. Click the Launch Process button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No message box is displayed.",
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
			"1. Check the ErrorDialog checkbox.{0}{0}" +
			"2. Check the UseShellExecute checkbox.{0}{0}" +
			"3. Click the Launch Process button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. An error dialog is displayed by the operating system.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck the ErrorDialog checkbox.{0}{0}" +
			"2. Uncheck the UseShellExecute checkbox.{0}{0}" +
			"3. Click the Launch Process button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No message box is displayed.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// _bugDescriptionText4
		// 
		_bugDescriptionText4 = new TextBox ();
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Check the ErrorDialog checkbox.{0}{0}" +
			"2. Uncheck the UseShellExecute checkbox.{0}{0}" +
			"3. Click the Launch Process button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No message box is displayed.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 200);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #345908";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
}
