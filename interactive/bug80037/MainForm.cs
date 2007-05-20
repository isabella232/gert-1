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
		_listView.CheckBoxes = true;
		_listView.Columns.Add ("Subcolumn 1", 100, HorizontalAlignment.Left);
		_listView.Columns.Add ("Subcolumn 2", 100, HorizontalAlignment.Center);
		_listView.Dock = DockStyle.Top;
		_listView.Height = 230;
		_listView.View = View.Details;
		Controls.Add (_listView);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 120;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. One every item is checked.{0}{0}" +
			"2. The checkmark is drawn in the center of the checkbox.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// MainForm
		//
		ClientSize = new Size (400, 360);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80037";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main (string [] args)
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		for (int i = 0; i < 10; i++) {
			ListViewItem item = new ListViewItem ();
			if ((i % 2) == 0)
				item.Checked = true;
			item.Text = "Item " + i;
			item.SubItems.Add ("subitem1");
			item.SubItems.Add ("subitem2");
			_listView.Items.Add (item);
		}
	}

	private ListView _listView;
	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
