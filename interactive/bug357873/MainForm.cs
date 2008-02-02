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
		_listView.AllowDrop = true;
		_listView.AutoArrange = false;	
		_listView.Dock = DockStyle.Fill;
		Controls.Add (_listView);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 200);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #357873";
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

		_listView.Items.Add ("One");
		_listView.Items.Add ("Two");
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
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the One item and hold the mouse button " +
			"pressed.{0}{0}" +
			"2. Move the mouse pointer.{0}{0}" +
			"3. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The item is not moved.",
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
		ClientSize = new Size (300, 200);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #357873";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
