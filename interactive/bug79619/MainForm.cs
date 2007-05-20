using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _tab
		// 
		_tab = new TabControl ();
		_tab.Alignment = TabAlignment.Top;
		_tab.Dock = DockStyle.Fill;
		_tab.SelectedIndex = 3;
		Controls.Add (_tab);
		// 
		// tab pages
		// 
		_tab.Controls.Add (CreateTabPage ("Red", Color.FromArgb (255, 255, 0, 0)));
		_tab.Controls.Add (CreateTabPage ("Orange", Color.FromArgb (255, 255, 153, 0)));
		_tab.Controls.Add (CreateTabPage ("Yellow", Color.FromArgb (255, 255, 255, 0)));
		_tab.Controls.Add (CreateTabPage ("Green", Color.FromArgb (255, 0, 153, 0)));
		_tab.Controls.Add (CreateTabPage ("Blue", Color.FromArgb (255, 0, 0, 255)));
		_tab.Controls.Add (CreateTabPage ("Purple", Color.FromArgb (255, 197, 0, 148)));
		// 
		// MainForm
		// 
		Location = new Point (230, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #79619";
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

	TabPage CreateTabPage (string label, Color c)
	{
		TabPage res = new TabPage (label);
		res.BackColor = c;
		return res;
	}

	private TabControl _tab;
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
			"Expected result on start-up{0}{0}" +
			"1. The \"Green\" tab is highlighted.{0}{0}" +
			"2. The background color of the tab is green.{0}{0}" +
			"3. Six tabs are displayed.{0}{0}" +
			"4. No arrows are displayed to navigate through the tabs.",
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
		ClientSize = new Size (360, 170);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #79619";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
