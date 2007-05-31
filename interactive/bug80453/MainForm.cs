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
		_dataGrid.DataMember = "";
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.Height = 200;
		_dataGrid.TabIndex = 0;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 300;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click inside the \"A\" cell of the first row.{0}{0}" +
			"2. Press Tab key until you're in the \"F\" cell.{0}{0}" +
			"3. Press Shift+Tab until you're in the \"A\" cell.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The content of visible cells is:{0}{0}" +
			"   A = Miguel de Icaza (cut off){0}" +
			"   B = 2007-01-05{0}" +
			"   C = 00000000000000{0}" +
			"   D = Mono / .NET{0}" +
			"   E = Linux / Windows{0}" +
			"   ...", Environment.NewLine);
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
		ClientSize = new Size (400, 530);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80453";
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
		System.Data.DataSet dataSet = new DataSet ();

		DataTable table = new DataTable ();
		dataSet.Tables.Add (table);

		table.Columns.Add (new DataColumn ("A"));
		table.Columns.Add (new DataColumn ("B"));
		table.Columns.Add (new DataColumn ("C"));
		table.Columns.Add (new DataColumn ("D"));
		table.Columns.Add (new DataColumn ("E"));
		table.Columns.Add (new DataColumn ("F"));

		DataRow row = table.NewRow ();
		row ["A"] = "Miguel de Icaza";
		row ["B"] = "2007-01-05";
		row ["C"] = "000000000000000";
		row ["D"] = "Mono / .NET";
		row ["E"] = "Linux / Windows";
		row ["F"] = "CSharp";
		table.Rows.Add (row);

		_dataGrid.DataSource = dataSet;
		_dataGrid.DataMember = dataSet.Tables [0].TableName;
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
