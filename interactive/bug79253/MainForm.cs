using System;
using System.Drawing;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		ListViewItem listViewItem1 = new ListViewItem (new string [] {
			"de Icaza",
			"Miguel",
			"Somewhere"}, -1);
		SuspendLayout ();
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.Dock = DockStyle.Top;
		_listView.FullRowSelect = true;
		_listView.Height = 97;
		_listView.Items.Add (listViewItem1);
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
		_bugDescriptionLabel.Location = new Point (8, 110);
		_bugDescriptionLabel.Size = new Size (280, 112);
		_bugDescriptionLabel.TabIndex = 2;
		_bugDescriptionLabel.Text = "The row in the listview should not have a focus rectangle drawn around it.";
		Controls.Add (_bugDescriptionLabel);
		// 
		// Form1
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (292, 160);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #79253";
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	private ListView _listView;
	private ColumnHeader _nameHeader;
	private ColumnHeader _firstNameHeader;
	private ColumnHeader _countryHeader;
	private Label _bugDescriptionLabel;
}
