using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dataGrid
		// 
		_dataGrid = new TestDataGrid ();
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.Height = 110;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 160;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click inside column A of the first row.{0}{0}" +
			"2. Press Spacebar.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The row is removed.",
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
		ClientSize = new Size (300, 280);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80465";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		DataSet dataSet = new DataSet ();
		DataTable dataTable = dataSet.Tables.Add ();
		dataTable.Columns.Add ("A");
		dataTable.Rows.Add (dataTable.NewRow ());
		_dataGrid.DataSource = dataSet;
		_dataGrid.DataMember = dataTable.TableName;
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;

	class TestDataGrid : DataGrid
	{
		protected override bool ProcessCmdKey (ref Message msg, Keys keyData)
		{
			DataRowView currentRow = GetCurrentRow ();
			if (currentRow == null)
				return true;
			currentRow.Delete ();
			DataSet ds = (DataSet) DataSource;
			for (int nTable = 0; nTable < ds.Tables.Count; nTable++) {
				for (int nRow = 0; nRow < ds.Tables [nTable].Rows.Count; nRow++) {
					if (ds.Tables [nTable].Rows [nRow].HasVersion (DataRowVersion.Proposed)) {
						ds.Tables [nTable].Rows [nRow].EndEdit ();
					}
				}
			}
			return true;
		}

		public virtual DataRowView GetCurrentRow ()
		{
			CurrencyManager cm = GetCurrencyManager ();
			if (cm.Position == -1)
				return null;
			return (DataRowView) cm.Current;
		}

		public virtual CurrencyManager GetCurrencyManager ()
		{
			return (CurrencyManager) BindingContext [
				DataSource, DataMember];
		}
	}
}
