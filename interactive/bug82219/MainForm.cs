using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _dataGridView
		// 
		_dataGridView = new DataGridView ();
		_dataGridView.Dock = DockStyle.Fill;
		Controls.Add (_dataGridView);
		// 
		// _nameTextBoxColumn
		// 
		_nameTextBoxColumn = new DataGridViewTextBoxColumn ();
		_nameTextBoxColumn.HeaderText = "Name";
		_dataGridView.Columns.Add (_nameTextBoxColumn);
		// 
		// _firstNameTextBoxColumn
		// 
		_firstNameTextBoxColumn = new DataGridViewTextBoxColumn ();
		_firstNameTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		_firstNameTextBoxColumn.HeaderText = "First Name";
		_dataGridView.Columns.Add (_firstNameTextBoxColumn);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 190);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82219";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private DataGridView _dataGridView;
	private DataGridViewTextBoxColumn _nameTextBoxColumn;
	private DataGridViewTextBoxColumn _firstNameTextBoxColumn;
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
			"1. The First Name column fills the remainder of the display area " +
			"of the DataGridView.",
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
		ClientSize = new Size (320, 110);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82219";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
