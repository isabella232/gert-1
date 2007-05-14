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
		// _groupBox1
		// 
		_groupBox1 = new GroupBox ();
		_groupBox1.Location = new Point (8, 8);
		_groupBox1.Size = new Size (140, 90);
		_groupBox1.Text = "1";
		Controls.Add (_groupBox1);
		// 
		// _comboBox1
		// 
		_comboBox1 = new ComboBox ();
		_comboBox1.DisplayMember = "displaymember";
		_comboBox1.Location = new Point (8, 20);
		_comboBox1.ValueMember = "valuemember";
		_groupBox1.Controls.Add (_comboBox1);
		// 
		// _selectedValueText1
		// 
		_selectedValueText1 = new TextBox ();
		_selectedValueText1.Location = new Point (8, 55);
		_selectedValueText1.Size = new Size (120, 20);
		_selectedValueText1.Text = "";
		_groupBox1.Controls.Add (_selectedValueText1);
		// 
		// _groupBox2
		// 
		_groupBox2 = new GroupBox ();
		_groupBox2.Location = new Point (150, 8);
		_groupBox2.Size = new Size (140, 90);
		_groupBox2.Text = "2";
		Controls.Add (_groupBox2);
		// 
		// _comboBox2
		// 
		_comboBox2 = new ComboBox ();
		_comboBox2.DisplayMember = "displaymember";
		_comboBox2.Location = new Point (8, 20);
		_comboBox2.ValueMember = "valuemember";
		_groupBox2.Controls.Add (_comboBox2);
		// 
		// _selectedValueText2
		// 
		_selectedValueText2 = new TextBox ();
		_selectedValueText2.Location = new Point (8, 55);
		_selectedValueText2.Size = new Size (120, 20);
		_selectedValueText2.Text = "";
		_groupBox2.Controls.Add (_selectedValueText2);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 110);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81610";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_selectedValueText1.Text = string.Empty;
		_comboBox1.DataSource = CreateDataTable ();
		_comboBox1.DataBindings.Add ("SelectedValue", new Controller (_selectedValueText1), "controlsrc");

		_selectedValueText2.Text = "a";
		_comboBox2.DataSource = CreateDataTable ();
		_comboBox2.DataBindings.Add ("SelectedValue", new Controller (_selectedValueText2), "controlsrc");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	DataTable CreateDataTable ()
	{
		DataTable dataTable = new DataTable ();
		dataTable.Columns.Add ("displaymember");
		dataTable.Columns.Add ("valuemember");
		DataRow row = dataTable.NewRow ();
		row [0] = "lower";
		row [1] = "a";
		dataTable.Rows.Add (row);
		row = dataTable.NewRow ();
		row [0] = "upper";
		row [1] = "A";
		dataTable.Rows.Add (row);
		row = dataTable.NewRow ();
		row [0] = "else";
		row [1] = "e";
		dataTable.Rows.Add (row);
		return dataTable;
	}

	private GroupBox _groupBox1;
	private GroupBox _groupBox2;
	private ComboBox _comboBox1;
	private ComboBox _comboBox2;
	private TextBox _selectedValueText1;
	private TextBox _selectedValueText2;

	class Controller
	{
		public Controller (TextBox textBox)
		{
			_textBox = textBox;
		}

		public string controlsrc
		{
			get { return _textBox.Text; }
			set { _textBox.Text = value; }
		}

		private TextBox _textBox;
	}
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
			"2. No item is selected in combobox1.{0}{0}" +
			"2. The \"lower\" entry is selected in combobox2.",
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
		ClientSize = new Size (300, 120);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81610";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
