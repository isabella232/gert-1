using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_treeView = new TreeView ();
		_treeView.AllowDrop = true;
		_treeView.Dock = DockStyle.Top;
		_treeView.Height = 150;
		_treeView.DragDrop += new DragEventHandler (TreeView_DragDrop);
		_treeView.DragEnter += new DragEventHandler (TreeView_DragEnter);
		_treeView.DragOver += new DragEventHandler (TreeView_DragOver);
		_treeView.ItemDrag += new ItemDragEventHandler (TreeView_ItemDrag);
		Controls.Add (_treeView);
		// 
		// _dragSizeLabel
		// 
		_dragSizeLabel = new Label ();
		_dragSizeLabel.Location = new Point (8, 160);
		_dragSizeLabel.Size = new Size (80, 20);
		_dragSizeLabel.Text = "DragSize:";
		Controls.Add (_dragSizeLabel);
		// 
		// _dragSizeText
		// 
		_dragSizeText = new TextBox ();
		_dragSizeText.Location = new Point (100, 160);
		_dragSizeText.ReadOnly = true;
		_dragSizeText.Size = new Size (150, 20);
		Controls.Add (_dragSizeText);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 150;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (292, 340);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82404";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		TreeNode treeNode1 = new TreeNode ("Node1");
		TreeNode treeNode0 = new TreeNode ("Node0", new TreeNode [] { treeNode1 });
		_treeView.Nodes.Add (treeNode0);
		treeNode0.Expand ();

		TreeNode treeNode3 = new TreeNode ("Node3");
		TreeNode treeNode2 = new TreeNode ("Node2", new TreeNode [] { treeNode3 });
		_treeView.Nodes.Add (treeNode2);

		TreeNode treeNode5 = new TreeNode ("Node5");
		TreeNode treeNode4 = new TreeNode ("Node4", new TreeNode [] { treeNode5 });
		_treeView.Nodes.Add (treeNode4);

		_dragSizeText.Text = SystemInformation.DragSize.ToString ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void TreeView_ItemDrag (object sender, ItemDragEventArgs e)
	{
		TreeNode draggedNode = (TreeNode) e.Item;
		_eventsText.AppendText ("ItemDrag (Begin): " + draggedNode.Text
			+ Environment.NewLine);

		if (e.Button == MouseButtons.Left)
			DoDragDrop (e.Item, DragDropEffects.Move);
		else if (e.Button == MouseButtons.Right)
			DoDragDrop (e.Item, DragDropEffects.Copy);

		_eventsText.AppendText ("ItemDrag (End): " + draggedNode.Text
			+ Environment.NewLine);
	}

	void TreeView_DragDrop (object sender, DragEventArgs e)
	{
		// Retrieve the client coordinates of the drop location.
		Point targetPoint = _treeView.PointToClient (new Point (e.X, e.Y));

		// Retrieve the node at the drop location
		TreeNode targetNode = _treeView.GetNodeAt (targetPoint);

		// Retrieve the node that was dragged.
		TreeNode draggedNode = (TreeNode) e.Data.GetData (typeof (TreeNode));

		// Confirm that the node at the drop location is not 
		// the dragged node or a descendant of the dragged node.
		if (draggedNode != targetNode && !ContainsNode (draggedNode, targetNode)) {
			// If it is a move operation, remove the node from its current 
			// location and add it to the node at the drop location.
			if (e.Effect == DragDropEffects.Move) {
				_eventsText.AppendText ("DragDrop (Move): " + draggedNode.Text
					+ " => " + targetNode.Text + Environment.NewLine);

				draggedNode.Remove ();
				targetNode.Nodes.Add (draggedNode);
			}

			// If it is a copy operation, clone the dragged node
			// and add it to the node at the drop location
			if (e.Effect == DragDropEffects.Copy) {
				_eventsText.AppendText ("DragDrop (Move): " + draggedNode.Text
					+ " => " + targetNode.Text + Environment.NewLine);

				targetNode.Nodes.Add ((TreeNode) draggedNode.Clone ());
			}

			// Expand the node at the location 
			// to show the dropped node.
			targetNode.Expand ();
		} else {
			_eventsText.AppendText ("DragDrop (Descendant): " + draggedNode.Text
				+ " => " + targetNode.Text + Environment.NewLine);
		}
	}

	void TreeView_DragEnter (object sender, DragEventArgs e)
	{
		// Retrieve the client coordinates of the mouse position
		Point targetPoint = _treeView.PointToClient (new Point (e.X, e.Y));

		// Retrieve the node at the mouse position
		TreeNode targetNode = _treeView.GetNodeAt (targetPoint);

		_eventsText.AppendText ("DragEnter: " + targetNode.Text
			+ Environment.NewLine);

		e.Effect = e.AllowedEffect;
	}

	void TreeView_DragOver (object sender, DragEventArgs e)
	{
		// Retrieve the client coordinates of the mouse position.
		Point targetPoint = _treeView.PointToClient (new Point (e.X, e.Y));

		// Retrieve the node at the mouse position
		TreeNode targetNode = _treeView.GetNodeAt (targetPoint);

		// Select the node at the mouse position
		_treeView.SelectedNode = targetNode;

		if (_treeView.SelectedNode.Text == "Node4")
			e.Effect = DragDropEffects.Copy;
		else
			e.Effect = e.AllowedEffect;
	}

	bool ContainsNode (TreeNode node1, TreeNode node2)
	{
		if (node2.Parent == null)
			return false;

		if (node2.Parent == node1)
			return true;

		return ContainsNode (node1, node2.Parent);
	}

	private TreeView _treeView;
	private Label _dragSizeLabel;
	private TextBox _dragSizeText;
	private TextBox _eventsText;
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
			"1. Left-click Node0 and hold the mouse button pressed.{0}{0}" +
			"2. Move the mouse less than the displayed DragSize.{0}{0}" +
			"3. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The mouse cursor has not changed.{0}{0}" +
			"2. No events have fired.",
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
			"Expected result on start-up:{0}{0}" +
			"1. Right-click Node0 and hold the mouse button pressed.{0}{0}" +
			"2. Move the mouse less than the displayed DragSize.{0}{0}" +
			"3. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The mouse cursor has not changed.{0}{0}" +
			"2. No events have fired.",
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
		ClientSize = new Size (330, 220);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82404";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
