using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// menuStrip
		// 
		menuStrip = new MenuStrip ();
		menuStrip.Location = new Point (0, 0);
		menuStrip.Size = new Size (632, 24);
		menuStrip.TabIndex = 0;
		menuStrip.Text = "MenuStrip";
		Controls.Add (menuStrip);
		// 
		// fileMenu
		// 
		fileMenu = new ToolStripMenuItem ();
		fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
		fileMenu.Size = new Size (35, 20);
		fileMenu.MergeAction = MergeAction.Append;
		fileMenu.MergeIndex = 1;
		fileMenu.Text = "&File";
		fileMenu.DropDownOpened += new EventHandler (FileMenu_DropDownOpened);
		menuStrip.Items.Add (fileMenu);
		// 
		// openToolStripMenuItem
		// 
		openToolStripMenuItem = new ToolStripMenuItem ();
		openToolStripMenuItem.ShortcutKeys = ((Keys) ((Keys.Control | Keys.O)));
		openToolStripMenuItem.Size = new Size (151, 22);
		openToolStripMenuItem.Text = "&Open";
		openToolStripMenuItem.Click += new EventHandler (OpenFile);
		openToolStripMenuItem.MergeAction = MergeAction.Append;
		openToolStripMenuItem.MergeIndex = 2;
		fileMenu.DropDownItems.Add (openToolStripMenuItem);
		// 
		// toolStripSeparator4
		// 
		toolStripSeparator4 = new ToolStripSeparator ();
		toolStripSeparator4.Size = new Size (148, 6);
		toolStripSeparator4.MergeAction = MergeAction.Append;
		toolStripSeparator4.MergeIndex = 7;
		// 
		// exitToolStripMenuItem
		// 
		exitToolStripMenuItem = new ToolStripMenuItem ();
		exitToolStripMenuItem.Size = new Size (151, 22);
		exitToolStripMenuItem.Text = "E&xit";
		exitToolStripMenuItem.Click += new EventHandler (ExitToolsStripMenuItem_Click);
		exitToolStripMenuItem.MergeAction = MergeAction.Append;
		exitToolStripMenuItem.MergeIndex = 11;
		fileMenu.DropDownItems.Add (exitToolStripMenuItem);
		// 
		// windowsMenu
		// 
		windowsMenu = new ToolStripMenuItem ();
		windowsMenu.Size = new Size (62, 20);
		windowsMenu.Text = "&Windows";
		menuStrip.MdiWindowListItem = windowsMenu;
		menuStrip.Items.Add (windowsMenu);
		// 
		// cascadeToolStripMenuItem
		// 
		cascadeToolStripMenuItem = new ToolStripMenuItem ();
		cascadeToolStripMenuItem.Size = new Size (153, 22);
		cascadeToolStripMenuItem.Text = "&Cascade";
		cascadeToolStripMenuItem.Click += new EventHandler (CascadeToolStripMenuItem_Click);
		windowsMenu.DropDownItems.Add (cascadeToolStripMenuItem);
		// 
		// tileVerticalToolStripMenuItem
		// 
		tileVerticalToolStripMenuItem = new ToolStripMenuItem ();
		tileVerticalToolStripMenuItem.Size = new Size (153, 22);
		tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
		windowsMenu.DropDownItems.Add (tileVerticalToolStripMenuItem);
		// 
		// tileHorizontalToolStripMenuItem
		// 
		tileHorizontalToolStripMenuItem = new ToolStripMenuItem ();
		tileHorizontalToolStripMenuItem.Size = new Size (153, 22);
		tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
		tileHorizontalToolStripMenuItem.Click += new EventHandler (TileHorizontalToolStripMenuItem_Click);
		windowsMenu.DropDownItems.Add (tileHorizontalToolStripMenuItem);
		// 
		// closeAllToolStripMenuItem
		// 
		closeAllToolStripMenuItem = new ToolStripMenuItem ();
		closeAllToolStripMenuItem.Size = new Size (153, 22);
		closeAllToolStripMenuItem.Text = "C&lose All";
		closeAllToolStripMenuItem.Click += new EventHandler (CloseAllToolStripMenuItem_Click);
		windowsMenu.DropDownItems.Add (closeAllToolStripMenuItem);
		// 
		// arrangeIconsToolStripMenuItem
		// 
		arrangeIconsToolStripMenuItem = new ToolStripMenuItem ();
		arrangeIconsToolStripMenuItem.Size = new Size (153, 22);
		arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
		arrangeIconsToolStripMenuItem.Click += new EventHandler (ArrangeIconsToolStripMenuItem_Click);
		windowsMenu.DropDownItems.Add (arrangeIconsToolStripMenuItem);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (400, 300);
		IsMdiContainer = true;
		Location = new Point (200, 100);
		MainMenuStrip = menuStrip;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82377";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.SetCompatibleTextRenderingDefault (false);
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		if (SystemInformation.MenuAccessKeysUnderlined) {
			MessageBox.Show ("This test only yields the expected result when " +
				"the \"Hide underlined letters for keyboard navigation until " +
				"I press the Alt key\" setting is enabled.", "bug #82378");
			Close ();
		}

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void FileMenu_DropDownOpened (object sender, EventArgs e)
	{
	}

	void OpenFile (object sender, EventArgs e)
	{
		ChildForm child = new ChildForm ();
		child.MdiParent = this;
		child.Text = "Child " + childFormNumber++;
		child.Show ();
	}

	void ExitToolsStripMenuItem_Click (object sender, EventArgs e)
	{
		Application.Exit ();
	}

	void CascadeToolStripMenuItem_Click (object sender, EventArgs e)
	{
		LayoutMdi (MdiLayout.Cascade);
	}

	void TileHorizontalToolStripMenuItem_Click (object sender, EventArgs e)
	{
		LayoutMdi (MdiLayout.TileHorizontal);
	}

	void ArrangeIconsToolStripMenuItem_Click (object sender, EventArgs e)
	{
		LayoutMdi (MdiLayout.ArrangeIcons);
	}

	void CloseAllToolStripMenuItem_Click (object sender, EventArgs e)
	{
		foreach (Form childForm in MdiChildren)
			childForm.Close ();
	}

	private int childFormNumber;
	private MenuStrip menuStrip;
	private ToolStripSeparator toolStripSeparator4;
	private ToolStripMenuItem tileHorizontalToolStripMenuItem;
	private ToolStripMenuItem fileMenu;
	private ToolStripMenuItem openToolStripMenuItem;
	private ToolStripMenuItem exitToolStripMenuItem;
	private ToolStripMenuItem windowsMenu;
	private ToolStripMenuItem cascadeToolStripMenuItem;
	private ToolStripMenuItem tileVerticalToolStripMenuItem;
	private ToolStripMenuItem closeAllToolStripMenuItem;
	private ToolStripMenuItem arrangeIconsToolStripMenuItem;
}

class ChildForm : Form
{
	public ChildForm ()
	{
		// 
		// ChildForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (150, 150);
	}
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
			"1. Press the Alt+W key.{0}{0}" +
			"2. Close the Windows menu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The mnemonic characters of the toplevel and non-toplevel menu " +
			"items are no longer displayed.",
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
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82377";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
