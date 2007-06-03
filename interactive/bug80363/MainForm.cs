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
		_tabControl.Height = 220;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the control column of the third row.{0}{0}" +
			"2. Hold the mouse button down.{0}{0}" +
			"3. Mouse the mouse to the first row.{0}{0}" +
			"4. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The first, second and third row are selected.",
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
			"2. Hold the mouse button down.{0}{0}" +
			"3. Move the mouse to the second row.{0}{0}" +
			"4. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The first and second row are selected.",
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
		ClientSize = new Size (292, 350);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80363";
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
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
