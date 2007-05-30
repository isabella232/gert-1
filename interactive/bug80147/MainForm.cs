using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// dataTable
		DataTable dataTable = new DataTable ("Testing Table");
		dataTable.Columns.Add (new DataColumn ("CustomerID"));
		dataTable.Columns.Add (new DataColumn ("Customer Age"));
		// 
		// _dataGrid
		// 
		_dataGrid = new DataGrid ();
		_dataGrid.CaptionText = "Caption";
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.DataSource = dataTable;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 200;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the \"CustomerID\" column header.{0}{0}" +
			"Expect result:{0}{0}" +
			"1. An up arrow is drawn in the \"CustomerID\" column header.{0}{0}" +
			"2. Part of the column header is cleared to make room for drawing " +
			"the up arrow (instead of drawing over the text of the column header).",
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
		ClientSize = new Size (300, 295);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80147";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
