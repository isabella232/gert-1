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
		_dataGrid.Height = 120;
		_dataGrid.ReadOnly = true;
		_dataGrid.TabIndex = 0;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 215;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click inside one of the cells.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The cell is grayed out.{0}{0}" +
			"2. The content is highlighted.{0}{0}" +
			"3. The content can be read fine.{0}{0}" +
			"4. The content cannot be modified.",
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
		ClientSize = new Size (292, 345);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80356";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	private static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private void MainForm_Load (object sender, EventArgs e)
	{
		DataSet ds = new DataSet();
		DataTable custTable = ds.Tables.Add("CustTable");

		DataColumn column = new DataColumn ("text", typeof (string));
		column.Caption = "Text";
		custTable.Columns.Add (column);

		DataRow row = custTable.NewRow ();
		row [0] = "iiiiiiiiii";
		custTable.Rows.Add (row);

		row = custTable.NewRow ();
		row [0] = "iiiiiiiiii";
		custTable.Rows.Add (row);

		_dataGrid.DataSource = ds;
		_dataGrid.DataMember = custTable.TableName;
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
