using System;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dataGrid
		// 
		_dataGrid = new DataGridView ();
		_dataGrid.AllowUserToAddRows = false;
		_dataGrid.AllowUserToDeleteRows = false;
		_dataGrid.AllowUserToResizeRows = true;
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.Height = 100;
		_dataGrid.MultiSelect = true;
		_dataGrid.RowHeadersVisible = false;
		_dataGrid.RowTemplate.Height = 18;
		_dataGrid.ShowCellToolTips = false;
		Controls.Add (_dataGrid);
		// 
		// _readOnlyGroupBox
		// 
		_readOnlyGroupBox = new GroupBox ();
		_readOnlyGroupBox.Dock = DockStyle.Bottom;
		_readOnlyGroupBox.Height = 100;
		_readOnlyGroupBox.Text = "ReadOnly";
		Controls.Add (_readOnlyGroupBox);
		// 
		// _dataGridViewReadOnlyCheckBox
		// 
		_dataGridViewReadOnlyCheckBox = new CheckBox ();
		_dataGridViewReadOnlyCheckBox.Location = new Point (8, 16);
		_dataGridViewReadOnlyCheckBox.Size = new Size (120, 20);
		_dataGridViewReadOnlyCheckBox.Text = "DataGridView";
		_dataGridViewReadOnlyCheckBox.CheckedChanged += new EventHandler (DataGridViewReadOnlyCheckBox_CheckChanged);
		_readOnlyGroupBox.Controls.Add (_dataGridViewReadOnlyCheckBox);
		// 
		// _rowReadOnlyCheckBox
		// 
		_rowReadOnlyCheckBox = new CheckBox ();
		_rowReadOnlyCheckBox.Location = new Point (8, 35);
		_rowReadOnlyCheckBox.Size = new Size (120, 20);
		_rowReadOnlyCheckBox.Text = "2nd Row";
		_rowReadOnlyCheckBox.CheckedChanged += new EventHandler (RowReadOnlyCheckBox_CheckChanged);
		_readOnlyGroupBox.Controls.Add (_rowReadOnlyCheckBox);
		// 
		// _columnReadOnlyCheckBox
		// 
		_columnReadOnlyCheckBox = new CheckBox ();
		_columnReadOnlyCheckBox.Location = new Point (8, 54);
		_columnReadOnlyCheckBox.Size = new Size (120, 20);
		_columnReadOnlyCheckBox.Text = "Person Column";
		_columnReadOnlyCheckBox.CheckedChanged += new EventHandler (ColumnReadOnlyCheckBox_CheckChanged);
		_readOnlyGroupBox.Controls.Add (_columnReadOnlyCheckBox);
		// 
		// _cellReadOnlyCheckBox
		// 
		_cellReadOnlyCheckBox = new CheckBox ();
		_cellReadOnlyCheckBox.Location = new Point (8, 73);
		_cellReadOnlyCheckBox.Size = new Size (200, 20);
		_cellReadOnlyCheckBox.Text = "Peron Cell in 2nd row";
		_cellReadOnlyCheckBox.CheckedChanged += new EventHandler (CellReadOnlyCheckBox_CheckChanged);
		_readOnlyGroupBox.Controls.Add (_cellReadOnlyCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (350, 210);
		Location = new Point (150, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81074";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_dataTable = new DataTable ();
		_dataTable.Columns.Add ("Date", typeof (DateTime));
		_dataTable.Columns.Add ("Person", typeof (string));
		_dataTable.Columns.Add ("Location", typeof (string));

		DataRow row = _dataTable.NewRow ();
		row ["Date"] = new DateTime (1973, 8, 13);
		row ["Person"] = "Dad";
		row ["Location"] = "Herk-de-stad";
		_dataTable.Rows.Add (row);

		row = _dataTable.NewRow ();
		row ["Date"] = new DateTime (2007, 8, 3);
		row ["Person"] = "Daughter";
		row ["Location"] = "Hasselt";
		_dataTable.Rows.Add (row);

		row = _dataTable.NewRow ();
		row ["Date"] = new DateTime (1974, 1, 24);
		row ["Person"] = "Girlfriend";
		row ["Location"] = "Aartselaar";
		_dataTable.Rows.Add (row);

		_dataGrid.DataSource = _dataTable;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void DataGridViewReadOnlyCheckBox_CheckChanged (object sender, EventArgs e)
	{
		_dataGrid.ReadOnly = _dataGridViewReadOnlyCheckBox.Checked;
	}

	void RowReadOnlyCheckBox_CheckChanged (object sender, EventArgs e)
	{
		_dataGrid.Rows [1].ReadOnly = _rowReadOnlyCheckBox.Checked;
	}

	void ColumnReadOnlyCheckBox_CheckChanged (object sender, EventArgs e)
	{
		_dataGrid.Columns [1].ReadOnly = _columnReadOnlyCheckBox.Checked;
	}

	void CellReadOnlyCheckBox_CheckChanged (object sender, EventArgs e)
	{
		_dataGrid.Rows [1].Cells [1].ReadOnly = _cellReadOnlyCheckBox.Checked;
	}

	private DataTable _dataTable;
	private DataGridView _dataGrid;
	private GroupBox _readOnlyGroupBox;
	private CheckBox _dataGridViewReadOnlyCheckBox;
	private CheckBox _rowReadOnlyCheckBox;
	private CheckBox _columnReadOnlyCheckBox;
	private CheckBox _cellReadOnlyCheckBox;
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
			"1. Uncheck all checkboxes.{0}{0}" +
			"2. Check the DataGridView checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. None of the cells can be edited.",
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
			"1. Uncheck all checkboxes.{0}{0}" +
			"2. Check the 2nd Row checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. None of the cell in the 2nd row can be edited.{0}{0}" +
			"2. All other cells can be edited.",
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
			"1. Uncheck all checkboxes.{0}{0}" +
			"2. Check the \"Person column\"  checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. None of the cells in the Person column can be edited.{0}{0}" +
			"2. All other cells can be edited.",
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
			"1. Uncheck all checkboxes.{0}{0}" +
			"2. Check the \"Person cell in the 2nd row\" checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Person cell in the 2nd row cannot be edited.{0}{0}" +
			"2. All other cells can be edited.",
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
		ClientSize = new Size (350, 190);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81074";
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
