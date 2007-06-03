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
		_dataGrid.Height = 120;
		_dataGrid.TabIndex = 0;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 230;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The content of the \"units\" cell of the first row is " +
			"highlighted.{0}{0}" +
			"2. The cursor caret is blinking in the \"units\" cell of the " +
			"first row.{0}{0}" +
			"3. The cursor caret is positioned behind the highlighted " +
			"text.{0}{0}" +
			"4. Pressing keys adds the pressed keys to the \"units\" cell of " +
			"the first row (and replaces the highlighted content).",
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
		ClientSize = new Size (292, 360);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80355";
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
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
