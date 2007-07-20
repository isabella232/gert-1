using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_treeView = new TreeView ();
		_treeView.Dock = DockStyle.Top;
		_treeView.Height = 100;
		Controls.Add (_treeView);
		// 
		// _expandButton
		// 
		_expandButton = new Button ();
		_expandButton.Location = new Point (100, 110);
		_expandButton.Size = new Size (70, 20);
		_expandButton.Text = "Expand";
		_expandButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_expandButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (292, 140);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82154";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Init ();
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ResetButton_Click (object sender, EventArgs e)
	{
		_treeView.Nodes.Clear ();
		Init ();
		_treeView.ExpandAll ();
	}

	void Init ()
	{
		TreeNode treeNode1 = new TreeNode ("Node1");
		TreeNode treeNode0 = new TreeNode ("Node0", new TreeNode [] { treeNode1 });
		_treeView.Nodes.Add (treeNode0);
	}

	private TreeView _treeView;
	private Button _expandButton;
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
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Expand button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Node0 is expanded.",
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
		ClientSize = new Size (330, 140);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82154";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
