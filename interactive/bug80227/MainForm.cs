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
		_dataGrid = new DataGrid ();
		((ISupportInitialize) (_dataGrid)).BeginInit ();
		SuspendLayout ();
		// 
		// _dataGrid
		// 
		_dataGrid.DataMember = string.Empty;
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.HeaderForeColor = SystemColors.ControlText;
		_dataGrid.Size = new Size (292, 120);
		_dataGrid.TabIndex = 0;
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = "some text";
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
		ClientSize = new Size (292, 300);
		Controls.Add (_dataGrid);
		Controls.Add (_tabControl);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80227";
		((ISupportInitialize) (_dataGrid)).EndInit ();
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	private static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private void MainForm_Load (object sender, EventArgs e)
	{
		DataSet ds = new DataSet ();
		DataTable custTable = ds.Tables.Add ("CustTable");

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

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}

public class InstructionsForm : Form
{
	public InstructionsForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Location = new Point (8, 8);
		_tabControl.Dock = DockStyle.Fill;
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The DataGrid should be displayed in the upper part of the " +
			"form.{0}{0}" +
			"2. The TabControl fills the entire form, causing it to be " +
			"partially hidden under the DataGrid.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (350, 140);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80227";
		Controls.Add (_tabControl);
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
