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
		_treeView.Dock = DockStyle.Top;
		_treeView.Height = 200;
		_treeView.LabelEdit = true;
		_treeView.AfterLabelEdit += new NodeLabelEditEventHandler (TreeView_AfterLabelEdit);
		Controls.Add (_treeView);
		// 
		// _addNodeButton
		// 
		_addNodeButton = new Button ();
		_addNodeButton.Location = new Point (105, 210);
		_addNodeButton.Text = "Add Node";
		_addNodeButton.Click += new EventHandler (AddNodeButton_Click);
		Controls.Add (_addNodeButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 245);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82577";
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

		TreeNode root = new TreeNode ("My Computer");
		_treeView.Nodes.Add (root);

		root.Nodes.Add (new TreeNode (@"C:\"));
		root.Nodes.Add (new TreeNode (@"D:\"));
		root.Nodes.Add (new TreeNode (@"E:\"));
		root.Nodes.Add (new TreeNode (@"F:\"));
		root.Nodes.Add (new TreeNode (@"G:\"));
	}

	void TreeView_AfterLabelEdit (object sender, NodeLabelEditEventArgs e)
	{
		if (e.Label == null)
			return;

		if (e.Label == "REFUSE") {
			e.CancelEdit = true;
			e.Node.BeginEdit ();
		}
	}

	void AddNodeButton_Click (object sender, EventArgs e)
	{
		TreeNode selected = _treeView.SelectedNode;
		if (selected == null)
			return;

		TreeNode new_node = new TreeNode ("New Node");
		selected.Nodes.Add (new_node);
		selected.Expand ();
		new_node.BeginEdit ();
	}

	private TreeView _treeView;
	private Button _addNodeButton;
}

class MyControl : Control
{
	public MyControl ()
	{
		this.SuspendLayout ();
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
		_textBox.Location = new Point (0, 0);
		_textBox.Multiline = true;
		_textBox.Size = new Size (60, 60);
		Controls.Add (_textBox);
		// 
		// MyControl
		// 
		BackColor = Color.Red;
		Size = new Size (292, 271);
		ResumeLayout (false);
		PerformLayout ();
	}

	private TextBox _textBox;
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
			"1. Select the My Computer node.{0}{0}" +
			"2. Click the Add Node button.{0}{0}" +
			"3. Enter REFUSE as label.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The label changes back to \"New Node\".{0}{0}" +
			"2. The label remains editable.",
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
		ClientSize = new Size (300, 220);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82577";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
