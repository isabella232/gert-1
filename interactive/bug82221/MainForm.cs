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
		_dataGridView.Height = 100;
		Controls.Add (_dataGridView);
		// 
		// _nameTextBoxColumn
		// 
		_nameTextBoxColumn = new DataGridViewTextBoxColumn ();
		_nameTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		_nameTextBoxColumn.HeaderText = "Name";
		_dataGridView.Columns.Add (_nameTextBoxColumn);
		// 
		// _columnHeadersHeightSizeModeGroupBox
		// 
		_columnHeadersHeightSizeModeGroupBox = new GroupBox ();
		_columnHeadersHeightSizeModeGroupBox.Dock = DockStyle.Bottom;
		_columnHeadersHeightSizeModeGroupBox.Height = 85;
		_columnHeadersHeightSizeModeGroupBox.Text = "ColumnHeadersHeightSizeMode";
		Controls.Add (_columnHeadersHeightSizeModeGroupBox);
		// 
		// _autoSizeHeightSizeMode
		// 
		_autoSizeHeightSizeMode = new RadioButton ();
		_autoSizeHeightSizeMode.Location = new Point (8, 16);
		_autoSizeHeightSizeMode.Text = "AutoSize";
		_autoSizeHeightSizeMode.CheckedChanged += new EventHandler (AutoSizeHeightSizeMode_CheckedChanged);
		_columnHeadersHeightSizeModeGroupBox.Controls.Add (_autoSizeHeightSizeMode);
		// 
		// _disableResizingHeightSizeMode
		// 
		_disableResizingHeightSizeMode = new RadioButton ();
		_disableResizingHeightSizeMode.Location = new Point (8, 36);
		_disableResizingHeightSizeMode.Text = "DisableResizing";
		_disableResizingHeightSizeMode.CheckedChanged += new EventHandler (DisableResizingHeightSizeMode_CheckedChanged);
		_columnHeadersHeightSizeModeGroupBox.Controls.Add (_disableResizingHeightSizeMode);
		// 
		// _enableResizingHeightSizeMode
		// 
		_enableResizingHeightSizeMode = new RadioButton ();
		_enableResizingHeightSizeMode.Checked = true;
		_enableResizingHeightSizeMode.Location = new Point (8, 56);
		_enableResizingHeightSizeMode.Text = "EnableResizing";
		_enableResizingHeightSizeMode.CheckedChanged += new EventHandler (EnableResizingHeightSizeMode_CheckedChanged);
		_columnHeadersHeightSizeModeGroupBox.Controls.Add (_enableResizingHeightSizeMode);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 195);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82221";
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

	void AutoSizeHeightSizeMode_CheckedChanged (object sender, EventArgs e)
	{
		if (_autoSizeHeightSizeMode.Checked)
			_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	}

	void DisableResizingHeightSizeMode_CheckedChanged (object sender, EventArgs e)
	{
		if (_disableResizingHeightSizeMode.Checked)
			_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
	}

	void EnableResizingHeightSizeMode_CheckedChanged (object sender, EventArgs e)
	{
		if (_enableResizingHeightSizeMode.Checked)
			_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
	}

	private DataGridView _dataGridView;
	private DataGridViewTextBoxColumn _nameTextBoxColumn;
	private GroupBox _columnHeadersHeightSizeModeGroupBox;
	private RadioButton _autoSizeHeightSizeMode;
	private RadioButton _disableResizingHeightSizeMode;
	private RadioButton _enableResizingHeightSizeMode;
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
			"1. Padding is 5 pixels for all edges.{0}{0}" +
			"2. The height of the column header can be resized.",
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
			"1. Check the AutoSize radiobutton.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The height of the column header resizes to fit the text.{0}{0}" +
			"2. Vertical padding is roughly 1 pixel.{0}{0}" +
			"3. Horizontal padding is 5 pixels.",
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
			"1. Check the DisableResizing radiobutton.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Padding is 5 pixels for all edges.{0}{0}" +
			"2. The height of the column header cannot be resized.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (320, 195);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82221";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
