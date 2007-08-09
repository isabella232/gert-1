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
		_listView.AllowColumnReorder = true;
		_listView.Dock = DockStyle.Top;
		_listView.HideSelection = false;
		_listView.Height = 120;
		_listView.View = View.Details;
		_listView.ColumnReordered += new ColumnReorderedEventHandler (ListView_ColumnReordered);
		Controls.Add (_listView);
		// 
		// _resetButton
		//
		_resetButton = new Button ();
		_resetButton.Location = new Point (8, 130);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _reorderButton
		//
		_reorderButton = new Button ();
		_reorderButton.Location = new Point (340, 130);
		_reorderButton.Size = new Size (60, 20);
		_reorderButton.Text = "Reorder";
		_reorderButton.Click += new EventHandler (ReorderButton_Click);
		Controls.Add (_reorderButton);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Multiline = true;
		_eventsText.Height = 80;
		_eventsText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (408, 240);
		Location = new Point (100, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80979";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main (string [] args)
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Init ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_listView.Clear ();
		Init ();
		_eventsText.Text = string.Empty;
	}

	void ReorderButton_Click (object sender, EventArgs e)
	{
		_firstNameColumn.DisplayIndex = 2;
		_companyColumn.DisplayIndex = 0;
	}

	void ListView_ColumnReordered (object sender, ColumnReorderedEventArgs e)
	{
		_eventsText.AppendText (
			"ColumnReordered => " + e.Header.Text + " | " + e.NewDisplayIndex.ToString ()
			+ " | " + e.OldDisplayIndex.ToString () + " | " + e.Cancel
			+ Environment.NewLine);
	}

	void Init ()
	{
		_firstNameColumn = new ColumnHeader ();
		_firstNameColumn.DisplayIndex = 2;
		_firstNameColumn.Text = "FirstName";
		_firstNameColumn.Width = 120;
		_listView.Columns.Add (_firstNameColumn);

		_nameColumn = new ColumnHeader ();
		_nameColumn.DisplayIndex = 0;
		_nameColumn.Text = "Name";
		_nameColumn.Width = 120;
		_listView.Columns.Add (_nameColumn);

		_companyColumn = new ColumnHeader ();
		_companyColumn.DisplayIndex = 1;
		_companyColumn.Text = "Company";
		_companyColumn.Width = 120;
		_listView.Columns.Add (_companyColumn);

		_listView.Items.Add (new ListViewItem (new string [] {
			"Miguel", "de Icaza", "Novell" }));
		_listView.Items.Add (new ListViewItem (new string [] {
				"Chris", "Sells", "Microsoft" }));
	}

	private ListView _listView;
	private ColumnHeader _firstNameColumn;
	private ColumnHeader _nameColumn;
	private ColumnHeader _companyColumn;
	private Button _resetButton;
	private Button _reorderButton;
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
			"Expected result on start-up:{0}{0}" +
			"1. The columns are layout in the following order:{0}{0}" +
			"   * FirstName{0}" +
			"   * Name{0}" +
			"   * Company{0}{0}" +
			"2. No events have fired.",
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
			"2. Click the \"Reorder\" button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The columns are layout in the following order:{0}{0}" +
			"   * Company{0}" +
			"   * Name{0}" +
			"   * FirstName{0}{0}" +
			"2. No events have fired.",
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
		ClientSize = new Size (320, 240);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80979";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
