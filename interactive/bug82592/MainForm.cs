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
		_treeView.HideSelection = false;
		_treeView.LabelEdit = true;
		Controls.Add (_treeView);
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Location = new Point (8, 210);
		_textBox.Size = new Size (190, 20);
		_textBox.Text = "New Folder";
		Controls.Add (_textBox);
		// 
		// _addNodeButton
		// 
		_addNodeButton = new Button ();
		_addNodeButton.Location = new Point (215, 210);
		_addNodeButton.Size = new Size (75, 20);
		_addNodeButton.Text = "Add Node";
		_addNodeButton.Click += new EventHandler (AddNodeButton_Click);
		Controls.Add (_addNodeButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 245);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82592";
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
		root.Nodes.Add (new TreeNode (@"H:\"));
		root.Nodes.Add (new TreeNode (@"I:\"));
		root.Nodes.Add (new TreeNode (@"J:\"));
		root.Nodes.Add (new TreeNode (@"K:\"));
		root.Nodes.Add (new TreeNode (@"L:\"));
		root.Nodes.Add (new TreeNode (@"M:\"));
		root.Nodes.Add (new TreeNode (@"N:\"));
		root.Nodes.Add (new TreeNode (@"O:\"));
		root.Nodes.Add (new TreeNode (@"P:\"));
		root.Nodes.Add (new TreeNode (@"Q:\"));
	}

	void AddNodeButton_Click (object sender, EventArgs e)
	{
		TreeNode selected = _treeView.SelectedNode;
		if (selected == null)
			return;

		if (_textBox.Text.Length == 0)
			return;

		TreeNode new_node = new TreeNode (_textBox.Text);
		selected.Nodes.Add (new_node);
		selected.Expand ();
		new_node.BeginEdit ();
	}

	private TreeView _treeView;
	private TextBox _textBox;
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
			"3. Enter \"Mono\" as label.{0}{0}" +
			"4. Press the Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"   * The new node is scrolled into view.{0}" +
			"   * The label of the new node can be edited.{0}" +
			"   * The edit box has focus.{0}{0}" +
			"2. On step 4:{0}{0}" +
			"   * The label of the new node is \"Mono\".{0}" +
			"   * The new node remains visible.{0}" +
			"   * The My Computer node is highlighted.{0}" +
			"   * The TreeView has focus.",
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
		ClientSize = new Size (300, 360);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82592";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
