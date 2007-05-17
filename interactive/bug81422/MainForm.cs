using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _tree
		// 
		_tree = new TreeView ();
		_tree.Dock = DockStyle.Top;
		_tree.Height = 100;
		Controls.Add (_tree);
		// 
		// _refreshButton
		// 
		_refreshButton = new Button ();
		_refreshButton.Location = new Point (8, 110);
		_refreshButton.Text = "Refresh";
		_refreshButton.Click += new EventHandler (RefreshButton_Click);
		Controls.Add (_refreshButton);
		// 
		// _visibleText
		// 
		_visibleText = new TextBox ();
		_visibleText.Dock = DockStyle.Bottom;
		_visibleText.Height = 200;
		_visibleText.Multiline = true;
		_visibleText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_visibleText);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 350);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81422";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main (string [] args)
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		for (int i = 0; i < 40; i++) {
			TreeNode node = _tree.Nodes.Add ("Node #" + i.ToString (CultureInfo.InvariantCulture));
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
		_tree.ExpandAll ();

		InitVisible ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void RefreshButton_Click (object sender, EventArgs e)
	{
		InitVisible ();
	}

	void InitVisible ()
	{
		_visibleText.Text = string.Empty;

		foreach (TreeNode node in _tree.Nodes) {
			if (node.IsVisible) {
				_visibleText.AppendText (node.Index + " (" + node.Text + ")"
					+ Environment.NewLine);
			}
			DumpVisibleNodes (node);
		}
	}

	void DumpVisibleNodes (TreeNode node)
	{
		foreach (TreeNode childNode in node.Nodes) {
			if (childNode.IsVisible) {
				_visibleText.AppendText (childNode.Index + " (" + childNode.Text + ")"
					+ Environment.NewLine);
			}
			DumpVisibleNodes (childNode);
		}
	}

	private TreeView _tree;
	private Button _refreshButton;
	private TextBox _visibleText;
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
			"Execpted result on start-up:{0}{0}" +
			"1. The textbox contains only the text of the nodes that are " +
			"visible.",
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
		ClientSize = new Size (300, 180);
		Location = new Point (700, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81422";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
