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
		_treeView.AllowDrop = true;
		_treeView.Dock = DockStyle.Top;
		_treeView.FullRowSelect = true;
		_treeView.Height = 300;
		_treeView.HideSelection = false;
		Controls.Add (_treeView);
		// 
		// _fullRowSelectCheck
		// 
		_fullRowSelectCheck = new CheckBox ();
		_fullRowSelectCheck.Checked = true;
		_fullRowSelectCheck.Location = new Point (8, 310);
		_fullRowSelectCheck.Size = new Size (120, 20);
		_fullRowSelectCheck.Text = "FullRowSelect";
		_fullRowSelectCheck.CheckedChanged += new EventHandler (FullRowSelectCheck_CheckedChanged);
		Controls.Add (_fullRowSelectCheck);
		// 
		// _showLinesCheck
		// 
		_showLinesCheck = new CheckBox ();
		_showLinesCheck.Checked = true;
		_showLinesCheck.Location = new Point (220, 310);
		_showLinesCheck.Size = new Size (80, 20);
		_showLinesCheck.Text = "ShowLines";
		_showLinesCheck.CheckedChanged += new EventHandler (ShowLinesCheck_CheckedChanged);
		Controls.Add (_showLinesCheck);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 335);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81839";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		TreeNode root = new TreeNode ("Root");
		_treeView.Nodes.Add (root);

		root.Nodes.Add ("Child 1");
		root.Nodes.Add ("Child 2");
		root.Nodes.Add ("Child 3");
		TreeNode child4 = root.Nodes.Add ("Child 4");
		child4.Nodes.Add ("Child 4_1");
		child4.Nodes.Add ("Child 4_2");
		child4.Nodes.Add ("Child 4_3");
		child4.Nodes.Add ("Child 4_4");
		child4.Nodes.Add ("Child 4_5");
		child4.Nodes.Add ("Child 4_6");
		child4.Nodes.Add ("Child 4_7");
		TreeNode child5 = root.Nodes.Add ("Child 5");
		child5.Nodes.Add ("Child 5_1");
		child5.Nodes.Add ("Child 5_2");
		TreeNode child53 = child5.Nodes.Add ("Child 5_3");
		child53.Nodes.Add ("Child 5_3_1");
		child53.Nodes.Add ("Child 5_3_2");
		child53.Nodes.Add ("Child 5_4");
		root.Nodes.Add ("Child 6");

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void FullRowSelectCheck_CheckedChanged (object sender, EventArgs e)
	{
		_treeView.FullRowSelect = _fullRowSelectCheck.Checked;
	}

	void ShowLinesCheck_CheckedChanged (object sender, EventArgs e)
	{
		_treeView.ShowLines = _showLinesCheck.Checked;
	}

	private TreeView _treeView;
	private CheckBox _fullRowSelectCheck;
	private CheckBox _showLinesCheck;
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
			"1. Click the Root node.{0}{0}" +
			"2. Uncheck the ShowLines checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The full row of the Root node (except for the icon) is highlighted.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck the ShowLines checkbox.{0}{0}" +
			"1. Expand the Root node.{0}{0}" +
			"2. Expand the Child 4 node.{0}{0}" +
			"3. Click the Child 4_1 node.{0}{0}" +
			"3. Click the Child 4 node.{0}{0}" +
			"3. Click the Child 3 node.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, the full row of the Child 4_1 node (except for " +
			"the icon) is highlighted.{0}{0}" +
			"1. On step 4, the full row of the Child 4 node (except for the " +
			"icon) is highlighted.{0}{0}"+
			"1. On step 5, the full row of the Child 3 node (except for the " +
			"icon) is highlighted.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (350, 360);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81839";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
