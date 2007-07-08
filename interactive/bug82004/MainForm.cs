using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_listView = new ListView ();
		_listView.Dock = DockStyle.Fill;
		_listView.View = View.Details;
		_listView.Items.Add ("item 1");
		_listView.Items.Add ("item 2");
		_listView.Items.Add ("item 3");
#if NET_2_0
		_listView.MouseClick += new MouseEventHandler (ListView_MouseClick);
#endif
		_listView.MouseMove += new MouseEventHandler (ListView_MouseMove);
		Controls.Add (_listView);
		// 
		// _nameColumnHeader
		// 
		_nameColumnHeader = new ColumnHeader ();
		_nameColumnHeader.Text = "Name";
		_listView.Columns.Add (_nameColumnHeader);
		// 
		// _statusBar
		// 
		_statusBar = new StatusBar ();
		_statusBar.ShowPanels = true;
		Controls.Add (_statusBar);
		// 
		// _activeItemPanel
		// 
		_activeItemPanel = new StatusBarPanel();
		_activeItemPanel.AutoSize = StatusBarPanelAutoSize.Contents;
		_activeItemPanel.MinWidth = 30;
		_statusBar.Panels.Add (_activeItemPanel);
		// 
		// _hitItemPanel
		// 
		_hitItemPanel = new StatusBarPanel ();
		_hitItemPanel.AutoSize = StatusBarPanelAutoSize.Spring;
		_statusBar.Panels.Add (_hitItemPanel);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82004";
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

#if NET_2_0
	void ListView_MouseClick (object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left) {
			ListViewHitTestInfo hitInfo = _listView.HitTest (e.Location);
			if ((hitInfo.Location & ListViewHitTestLocations.Label) > 0) {
				_hitItemPanel.Text = hitInfo.Item.Text;
			}
		}
	}
#endif

	void ListView_MouseMove (object sender, MouseEventArgs e)
	{
		ListViewItem item = _listView.GetItemAt (e.X, e.Y);
		if (item != null)
			_activeItemPanel.Text = item.Text;
		else
			_activeItemPanel.Text = string.Empty;
	}

	private ListView _listView;
	private ColumnHeader _nameColumnHeader;
	private StatusBar _statusBar;
	private StatusBarPanel _activeItemPanel;
	private StatusBarPanel _hitItemPanel;
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
			"1. Move the mouse over the items in the ListView.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. When the mouse pointer is moved over an item, the text of " +
			"the item is displayed in the left panel of the StatusBar.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
#if NET_2_0
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click each of the items in the ListView.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The right panel of the StatusBar contains the text of the " +
			"item that was last clicked.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
#endif
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (360, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82004";
	}

	private TextBox _bugDescriptionText1;
#if NET_2_0
	private TextBox _bugDescriptionText2;
#endif
	private TabControl _tabControl;
	private TabPage _tabPage1;
#if NET_2_0
	private TabPage _tabPage2;
#endif
}
