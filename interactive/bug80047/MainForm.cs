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
		_dataGrid = new System.Windows.Forms.DataGrid ();
		_dataGrid.DataMember = "";
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.Height = 250;
		_dataGrid.TabIndex = 0;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 270;
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
			"Expected result:{0}{0}" +
			"1. While pressing the Tab key, the entered cell scrolls into " +
			"view when necessary.{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * The content of the cell is cleared.{0}" +
			"   * The view does not shift away from the current cell.{0}" +
			"   * The cursor caret stays in the cell.",
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
		ClientSize = new Size (400, 530);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80047";
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
		DataSet dataSet1 = new DataSet ();
		dataSet1.ReadXml ("test.xml");

		DataColumn column = new DataColumn ();
		column.DataType = System.Type.GetType ("System.Decimal");
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
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
