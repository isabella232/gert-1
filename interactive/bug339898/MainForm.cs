using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _hideButton
		// 
		_hideButton = new Button ();
		_hideButton.Location = new Point (110, 20);
		_hideButton.Size = new Size (60, 20);
		_hideButton.Text = "Hide";
		_hideButton.Click += new EventHandler (HideButton_Click);
		Controls.Add (_hideButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 60);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #339898";
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

	void HideButton_Click (object sender, EventArgs e)
	{
		_hideButton.Visible = false;
		Thread.Sleep (2000);
		_hideButton.Visible = true;
	}

	private Button _hideButton;
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
			"1. Click the Hide button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The button immediately renders invisible, and " +
			"becomes visible again after two seconds.",
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
		ClientSize = new Size (300, 155);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #339898";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
