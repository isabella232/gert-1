using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dataGridView
		// 
		_dataGridView = new DataGridView ();
		_dataGridView.Dock = DockStyle.Top;
		_dataGridView.Height = 120;
		_dataGridView.MultiSelect = true;
		Controls.Add (_dataGridView);
		// 
		// _nameTextBoxColumn
		// 
		_nameTextBoxColumn = new DataGridViewTextBoxColumn ();
		_nameTextBoxColumn.HeaderText = "Name";
		_dataGridView.Columns.Add (_nameTextBoxColumn);
		// 
		// _firstNameTextBoxColumn
		// 
		_firstNameTextBoxColumn = new DataGridViewTextBoxColumn ();
		_firstNameTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		_firstNameTextBoxColumn.HeaderText = "First Name";
		_dataGridView.Columns.Add (_firstNameTextBoxColumn);
		// 
		// _refreshButton
		// 
		_refreshButton = new Button ();
		_refreshButton.Location = new Point (8, 130);
		_refreshButton.Size = new Size (60, 20);
		_refreshButton.Text = "Refresh";
		_refreshButton.Click += new EventHandler (RefreshButton_Click);
		Controls.Add (_refreshButton);
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Dock = DockStyle.Bottom;
		_textBox.Height = 50;
		_textBox.Multiline = true;
		_textBox.ReadOnly = true;
		Controls.Add (_textBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 210);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81075";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_dataGridView.Rows.Add ("de Icaza", "Miguel");
		_dataGridView.Rows.Add ("Toshok", "Chris");
		_dataGridView.Rows.Add ("Harper", "Jackson");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void RefreshButton_Click (object sender, EventArgs e)
	{
		_textBox.Text = string.Empty;
		for (int i = 0; i < _dataGridView.SelectedRows.Count; i++) {
			DataGridViewRow row = _dataGridView.SelectedRows [i];
			if (i > 0)
				_textBox.Text += Environment.NewLine;
			_textBox.Text += string.Format ("{0} => {1}", row.Index,
				row.Cells [1].Value + " " + row.Cells [0].Value);
		}
	}

	private DataGridView _dataGridView;
	private DataGridViewTextBoxColumn _nameTextBoxColumn;
	private DataGridViewTextBoxColumn _firstNameTextBoxColumn;
	private Button _refreshButton;
	private TextBox _textBox;
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
			"1. Click in the Name cell of the second row.{0}{0}" +
			"2. Click the Refresh button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The textbox is empty.",
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
			"1. Select the third row of the DataGridView.{0}{0}" +
			"2. Click the Refresh button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The textbox contains the following text:{0}{0}" +
			"   [2] => Jackson Harper",
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
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Select the third row of the DataGridView.{0}{0}" +
			"2. Press and hold the Ctrl key.{0}{0}" +
			"3. Select the first row of the DataGridView.{0}{0}" +
			"4. Click the Refresh button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The textbox contains the following text:{0}{0}" +
			"   [0] => Miguel de Icaza{0}" +
			"   [2] => Jackson Harper",
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
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Select the second row of the DataGridView.{0}{0}" +
			"2. Press and hold the Ctrl key.{0}{0}" +
			"3. Select the third row of the DataGridView.{0}{0}" +
			"4. Click the Refresh button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The textbox contains the following text:{0}{0}" +
			"   [2] => Jackson Harper{0}" + 
			"   [1] => Chris Toshok",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (320, 250);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81075";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
}
