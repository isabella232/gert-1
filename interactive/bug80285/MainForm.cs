using System;
using System.ComponentModel;
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
		_dataGrid.DataMember = string.Empty;
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.HeaderForeColor = SystemColors.ControlText;
		_dataGrid.Size = new Size (370, 140);
		_dataGrid.TabIndex = 0;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 175;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the units cell of the 1st row.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The gridline between the units cell of the 1st and 2nd row is " +
			"still drawn.{0}{0}" +
			"2. The vertical position of the cursor caret matches that of the " +
			"highlighted text.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// MainForm
		// 
		ClientSize = new Size (370, 325);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80285";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		DataSet ds = new DataSet();
		DataTable custTable = ds.Tables.Add("CustTable");

		DataColumn column = new DataColumn ("units", typeof (int));
		column.AllowDBNull = false;
		column.Caption = "Units";
		column.DefaultValue = 1;
		custTable.Columns.Add (column);

		column = new DataColumn ("price", typeof (decimal));
		column.AllowDBNull = false;
		column.Caption = "Price";
		column.DefaultValue = 25;
		custTable.Columns.Add (column);

		column = new DataColumn ("total", typeof (string));
		column.Caption = "Total";
		column.Expression = "price*units";
		custTable.Columns.Add (column);

		DataRow row = custTable.NewRow ();
		row ["price"] = 200;
		custTable.Rows.Add (row);

		row = custTable.NewRow ();
		row ["units"] = 5;
		row ["price"] = 200;
		custTable.Rows.Add (row);

		row = custTable.NewRow ();
		custTable.Rows.Add (row);

		_dataGrid.DataSource = ds;
		_dataGrid.DataMember = custTable.TableName;
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
