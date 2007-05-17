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
		Controls.Add (_treeView);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 345);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81424";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main (string [] args)
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();

		for (int i = 0; i < 40; i++) {
			TreeNode node = _treeView.Nodes.Add ("Node #" + i.ToString (CultureInfo.InvariantCulture));
			for (int j = 0; j < 5; j++) {
				TreeNode childLevelOne = node.Nodes.Add (string.Format (CultureInfo.InvariantCulture,
					"Childnode #{0}.{1} Level 1", i, j));
				for (int k = 0; k < 3; k++) {
					TreeNode childLevelTwo = childLevelOne.Nodes.Add (string.Format (CultureInfo.InvariantCulture,
						"Childnode #{0}.{1}.{2} Level 2", i, j, k));
					for (int l = 0; l < 2; l++) {
						TreeNode childLevelThree = childLevelTwo.Nodes.Add (string.Format (CultureInfo.InvariantCulture,
							"Childnode #{0}.{1}.{2}.{3} Level 3", i, j, k, l));
						for (int m = 0; m < 2; m++) {
							childLevelThree.Nodes.Add (string.Format (CultureInfo.InvariantCulture,
								"Childnode #{0}.{1}.{2}.{3}.{4} Level 4 With Some Very Long Text",
								i, j, k, l, m));
						}
					}
				}
			}
		}
		_treeView.ExpandAll ();
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
			"Steps to execute:{0}{0}" +
			"1. Scroll both horizontally and vertically in the TreeView " +
			"using both the scrollbar thumb and the buttons.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Scrolling works fine without drawing bad artifacts.",
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
		ClientSize = new Size (300, 200);
		Location = new Point (700, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81424";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
