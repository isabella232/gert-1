using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _columnHeader
		// 
		_columnHeader = new ColumnHeader ();
		_columnHeader.Text = "Reference";
		_columnHeader.Width = 400;
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.Columns.Add (_columnHeader);
		_listView.Dock = DockStyle.Fill;
		_listView.View = View.Details;
		Controls.Add (_listView);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 150);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82197";
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

	private ColumnHeader _columnHeader;
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
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The Reference column is displayed.{0}{0}" +
			"2. A horizontal scrollbar is displayed.",
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
		Text = "Instructions - bug #82197";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
