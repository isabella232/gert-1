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
		_tabControl.Height = 180;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"units\" cell of the first row.{0}{0}" +
			"2. Press Tab key three times.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"total\" cell of the first row is no longer grayed out.",
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
			"1. Click the \"total\" cell of the first row.{0}{0}" +
			"2. Click inside the textbox on this tab page.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"total\" cell of the first row is no longer grayed out.",
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
			"1. Click the \"total\" cell of the first row.{0}{0}" +
			"2. Click the \"units\" cell of the third row.{0}{0}" +
			"Expected result:{0}{0}" +
#if NET_2_0
			"1. The \"total\" cell of the first row is no longer grayed out.",
#else
			"1. The \"total\" cell of the first row is still grayed out.",
#endif
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
		ClientSize = new Size (292, 330);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80214";
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
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
