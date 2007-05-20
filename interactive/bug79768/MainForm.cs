using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		SuspendLayout ();
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.Dock = DockStyle.Top;
		_listView.FullRowSelect = true;
		_listView.Height = 140;
		_listView.TabIndex = 0;
		_listView.View = View.Details;
		Controls.Add (_listView);
		// 
		// _nameHeader
		// 
		_nameHeader = new ColumnHeader ();
		_nameHeader.Text = "Name";
		_nameHeader.Width = 75;
		_listView.Columns.Add (_nameHeader);
		// 
		// _firstNameHeader
		// 
		_firstNameHeader = new ColumnHeader ();
		_firstNameHeader.Text = "FirstName";
		_firstNameHeader.Width = 77;
		_listView.Columns.Add (_firstNameHeader);
		// 
		// _countryHeader
		// 
		_countryHeader = new ColumnHeader ();
		_countryHeader.Text = "Country";
		_countryHeader.Width = 108;
		_listView.Columns.Add (_countryHeader);
		// 
		// _bugDescriptionLabel
		// 
		_bugDescriptionLabel = new Label ();
		_bugDescriptionLabel.Location = new Point (8, 160);
		_bugDescriptionLabel.Size = new Size (280, 112);
		_bugDescriptionLabel.TabIndex = 2;
		_bugDescriptionLabel.Text = string.Format (CultureInfo.InvariantCulture,
			"The ListView column headers should not overlap the " +
			"top of the vertical scrollbar.{0}{0}" +
			"The horizontal scrollbar should not overlap the " +
			"bottom of the vertical scrollbar.",
			Environment.NewLine);
		Controls.Add (_bugDescriptionLabel);
		// 
		// Form1
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (292, 240);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79768";
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
		for (int i = 0; i < 200; i++) {
			ListViewItem listViewItem = new ListViewItem (new string [] {
				"de Icaza",
				"Miguel",
				"Somewhere"}, 0);
			_listView.Items.Add (listViewItem);
		}
	}

	private ListView _listView;
	private ColumnHeader _nameHeader;
	private ColumnHeader _firstNameHeader;
	private ColumnHeader _countryHeader;
	private Label _bugDescriptionLabel;
}
