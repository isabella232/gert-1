using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_resizeControl = new ResizeControl ();
		// 
		// _panel
		// 
		_panel = new Panel ();
		_panel.Anchor = ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom)
					| AnchorStyles.Left)
					| AnchorStyles.Right)));
		_panel.BackColor = SystemColors.Window;
		_panel.Controls.Add (_resizeControl);
		_panel.Location = new Point (12, 25);
		_panel.Size = new Size (265, 230);
		_panel.TabIndex = 0;
		Controls.Add (_panel);
		// 
		// _resizeControl
		// 
		_resizeControl.Dock = DockStyle.Fill;
		_resizeControl.Location = new Point (0, 0);
		_resizeControl.Size = new Size (795, 265);
		_resizeControl.TabIndex = 0;
		// 
		// MainForm
		// 
		ClientSize = new Size (500, 326);
		Location = new Point (100, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81199";
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
	}

	private Panel _panel;
	private ResizeControl _resizeControl;
}

public class ResizeControl : UserControl
{
	public ResizeControl ()
	{
		// 
		// _listView
		// 
		_listView = new ListView ();
		_listView.Anchor = ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom)
					| AnchorStyles.Left)
					| AnchorStyles.Right)));
		_listView.Columns.Add (new ColumnHeader ());
		_listView.Columns.Add (new ColumnHeader ());
		_listView.Location = new Point (3, 3);
		_listView.Size = new Size (147, 150);
		_listView.TabIndex = 0;
		_listView.View = View.Details;
		Controls.Add (_listView);
		// 
		// ResizeControl
		// 
		Size = new Size (587, 566);
		Load += new EventHandler (ResizeContol_Load);
	}

	void ResizeContol_Load (object sender, EventArgs e)
	{
		for (int i = 0; i < 100; i++)
			_listView.Items.Add ("test" + i.ToString ());
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
			"Expected result on start-up:{0}{0}" +
			"1. The top and bottom handle of the ListView's vertical " +
			"scrollbar are visible.{0}{0}" +
			"2. When the form is resized, the ListView resizes accordingly.",
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
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81199";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
