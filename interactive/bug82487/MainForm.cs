using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _statusBar
		// 
		_statusBar = new StatusBar ();
		_statusBar.ShowPanels = true;
		Controls.Add (_statusBar);
		// 
		// _myComputerPanel
		// 
		_myComputerPanel = new StatusBarPanel ();
		_myComputerPanel.AutoSize = StatusBarPanelAutoSize.Contents;
		_myComputerPanel.Icon = Icon;
		_myComputerPanel.Text = "My Computer";
		_statusBar.Panels.Add (_myComputerPanel);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 60);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82487";
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

	private StatusBar _statusBar;
	private StatusBarPanel _myComputerPanel;
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
			"1. The form icon and the text \"My Computer\" are " +
			"displayed as content of the first panel in the " +
			"StatusBar.",
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
		ClientSize = new Size (300, 100);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82487";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
