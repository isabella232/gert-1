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
		_dataGrid.Dock = DockStyle.Fill;
		Controls.Add (_dataGrid);
		// 
		// MainForm
		// 
		ClientSize = new Size (200, 200);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80647";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		DataTable t = new DataTable ();
		t.Columns.Add ();
		t.Columns.Add ();
		DataRow row = t.NewRow ();
		row [0] = "111111";
		row [1] = "222222";
		t.Rows.Add (row);
		_dataGrid.DataSource = t;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	protected override void OnActivated (EventArgs e)
	{
		base.OnActivated (e);
		if (_done)
			return;

		Control o = ActiveForm;
		while (o is ContainerControl) {
			ContainerControl oContainer = (ContainerControl) o;
			o = oContainer.ActiveControl;
		}
		if (o != null && o is TextBox)
			((TextBox) o).Cut ();
		SendKeys.SendWait ("{TAB}");
		_done = true;
	}

	private DataGrid _dataGrid;
	private bool _done;
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
			"Expected result on start-up:{0}{0}" +
			"1. The cell in the first column is empty.{0}{0}" +
			"2. The text cursor is located at the end of the content in the " +
			"second column.",
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
		ClientSize = new Size (300, 130);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80647";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
