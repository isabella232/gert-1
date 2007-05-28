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
		// _comboBox
		// 
		_comboBox = new ComboBox ();
		_comboBox.Dock = DockStyle.Top;
		_comboBox.DisplayMember = "displaymember";
		_comboBox.ValueMember = "valuemember";
		_comboBox.DataBindings.Add ("SelectedValue", new bo(), "controlsrc");
		Controls.Add (_comboBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (180, 50);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81612";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		DataTable t = new DataTable ();
		t.Columns.Add ("displaymember");
		t.Columns.Add ("valuemember");
		DataRow row = t.NewRow ();
		row [0] = "lower";
		row [1] = "a";
		t.Rows.Add (row);
		row = t.NewRow ();
		row [0] = "upper";
		row [1] = "A";
		t.Rows.Add (row);
		_comboBox.DataSource = t;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private ComboBox _comboBox;

	class bo
	{
		string t;
		public string controlsrc
		{
			get { return t; }
			set { t = value; }
		}
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
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the dropdown arrow of the ComboBox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The height of the dropdown area is sized to hold exactly " +
			"the two items.",
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
		ClientSize = new Size (360, 160);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81612";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
