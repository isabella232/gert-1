using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _treeView
		// 
		_treeView = new TreeView ();
		_treeView.Dock = DockStyle.Fill;
		_treeView.TabIndex = 0;
		Controls.Add (_treeView);
		// 
		// MainForm
		// 
		ClientSize = new Size (200, 50);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81603";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_treeView.Nodes.Add ("A");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private TreeView _treeView;
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
			"1. TreeView node A is highlighted.",
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
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81603";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
