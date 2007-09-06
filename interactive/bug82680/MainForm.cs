using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _contextMenu
		// 
		_contextMenu = new ContextMenu ();
		_contextMenu.MenuItems.Add (new MenuItem ("Close"));
		// 
		// _treeView
		// 
		_treeView = new TreeView ();
		_treeView.ContextMenu = _contextMenu;
		_treeView.Dock = DockStyle.Fill;
		Controls.Add (_treeView);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 70);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82680";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		TreeNode inbox = new TreeNode ("Inbox");
		TreeNode personalFolders = new TreeNode ("Personal Folders");
		personalFolders.Nodes.Add (inbox);
		_treeView.Nodes.Add (personalFolders);
		_treeView.ExpandAll ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private ContextMenu _contextMenu;
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
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Right-click the Personal Folders node.{0}{0}" +
			"2. Right-click the Inbox node.{0}{0}" +
			"3. Right-click unoccupied area in the treeview.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A contextmenu is displayed on each step.",
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
		ClientSize = new Size (300, 190);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82680";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
