using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dataGrid
		// 
		_dataGrid = new DataGrid ();
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.Height = 100;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 270;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. There one row in the DataGrid.{0}{0}" +
			"2. Both cells have (null) as initial value.",
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
			"1. Click inside the first cell.{0}{0}" +
			"2. Press Tab key.{0}{0}" +
			"3. Press Shift-Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. After step 2, focus is in the second cell.{0}{0}" +
			"2. After step 3, focus is in the first cell.",
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
			"1. Click inside the first cell.{0}{0}" +
			"2. Enter a random value.{0}{0}" +
			"3. Press Tab key.{0}{0}" +
			"4. Enter a random value.{0}{0}" +
			"5. Press Down arrow.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. After step 2, an empty row is added to the DataGrid.{0}{0}" +
			"2. After step 5, focus is in the second row.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 380);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80364";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		DataTable table = new DataTable ();
		table.RowChanging += new DataRowChangeEventHandler (DataTable_OnRowChanging);
		DataColumn column1 = new DataColumn ();
		table.Columns.Add (column1);
		DataColumn column2 = new DataColumn ();
		table.Columns.Add (column2);

		DataColumn [] keys = new DataColumn [1];
		keys [0] = column2;
		table.PrimaryKey = keys;
		_dataGrid.SetDataBinding (table, "");
	}

	void DataTable_OnRowChanging (object sender, DataRowChangeEventArgs e)
	{
		if (e.Action == DataRowAction.Add) {
			string pk = e.Row.Table.PrimaryKey [0].ColumnName;
			if (e.Row [pk] == null)
				e.Row [pk] = new Guid ();
		}
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
