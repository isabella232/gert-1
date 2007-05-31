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
		_dataGrid.DataMember = string.Empty;
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.Height = 100;
		_dataGrid.TabIndex = 0;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 250;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up{0}{0}" +
			"1. The value of the \"Name\" column starts with \"Miguel\".",
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
			"1. Click inside the first row of the Product column.{0}{0}" +
			"2. Click inside the first row of the Name column.{0}{0}" +
			"3. Press the Down arrow.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the displayed text in the \"Name\" column starts " +
			"with \"Miguel\".{0}{0}" +
			"2. On step 3, the text cursor moves to \"Name\" cell in the " +
			"second row.",
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
			"1. Click inside the first row of the Product column.{0}{0}" +
			"2. Click inside the first row of the Name column.{0}{0}" +
			"3. Click again inside the first row of the Name column.{0}{0}" +
			"4. Press the Down arrow.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The text cursor moves to the second line of the textbox.{0}{0}" +
			"2. The value \"U.S.\" is now displayed in the \"Name\" column.",
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
		ClientSize = new Size (450, 360);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81267";
		Load += new EventHandler (MainForm_Load);
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

		table.Columns.Add (new DataColumn ("Name"));
		table.Columns.Add (new DataColumn ("Product"));

		DataRow row = table.NewRow ();
		row ["Name"] = "Miguel de Icaza (Novell)" + Environment.NewLine + "U.S.";
		row ["Product"] = "Mono is a great product";
		table.Rows.Add (row);

		_dataGrid.DataSource = dataSet;
		_dataGrid.DataMember = dataSet.Tables [0].TableName;
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
