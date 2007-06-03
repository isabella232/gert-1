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
		// _resetButton
		//
		_resetButton = new Button ();
		_resetButton.Location = new Point (335, 265);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _multiSelectCheck
		//
		_multiSelectCheck = new CheckBox ();
		_multiSelectCheck.Location = new Point (10, 265);
		_multiSelectCheck.Size = new Size (100, 20);
		_multiSelectCheck.Text = "MultiSelect";
		_multiSelectCheck.CheckedChanged += new EventHandler (MultiSelectCheck_CheckedChanged);
		Controls.Add (_multiSelectCheck);
		// 
		// _fullRowSelectCheck
		//
		_fullRowSelectCheck = new CheckBox ();
		_fullRowSelectCheck.Location = new Point (150, 265);
		_fullRowSelectCheck.Size = new Size (100, 20);
		_fullRowSelectCheck.Text = "FullRowSelect";
		_fullRowSelectCheck.CheckedChanged += new EventHandler (FullRowSelectCheck_CheckedChanged);
		Controls.Add (_fullRowSelectCheck);
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.Dock = DockStyle.Top;
		_listView.FullRowSelect = false;
		_listView.Height = 250;
		_listView.HideSelection = false;
		_listView.MultiSelect = true;
		_listView.TabIndex = 0;
		_listView.View = View.Details;
		_listView.SelectedIndexChanged += new EventHandler (ListView_SelectedIndexChanged);
		Controls.Add (_listView);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (408, 295);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80375";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_multiSelectCheck.Checked = _listView.MultiSelect;
		_fullRowSelectCheck.Checked = _listView.FullRowSelect;

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

		for (int i = 0; i < 100; i++) {
			ListViewItem item = null;
			if ((i % 2) == 0) {
				item = _listView.Items.Add ("Short" + i);
			} else {
				item = _listView.Items.Add ("Looooooooooooooooooooooooooooooooooooooooooooooooooooong" + i);
			}
			item.SubItems.Add ("text");
			item.SubItems.Add ("text");
			item.SubItems.Add ("text");
		}

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_listView.SelectedItems.Clear ();
		_multiSelectCheck.Checked = true;
		_fullRowSelectCheck.Checked = false;
	}

	void FullRowSelectCheck_CheckedChanged (object sender, EventArgs e)
	{
		_listView.FullRowSelect = _fullRowSelectCheck.Checked;
	}

	void MultiSelectCheck_CheckedChanged (object sender, EventArgs e)
	{
		_listView.MultiSelect = _multiSelectCheck.Checked;
	}

	void ListView_SelectedIndexChanged (object sender, EventArgs e)
	{
	}

	private ListView _listView;
	private Button _resetButton;
	private CheckBox _fullRowSelectCheck;
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
			"1. Click the first item in the ListView.{0}{0}" +
			"2. Press Down arrow.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The second item is selected.{0}{0}" +
			"2. The view does not shift to the last column.{0}{0}" +
			"3. No rectange is visible in the second and third column.",
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
		ClientSize = new Size (300, 220);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80375";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
