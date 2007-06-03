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
		_dataGrid.Height = 150;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 130;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The second column in the first row has focus.{0}{0}" +
			"2. The cursor caret is blinking.",
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
		ClientSize = new Size (300, 290);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80464";
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
		dataTable.Columns.Add ();
		dataTable.Columns.Add ();
		_dataGrid.DataSource = dataSet;
		_dataGrid.DataMember = dataTable.TableName;
	}

	protected override void OnActivated (EventArgs e)
	{
		base.OnActivated (e);
		SendKeys.Send ("{Enter}");
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;

	class TestDataGrid : DataGrid
	{
		protected override bool ProcessCmdKey (ref Message msg, Keys keyData)
		{
			if (msg.WParam.ToInt32 () == (int) Keys.Enter) {
				SendKeys.Send ("{Tab}");
				return true;
			}
			return base.ProcessCmdKey (ref msg, keyData);
		}
	}
}
