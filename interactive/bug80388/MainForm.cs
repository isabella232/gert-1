using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		this.SuspendLayout ();
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Multiline = true;
		_eventsText.Location = new Point (0, 60);
		_eventsText.Size = new Size (405, 200);
		_eventsText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_eventsText);
		// 
		// _resetButton
		//
		_resetButton = new Button ();
		_resetButton.Location = new Point (340, 270);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _multiSelectCheck
		//
		_multiSelectCheck = new CheckBox ();
		_multiSelectCheck.Location = new Point (10, 270);
		_multiSelectCheck.Size = new Size (100, 20);
		_multiSelectCheck.Text = "MultiSelect";
		_multiSelectCheck.CheckedChanged += new EventHandler (HideSelectionCheck_CheckedChanged);
		Controls.Add (_multiSelectCheck);
		// 
		// _openMenuItem
		// 
		_openMenuItem = new MenuItem ();
		_openMenuItem.Shortcut = Shortcut.CtrlO;
		_openMenuItem.ShowShortcut = true;
		_openMenuItem.Text = "Open";
		// 
		// _listViewItemMenu
		// 
		_listViewItemMenu = new ContextMenu ();
		_listViewItemMenu.MenuItems.Add (_openMenuItem);
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.ContextMenu = _listViewItemMenu;
		_listView.Dock = DockStyle.Top;
		_listView.Height = 50;
		_listView.HideSelection = false;
		_listView.MultiSelect = false;
		_listView.TabIndex = 0;
		_listView.GotFocus += new EventHandler (ListView_GotFocus);
		_listView.LostFocus += new EventHandler (ListView_LostFocus);
		Controls.Add (_listView);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (408, 300);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80388";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main (string [] args)
	{
		Application.Run (new MainForm ());
	}

	private void MainForm_Load (object sender, EventArgs e)
	{
		_multiSelectCheck.Checked = _listView.MultiSelect;

		ColumnHeader columnHeader = new ColumnHeader ();
		columnHeader.Text = "Name";
		columnHeader.Width = 200;
		_listView.Columns.Add (columnHeader);

		columnHeader = new ColumnHeader ();
		columnHeader.Text = "FirstName";
		columnHeader.Width = 150;
		_listView.Columns.Add (columnHeader);

		columnHeader = new ColumnHeader ();
		columnHeader.Text = "Address";
		columnHeader.Width = 150;
		_listView.Columns.Add (columnHeader);

		columnHeader = new ColumnHeader ();
		columnHeader.Text = "City";
		columnHeader.Width = 150;
		_listView.Columns.Add (columnHeader);

		for (int i = 1; i <= 100; i++) {
			_listView.Items.Add ("Item" + i);
		}

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private void ListView_GotFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"ListView => GotFocus" +
			Environment.NewLine);
	}

	private void ListView_LostFocus (object sender, EventArgs e)
	{
		_eventsText.AppendText (
			"ListView => LostFocus" +
			Environment.NewLine);
	}

	private void ResetButton_Click (object sender, EventArgs e)
	{
		_listView.SelectedItems.Clear ();
		_multiSelectCheck.Checked = false;
		_eventsText.Text = string.Empty;
	}

	private void HideSelectionCheck_CheckedChanged (object sender, EventArgs e)
	{
		_listView.MultiSelect = _multiSelectCheck.Checked;
	}

	private ListView _listView;
	private MenuItem _openMenuItem;
	private ContextMenu _listViewItemMenu;
	private TextBox _eventsText;
	private Button _resetButton;
	private CheckBox _multiSelectCheck;
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
			"1. Click the Reset button.{0}{0}" +
			"2. Click Item1 in the ListView.{0}{0}" +
			"3. Click Item2 in the ListView.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A single GotFocus event has fired.",
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
			"1. Click the \"Reset\" button.{0}{0}" +
			"2. Right-click Item1 in the ListView.{0}{0}" +
			"3. Right-click Item2 in the ListView.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A single GotFocus event has fired.",
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
		ClientSize = new Size (300, 190);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80388";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
