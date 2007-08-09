using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.Dock = DockStyle.Top;
		_listView.Height = 100;
		_listView.HideSelection = false;
		_listView.LabelEdit = true;
		_listView.TabIndex = 0;
		_listView.AfterLabelEdit += new LabelEditEventHandler (ListView_AfterLabelEdit);
		_listView.BeforeLabelEdit += new LabelEditEventHandler (ListView_BeforeLabelEdit);
		_listView.DoubleClick += new EventHandler (ListView_DoubleClick);
		Controls.Add (_listView);
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (8, 110);
		_resetButton.Size = new Size (80, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 140;
		_eventsText.Multiline = true;
		_eventsText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (292, 280);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80888";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_listView.Items.Add ("Miguel");
		_listView.Items.Add ("Chris");
		_listView.Items.Add ("JacksonHarper");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ListView_AfterLabelEdit (object sender, LabelEditEventArgs e)
	{
		string label = e.Label == null ? "(null)" : e.Label;
		_eventsText.AppendText (
			"AfterLabelEdit => " + label + " | " + e.Item.ToString ()
			+ " | " + e.CancelEdit + Environment.NewLine);
	}

	void ListView_BeforeLabelEdit (object sender, LabelEditEventArgs e)
	{
		string label = e.Label == null ? "(null)" : e.Label;
		_eventsText.AppendText (
			"BeforeLabelEdit => " + label + " | " + e.Item.ToString ()
			+ " | " + e.CancelEdit + Environment.NewLine);
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_listView.Clear ();
		_listView.Items.Add ("Miguel");
		_listView.Items.Add ("Chris");
		_listView.Items.Add ("JacksonHarper");
		_eventsText.Text = string.Empty;
	}

	void ListView_DoubleClick (object sender, EventArgs e)
	{
		_listView.Clear ();
		_listView.Items.Add ("Shana");
	}

	private ListView _listView;
	private Button _resetButton;
	private TextBox _eventsText;
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
			"Expected result at start-up:{0}{0}" +
			"1. All three items are vertically aligned at the same level.",
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
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the \"Chris\" item.{0}{0}" +
			"3. Wait a second.{0}{0}" +
			"4. Click the \"Chris\" item.{0}{0}" +
			"5. Modify the label to \"Chris Toshok\".{0}{0}" +
			"6. Press Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"Chris Toshok\" item is highlighted and has focus.{0}{0}" +
			"2. The following events are signaled:{0}{0}" +
			"   * BeforeLabelEdit => (null) | 1 | False{0}" +
			"   * AfterLabelEdit => Chris Toshok | 1 | False{0}{0}" +
			"3. The two words of the label are spread over 2 lines.",
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
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the \"Miguel\" item.{0}{0}" +
			"3. Wait a second.{0}{0}" +
			"4. Click the \"Miguel\" item.{0}{0}" +
			"5. Modify the label to \"Miguel de Icaza from Novell\".{0}{0}" +
			"6. Press Enter key.{0}{0}" +
			"7. Press Tab key.{0}{0}" +
			"8. Press Shift+Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 6:{0}{0}" +
			"   * The \"Miguel de Icaza from Novell\" item is highlighted " +
			"and has focus.{0}{0}" +
			"   * The following events are signaled:{0}{0}" +
			"       BeforeLabelEdit => (null) | 0 | False{0}" +
			"       AfterLabelEdit => Miguel de Icaza from Novell | 0 | False{0}{0}" +
			"   * The complete label is visible, and spread over multiple " +
			"lines.{0}{0}" +
			"2. On step 7:{0}{0}" +
			"   * Only two lines of the \"Miguel de Icaza from Novell\" item " +
			"are visible.{0}" +
			"   * The visible part ends with three dots to show that it was " +
			"cut off.{0}{0}" +
			"3. On step 8:{0}{0}" +
			"   * The \"Miguel de Icaza from Novell\" item is highlighted " +
			"and has focus.{0}" +
			"   * The complete label is visible, and spread over multiple " +
			"lines.",
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
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the \"JacksonHarper\" item.{0}{0}" +
			"3. Wait a second.{0}{0}" +
			"4. Click the \"JacksonHarper\" item.{0}{0}" +
			"5. Do not modify the label.{0}{0}" +
			"6. Press Enter key.{0}{0}" +
			"7. Press Tab key.{0}{0}" +
			"8. Press Shift+Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 6:{0}{0}" +
			"   * The \"JacksonHarper\" item is highlighted and has focus.{0}{0}" +
			"   * The following events are signaled:{0}{0}" +
			"       BeforeLabelEdit => (null) | 2 | False{0}" +
			"       AfterLabelEdit => (null) | 2 | False{0}{0}" +
			"   * The complete label is visible, and spread over multiple " +
			"lines.{0}{0}" +
			"2. On step 7:{0}{0}" +
			"   * Only a single line of the \"JacksonHarper\" item is visible." +
			"{0}" +
			"   * The visible part ends with three dots to show that it was " +
			"cut off.{0}{0}" +
			"3. On step 8:{0}{0}" +
			"   * The \"JacksonHarper\" item is highlighted and has focus." +
			"{0}" +
			"   * The complete label is visible, and spread over multiple " +
			"lines.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// _bugDescriptionText5
		// 
		_bugDescriptionText5 = new TextBox ();
		_bugDescriptionText5.Multiline = true;
		_bugDescriptionText5.Dock = DockStyle.Fill;
		_bugDescriptionText5.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the \"JacksonHarper\" item.{0}{0}" +
			"3. Wait a second.{0}{0}" +
			"4. Click the \"JacksonHarper\" item.{0}{0}" +
			"5. Remove the last \"r\" character and add it back.{0}{0}" +
			"6. Press Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"JacksonHarper\" item is highlighted and has focus.{0}{0}" +
			"2. The following events are signaled:{0}{0}" +
			"   * BeforeLabelEdit => (null) | 2 | False{0}" +
			"   * AfterLabelEdit => JacksonHarper | 2 | False",
			Environment.NewLine);
		// 
		// _tabPage5
		// 
		_tabPage5 = new TabPage ();
		_tabPage5.Text = "#5";
		_tabPage5.Controls.Add (_bugDescriptionText5);
		_tabControl.Controls.Add (_tabPage5);
		//
		// _bugDescriptionText6
		//
		_bugDescriptionText6 = new TextBox ();
		_bugDescriptionText6.Multiline = true;
		_bugDescriptionText6.Dock = DockStyle.Fill;
		_bugDescriptionText6.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the \"Chris\" item.{0}{0}" +
			"3. Wait a second.{0}{0}" +
			"4. Click the \"Chris\" item.{0}{0}" +
			"5. Modify the label to \"Chris Toshok\".{0}{0}" +
			"6. Press Escape key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The label is still \"Chris\".{0}{0}" +
			"2. The \"Chris\" item is highlighted and has focus.{0}{0}" +
			"3. The label is no longer editable{0}{0}" +
			"4. The following events are signaled:{0}{0}" +
			"   * BeforeLabelEdit => (null) | 1 | False{0}" +
			"   * AfterLabelEdit => (null) | 1 | False",
			Environment.NewLine);
		//
		// _tabPage6
		//
		_tabPage6 = new TabPage ();
		_tabPage6.Text = "#6";
		_tabPage6.Controls.Add (_bugDescriptionText6);
		_tabControl.Controls.Add (_tabPage6);
		//
		// _bugDescriptionText7
		//
		_bugDescriptionText7 = new TextBox ();
		_bugDescriptionText7.Multiline = true;
		_bugDescriptionText7.Dock = DockStyle.Fill;
		_bugDescriptionText7.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Click the \"Miguel\" item.{0}{0}" +
			"3. Press Tab key.{0}{0}" +
			"4. Click the \"Miguel\" item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"Miguel\" item is highlighted and has focus.{0}{0}" +
			"2. The label can be edited.",
			Environment.NewLine);
		//
		// _tabPage7
		//
		_tabPage7 = new TabPage ();
		_tabPage7.Text = "#7";
		_tabPage7.Controls.Add (_bugDescriptionText7);
		_tabControl.Controls.Add (_tabPage7);
		//
		// _bugDescriptionText8
		//
		_bugDescriptionText8 = new TextBox ();
		_bugDescriptionText8.Multiline = true;
		_bugDescriptionText8.Dock = DockStyle.Fill;
		_bugDescriptionText8.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Double-click the \"Chris\" item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A single \"Shana\" item is displayed in the ListView.{0}{0}" +
			"2. The \"Shana\" item is not highlighted.",
			Environment.NewLine);
		//
		// _tabPage8
		//
		_tabPage8 = new TabPage ();
		_tabPage8.Text = "#8";
		_tabPage8.Controls.Add (_bugDescriptionText8);
		_tabControl.Controls.Add (_tabPage8);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (500, 600);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80888";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private TextBox _bugDescriptionText6;
	private TextBox _bugDescriptionText7;
	private TextBox _bugDescriptionText8;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
	private TabPage _tabPage6;
	private TabPage _tabPage7;
	private TabPage _tabPage8;
}
