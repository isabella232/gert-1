using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Location = new Point (8, 8);
		_tabControl.Size = new Size (280, 80);
		Controls.Add (_tabControl);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Multiline = true;
		_eventsText.Height = 200;
		_eventsText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_eventsText);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Enter += new EventHandler (TabPage1_Enter);
		_tabPage1.GotFocus += new EventHandler (TabPage1_GotFocus);
		_tabPage1.Leave += new EventHandler (TabPage1_Leave);
		_tabPage1.Validating += new CancelEventHandler (TabPage1_Validating);
		_tabPage1.Validated += new EventHandler (TabPage1_Validated);
		_tabPage1.LostFocus += new EventHandler (TabPage1_LostFocus);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Enter += new EventHandler (TabPage2_Enter);
		_tabPage2.GotFocus += new EventHandler (TabPage2_GotFocus);
		_tabPage2.Leave += new EventHandler (TabPage2_Leave);
		_tabPage2.Validating += new CancelEventHandler (TabPage2_Validating);
		_tabPage2.Validated += new EventHandler (TabPage2_Validated);
		_tabPage2.LostFocus += new EventHandler (TabPage2_LostFocus);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (300, 320);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #79869";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main (string [] args)
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void TabPage1_Enter (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabPage1 => Enter" +
			Environment.NewLine);
	}

	void TabPage1_GotFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabPage1 => GotFocus" +
			Environment.NewLine);
	}

	void TabPage1_Leave (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabPage1 => Leave" +
			Environment.NewLine);
	}

	void TabPage1_Validating (object sender, CancelEventArgs e)
	{
		_eventsText.AppendText (
			"TabPage2 => Validating" +
			Environment.NewLine);
	}

	void TabPage1_Validated (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabPage2 => Validated" +
			Environment.NewLine);
	}

	void TabPage1_LostFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabPage1 => LostFocus" +
			Environment.NewLine);
	}

	void TabPage2_Enter (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabPage2 => Enter" +
			Environment.NewLine);
	}

	void TabPage2_GotFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabPage2 => GotFocus" +
			Environment.NewLine);
	}

	void TabPage2_Leave (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabPage2 => Leave" +
			Environment.NewLine);
	}

	void TabPage2_Validating (object sender, CancelEventArgs e)
	{
		_eventsText.AppendText (
			"TabPage2 => Validating" +
			Environment.NewLine);
	}

	void TabPage2_Validated (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabPage2 => Validated" +
			Environment.NewLine);
	}

	void TabPage2_LostFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabPage2 => LostFocus" +
			Environment.NewLine);
	}

	private TextBox _eventsText;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
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
			"Expected result on start-up:{0}{0}" +
			"1. Tab #1 has focus.{0}{0}" +
#if NET_2_0
			"2. The following event has fired:{0}{0}" +
			"   * TabPage1 => Enter",
#else
			"2. No events have fired.",
#endif
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
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click on tab #2.{0}{0}" +
			"2. Click on tab #1.{0}{0}" +
			"Expected result:{0}{0}" +
#if NET_2_0
			"1. On step 1, the following events have fired:{0}{0}" +
			"   * TabPage1 => Leave{0}" +
			"   * TabPage2 => Enter{0}{0}" +
			"2. On step 2, the following events have fired:{0}{0}" +
			"   * TabPage2 => Leave{0}" +
			"   * TabPage1 => Enter",
#else
			"1. No events have fired.",
#endif
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
		ClientSize = new Size (300, 330);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #79869";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
