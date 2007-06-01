using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dataGrid
		// 
		_dataGrid = new DataGrid ();
		_dataGrid.CaptionText = "Caption";
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.DataSource = new DataTable ();
		Controls.Add (_dataGrid);
		// 
		// _captionVisibleCheck
		// 
		_captionVisibleCheck = new CheckBox ();
		_captionVisibleCheck.Checked = _dataGrid.CaptionVisible;
		_captionVisibleCheck.Location = new Point (8, 90);
		_captionVisibleCheck.Size = new Size (80, 20);
		_captionVisibleCheck.Text = "Caption";
		_captionVisibleCheck.CheckedChanged += new EventHandler (CaptionVisibleCheck_CheckedChanged);
		Controls.Add (_captionVisibleCheck);
		// 
		// _columnHeadersVisibleCheck
		// 
		_columnHeadersVisibleCheck = new CheckBox ();
		_columnHeadersVisibleCheck.Checked = _dataGrid.ColumnHeadersVisible;
		_columnHeadersVisibleCheck.Location = new Point (170, 90);
		_columnHeadersVisibleCheck.Size = new Size (130, 20);
		_columnHeadersVisibleCheck.Text = "Column Headers";
		_columnHeadersVisibleCheck.CheckedChanged += new EventHandler (ColumnHeadersVisibleCheck_CheckedChanged);
		Controls.Add (_columnHeadersVisibleCheck);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 110;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expect result on start-up:{0}{0}" +
			"1. The row for the column headers is displayed.{0}{0}" +
			"2. A row with a single column containing an * is displayed.",
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
		ClientSize = new Size (300, 230);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80168";
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void CaptionVisibleCheck_CheckedChanged (object sender, EventArgs e)
	{
		_dataGrid.CaptionVisible = _captionVisibleCheck.Checked;
	}

	void ColumnHeadersVisibleCheck_CheckedChanged (object sender, EventArgs e)
	{
		_dataGrid.ColumnHeadersVisible = _columnHeadersVisibleCheck.Checked;
	}

	private CheckBox _captionVisibleCheck;
	private CheckBox _columnHeadersVisibleCheck;
	private DataGrid _dataGrid;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
