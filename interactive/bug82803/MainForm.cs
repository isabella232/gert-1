using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _menuStrip
		// 
		_menuStrip = new MenuStrip ();
		_menuStrip.TabIndex = 1;
		Controls.Add (_menuStrip);
		// 
		// _fileToolStripMenuItem
		// 
		_fileToolStripMenuItem = new ToolStripMenuItem ();
		_fileToolStripMenuItem.Text = "&File";
		_menuStrip.Items.Add (_fileToolStripMenuItem);
		// 
		// _newToolStripMenuItem
		// 
		_newToolStripMenuItem = new ToolStripMenuItem ();
		_newToolStripMenuItem.ShortcutKeys = ((Keys) ((Keys.Control | Keys.N)));
		_newToolStripMenuItem.Text = "&New";
		_newToolStripMenuItem.Click += new EventHandler (NewToolStripMenuItem_Click);
		_fileToolStripMenuItem.DropDownItems.Add (_newToolStripMenuItem);
		// 
		// _toolStripSeparator
		// 
		_toolStripSeparator = new ToolStripSeparator ();
		_fileToolStripMenuItem.DropDownItems.Add (_toolStripSeparator);
		// 
		// _exitToolStripMenuItem
		// 
		_exitToolStripMenuItem = new ToolStripMenuItem ();
		_exitToolStripMenuItem.Text = "E&xit";
		_exitToolStripMenuItem.Click += new EventHandler (ExitToolStripMenuItem_Click);
		_fileToolStripMenuItem.DropDownItems.Add (_exitToolStripMenuItem);
		// 
		// _windowToolStripMenuItem
		// 
		_windowToolStripMenuItem = new ToolStripMenuItem ();
		_windowToolStripMenuItem.Text = "&Window";
		_menuStrip.Items.Add (_windowToolStripMenuItem);
		_menuStrip.MdiWindowListItem = _windowToolStripMenuItem;
		// 
		// _arrangeIconsToolStripMenuItem
		// 
		_arrangeIconsToolStripMenuItem = new ToolStripMenuItem ();
		_arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
		_arrangeIconsToolStripMenuItem.Click += new EventHandler (ArrangeIconsToolStripMenuItem_Click);
		_windowToolStripMenuItem.DropDownItems.Add (_arrangeIconsToolStripMenuItem);
		// 
		// _cascadeToolStripMenuItem
		// 
		_cascadeToolStripMenuItem = new ToolStripMenuItem ();
		_cascadeToolStripMenuItem.Text = "&Cascade";
		_cascadeToolStripMenuItem.Click += new EventHandler (CascadeToolStripMenuItem_Click);
		_windowToolStripMenuItem.DropDownItems.Add (_cascadeToolStripMenuItem);
		// 
		// _tileVerticallyToolStripMenuItem
		// 
		_tileVerticallyToolStripMenuItem = new ToolStripMenuItem ();
		_tileVerticallyToolStripMenuItem.Text = "Tile &Vertically";
		_tileVerticallyToolStripMenuItem.Click += new EventHandler (TileVerticallyToolStripMenuItem_Click);
		_windowToolStripMenuItem.DropDownItems.Add (_tileVerticallyToolStripMenuItem);
		// 
		// _tileHorizontallyToolStripMenuItem
		// 
		_tileHorizontallyToolStripMenuItem = new ToolStripMenuItem ();
		_tileHorizontallyToolStripMenuItem.Text = "Tile &Horizontally";
		_tileHorizontallyToolStripMenuItem.Click += new EventHandler (TileHorizontallyToolStripMenuItem_Click);
		_windowToolStripMenuItem.DropDownItems.Add (_tileHorizontallyToolStripMenuItem);
		// 
		// _closeAllToolStripMenuItem
		// 
		_closeAllToolStripMenuItem = new ToolStripMenuItem ();
		_closeAllToolStripMenuItem.Text = "C&lose All";
		_closeAllToolStripMenuItem.Click += new EventHandler (CloseAllToolStripMenuItem_Click);
		_windowToolStripMenuItem.DropDownItems.Add (_closeAllToolStripMenuItem);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (300, 200);
		IsMdiContainer = true;
		Location = new Point (250, 100);
		MainMenuStrip = _menuStrip;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82803";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ExitToolStripMenuItem_Click (object sender, EventArgs e)
	{
		this.Close ();
	}

	void ArrangeIconsToolStripMenuItem_Click (object sender, EventArgs e)
	{
		this.LayoutMdi (MdiLayout.ArrangeIcons);
	}

	void CascadeToolStripMenuItem_Click (object sender, EventArgs e)
	{
		this.LayoutMdi (MdiLayout.Cascade);
	}

	void TileVerticallyToolStripMenuItem_Click (object sender, EventArgs e)
	{
		this.LayoutMdi (MdiLayout.TileVertical);
	}

	void TileHorizontallyToolStripMenuItem_Click (object sender, EventArgs e)
	{
		this.LayoutMdi (MdiLayout.TileHorizontal);
	}

	void NewToolStripMenuItem_Click (object sender, EventArgs e)
	{
		ChildForm child = new ChildForm ();
		child.MdiParent = this;
		child.Text = "Child " + (++formCount).ToString (CultureInfo.InvariantCulture);
		child.Show ();
	}

	void CloseAllToolStripMenuItem_Click (object sender, EventArgs e)
	{
		foreach (Form mdiChildForm in MdiChildren)
			mdiChildForm.Close ();
	}

	private int formCount;
	private MenuStrip _menuStrip;
	private ToolStripMenuItem _fileToolStripMenuItem;
	private ToolStripMenuItem _newToolStripMenuItem;
	private ToolStripMenuItem _windowToolStripMenuItem;
	private ToolStripMenuItem _arrangeIconsToolStripMenuItem;
	private ToolStripMenuItem _cascadeToolStripMenuItem;
	private ToolStripMenuItem _tileVerticallyToolStripMenuItem;
	private ToolStripMenuItem _tileHorizontallyToolStripMenuItem;
	private ToolStripMenuItem _exitToolStripMenuItem;
	private ToolStripSeparator _toolStripSeparator;
	private ToolStripMenuItem _closeAllToolStripMenuItem;
}

public class ChildForm : Form
{
	public ChildForm ()
	{
		// 
		// _menuStrip
		// 
		_menuStrip = new MenuStrip ();
		_menuStrip.Visible = false;
		Controls.Add (_menuStrip);
		// 
		// _fileToolStripMenuItem
		// 
		_fileToolStripMenuItem = new ToolStripMenuItem ();
		_fileToolStripMenuItem.MergeAction = MergeAction.MatchOnly;
		_fileToolStripMenuItem.Text = "&File";
		_menuStrip.Items.Add (_fileToolStripMenuItem);
		// 
		// _saveToolStripMenuItem
		// 
		_saveToolStripMenuItem = new ToolStripMenuItem ();
		_saveToolStripMenuItem.MergeAction = MergeAction.Insert;
		_saveToolStripMenuItem.MergeIndex = 1;
		_saveToolStripMenuItem.Text = "&Save";
		_fileToolStripMenuItem.DropDownItems.Add (_saveToolStripMenuItem);
		// 
		// _closeToolStripMenuItem
		// 
		_closeToolStripMenuItem = new ToolStripMenuItem ();
		_closeToolStripMenuItem.MergeAction = MergeAction.Insert;
		_closeToolStripMenuItem.MergeIndex = 2;
		_closeToolStripMenuItem.Text = "&Close";
		_closeToolStripMenuItem.Click += new EventHandler (CloseToolStripMenuItem_Click);
		_fileToolStripMenuItem.DropDownItems.Add (_closeToolStripMenuItem);
		// 
		// _editToolStripMenuItem
		// 
		_editToolStripMenuItem = new ToolStripMenuItem ();
		_editToolStripMenuItem.MergeAction = MergeAction.Insert;
		_editToolStripMenuItem.MergeIndex = 1;
		_editToolStripMenuItem.Text = "&Edit";
		_menuStrip.Items.Add (_editToolStripMenuItem);
		// 
		// MDIChildForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (209, 100);
		MainMenuStrip = _menuStrip;
		Text = "Child";
	}

	void CloseToolStripMenuItem_Click (object sender, EventArgs e)
	{
		Close ();
	}

	private MenuStrip _menuStrip;
	private ToolStripMenuItem _fileToolStripMenuItem;
	private ToolStripMenuItem _closeToolStripMenuItem;
	private ToolStripMenuItem _saveToolStripMenuItem;
	private ToolStripMenuItem _editToolStripMenuItem;
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
			"1. Press and hold the Alt key.{0}{0}" +
			"2. Press the F key.{0}{0}" +
			"3. Release Alt and F keys.{0}{0}" +
			"4. Press the N key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the mnemonic characters of the File " +
			"and Window menu are underlined.{0}{0}" +
			"2. On step 2, the File menu is dropped down.{0}{0}" +
			"3. On step 3, the File menu remains dropped down.{0}{0}" +
			"4. On step 4, a new child form is opened.",
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
		ClientSize = new Size (300, 315);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82803";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
