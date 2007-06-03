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
		_tabControl.Height = 280;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the control column of the second row.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. All cells of the second row are highlighted.{0}{0}" +
			"2. The cursor caret is not visible.",
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
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the control column of the first row.{0}{0}" +
			"2. Click the control column of the second row.{0}{0}" +
			"3. Press any key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"Units\" cell of the second row is no longer highlighed, " +
			"but the \"Price\" cell still is.{0}{0}" +
			"2. The key that was pressed is echoed in the \"Units\" cell of " +
			"the second row.{0}{0}" +
			"3. The cursor caret is in the \"Units\" cell of the second row.",
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
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the control column of the first row.{0}{0}" +
			"2. Click the control column of the second row.{0}{0}" +
			"3. Click inside the \"Units\" cell of the second row.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The cells of the second row are no longer highlighed.{0}{0}" +
			"2. The context of the \"Units\" cell of the second row is " +
			"highlighted.{0}{0}" +
			"3. The cursor caret is positioned behind the content of the " +
			"\"Units\" cell of the second row.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// _bugDescriptionText4
		// 
		_bugDescriptionText4 = new TextBox ();
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the control column of the first row.{0}{0}" +
			"2. Hold the Shift key.{0}{0}" +
			"3. Click the control column of the third row.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. All cells of the first, second and third row are " +
			"highlighted.{0}{0}" +
			"2. The cursor caret is not visible.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// MainForm
		// 
		ClientSize = new Size (292, 410);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80362";
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
		DataTable dt = new DataTable ();
		DataColumn column = new DataColumn ("Units", typeof(int));
		column.AllowDBNull = false;
		dt.Columns.Add (column);
		column = new DataColumn ("Price", typeof (int));
		column.AllowDBNull = false;
		dt.Columns.Add (column);

		DataRow row = dt.NewRow ();
		row [0] = 5;
		row [1] = 20;
		dt.Rows.Add (row);

		row = dt.NewRow ();
		row [0] = 10;
		row [1] = 14;
		dt.Rows.Add (row);

		row = dt.NewRow ();
		row [0] = 8;
		row [1] = 17;
		dt.Rows.Add (row);

		_dataGrid.SetDataBinding (dt, "");
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
}
