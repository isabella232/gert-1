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
		_tabControl.Height = 170;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Select the second row.{0}{0}" +
			"2. Press Del key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The second row is removed.",
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
		ClientSize = new Size (292, 300);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80352";
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
		_dataSet = new DataSet ();
		_dataSet.ReadXml ("test.xml");
		_dataGrid.DataSource = _dataSet;
		_dataGrid.DataMember = "Table";
		_dataSet.AcceptChanges ();
	}

	private DataSet _dataSet;
	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
