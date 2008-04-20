using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _controlA
		// 
		_controlA = new SelectionTestControl ();
		_controlA.Height = 150;
		_controlA.Width = 300;
		Controls.Add (_controlA);
		// 
		// _controlB
		// 
		_controlB = new SelectionTestControl ();
		_controlB.Height = 150;
		_controlB.Width = 300;
		_controlB.Top = _controlA.Bottom;
		Controls.Add (_controlB);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #322904";
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

	private UserControl _controlA;
	private UserControl _controlB;
}

class SelectionTestControl : UserControl
{
	public SelectionTestControl ()
	{
		BackColor = Color.White;
	}

	protected override void OnEnter (EventArgs e)
	{
		base.OnEnter (e);
		BackColor = Color.Blue;
	}

	protected override void OnLeave (EventArgs e)
	{
		base.OnLeave (e);
		BackColor = Color.Red;
	}
}

class InstructionsForm : Form
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
			"1. The top control is blue.{0}{0}" +
			"1. The bottom control is white.",
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
			"1. Click the bottom control.{0}{0}" +
			"2. Click the top control.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1:{0}{0}" +
			"   * the top control is red.{0}" +
			"   * the bottom control is blue.{0}{0}" +
			"2. On step 2:{0}{0}" +
			"   * the top control is blue.{0}" +
			"   * the bottom control is red.",
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
		ClientSize = new Size (320, 300);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #322904";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
