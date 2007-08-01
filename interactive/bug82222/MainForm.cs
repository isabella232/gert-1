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
		Text = "bug #82222";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_dataGridView.Rows.Add ("de Icaza", "Miguel");
		_dataGridView.Rows.Add ("Toshok", "Chris");
		_dataGridView.Rows.Add ("Harper", "Jackson");

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
			"Steps to execute:{0}{0}" +
			"1. Click the header of the Name column.{0}{0}" +
			"2. Click the header of the Name column.{0}{0}" +
			"3. Click the header of the Name column.{0}{0}" +
			"4. Click the header of the First Name column.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1:{0}{0}" +
			"   * An up arrow is drawn in the Name column.{0}" +
			"   * The rows are sorted ascending on the Name.{0}{0}" +
			"2. On step 2:{0}{0}" +
			"   * A down arrow is drawn in the Name column.{0}" +
			"   * The rows are sorted descending on the Name.{0}{0}" +
			"3. On step 3:{0}{0}" +
			"   * An up arrow is drawn in the Name column.{0}" +
			"   * The rows are sorted ascending on the Name.{0}{0}" +
			"4. On step 4:{0}{0}" +
			"   * An up arrow is drawn in the First Name column.{0}" +
			"   * The rows are sorted ascending on the First Name.",
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
		ClientSize = new Size (320, 450);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82222";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
