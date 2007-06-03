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
		// MainForm
		// 
		ClientSize = new Size (550, 700);
		IsMdiContainer = true;
		Location = new Point (100, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80533";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		ChildForm childA = new ChildForm ();
		childA.MdiParent = this;
		childA.Text = "Child A";
		childA.Show ();

		ChildForm childB = new ChildForm ();
		childB.MdiParent = this;
		childB.Text = "Child B";
		childB.Show ();

		ChildForm childC = new ChildForm ();
		childC.MdiParent = this;
		childC.Text = "Child C";
		childC.Show ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}
}

public class ChildForm : Form
{
	public ChildForm ()
	{
		SuspendLayout ();
		// 
		// _dataGrid
		// 
		_dataGrid = new System.Windows.Forms.DataGrid ();
		_dataGrid.DataMember = "";
		_dataGrid.Dock = DockStyle.Top;
		_dataGrid.Size = new System.Drawing.Size (292, 273);
		_dataGrid.TabIndex = 0;
		Controls.Add (_dataGrid);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 260;
		Controls.Add (_tabControl);
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Dock = DockStyle.Fill;
		_textBox.Multiline = true;
		// 
		// _tabPage
		// 
		_tabPage = new TabPage ();
		_tabPage.Text = "Text";
		_tabPage.Controls.Add (_textBox);
		_tabControl.Controls.Add (_tabPage);
		// 
		// ChildForm
		// 
		ClientSize = new Size (400, 550);
		Load += new EventHandler (ChildForm_Load);
		ResumeLayout (false);
	}

	void ChildForm_Load (object sender, EventArgs e)
	{
		System.Data.DataSet ds = new DataSet ();
		DataTable dt = new DataTable ();
		ds.Tables.Add (dt);

		DataColumn columnA = new DataColumn ("A");
		dt.Columns.Add (columnA);
		DataColumn columnB = new DataColumn ("B");
		dt.Columns.Add (columnB);

		for (int i = 0; i < 40; i++) {
			DataRow row = dt.NewRow ();
			row [0] = "Miguel";
			row [1] = "de Icaza";
			dt.Rows.Add (row);
		}

		_dataGrid.DataSource = ds;
		_dataGrid.DataMember = dt.TableName;
	}

	private DataGrid _dataGrid;
	private TextBox _textBox;
	private TabControl _tabControl;
	private TabPage _tabPage;
}

public class InstructionsForm : Form
{
	public InstructionsForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The scrollbar of the DataGrid on Child C is fully visible.{0}{0}" +
			"2. The right and bottom border of the TabControl are visible.",
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
			"1. Maximize Child C.{0}{0}" +
			"3. Press Ctrl+Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The TabControl on Child B is docked to the bottom of the form.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (360, 165);
		Location = new Point (700, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80533";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
