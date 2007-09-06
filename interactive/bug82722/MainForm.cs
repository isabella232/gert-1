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
		_treeView.Dock = DockStyle.Top;
		_treeView.Height = 100;
		_treeView.HideSelection = false;
		_treeView.BeforeSelect += new TreeViewCancelEventHandler (TreeView_BeforeSelect);
		_treeView.AfterSelect += new TreeViewEventHandler (TreeView_AfterSelect);
		Controls.Add (_treeView);
		// 
		// _contextMenuGroupBox
		// 
		_contextMenuGroupBox = new GroupBox ();
#if NET_2_0
		_contextMenuGroupBox.Height = 82;
#else
		_contextMenuGroupBox.Height = 62;
#endif
		_contextMenuGroupBox.Location = new Point (0, 105);
		_contextMenuGroupBox.Text = "ContextMenu";
		_contextMenuGroupBox.Width = 200;
		Controls.Add (_contextMenuGroupBox);
		// 
		// _noneContextMenuRadioButton
		// 
		_noneContextMenuRadioButton = new RadioButton ();
		_noneContextMenuRadioButton.Location = new Point (8, 16);
		_noneContextMenuRadioButton.Text = "None";
		_contextMenuGroupBox.Controls.Add (_noneContextMenuRadioButton);
		// 
		// _treeViewContextMenuRadioButton
		// 
		_treeViewContextMenuRadioButton = new RadioButton ();
		_treeViewContextMenuRadioButton.Checked = true;
		_treeViewContextMenuRadioButton.Location = new Point (8, 36);
		_treeViewContextMenuRadioButton.Text = "TreeView";
		_treeViewContextMenuRadioButton.CheckedChanged += new EventHandler (TreeViewContextMenuRadioButton_CheckedChanged);
		_contextMenuGroupBox.Controls.Add (_treeViewContextMenuRadioButton);
#if NET_2_0
		// 
		// _treeViewContextMenuRadioButton
		// 
		_treeNodeContextMenuRadioButton = new RadioButton ();
		_treeNodeContextMenuRadioButton.Location = new Point (8, 56);
		_treeNodeContextMenuRadioButton.Text = "TreeNode";
		_treeNodeContextMenuRadioButton.CheckedChanged += new EventHandler (TreeNodeContextMenuRadioButton_CheckedChanged);
		_contextMenuGroupBox.Controls.Add (_treeNodeContextMenuRadioButton);
#endif
		// 
		// _resetButton
		// 
		_resetButton = new Button ();
		_resetButton.Location = new Point (220, 140);
		_resetButton.Size = new Size (60, 20);
		_resetButton.Text = "Reset";
		_resetButton.Click += new EventHandler (ResetButton_Click);
		Controls.Add (_resetButton);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 100;
		_eventsText.Multiline = true;
		_eventsText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
#if NET_2_0
		ClientSize = new Size (300, 290);
#else
		ClientSize = new Size (300, 270);
#endif
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82722";
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

	void TreeView_AfterSelect (object sender, TreeViewEventArgs e)
	{
		_eventsText.AppendText ("TreeView => AfterSelect" +
			Environment.NewLine);
	}

	void TreeView_BeforeSelect (object sender, TreeViewCancelEventArgs e)
	{
		_eventsText.AppendText ("TreeView => BeforeSelect" +
			Environment.NewLine);
	}

	void TreeViewContextMenuRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_treeViewContextMenuRadioButton.Checked) {
			_treeView.ContextMenu = _contextMenu;
		} else {
			_treeView.ContextMenu = null;
		}
	}

#if NET_2_0
	void TreeNodeContextMenuRadioButton_CheckedChanged (object sender, EventArgs e)
	{
		if (_treeNodeContextMenuRadioButton.Checked) {
			_treeView.Nodes [0].ContextMenu = _contextMenu;
		} else {
			_treeView.Nodes [0].ContextMenu = null;
		}
	}
#endif

	void ResetButton_Click (object sender, EventArgs e)
	{
		_eventsText.Text = string.Empty;
	}

	private ContextMenu _contextMenu;
	private TreeView _treeView;
	private GroupBox _contextMenuGroupBox;
	private RadioButton _noneContextMenuRadioButton;
	private RadioButton _treeViewContextMenuRadioButton;
#if NET_2_0
	private RadioButton _treeNodeContextMenuRadioButton;
#endif
	private Button _resetButton;
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
			"Steps to execute:{0}{0}" +
			"1. Check the TreeView radiobutton.{0}{0}" +
			"2. Click the Reset button.{0}{0}" +
			"3. Click the Personal Folders radiobutton.{0}{0}" +
			"4. Right-click the Inbox node.{0}{0}" +
			"5. Release the mouse button.{0}{0}" +
			"6. Click the Close menuitem in the contextmenu.{0}{0}" +
			"7. Click the Inbox radiobutton.{0}{0}" +
			"8. Right-click the Personal Folders node.{0}{0}" +
			"9. Release the mouse button.{0}{0}" +
			"10. Click the Close menuitem in the contextmenu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3:{0}{0}" +
			"   * The Personal Folders node is selected.{0}" +
			"   * The following events have fired:{0}{0}" +
			"       TreeView => BeforeSelect{0}" +
			"       TreeView => AfterSelect{0}{0}" +
			"2. On step 4 and 5, the Inbox node is highlighted.{0}{0}" +
			"3. On step 6:{0}{0}" +
			"   * The Personal Folders node is highlighted.{0}" +
			"   * No events have fired.{0}{0}" +
			"4. On step 7:{0}{0}" +
			"   * The Inbox node is selected.{0}" +
			"   * The following events have fired:{0}{0}" +
			"       TreeView => BeforeSelect{0}" +
			"       TreeView => AfterSelect{0}{0}" +
			"5. On step 8 and 9, the Personal Folders node is highlighted.{0}{0}" +
			"6. On step 10:{0}{0}" +
			"   * The Personal Folders node is highlighted.{0}" +
			"   * No events have fired.",
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
			"1. Check the None radiobutton.{0}{0}" +
			"2. Click the reset button.{0}{0}" +
			"3. Click the Personal Folders radiobutton.{0}{0}" +
			"4. Right-click the Inbox node.{0}{0}" +
			"5. Release the mouse button.{0}{0}" +
			"6. Click the Inbox radiobutton.{0}{0}" +
			"7. Right-click the Personal Folders node.{0}{0}" +
			"8. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3:{0}{0}" +
			"   * The Personal Folders node is selected.{0}" +
			"   * The following events have fired:{0}{0}" +
			"       TreeView => BeforeSelect{0}" +
			"       TreeView => AfterSelect{0}{0}" +
			"2. On step 4, the Inbox node is highlighted.{0}{0}" +
			"3. On step 5:{0}{0}" +
			"   * The Personal Folders node is highlighted.{0}" +
			"   * No events have fired.{0}{0}" +
			"4. On step 6:{0}{0}" +
			"   * The Inbox node is selected.{0}" +
			"   * The following events have fired:{0}{0}" +
			"       TreeView => BeforeSelect{0}" +
			"       TreeView => AfterSelect{0}{0}" +
			"5. On step 7, the Personal Folders node is highlighted.{0}{0}" +
			"6. On step 8:{0}{0}" + 
			"   * The Inbox node is highlighted.{0}" +
			"   * No events have fired.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
#if NET_2_0
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Check the TreeNode radiobutton.{0}{0}" +
			"2. Click the Reset button.{0}{0}" +
			"3. Click the Personal Folders radiobutton.{0}{0}" +
			"4. Right-click the Inbox node.{0}{0}" +
			"5. Release the mouse button.{0}{0}" +
			"6. Click the Inbox radiobutton.{0}{0}" +
			"7. Right-click the Personal Folders node.{0}{0}" +
			"8. Release the mouse button.{0}{0}" +
			"9. Click the Close menuitem in the contextmenu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, the Personal Folders node is selected.{0}{0}" +
			"2. On step 4, the Inbox node is highlighted.{0}{0}" +
			"2. On step 5:{0}{0}" +
			"   * The Personal Folders node is highlighted.{0}" +
			"   * No events have fired.{0}{0}" +
			"4. On step 6:{0}{0}" +
			"   * The Inbox node is selected.{0}" +
			"   * The following events have fired:{0}{0}" +
			"       TreeView => BeforeSelect{0}" +
			"       TreeView => AfterSelect{0}{0}" +
			"5. On step 7 and 8, the Personal Folders node is selected.{0}{0}" +
			"6. On step 9:{0}{0}" +
			"   * The Inbox node is selected.{0}" +
			"   * No events have fired.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
#endif
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (330, 745);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82722";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
#if NET_2_0
	private TextBox _bugDescriptionText3;
#endif
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
#if NET_2_0
	private TabPage _tabPage3;
#endif
}
