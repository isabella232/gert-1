using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _linkLabel
		// 
		_linkLabel = new LinkLabel ();
		_linkLabel.Location = new Point (8, 8);
		_linkLabel.Text = "1234567890";
		_linkLabel.GotFocus += new EventHandler (LinkLabel_GotFocus);
		_linkLabel.LostFocus += new EventHandler (LinkLabel_LostFocus);
		Controls.Add (_linkLabel);
		// 
		// _resetButton
		//
		_resetButton = new Button ();
		_resetButton.Location = new Point (385, 8);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 450;
		_tabControl.TabIndex = 1;
		_tabControl.GotFocus += new EventHandler (TabControl_GotFocus);
		_tabControl.LostFocus += new EventHandler (TabControl_LostFocus);
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.ScrollBars = ScrollBars.Vertical;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The LinkLabel has focus.{0}{0}" +
			"2. The following event has fired;{0}{0}" +
			"   * LinkLabel => GotFocus",
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
		_bugDescriptionText2.ScrollBars = ScrollBars.Vertical;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Reset button.{0}{0}" +
			"2. Press the Tab key.{0}{0}" +
			"3. Click on the link of the LinkLabel control.{0}{0}" +
			"4. Click on the leaf of tab #2.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, focus rectangle is drawn inside the leaf of tab " +
			"#2.{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * Focus rectangle is no longer drawn inside the leaf of " +
			"tab #2.{0}" +
			"   * Focus rectangle is drawn around the LinkLabel control.{0}{0}" +
			"3. On step 4:{0}{0}" +
			"   * Focus rectangle is drawn inside the leaf of tab #2.{0}" +
			"   * Focus rectangle is no longer drawn around the LinkLabel " +
			"control.{0}{0}" + 
			"4. The following events have fired;{0}{0}" +
			"   * TabControl => GotFocus{0}" +
			"   * TabControl => LostFocus{0}" +
			"   * LinkLabel => GotFocus{0}" +
			"   * LinkLabel => LostFocus{0}" +
			"   * TabControl => GotFocus{0}",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Location = new Point (8, 40);
		_eventsText.Multiline = true;
		_eventsText.Size = new Size (435, 200);
		_eventsText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (450, 700);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80501";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_eventsText.Text = string.Empty;
	}

	void LinkLabel_GotFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"LinkLabel => GotFocus" +
			Environment.NewLine);
	}

	void LinkLabel_LostFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"LinkLabel => LostFocus" +
			Environment.NewLine);
	}

	void TabControl_GotFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabControl => GotFocus" +
			Environment.NewLine);
	}

	void TabControl_LostFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"TabControl => LostFocus" +
			Environment.NewLine);
	}

	private LinkLabel _linkLabel;
	private Button _resetButton;
	private TextBox _eventsText;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
