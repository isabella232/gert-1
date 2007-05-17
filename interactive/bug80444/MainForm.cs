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
		Text = "bug #80444";
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
		_tabControl.Height = 240;
		Controls.Add (_tabControl);
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Multiline = true;
		_textBox.Dock = DockStyle.Fill;
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

		DataRow row = dt.NewRow ();
		row [0] = "Miguel";
		row [1] = "de ICaza";
		dt.Rows.Add (row);

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
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click inside a cell of the DataGrid on Child C.{0}{0}" +
			"2. Press Ctrl+Tab key.{0}{0}" +
			"3. Press Ctrl+Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, Child B is activated.{0}{0}" +
			"2. On step 3, Child A is activated.",
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
			"1. Click on Child C.{0}{0}" +
			"2. Click on Child B.{0}{0}" +
			"3. Press Ctrl+Shift+Tab key.{0}{0}" +
			"4. Press Ctrl+Shift+Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, Child A is activated.{0}{0}" +
			"2. On step 4, Child C is activated.",
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
			"1. Click on Child A.{0}{0}" +
			"2. Click on Child C.{0}{0}" +
			"3. Press Ctrl+F6 key.{0}{0}" +
			"4. Press Ctrl+F6 key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, Child A is activated.{0}{0}" +
			"2. On step 4, Child B is activated.",
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
			"1. Click on Child A.{0}{0}" +
			"2. Click on Child B.{0}{0}" +
			"3. Press Ctrl+Shift+F6 key.{0}{0}" +
			"4. Press Ctrl+Shift+F6 key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, Child C is activated.{0}{0}" +
			"2. On step 4, Child A is activated.",
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
			"1. Click on Child A.{0}{0}" +
			"2. Click on Child B.{0}{0}" +
			"3. Press Ctrl+F4 key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Child B is closed.{0}{0}" +
			"2. Child A is activated.",
			Environment.NewLine);
		// 
		// _tabPage5
		// 
		_tabPage5 = new TabPage ();
		_tabPage5.Text = "#5";
		_tabPage5.Controls.Add (_bugDescriptionText5);
		_tabControl.Controls.Add (_tabPage5);
		// 
		// _bugDescriptionText6
		// 
		_bugDescriptionText6 = new TextBox ();
		_bugDescriptionText6.Multiline = true;
		_bugDescriptionText6.Dock = DockStyle.Fill;
		_bugDescriptionText6.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click on Child A.{0}{0}" +
			"2. Press Ctrl+Shift+F4 key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Child A is closed.{0}{0}" +
			"2. Child C is activated.",
			Environment.NewLine);
		// 
		// _tabPage6
		// 
		_tabPage6 = new TabPage ();
		_tabPage6.Text = "#6";
		_tabPage6.Controls.Add (_bugDescriptionText6);
		_tabControl.Controls.Add (_tabPage6);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (400, 250);
		Location = new Point (700, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80444";
		Controls.Add (_tabControl);
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TextBox _bugDescriptionText5;
	private TextBox _bugDescriptionText6;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
	private TabPage _tabPage5;
	private TabPage _tabPage6;
}
