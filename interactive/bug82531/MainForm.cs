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
		// _showDialogButton
		// 
		_showDialogButton = new Button ();
		_showDialogButton.Location = new Point (100, 20);
		_showDialogButton.Size = new Size (80, 20);
		_showDialogButton.Text = "Show Dialog";
		_showDialogButton.Click += new EventHandler (ShowDialogButton_Click);
		Controls.Add (_showDialogButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 60);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82531";
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

	void ShowDialogButton_Click (object sender, EventArgs e)
	{
		CommonDialog commonDialog = new MyOpenCommonDialog ();
		if (commonDialog.ShowDialog () != DialogResult.OK) {
			MessageBox.Show ("DialogResult was not OK!!");
			Environment.Exit (1);
		} else {
			Close ();
		}
	}

	private Button _showDialogButton;
}

class MyOpenCommonDialog : CommonDialog
{
	protected override bool RunDialog (IntPtr hwndOwner)
	{
		DialogResult rslt = MessageBox.Show (
		   "Click OK", "bug #82531",
		   MessageBoxButtons.OKCancel);
		return rslt == DialogResult.OK;
	}

	public override void Reset ()
	{
	}
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
			"1. Click the Show Dialog button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A message box stating \"Click OK\" is displayed.{0}{0}" +
			"2. After clicking OK, but application exits cleanly.",
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
		ClientSize = new Size (300, 165);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82531";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
