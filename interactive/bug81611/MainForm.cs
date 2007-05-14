using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _comboBox
		// 
		_comboBox = new ComboBox ();
		_comboBox.DisplayMember = "displaymember";
		_comboBox.Location = new Point (8, 8);
		_comboBox.Size = new Size (150, 20);
		_comboBox.ValueMember = "valuemember";
		Controls.Add (_comboBox);
		// 
		// _selectedValueText
		// 
		_selectedValueText = new TextBox ();
		_selectedValueText.Location = new Point (8, 40);
		_selectedValueText.Size = new Size (150, 20);
		_selectedValueText.Text = "";
		Controls.Add (_selectedValueText);
		// 
		// MainForm
		// 
		ClientSize = new Size (170, 75);
		Location = new Point (400, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81611";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("tr-TR");
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
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
		row = dataTable.NewRow ();
		row [0] = "inter";
		row [1] = "i";
		dataTable.Rows.Add (row);
		row = dataTable.NewRow ();
		row [0] = "net";
		row [1] = "I";
		dataTable.Rows.Add (row);

		_comboBox.DataSource = dataTable;
		_comboBox.DataBindings.Add ("SelectedValue", new Controller (_selectedValueText), "controlsrc");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private ComboBox _comboBox;
	private TextBox _selectedValueText;

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
			"Steps to execute:{0}{0}" +
			"1. Select the \"upper\" entry in the combobox.{0}{0}" +
			"2. Press the Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"lower\" entry is selected in the combobox.{0}{0}" +
			"2. The textbox contains the text \"A\".",
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
			"1. Select the \"inter\" entry in the combobox.{0}{0}" +
			"2. Press the Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"inter\" entry is selected in the combobox.{0}{0}" +
			"2. The textbox contains the text \"i\".",
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
			"1. Select the \"lower\" entry in the combobox.{0}{0}" +
			"2. Press the Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"lower\" entry is selected in the combobox.{0}{0}" +
			"2. The textbox contains the text \"a\".",
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
			"1. Select the \"net\" entry in the combobox.{0}{0}" +
			"2. Press the Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The \"net\" entry is selected in the combobox.{0}{0}" +
			"2. The textbox contains the text \"I\".",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 200);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81611";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
}
