using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.Dock = DockStyle.Fill;
		_listView.FullRowSelect = true;
		_listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		_listView.HideSelection = false;
		_listView.TabIndex = 3;
		_listView.View = View.Details;
		Controls.Add (_listView);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 265);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81578";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();

		_listView.Columns.Add ("Topic", 200, HorizontalAlignment.Left);
		_listView.Columns.Add ("TraceLevel", 80, HorizontalAlignment.Left);
		_listView.Items.Add ("Item One").SubItems.Add ("Sub one");
		_listView.Items.Add ("Item Two").SubItems.Add ("Sub two");
		_listView.Items.Add ("Item Three").SubItems.Add ("Sub three");
		_listView.Items.Add ("Item Four").SubItems.Add ("Sub four");
	}

	private ListView _listView;
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
			"1. Select an item in the ListView.{0}{0}" +
			"2. Press Alt+F4.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The form is closed.",
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
		ClientSize = new Size (300, 165);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81578";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
