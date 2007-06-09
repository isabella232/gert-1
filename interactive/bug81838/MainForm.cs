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
		_listView.AllowColumnReorder = true;
		_listView.AllowDrop = true;
		_listView.Dock = DockStyle.Top;
		_listView.FullRowSelect = true;
		_listView.HideSelection = false;
		_listView.Size = new Size (300, 450);
		_listView.View = View.Details;
		Controls.Add (_listView);
		// 
		// MainForm
		// 
		ClientSize = new Size (510, 400);
		Location = new Point (175, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81838";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		ColumnHeader header = null;

		header = new ColumnHeader ();
		header.Text = "";
		header.Width = 28;
		_listView.Columns.Add (header);

		header = new ColumnHeader ();
		header.Text = "Title";
		header.Width = 102;
		_listView.Columns.Add (header);

		header = new ColumnHeader ();
		header.Text = "Checkout by";
		header.Width = 77;
		_listView.Columns.Add (header);

		header = new ColumnHeader ();
		header.Text = "FileName";
		header.Width = 123;
		_listView.Columns.Add (header);

		header = new ColumnHeader ();
		header.Text = "Doctype";
		header.Width = 72;
		_listView.Columns.Add (header);

		header = new ColumnHeader ();
		header.Text = "Archive";
		header.Width = 80;
		_listView.Columns.Add (header);

		_listView.BeginUpdate ();
		_listView.SuspendLayout ();

		for (int i = 1; i < 1000; i++) {
			ListViewItem item = _listView.Items.Add ("");

			if ((i % 3) == 0)
				item.ForeColor = Color.DarkRed;

			item.SubItems.Add ("Name  123 123 123 13 123 123 123 " + i);
			item.SubItems.Add ("Test" + i);
			item.SubItems.Add ("Test  123 123 123 13 123 123 123" + i);
			item.SubItems.Add ("Test" + i);
			item.SubItems.Add ("Test" + i);
			item.SubItems.Add ("");
		}

		_listView.ResumeLayout ();
		_listView.EndUpdate ();
		//_listView.Height = 600;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
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
			"1. Press Page-Down until scrolling stops.{0}{0}" +
			"2. Press Page-Up until scrolling stops.{0}{0}" +
			"3. Press the Down arrow until scrolling starts.{0}{0}" +
			"4. Scroll further down using the mousewheel.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the thumb is displayed at the top of the " +
			"ScrollBar.{0}{0}" +
			"2. On steps 3 and 4:{0}{0}" +
			"   * The scrollbar thumb is visible.{0}" +
			"   * No drawing issues for items that are scrolled into view.",
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
		ClientSize = new Size (330, 280);
		Location = new Point (700, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81838";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
