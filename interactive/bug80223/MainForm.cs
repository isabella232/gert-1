using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _treeView
		// 
		_treeView = new TreeView ();
		_treeView.Dock = DockStyle.Left;
		Controls.Add (_treeView);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 400);
		IsMdiContainer = true;
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80223";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main (string [] args)
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Form frm = new ChildForm ();
		frm.MdiParent = this;
		frm.Show ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private TreeView _treeView;
}

class ChildForm : Form
{
	public ChildForm ()
	{
		// 
		// ChildForm
		// 
		ClientSize = new Size (150, 100);
		Move += new EventHandler (ChildForm_Move);
		Text = "child";
	}

	void ChildForm_Move (object sender, EventArgs e)
	{
		//throw new Exception ("should not happen");
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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The TreeView should not overlap the MDI child.",
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
		ClientSize = new Size (300, 120);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80223";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
