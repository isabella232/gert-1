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
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.Height = 100;
		Controls.Add (_dataGrid);
		// 
		// _stylesCheck
		// 
		_stylesCheck = new CheckBox ();
		_stylesCheck.Location = new Point (8, 110);
		_stylesCheck.Text = "Styles";
		_stylesCheck.Checked = true;
		_stylesCheck.CheckedChanged += new EventHandler (StylesCheck_CheckedChanged);
		Controls.Add (_stylesCheck);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 140;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The Styles checkbox is checked.{0}{0}" +
			"2. The DataGrid contains a single column (B).",
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
			"1. Uncheck the Styles checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The DataGrid contains three columns (A, B, C).",
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
			"1. Check the Styles checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The DataGrid contains a single column (B).",
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
		ClientSize = new Size (300, 280);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80422";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Bind ();
	}

	void StylesCheck_CheckedChanged (object sender, EventArgs e)
	{
		Bind ();
	}

	void Bind ()
	{
		DataTable table = new DataTable ();
		DataColumn columnA = new DataColumn ("A");
		table.Columns.Add (columnA);
		DataColumn columnB = new DataColumn ("B");
		table.Columns.Add (columnB);
		table.Rows.Add (new object [0]);

		_dataGrid.TableStyles.Clear ();
		if (_stylesCheck.Checked) {
			DataGridTableStyle tableStyle = new DataGridTableStyle ();
			DataGridColumnStyle colStyleB = new DataGridTextBoxColumn ();
			colStyleB.MappingName = "B";
			colStyleB.HeaderText = "B";
			tableStyle.GridColumnStyles.Add (colStyleB);
			DataGridColumnStyle colStyleD = new DataGridTextBoxColumn ();
			tableStyle.GridColumnStyles.Add (colStyleD);
			_dataGrid.TableStyles.Add (tableStyle);
		}
		_dataGrid.DataSource = table;
		table.Columns.Add ("C");
	}

	private DataGrid _dataGrid;
	private CheckBox _stylesCheck;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
