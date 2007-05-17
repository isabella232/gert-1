using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _toolTip
		// 
		_toolTip = new ToolTip ();
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.Dock = DockStyle.Fill;
		_listView.TabIndex = 0;
		_listView.MouseMove += new MouseEventHandler (ListView_MouseMove);
		Controls.Add (_listView);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (292, 266);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #79777";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main (string [] args)
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		for (int i = 0; i < 50; i++) {
			_listView.Items.Add ("Item " + i.ToString (CultureInfo.InvariantCulture));
		}

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ListView_MouseMove (object sender, MouseEventArgs e)
	{
		if (((ListView) sender).GetItemAt (e.X, e.Y) != null) {
			_toolTip.Active = true;
			_toolTip.SetToolTip ((Control) sender, (((ListView) sender).GetItemAt (e.X, e.Y)).Text);
		} else
			_toolTip.Active = false;
	}

	private ToolTip _toolTip;
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
			"1. Hover over multiple items in the ListView.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Whenever you hover over an item, a ToolTip containing the " +
			"text of the item is displayed.",
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
		ClientSize = new Size (300, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #79777";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
