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
		_tabControl.Height = 290;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click inside cell A of the first row.{0}{0}" +
			"2. Press CTRL+0.{0}{0}" +
			"3. Press Down arrow.{0}{0}" +
			"4. Click Yes in message box.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the value of the cell is replaced with (null).{0}{0}" +
			"2. After step 3, the original value of the cell is restored " +
			"before the message box is displayed.{0}{0}" +
			"3. After step 4, focus is inside the cell of the first row.",
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
			"1. Click inside cell A of the first row.{0}{0}" +
			"2. Press CTRL+0.{0}{0}" +
			"3. Press Down arrow.{0}{0}" +
			"4. Click No in message box.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the value of the cell is replaced with (null).{0}{0}" +
			"2. After step 3, the original value of the cell is restored " +
			"before the message box is displayed.{0}{0}" +
			"3. After step 4, focus is inside the cell of the second row.",
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
			"1. Click inside cell A of the second row.{0}{0}" +
			"2. Press CTRL+0.{0}{0}" +
			"3. Press Down arrow.{0}{0}" +
			"4. Click No in message box.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the value of the cell is replaced with (null).{0}{0}" +
			"2. After step 3, the original value of the cell is restored " +
			"before the message box is displayed.{0}{0}" +
			"3. After step 4, focus is inside the cell of the second row.",
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
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click inside cell A of the first row.{0}{0}" +
			"2. Press CTRL+0.{0}{0}" +
			"3. Press Esc key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the value of the cell is replaced with (null).{0}{0}" +
			"2. After step 3, the original value of the cell is restored.{0}{0}" +
			"3. Focus is inside the cell of the first row.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// _bugDescriptionText5
		// 
		_bugDescriptionText5 = new TextBox ();
		_bugDescriptionText5.Multiline = true;
		_bugDescriptionText5.Dock = DockStyle.Fill;
		_bugDescriptionText5.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click inside cell B of the first row.{0}{0}" +
			"2. Press CTRL+0.{0}{0}" +
			"3. Press Down arrow.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The value of the cell is replaced with (null).",
			Environment.NewLine);
		// 
		// _tabPage5
		// 
		_tabPage5 = new TabPage ();
		_tabPage5.Text = "#5";
		_tabPage5.Controls.Add (_bugDescriptionText5);
		_tabControl.Controls.Add (_tabPage5);
		// 
		// MainForm
		// 
		ClientSize = new Size (292, 420);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80361";
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
		DataColumn column = null;
		DataRow row = null;

		DataTable dt = new DataTable ();

		column = new DataColumn ("A", typeof(int));
		column.AllowDBNull = false;
		dt.Columns.Add (column);

		column = new DataColumn ("B", typeof (string));
		column.AllowDBNull = true;
		dt.Columns.Add (column);

		row = dt.NewRow ();
		row [0] = "5";
		row [1] = "6";
		dt.Rows.Add (row);

		row = dt.NewRow ();
		row [0] = "7";
		row [1] = "8";
		dt.Rows.Add (row);

		_dataGrid.SetDataBinding (dt, "");
	}

	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
}
