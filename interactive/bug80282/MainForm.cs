using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		SuspendLayout ();
		// 
		// _dataGrid
		// 
		_dataGrid = new DataGrid ();
		_dataGrid.DataMember = string.Empty;
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.HeaderForeColor = SystemColors.ControlText;
		_dataGrid.Height = 140;
		_dataGrid.TabIndex = 0;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 415;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the units cell of the 4th row.{0}{0}" +
			"2. Press Esc key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1:{0}{0}" +
			"    - No empty 5th row is created.{0}" +
			"    - The units cell of the 4th row has value 1.{0}" +
			"    - The price cell of the 4th row has value 25.{0}" +
			"    - The total cell of the 4th row has value (null).{0}{0}" +
			"2. On step 2:{0}{0}" +
			"    - The 4th row is cleared.{0}" +
			"    - Focus is moved to the units cell of the 3rd row.{0}",
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
			"1. Click the units cell of the 4th row.{0}{0}" +
			"2. Press Tab key.{0}{0}" +
			"3. Click the price cell of the 3rd row.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"    - The total cell of the 4th row remains (null).{0}{0}" +
			"2. On step 3:{0}{0}" +
			"    - The 4th row is cleared.{0}" +
			"    - Focus is moved to the units cell of the third row.{0}" +
			"    - No 5th row is created.",
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
			"1. Click the units cell of the 4th row.{0}{0}" +
			"2. Press Tab key.{0}{0}" +
			"3. Press Enter key.{0}{0}" +
			"4. Press Esc key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3 nothing happens.",
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
			"1. Click the units cell of the 4th row.{0}{0}" +
			"2. Press 5 key.{0}{0}" +
			"3. Press Tab key.{0}{0}" +
			"4. Click the price cell of the 3rd row.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"    - The value of the units cell of the 4th row is now 5.{0}" +
			"    - The icon in the left-most column of the 4th row {0}" +
			"      changes to indicate we're in edit mode.{0}" +
			"    - An empty 5th row is created (with * in left-most column).{0}{0}" +
			"2. On step 3:{0}{0}" +
			"    - The icon in the left-most column of the 4th row changes{0}" +
			"      back to an arrow.{0}{0}" +
			"3. On step 4:{0}{0}" +
			"    - The 4th row is NOT cleared.{0}",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// MainForm
		// 
		ClientSize = new Size (370, 565);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80282";
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
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
}
