using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		components = new Container ();
		//SuspendLayout ();
		// 
		// _timer
		// 
		_timer = new Timer (components);
		_timer.Tick += new EventHandler (Timer_Tick);
		// 
		// _label
		// 
		_label = new Label ();
		_label.Dock = DockStyle.Fill;
		_label.TextAlign = ContentAlignment.MiddleCenter;
		Controls.Add (_label);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 65);
		Font = new Font ("Microsoft Sans Serif", 12F, FontStyle.Bold);
		Location = new Point (250, 100);
		Opacity = 0.5;
		StartPosition = FormStartPosition.Manual;
		Text = "Opacity = " + Opacity.ToString (CultureInfo.InvariantCulture);
		TopMost = true;
		Activated += new EventHandler (MainForm_Activated);
		Deactivate += new EventHandler (MainForm_Deactivate);
		Load += new EventHandler (MainForm_Load);
		Resize += new EventHandler (MainForm_Resize);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	protected override void Dispose (bool disposing)
	{
		if (disposing && (components != null))
			components.Dispose ();
		base.Dispose (disposing);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_label.Text = ClientSize.ToString ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void MainForm_Activated (object sender, EventArgs e)
	{
		_timer.Enabled = true;
	}

	void MainForm_Deactivate (object sender, EventArgs e)
	{
		_timer.Enabled = false;
		Opacity = 0.5;
		Text = "Opacity = " + Opacity.ToString (CultureInfo.InvariantCulture);
	}

	void MainForm_Resize (object sender, EventArgs e)
	{
		_label.Text = ClientSize.ToString ();
		//Environment.Exit (1);
	}

	void Timer_Tick (object sender, EventArgs e)
	{
		if (Opacity < 1.0) {
			Opacity += 0.1;
			System.Threading.Thread.Sleep (150);
			Text = "Opacity = " + Opacity.ToString (CultureInfo.InvariantCulture);
		} else {
			_timer.Enabled = false;
		}
	}

	private IContainer components;
	private Timer _timer;
	private Label _label;
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
			"1. The form slowly becomes non-transparant (opacity " +
			"0.5 => 1.0).{0}{0}" +
			"2. The ClientSize of the form is {{300, 65}}.",
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
			"1. Activate another form.{0}{0}" +
			"2. Activate the main form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the main form becomes semi-transparant " +
			"(Opacity = 0.5).{0}{0}" +
			"2. On step 2, the main form slowly becomes non-transparent.",
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
		ClientSize = new Size (300, 225);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82765";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
