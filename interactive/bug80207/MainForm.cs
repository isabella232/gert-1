using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		this.SuspendLayout ();
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 150;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The text in the first column header is fully visible.{0}{0}" +
			"2. The text in the second column headers is not visible.{0}{0}" +
			"3. Both column headers have the same height.",
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
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Resize both columns in the ListView.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The height of the column headers does not change.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.Columns.Add (new ColumnHeader ());
		_listView.Columns.Add (new ColumnHeader ());
		_listView.Columns [0].Width = -2;
		_listView.Columns [1].Width = -1;
		_listView.Dock = DockStyle.Top;
		_listView.Height = 100;
		_listView.TabIndex = 0;
		_listView.View = View.Details;
		Controls.Add (_listView);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (330, 260);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #80207";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		ListViewItem item = _listView.Items.Add ("Very long text ...............................");
		item.SubItems.Add ("Very long text ...............................");
	}

	private ListView _listView;
	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
