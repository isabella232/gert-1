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
		_dataGrid.DataMember = string.Empty;
		_dataGrid.Dock = DockStyle.Fill;
		_dataGrid.HeaderForeColor = SystemColors.ControlText;
		_dataGrid.TabIndex = 0;
		Controls.Add (_dataGrid);
		// 
		// MainForm
		// 
		ClientSize = new Size (292, 400);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80291";
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
		_dataGrid.DataMember = _dataSet.Tables [0].TableName;
		_dataSet.AcceptChanges ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		_dataSet.GetChanges ();
		return base.ProcessCmdKey(ref msg, keyData);
	}

	private DataSet _dataSet;
	private DataGrid _dataGrid;
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Select the first row.{0}{0}" +
			"2. Hold the Shift key and press the Down arrow 9 times to select " +
			"10 rows.{0}{0}" +
			"3. Hold the Shift key and press the Up arrow 9 times.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No crash.",
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
		ClientSize = new Size (360, 190);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80291";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
