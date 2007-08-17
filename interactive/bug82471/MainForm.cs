using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		Controls.Add (_tabControl);
		// 
		// _tabGeneral
		// 
		_tabGeneral = new TabPage ();
		_tabGeneral.TabIndex = 0;
		_tabGeneral.Text = "General";
		_tabControl.Controls.Add (_tabGeneral);
		// 
		// _tabLookAndFeel
		// 
		_tabLookAndFeel = new TabPage ();
		_tabLookAndFeel.TabIndex = 4;
		_tabLookAndFeel.Text = "Look And Feel";
		_tabControl.Controls.Add (_tabLookAndFeel);
		// 
		// _tabNetwork
		// 
		_tabNetwork = new TabPage ();
		_tabNetwork.TabIndex = 2;
		_tabNetwork.Text = "Network";
		_tabControl.Controls.Add (_tabNetwork);
		// 
		// _tabAlerts
		// 
		_tabAlerts = new TabPage ();
		_tabAlerts.TabIndex = 1;
		_tabAlerts.Text = "Alerts";
		_tabControl.Controls.Add (_tabAlerts);
		// 
		// _tabUpdates
		// 
		_tabUpdates = new TabPage ();
		_tabUpdates.TabIndex = 3;
		_tabUpdates.Text = "Updates";
		_tabControl.Controls.Add (_tabUpdates);
		// 
		// _tabCalendar
		// 
		_tabCalendar = new TabPage ();
		_tabCalendar.TabIndex = 5;
		_tabCalendar.Text = "Calendar";
		_tabControl.Controls.Add (_tabCalendar);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 100);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82471";
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

	private System.Windows.Forms.TabControl _tabControl;
	private System.Windows.Forms.TabPage _tabGeneral;
	private System.Windows.Forms.TabPage _tabAlerts;
	private System.Windows.Forms.TabPage _tabNetwork;
	private System.Windows.Forms.TabPage _tabUpdates;
	private System.Windows.Forms.TabPage _tabLookAndFeel;
	private System.Windows.Forms.TabPage _tabCalendar;
}

public class ChildForm : Form
{
	public ChildForm ()
	{
		// 
		// ChildForm
		// 
		ClientSize = new Size (300, 90);
		Location = new Point (250, 250);
		StartPosition = FormStartPosition.Manual;
		Text = "Child";
		Load += new EventHandler (ChildForm_Load);
	}

	void ChildForm_Load (object sender, EventArgs e)
	{
		Visible = false;
	}
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
			"1. The TabControl contains the following tabs:{0}{0}" +
			"   * General{0}" +
			"   * Look And Feel{0}" +
			"   * Network{0}" +
			"   * Alerts{0}" +
			"   * Updates{0}" +
			"   * Calendar{0}{0}" +
			"2. The text on each leaf is fully visible.",
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
		ClientSize = new Size (300, 210	);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82471";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
