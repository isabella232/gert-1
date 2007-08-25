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
		_treeView.AfterLabelEdit += new NodeLabelEditEventHandler (TreeView_AfterLabelEdit);
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
		Text = "bug #82590";
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

		switch (e.Label.ToUpper ()) {
		case "MWF":
		case "MONO":
			_treeView.SelectedNode = e.Node;
			break;
		case "REMOVE":
			e.Node.Remove ();
			break;
		case "CANCEL":
			e.CancelEdit = true;
			break;
		default:
			break;
		}
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
			"1. The label of the new node is \"Mono\".{0}{0}" +
			"2. The new node is highlighted.{0}{0}" +
			"3. The TreeView has focus.",
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
			"1. Select the My Computer node.{0}{0}" +
			"2. Click the Add Node button.{0}{0}" +
			"3. Enter \"MWF\" as label.{0}{0}" +
			"4. Click inside the TextBox below.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The label of the new node is \"MWF\".{0}{0}" +
			"2. The new node is highlighted.{0}{0}" +
			"3. The TextBox has focus.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Select the C:\\ node.{0}{0}" +
			"2. Click the Add Node button.{0}{0}" +
			"3. Enter \"Winforms\" as label.{0}{0}" +
			"4. Press the Esc key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The label of the new node is \"New Folder\".{0}{0}" +
			"2. The C:\\ node is highlighted.{0}{0}" +
			"3. The TreeView has focus.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// _bugDescriptionText4
		// 
		_bugDescriptionText4 = new TextBox ();
		_bugDescriptionText4.Dock = DockStyle.Fill;
		_bugDescriptionText4.Multiline = true;
		_bugDescriptionText4.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Select the My Computer node.{0}{0}" +
			"2. Click the Add Node button.{0}{0}" +
			"3. Enter \"REMOVE\" as label.{0}{0}" +
			"4. Press the Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The new node is removed from the TreeView.{0}{0}" +
			"2. The My Computer node is highlighted.{0}{0}" +
			"3. The TreeView has focus.",
			Environment.NewLine);
		// 
		// _tabPage4
		// 
		_tabPage4 = new TabPage ();
		_tabPage4.Text = "#4";
		_tabPage4.Controls.Add (_bugDescriptionText4);
		_tabControl.Controls.Add (_tabPage4);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 270);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82590";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TextBox _bugDescriptionText4;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
	private TabPage _tabPage4;
}
