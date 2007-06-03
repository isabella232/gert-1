using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
		_dataGrid.Size = new Size (292, 273);
		_dataGrid.TabIndex = 0;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 240;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click inside the \"kood\" cell of the first row.{0}{0}" +
			"2. Press Tab key 7 times.{0}{0}" +
			"3. Press Del key.{0}{0}" +
			"4. Press Down arrow.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The content of the cell is cleared.",
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
			"1. Click inside the \"kood\" cell of the first row.{0}{0}" +
			"2. Press Tab key 7 times.{0}{0}" +
			"3. Grab horizontal scrollbar, and move it to left and " +
			"right a few times.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No bad drawing in first row.",
			Environment.NewLine);
		//
		// _tabPage2
		//
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 530);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80450";
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
		string xmlFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"test.xml");

		DataSet dataSet1 = new DataSet ();
		dataSet1.ReadXml (xmlFile);

		DataColumn column = new DataColumn ();
		column.DataType = typeof (decimal);
		column.AllowDBNull = false;
		column.Caption = "rw veerg";
		column.ColumnName = "Pricex";
		column.DefaultValue = 25;
		dataSet1.Tables [0].Columns.Add (column);

		column = new DataColumn ("Contactx", typeof (string));
		column.Expression = "pricex*10";
		dataSet1.Tables [0].Columns.Add (column);
		_dataGrid.DataSource = dataSet1;
		_dataGrid.DataMember = dataSet1.Tables [0].TableName;
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
