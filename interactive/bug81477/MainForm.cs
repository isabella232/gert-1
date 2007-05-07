using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	private int childFormNumber = 0;

	public MainForm ()
	{
		components = new Container ();
		ComponentResourceManager resources = new ComponentResourceManager (typeof (MainForm));
		menuStrip = new MenuStrip ();
		fileMenu = new ToolStripMenuItem ();
		openToolStripMenuItem = new ToolStripMenuItem ();
		reopenToolStripMenuItem = new ToolStripMenuItem ();
		closeToolStripMenuItem = new ToolStripMenuItem ();
		snipperToolStripMenuItem = new ToolStripMenuItem ();
		toolStripSeparator4 = new ToolStripSeparator ();
		exitToolStripMenuItem = new ToolStripMenuItem ();
		copyToolStripMenuItem = new ToolStripMenuItem ();
		viewMenu = new ToolStripMenuItem ();
		editMenu = new ToolStripMenuItem ();
		toolBarToolStripMenuItem = new ToolStripMenuItem ();
		statusBarToolStripMenuItem = new ToolStripMenuItem ();
		sourceViewToolStripMenuItem = new ToolStripMenuItem ();
		timeZoneToolStripMenuItem = new ToolStripMenuItem ();
		timeZoneMyLocalToolStripMenuItem = new ToolStripMenuItem ();
		timeZoneLogLocalToolStripMenuItem = new ToolStripMenuItem ();
		timeZoneUniversalToolStripMenuItem = new ToolStripMenuItem ();
		timeZoneCycleToolStripMenuItem = new ToolStripMenuItem ();
		toolsMenu = new ToolStripMenuItem ();
		optionsToolStripMenuItem = new ToolStripMenuItem ();
		traceConfigToolStripMenuItem = new ToolStripMenuItem ();
		windowsMenu = new ToolStripMenuItem ();
		cascadeToolStripMenuItem = new ToolStripMenuItem ();
		tileVerticalToolStripMenuItem = new ToolStripMenuItem ();
		tileHorizontalToolStripMenuItem = new ToolStripMenuItem ();
		closeAllToolStripMenuItem = new ToolStripMenuItem ();
		arrangeIconsToolStripMenuItem = new ToolStripMenuItem ();
		helpMenu = new ToolStripMenuItem ();
		contentsToolStripMenuItem = new ToolStripMenuItem ();
		indexToolStripMenuItem = new ToolStripMenuItem ();
		searchToolStripMenuItem = new ToolStripMenuItem ();
		toolStripSeparator8 = new ToolStripSeparator ();
		aboutToolStripMenuItem = new ToolStripMenuItem ();
		toolStrip = new ToolStrip ();
		newToolStripButton = new ToolStripButton ();
		openToolStripButton = new ToolStripButton ();
		saveToolStripButton = new ToolStripButton ();
		toolStripSeparator1 = new ToolStripSeparator ();
		printToolStripButton = new ToolStripButton ();
		printPreviewToolStripButton = new ToolStripButton ();
		helpToolStripButton = new ToolStripButton ();
		statusStrip = new StatusStrip ();
		toolStripStatusLabel = new ToolStripStatusLabel ();
		menuStrip.SuspendLayout ();
		toolStrip.SuspendLayout ();
		statusStrip.SuspendLayout ();
		SuspendLayout ();
		// 
		// menuStrip
		// 
		menuStrip.Items.AddRange (new ToolStripItem [] {
			fileMenu,
			editMenu,
			viewMenu,
			toolsMenu,
			windowsMenu,
			helpMenu});
		menuStrip.Location = new Point (0, 0);
		menuStrip.MdiWindowListItem = windowsMenu;
		menuStrip.Size = new Size (632, 24);
		menuStrip.TabIndex = 0;
		menuStrip.Text = "MenuStrip";
		// 
		// fileMenu
		// 
		fileMenu.DropDownItems.AddRange (new ToolStripItem [] {
			openToolStripMenuItem,
			reopenToolStripMenuItem,
			closeToolStripMenuItem,
			snipperToolStripMenuItem,
			toolStripSeparator4,
			exitToolStripMenuItem});
		fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
		fileMenu.Size = new Size (35, 20);
		fileMenu.MergeAction = MergeAction.Append;
		fileMenu.MergeIndex = 1;
		fileMenu.Text = "&File";
		// 
		// openToolStripMenuItem
		// 
		openToolStripMenuItem.Image = ((Image) (resources.GetObject ("openToolStripMenuItem.Image")));
		openToolStripMenuItem.ImageTransparentColor = Color.Black;
		openToolStripMenuItem.ShortcutKeys = ((Keys) ((Keys.Control | Keys.O)));
		openToolStripMenuItem.Size = new Size (151, 22);
		openToolStripMenuItem.Text = "&Open";
		openToolStripMenuItem.Click += new System.EventHandler (OpenFile);
		openToolStripMenuItem.MergeAction = MergeAction.Append;
		openToolStripMenuItem.MergeIndex = 2;
		// 
		// reopenToolStripMenuItem
		// 
		reopenToolStripMenuItem.Image = ((Image) (resources.GetObject ("openToolStripMenuItem.Image")));
		reopenToolStripMenuItem.ImageTransparentColor = Color.Black;
		reopenToolStripMenuItem.Size = new Size (151, 22);
		reopenToolStripMenuItem.Text = "&Reopen";
		reopenToolStripMenuItem.MergeAction = MergeAction.Append;
		reopenToolStripMenuItem.MergeIndex = 3;
		// 
		// closeToolStripMenuItem
		// 
		//is.closeToolStripMenuItem.Image = ((Image)(resources.GetObject("saveToolStripMenuItem.Image")));
		closeToolStripMenuItem.ImageTransparentColor = Color.Black;
		//is.closeToolStripMenuItem.ShortcutKeys = ((Keys)((Keys.Control | Keys.S)));
		closeToolStripMenuItem.Size = new Size (151, 22);
		closeToolStripMenuItem.Text = "&Close";
		closeToolStripMenuItem.MergeAction = MergeAction.Append;
		closeToolStripMenuItem.MergeIndex = 5;
		// 
		// snipperToolStripMenuItem
		// 
		snipperToolStripMenuItem.Size = new Size (151, 22);
		snipperToolStripMenuItem.Text = "Snip/Merge Log File(s)...";
		snipperToolStripMenuItem.MergeAction = MergeAction.Append;
		snipperToolStripMenuItem.MergeIndex = 6;
		// 
		// toolStripSeparator4
		// 
		toolStripSeparator4.Size = new Size (148, 6);
		toolStripSeparator4.MergeAction = MergeAction.Append;
		toolStripSeparator4.MergeIndex = 7;
		// 
		// exitToolStripMenuItem
		// 
		exitToolStripMenuItem.Size = new Size (151, 22);
		exitToolStripMenuItem.Text = "E&xit";
		exitToolStripMenuItem.Click += new System.EventHandler (ExitToolsStripMenuItem_Click);
		exitToolStripMenuItem.MergeAction = MergeAction.Append;
		exitToolStripMenuItem.MergeIndex = 11;
		// 
		// editMenu
		// 
		editMenu.DropDownItems.Add (copyToolStripMenuItem);
		editMenu.Size = new Size (41, 20);
		editMenu.Text = "&Edit";
		editMenu.MergeAction = MergeAction.Append;
		// 
		// copyToolStripMenuItem
		// 
		copyToolStripMenuItem.MergeAction = MergeAction.Append;
		copyToolStripMenuItem.MergeIndex = 1;
		copyToolStripMenuItem.Size = new Size (190, 22);
		copyToolStripMenuItem.Text = "Copy";
		copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
		copyToolStripMenuItem.ShowShortcutKeys = true;
		copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
		// 
		// viewMenu
		// 
		viewMenu.DropDownItems.AddRange (new ToolStripItem [] {
			toolBarToolStripMenuItem,
			statusBarToolStripMenuItem,
			sourceViewToolStripMenuItem,
			timeZoneToolStripMenuItem});
		viewMenu.Size = new Size (41, 20);
		viewMenu.Text = "&View";
		viewMenu.MergeAction = MergeAction.Append;
		// 
		// toolBarToolStripMenuItem
		// 
		toolBarToolStripMenuItem.Checked = true;
		toolBarToolStripMenuItem.CheckOnClick = true;
		toolBarToolStripMenuItem.CheckState = CheckState.Checked;
		toolBarToolStripMenuItem.Size = new Size (135, 22);
		toolBarToolStripMenuItem.Text = "&Toolbar";
		toolBarToolStripMenuItem.Click += new System.EventHandler (ToolBarToolStripMenuItem_Click);
		toolBarToolStripMenuItem.MergeAction = MergeAction.Append;
		toolBarToolStripMenuItem.MergeIndex = 68;
		// 
		// statusBarToolStripMenuItem
		// 
		statusBarToolStripMenuItem.Checked = true;
		statusBarToolStripMenuItem.CheckOnClick = true;
		statusBarToolStripMenuItem.CheckState = CheckState.Checked;
		statusBarToolStripMenuItem.Size = new Size (135, 22);
		statusBarToolStripMenuItem.Text = "&Status Bar";
		statusBarToolStripMenuItem.Click += new System.EventHandler (StatusBarToolStripMenuItem_Click);
		statusBarToolStripMenuItem.MergeAction = MergeAction.Append;
		statusBarToolStripMenuItem.MergeIndex = 99;
		// 
		// sourceViewToolStripMenuItem
		// 
		sourceViewToolStripMenuItem.Checked = true;
		sourceViewToolStripMenuItem.CheckOnClick = true;
		sourceViewToolStripMenuItem.CheckState = CheckState.Checked;
		sourceViewToolStripMenuItem.Size = new Size (135, 22);
		sourceViewToolStripMenuItem.Text = "Source &View";
		sourceViewToolStripMenuItem.MergeAction = MergeAction.Append;
		sourceViewToolStripMenuItem.MergeIndex = 100;
		//
		// timeZoneToolStripMenuItem
		//
		timeZoneToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
			timeZoneMyLocalToolStripMenuItem,
			timeZoneLogLocalToolStripMenuItem,
			timeZoneUniversalToolStripMenuItem,
			timeZoneCycleToolStripMenuItem});
		timeZoneToolStripMenuItem.Size = new Size (41, 20);
		timeZoneToolStripMenuItem.Text = "Time Zone Setting";
		timeZoneToolStripMenuItem.MergeAction = MergeAction.Append;
		timeZoneToolStripMenuItem.MergeIndex = 10;
		//
		// timeZoneMyLocalToolStripMenuItem
		//
		timeZoneMyLocalToolStripMenuItem.Size = new Size (135, 22);
		timeZoneMyLocalToolStripMenuItem.Text = "My &Local Time Zone";
		timeZoneMyLocalToolStripMenuItem.MergeAction = MergeAction.Append;
		timeZoneMyLocalToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+T";
		timeZoneMyLocalToolStripMenuItem.ShowShortcutKeys = true;
		timeZoneMyLocalToolStripMenuItem.ShortcutKeys = Keys.None;
		//
		// timeZoneLogLocalToolStripMenuItem
		//
		timeZoneLogLocalToolStripMenuItem.Size = new Size (135, 22);
		timeZoneLogLocalToolStripMenuItem.Text = "Log &Creator's Time Zone";
		timeZoneLogLocalToolStripMenuItem.MergeAction = MergeAction.Append;
		timeZoneLogLocalToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+T";
		timeZoneLogLocalToolStripMenuItem.ShowShortcutKeys = true;
		timeZoneLogLocalToolStripMenuItem.ShortcutKeys = Keys.None;
		//
		// timeZoneUniversalToolStripMenuItem
		//
		timeZoneUniversalToolStripMenuItem.Size = new Size (135, 22);
		timeZoneUniversalToolStripMenuItem.Text = "&Universal Coordinated Time";
		timeZoneUniversalToolStripMenuItem.MergeAction = MergeAction.Append;
		timeZoneUniversalToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+T";
		timeZoneUniversalToolStripMenuItem.ShowShortcutKeys = true;
		timeZoneUniversalToolStripMenuItem.ShortcutKeys = Keys.None;
		//
		// timeZoneCycleToolStripMenuItem 
		//
		timeZoneCycleToolStripMenuItem.Size = new Size (135, 22);
		timeZoneCycleToolStripMenuItem.Text = "Cycle Time Zones";
		timeZoneCycleToolStripMenuItem.MergeAction = MergeAction.Append;
		timeZoneCycleToolStripMenuItem.Visible = false;
		timeZoneCycleToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+T";
		timeZoneCycleToolStripMenuItem.ShowShortcutKeys = true;
		timeZoneCycleToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.T;
		// 
		// toolsMenu
		// 
		toolsMenu.DropDownItems.AddRange (new ToolStripItem [] {
			optionsToolStripMenuItem,
			traceConfigToolStripMenuItem});
		toolsMenu.Size = new Size (44, 20);
		toolsMenu.Text = "&Tools";
		// 
		// optionsToolStripMenuItem
		// 
		optionsToolStripMenuItem.Size = new Size (122, 22);
		optionsToolStripMenuItem.Text = "&Options...";
		// 
		// traceConfigToolStripMenuItem
		// 
		traceConfigToolStripMenuItem.Size = new Size (122, 22);
		traceConfigToolStripMenuItem.Text = "Launch Trace&Config";
		// 
		// windowsMenu
		// 
		windowsMenu.DropDownItems.AddRange (new ToolStripItem [] {
			cascadeToolStripMenuItem,
			tileVerticalToolStripMenuItem,
			tileHorizontalToolStripMenuItem,
			closeAllToolStripMenuItem,
			arrangeIconsToolStripMenuItem});
		windowsMenu.Size = new Size (62, 20);
		windowsMenu.Text = "&Windows";
		// 
		// cascadeToolStripMenuItem
		// 
		cascadeToolStripMenuItem.Size = new Size (153, 22);
		cascadeToolStripMenuItem.Text = "&Cascade";
		cascadeToolStripMenuItem.Click += new System.EventHandler (CascadeToolStripMenuItem_Click);
		// 
		// tileVerticalToolStripMenuItem
		// 
		tileVerticalToolStripMenuItem.Size = new Size (153, 22);
		tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
		// 
		// tileHorizontalToolStripMenuItem
		// 
		tileHorizontalToolStripMenuItem.Size = new Size (153, 22);
		tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
		tileHorizontalToolStripMenuItem.Click += new System.EventHandler (TileHorizontalToolStripMenuItem_Click);
		// 
		// closeAllToolStripMenuItem
		// 
		closeAllToolStripMenuItem.Size = new Size (153, 22);
		closeAllToolStripMenuItem.Text = "C&lose All";
		closeAllToolStripMenuItem.Click += new System.EventHandler (CloseAllToolStripMenuItem_Click);
		// 
		// arrangeIconsToolStripMenuItem
		// 
		arrangeIconsToolStripMenuItem.Size = new Size (153, 22);
		arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
		arrangeIconsToolStripMenuItem.Click += new System.EventHandler (ArrangeIconsToolStripMenuItem_Click);
		// 
		// helpMenu
		// 
		helpMenu.DropDownItems.AddRange (new ToolStripItem [] {
			contentsToolStripMenuItem,
			indexToolStripMenuItem,
			searchToolStripMenuItem,
			toolStripSeparator8,
			aboutToolStripMenuItem});
		helpMenu.Size = new Size (40, 20);
		helpMenu.Text = "&Help";
		// 
		// contentsToolStripMenuItem
		// 
		contentsToolStripMenuItem.ShortcutKeys = ((Keys) ((Keys.Control | Keys.F1)));
		contentsToolStripMenuItem.Size = new Size (173, 22);
		contentsToolStripMenuItem.Text = "&Contents";
		// 
		// indexToolStripMenuItem
		// 
		indexToolStripMenuItem.Image = ((Image) (resources.GetObject ("indexToolStripMenuItem.Image")));
		indexToolStripMenuItem.ImageTransparentColor = Color.Black;
		indexToolStripMenuItem.Size = new Size (173, 22);
		indexToolStripMenuItem.Text = "&Index";
		// 
		// searchToolStripMenuItem
		// 
		searchToolStripMenuItem.Image = ((Image) (resources.GetObject ("searchToolStripMenuItem.Image")));
		searchToolStripMenuItem.ImageTransparentColor = Color.Black;
		searchToolStripMenuItem.Size = new Size (173, 22);
		searchToolStripMenuItem.Text = "&Search";
		// 
		// toolStripSeparator8
		// 
		toolStripSeparator8.Size = new Size (170, 6);
		// 
		// aboutToolStripMenuItem
		// 
		aboutToolStripMenuItem.Size = new Size (173, 22);
		aboutToolStripMenuItem.Text = "&About ...";
		// 
		// toolStrip
		// 
		toolStrip.Items.AddRange (new ToolStripItem [] {
			newToolStripButton,
			openToolStripButton,
			saveToolStripButton,
			toolStripSeparator1,
			printToolStripButton,
			printPreviewToolStripButton,
			helpToolStripButton});
		toolStrip.Location = new Point (0, 24);
		toolStrip.Size = new Size (632, 25);
		toolStrip.TabIndex = 1;
		toolStrip.Text = "ToolStrip";
		// 
		// newToolStripButton
		// 
		newToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		newToolStripButton.Image = ((Image) (resources.GetObject ("newToolStripButton.Image")));
		newToolStripButton.ImageTransparentColor = Color.Black;
		newToolStripButton.Text = "New";
		newToolStripButton.Click += new System.EventHandler (ShowNewForm);
		// 
		// openToolStripButton
		// 
		openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		openToolStripButton.Image = ((Image) (resources.GetObject ("openToolStripButton.Image")));
		openToolStripButton.ImageTransparentColor = Color.Black;
		openToolStripButton.Text = "Open";
		openToolStripButton.Click += new System.EventHandler (OpenFile);
		// 
		// saveToolStripButton
		// 
		saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		saveToolStripButton.Image = ((Image) (resources.GetObject ("saveToolStripButton.Image")));
		saveToolStripButton.ImageTransparentColor = Color.Black;
		saveToolStripButton.Text = "Save";
		// 
		// toolStripSeparator1
		// 

		// 
		// printToolStripButton
		// 
		printToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		printToolStripButton.Image = ((Image) (resources.GetObject ("printToolStripButton.Image")));
		printToolStripButton.ImageTransparentColor = Color.Black;
		printToolStripButton.Text = "Print";
		// 
		// printPreviewToolStripButton
		// 
		printPreviewToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		printPreviewToolStripButton.Image = ((Image) (resources.GetObject ("printPreviewToolStripButton.Image")));
		printPreviewToolStripButton.ImageTransparentColor = Color.Black;
		printPreviewToolStripButton.Text = "Print Preview";
		// 
		// helpToolStripButton
		// 
		helpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
		helpToolStripButton.Image = ((Image) (resources.GetObject ("helpToolStripButton.Image")));
		helpToolStripButton.ImageTransparentColor = Color.Black;
		helpToolStripButton.Text = "Help";
		// 
		// statusStrip
		// 
		statusStrip.Items.Add (toolStripStatusLabel);
		statusStrip.LayoutStyle = ToolStripLayoutStyle.Table;
		statusStrip.Location = new Point (0, 433);
		statusStrip.Size = new Size (632, 20);
		statusStrip.TabIndex = 2;
		statusStrip.Text = "StatusStrip";
		// 
		// toolStripStatusLabel
		// 
		toolStripStatusLabel.Text = "Status";
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (400, 300);
		Controls.Add (statusStrip);
		Controls.Add (toolStrip);
		Controls.Add (menuStrip);
		IsMdiContainer = true;
		Location = new Point (200, 100);
		MainMenuStrip = menuStrip;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81477";
		menuStrip.ResumeLayout (false);
		toolStrip.ResumeLayout (false);
		statusStrip.ResumeLayout (false);
		ResumeLayout (false);
		PerformLayout ();
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.SetCompatibleTextRenderingDefault (false);
		Application.Run (new MainForm ());
	}

	protected override void Dispose (bool disposing)
	{
		if (disposing && (components != null)) {
			components.Dispose ();
		}
		base.Dispose (disposing);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ShowNewForm (object sender, EventArgs e)
	{
		ChildForm child = new ChildForm ();
		child.MdiParent = this;
		child.Text = "Window " + childFormNumber++;
		child.Show ();
	}

	void OpenFile (object sender, EventArgs e)
	{
		ChildForm child = new ChildForm ();
		child.MdiParent = this;
		child.Text = "Child";
		child.Show ();
	}

	void ExitToolsStripMenuItem_Click (object sender, EventArgs e)
	{
		Application.Exit ();
	}

	void ToolBarToolStripMenuItem_Click (object sender, EventArgs e)
	{
		toolStrip.Visible = toolBarToolStripMenuItem.Checked;
	}

	void StatusBarToolStripMenuItem_Click (object sender, EventArgs e)
	{
		statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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

	private IContainer components;
	private MenuStrip menuStrip;
	private ToolStrip toolStrip;
	private StatusStrip statusStrip;
	private ToolStripStatusLabel toolStripStatusLabel;

	private ToolStripSeparator toolStripSeparator1;
	private ToolStripSeparator toolStripSeparator4;
	private ToolStripSeparator toolStripSeparator8;
	private ToolStripMenuItem aboutToolStripMenuItem;
	private ToolStripMenuItem tileHorizontalToolStripMenuItem;
	private ToolStripMenuItem fileMenu;
	private ToolStripMenuItem openToolStripMenuItem;
	private ToolStripMenuItem reopenToolStripMenuItem;
	private ToolStripMenuItem closeToolStripMenuItem;
	private ToolStripMenuItem exitToolStripMenuItem;
	private ToolStripMenuItem snipperToolStripMenuItem;
	private ToolStripMenuItem editMenu;
	private ToolStripMenuItem copyToolStripMenuItem;
	private ToolStripMenuItem viewMenu;
	private ToolStripMenuItem toolBarToolStripMenuItem;
	private ToolStripMenuItem statusBarToolStripMenuItem;
	private ToolStripMenuItem sourceViewToolStripMenuItem;
	private ToolStripMenuItem timeZoneToolStripMenuItem;
	private ToolStripMenuItem timeZoneMyLocalToolStripMenuItem;
	private ToolStripMenuItem timeZoneLogLocalToolStripMenuItem;
	private ToolStripMenuItem timeZoneUniversalToolStripMenuItem;
	private ToolStripMenuItem timeZoneCycleToolStripMenuItem;
	private ToolStripMenuItem toolsMenu;
	private ToolStripMenuItem optionsToolStripMenuItem;
	private ToolStripMenuItem traceConfigToolStripMenuItem;
	private ToolStripMenuItem windowsMenu;
	private ToolStripMenuItem cascadeToolStripMenuItem;
	private ToolStripMenuItem tileVerticalToolStripMenuItem;
	private ToolStripMenuItem closeAllToolStripMenuItem;
	private ToolStripMenuItem arrangeIconsToolStripMenuItem;
	private ToolStripMenuItem helpMenu;
	private ToolStripMenuItem contentsToolStripMenuItem;
	private ToolStripMenuItem indexToolStripMenuItem;
	private ToolStripMenuItem searchToolStripMenuItem;

	private ToolStripButton newToolStripButton;
	private ToolStripButton openToolStripButton;
	private ToolStripButton saveToolStripButton;
	private ToolStripButton printToolStripButton;
	private ToolStripButton printPreviewToolStripButton;
	private ToolStripButton helpToolStripButton;
}

class ChildForm : Form
{
	public ChildForm ()
	{
		_menuStrip = new MenuStrip ();
		fileToolStripMenuItem = new ToolStripMenuItem ();
		fileNewWindowToolStripMenuItem = new ToolStripMenuItem ();
		fileOpenLatestToolStripMenuItem = new ToolStripMenuItem ();
		fileDeleteLogToolStripMenuItem = new ToolStripMenuItem ();
		editToolStripMenuItem = new ToolStripMenuItem ();
		copyAsToolStripMenuItem = new ToolStripMenuItem ();
		copyAsSimpleTextToolStripMenuItem = new ToolStripMenuItem ();
		copyAsRichTextToolStripMenuItem = new ToolStripMenuItem ();
		copyAsHtmlToolStripMenuItem = new ToolStripMenuItem ();
		copyAsCsvToolStripMenuItem = new ToolStripMenuItem ();
		viewToolStripMenuItem = new ToolStripMenuItem ();
		timeJitterToolStripMenuItem = new ToolStripMenuItem ();
		logHeaderToolStripMenuItem = new ToolStripMenuItem ();
		showFunctionNamesToolStripMenuItem = new ToolStripMenuItem ();
		showContextInDetailToolStripMenuItem = new ToolStripMenuItem ();
		manageColumnsToolStripMenuItem = new ToolStripMenuItem ();
		refreshLogToolStripMenuItem = new ToolStripMenuItem ();
		autoRefreshLogToolStripMenuItem = new ToolStripMenuItem ();
		showBookmarksToolStripMenuItem = new ToolStripMenuItem ();
		colorColumnToolStripMenuItem = new ToolStripMenuItem ();
		timeSynchroNowToolStripMenuItem = new ToolStripMenuItem ();
		decryptMessageToolStripMenuItem = new ToolStripMenuItem ();
		filterToolStripMenuItem = new ToolStripMenuItem ();
		filterUndoToolStripMenuItem = new ToolStripMenuItem ();
		filterRedoToolStripMenuItem = new ToolStripMenuItem ();
		filterSeparator90 = new ToolStripSeparator ();
		filterQuickStringToolStripMenuItem = new ToolStripMenuItem ();
		filterAddToCurrentToolStripMenuItem = new ToolStripMenuItem ();
		filterSetTraceLevelToolStripMenuItem = new ToolStripMenuItem ();
		filterSetTraceLevelAllToolStripMenuItem = new ToolStripMenuItem ();
		filterSetTraceLevelVerboseToolStripMenuItem = new ToolStripMenuItem ();
		filterSetTraceLevelNotesToolStripMenuItem = new ToolStripMenuItem ();
		filterSetTraceLevelStatusToolStripMenuItem = new ToolStripMenuItem ();
		filterSetTraceLevelWarningToolStripMenuItem = new ToolStripMenuItem ();
		filterSetTraceLevelErrorToolStripMenuItem = new ToolStripMenuItem ();
		filterSetTraceLevelCriticalToolStripMenuItem = new ToolStripMenuItem ();
		filterConfigToolStripMenuItem = new ToolStripMenuItem ();
		filterClearAllToolStripMenuItem = new ToolStripMenuItem ();
		filterSavedFiltersToolStripMenuItem = new ToolStripMenuItem ();
		filterSaveCurrentFilterToolStripMenuItem = new ToolStripMenuItem ();
		filterImportFiltersToolStripMenuItem = new ToolStripMenuItem ();
		searchToolStripMenuItem = new ToolStripMenuItem ();
		searchForwardToolStripMenuItem = new ToolStripMenuItem ();
		searchBackwardToolStripMenuItem = new ToolStripMenuItem ();
		searchForwardOnNamedFilterToolStripMenuItem = new ToolStripMenuItem ();
		searchBackwardOnNamedFilterToolStripMenuItem = new ToolStripMenuItem ();
		searchForwardOnMsgTypeFilterToolStripMenuItem = new ToolStripMenuItem ();
		searchBackwardOnMsgTypeFilterToolStripMenuItem = new ToolStripMenuItem ();
		toolStripSeparator80 = new ToolStripSeparator ();
		searchForwardAgainToolStripMenuItem = new ToolStripMenuItem ();
		searchBackwardAgainToolStripMenuItem = new ToolStripMenuItem ();
		toolStripSeparator81 = new ToolStripSeparator ();
		searchMatchingScopeToolStripMenuItem = new ToolStripMenuItem ();
		searchTimestampJumpToolStripMenuItem = new ToolStripMenuItem ();
		searchNextSameThreadToolStripMenuItem = new ToolStripMenuItem ();
		searchPrevSameThreadToolStripMenuItem = new ToolStripMenuItem ();
		searchStepOutForwardCallLevelToolStripMenuItem = new ToolStripMenuItem ();
		searchStepOutBackwardCallLevelToolStripMenuItem = new ToolStripMenuItem ();
		searchStepOverForwardCallLevelToolStripMenuItem = new ToolStripMenuItem ();
		searchStepOverBackwardCallLevelToolStripMenuItem = new ToolStripMenuItem ();
		searchStepIntoForwardCallLevelToolStripMenuItem = new ToolStripMenuItem ();
		searchStepIntoBackwardCallLevelToolStripMenuItem = new ToolStripMenuItem ();
		toolStripSeparator82 = new ToolStripSeparator ();
		searchToggleBookmarkToolStripMenuItem = new ToolStripMenuItem ();
		searchNextBookmarkToolStripMenuItem = new ToolStripMenuItem ();
		searchPrevBookmarkToolStripMenuItem = new ToolStripMenuItem ();
		toolsMenu = new ToolStripMenuItem ();
		toolsAnaylzeContextAttribs = new ToolStripMenuItem ();
		_menuStrip.SuspendLayout ();
		SuspendLayout ();
		// 
		// _menuStrip
		// 
		_menuStrip.Items.AddRange (new ToolStripItem [] {
			fileToolStripMenuItem,
			editToolStripMenuItem,
			viewToolStripMenuItem,
			toolsMenu,
			filterToolStripMenuItem,
			searchToolStripMenuItem });
		_menuStrip.Location = new Point (0, 0);
		_menuStrip.Size = new Size (706, 24);
		_menuStrip.TabIndex = 2;
		_menuStrip.Text = "_menuStrip";
		_menuStrip.Visible = false;
		Controls.Add (_menuStrip);
		// 
		// fileToolStripMenuItem
		// 
		fileToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
			fileNewWindowToolStripMenuItem,
			fileOpenLatestToolStripMenuItem,
			fileDeleteLogToolStripMenuItem});
		fileToolStripMenuItem.MergeAction = MergeAction.MatchOnly;
		fileToolStripMenuItem.MergeIndex = -1;
		fileToolStripMenuItem.Size = new Size (41, 20);
		fileToolStripMenuItem.Text = "&File";
		// 
		// fileNewWindowToolStripMenuItem
		// 
		fileNewWindowToolStripMenuItem.MergeAction = MergeAction.Insert;
		fileNewWindowToolStripMenuItem.MergeIndex = 0;
		fileNewWindowToolStripMenuItem.Size = new Size (190, 22);
		fileNewWindowToolStripMenuItem.Text = "Clone Log &Window";
		fileNewWindowToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
		fileNewWindowToolStripMenuItem.ShowShortcutKeys = true;
		fileNewWindowToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
		// 
		// fileOpenLatestToolStripMenuItem
		// 
		fileOpenLatestToolStripMenuItem.MergeAction = MergeAction.Insert;
		fileOpenLatestToolStripMenuItem.MergeIndex = 1;
		fileOpenLatestToolStripMenuItem.Size = new Size (190, 22);
		fileOpenLatestToolStripMenuItem.Text = "Open Latest in &Series";
		fileOpenLatestToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+N";
		fileOpenLatestToolStripMenuItem.ShowShortcutKeys = true;
		fileOpenLatestToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
		// 
		// fileDeleteLogToolStripMenuItem
		// 
		fileDeleteLogToolStripMenuItem.MergeAction = MergeAction.Insert;
		fileDeleteLogToolStripMenuItem.MergeIndex = 4;
		fileDeleteLogToolStripMenuItem.Size = new Size (190, 22);
		fileDeleteLogToolStripMenuItem.Text = "&Delete Log";
		fileDeleteLogToolStripMenuItem.ShowShortcutKeys = false;
		// 
		// editToolStripMenuItem
		// 
		editToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
			copyAsToolStripMenuItem});
		editToolStripMenuItem.MergeAction = MergeAction.MatchOnly;
		editToolStripMenuItem.MergeIndex = -1;
		editToolStripMenuItem.Size = new Size (41, 20);
		editToolStripMenuItem.Text = "&Edit";
		// 
		// copyAsToolStripMenuItem
		// 
		copyAsToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
			copyAsSimpleTextToolStripMenuItem,
			copyAsRichTextToolStripMenuItem,
			copyAsHtmlToolStripMenuItem,
			copyAsCsvToolStripMenuItem});
		copyAsToolStripMenuItem.MergeAction = MergeAction.Insert;
		copyAsToolStripMenuItem.MergeIndex = 2;
		copyAsToolStripMenuItem.Size = new Size (190, 22);
		copyAsToolStripMenuItem.Text = "Copy &As";
		copyAsToolStripMenuItem.ShowShortcutKeys = false;
		// 
		// copyAsSimpleTextToolStripMenuItem
		// 
		copyAsSimpleTextToolStripMenuItem.Size = new Size (190, 22);
		copyAsSimpleTextToolStripMenuItem.Text = "&Simple Text";
		// 
		// copyAsRichTextToolStripMenuItem
		// 
		copyAsRichTextToolStripMenuItem.Size = new Size (190, 22);
		copyAsRichTextToolStripMenuItem.Text = "&Rich Text";
		// 
		// copyAsHtmlToolStripMenuItem
		// 
		copyAsHtmlToolStripMenuItem.Size = new Size (190, 22);
		copyAsHtmlToolStripMenuItem.Text = "&HTML Table";
		// 
		// copyAsCsvToolStripMenuItem
		// 
		copyAsCsvToolStripMenuItem.Size = new Size (190, 22);
		copyAsCsvToolStripMenuItem.Text = "&CSV Text";
		// 
		// viewToolStripMenuItem
		// 
		viewToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
			timeJitterToolStripMenuItem,
			logHeaderToolStripMenuItem,
			showFunctionNamesToolStripMenuItem,
			showContextInDetailToolStripMenuItem,
			manageColumnsToolStripMenuItem,
			showBookmarksToolStripMenuItem,
			autoRefreshLogToolStripMenuItem,
			refreshLogToolStripMenuItem,
			colorColumnToolStripMenuItem,
			timeSynchroNowToolStripMenuItem,
			decryptMessageToolStripMenuItem});
		viewToolStripMenuItem.MergeAction = MergeAction.MatchOnly;
		viewToolStripMenuItem.MergeIndex = -1;
		viewToolStripMenuItem.Size = new Size (41, 20);
		viewToolStripMenuItem.Text = "&View";
		// 
		// timeJitterToolStripMenuItem
		// 
		timeJitterToolStripMenuItem.MergeAction = MergeAction.Append;
		timeJitterToolStripMenuItem.MergeIndex = 3;
		timeJitterToolStripMenuItem.Size = new Size (190, 22);
		timeJitterToolStripMenuItem.Text = "Set Manual Time Offset...";
		// 
		// logHeaderToolStripMenuItem
		// 
		logHeaderToolStripMenuItem.MergeAction = MergeAction.Append;
		logHeaderToolStripMenuItem.MergeIndex = 3;
		logHeaderToolStripMenuItem.Size = new Size (190, 22);
		logHeaderToolStripMenuItem.Text = "Log &Header...";
		// 
		// showFunctionNamesToolStripMenuItem
		// 
		showFunctionNamesToolStripMenuItem.Checked = true;
		showFunctionNamesToolStripMenuItem.CheckState = CheckState.Checked;
		showFunctionNamesToolStripMenuItem.MergeAction = MergeAction.Append;
		showFunctionNamesToolStripMenuItem.MergeIndex = 4;
		showFunctionNamesToolStripMenuItem.Size = new Size (190, 22);
		showFunctionNamesToolStripMenuItem.Text = "Show &Function Names";
		//
		// showContextInDetailToolStripMenuItem
		//
		showContextInDetailToolStripMenuItem.CheckOnClick = true;
		showContextInDetailToolStripMenuItem.Checked = true;
		showContextInDetailToolStripMenuItem.MergeAction = MergeAction.Append;
		showContextInDetailToolStripMenuItem.MergeIndex = 5;
		showContextInDetailToolStripMenuItem.Size = new Size (190, 22);
		showContextInDetailToolStripMenuItem.Text = "Show Context Attributes in Message &Detail";
		// 
		// manageColumnsToolStripMenuItem
		// 
		manageColumnsToolStripMenuItem.MergeAction = MergeAction.Append;
		manageColumnsToolStripMenuItem.MergeIndex = 6;
		manageColumnsToolStripMenuItem.Size = new Size (190, 22);
		manageColumnsToolStripMenuItem.Text = "Manage &Columns...";
		// 
		// refreshLogToolStripMenuItem
		// 
		refreshLogToolStripMenuItem.MergeAction = MergeAction.Append;
		refreshLogToolStripMenuItem.MergeIndex = 9;
		refreshLogToolStripMenuItem.Size = new Size (190, 22);
		refreshLogToolStripMenuItem.Text = "&Refresh Log!";
		refreshLogToolStripMenuItem.ShortcutKeys = Keys.F5;
		refreshLogToolStripMenuItem.ShowShortcutKeys = true;
		refreshLogToolStripMenuItem.ShortcutKeyDisplayString = "F5";
		// 
		// autoRefreshLogToolStripMenuItem
		// 
		autoRefreshLogToolStripMenuItem.MergeAction = MergeAction.Append;
		autoRefreshLogToolStripMenuItem.MergeIndex = 8;
		autoRefreshLogToolStripMenuItem.Size = new Size (190, 22);
		autoRefreshLogToolStripMenuItem.Text = "&Auto Refresh Log";
		autoRefreshLogToolStripMenuItem.CheckOnClick = true;
		// 
		// showBookmarksToolStripMenuItem
		// 
		showBookmarksToolStripMenuItem.MergeAction = MergeAction.Append;
		showBookmarksToolStripMenuItem.MergeIndex = 7;
		showBookmarksToolStripMenuItem.Size = new Size (190, 22);
		showBookmarksToolStripMenuItem.Text = "Show Bookmarks...";
		showBookmarksToolStripMenuItem.ShowShortcutKeys = true;
		showBookmarksToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F2";
		showBookmarksToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F2;
		// 
		// colorColumnToolStripMenuItem
		// 
		colorColumnToolStripMenuItem.MergeAction = MergeAction.Append;
		colorColumnToolStripMenuItem.MergeIndex = 19;
		colorColumnToolStripMenuItem.Size = new Size (190, 22);
		colorColumnToolStripMenuItem.Text = "Color Column";
		colorColumnToolStripMenuItem.ShowShortcutKeys = false;
		// 
		// timeSynchroNowToolStripMenuItem
		// 
		timeSynchroNowToolStripMenuItem.MergeAction = MergeAction.Append;
		timeSynchroNowToolStripMenuItem.MergeIndex = 20;
		timeSynchroNowToolStripMenuItem.Size = new Size (190, 22);
		timeSynchroNowToolStripMenuItem.Text = "Synchronize Now With Other Logs";
		timeSynchroNowToolStripMenuItem.ShowShortcutKeys = false;
		// 
		// decryptMessageToolStripMenuItem
		// 
		decryptMessageToolStripMenuItem.MergeAction = MergeAction.Append;
		decryptMessageToolStripMenuItem.MergeIndex = 21;
		decryptMessageToolStripMenuItem.Size = new Size (190, 22);
		decryptMessageToolStripMenuItem.Text = "Decrypt Message";
		decryptMessageToolStripMenuItem.ShowShortcutKeys = false;
		// 
		// filterToolStripMenuItem
		// 
		filterToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
            filterUndoToolStripMenuItem,
            filterRedoToolStripMenuItem,
            filterSeparator90,
            filterQuickStringToolStripMenuItem,
            filterAddToCurrentToolStripMenuItem,
            filterSetTraceLevelToolStripMenuItem,
            filterConfigToolStripMenuItem,
            filterClearAllToolStripMenuItem,
            filterSavedFiltersToolStripMenuItem});
		filterToolStripMenuItem.MergeAction = MergeAction.Insert;
		filterToolStripMenuItem.MergeIndex = 3;
		filterToolStripMenuItem.Size = new Size (41, 20);
		filterToolStripMenuItem.Text = "F&ilter";
		// 
		// filterUndoToolStripMenuItem
		// 
		filterUndoToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.filterUndoToolStripMenuItem.MergeIndex = 167;
		filterUndoToolStripMenuItem.Size = new Size (190, 22);
		filterUndoToolStripMenuItem.Text = "&Undo Filter Change";
		filterUndoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
		filterUndoToolStripMenuItem.ShowShortcutKeys = true;
		filterUndoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Z";
		// 
		// filterRedoToolStripMenuItem
		// 
		filterRedoToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.filterRedoToolStripMenuItem.MergeIndex = 167;
		filterRedoToolStripMenuItem.Size = new Size (190, 22);
		filterRedoToolStripMenuItem.Text = "&Redo Filter Change";
		filterRedoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
		filterRedoToolStripMenuItem.ShowShortcutKeys = true;
		filterRedoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Y";
		// 
		// filterSeparator90
		//            
		filterSeparator90.Size = new Size (148, 6);
		filterSeparator90.MergeAction = MergeAction.Insert;
		// 
		// filterQuickStringToolStripMenuItem
		// 
		filterQuickStringToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.filterQuickStringToolStripMenuItem.MergeIndex = 167;
		filterQuickStringToolStripMenuItem.Size = new Size (190, 22);
		filterQuickStringToolStripMenuItem.Text = "Quick &String Filter...";
		filterQuickStringToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Alt+F";
		filterQuickStringToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.F;
		filterQuickStringToolStripMenuItem.ShowShortcutKeys = true;
		//
		// filterAddToCurrentToolStripMenuItem
		//
		filterAddToCurrentToolStripMenuItem.Text = "Add to Filter";
		//
		// filterSetTraceLevelToolStripMenuItem
		//
		filterSetTraceLevelToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
            filterSetTraceLevelAllToolStripMenuItem,
            filterSetTraceLevelVerboseToolStripMenuItem,
            filterSetTraceLevelNotesToolStripMenuItem,
            filterSetTraceLevelStatusToolStripMenuItem,
            filterSetTraceLevelWarningToolStripMenuItem,
            filterSetTraceLevelErrorToolStripMenuItem,
            filterSetTraceLevelCriticalToolStripMenuItem});
		filterSetTraceLevelToolStripMenuItem.Text = "Set Trace Level Filter";
		//
		// filterSetTraceLevelAllToolStripMenuItem
		//
		filterSetTraceLevelAllToolStripMenuItem.Text = "&All";
		//
		// filterSetTraceLevelVerboseToolStripMenuItem
		//
		filterSetTraceLevelVerboseToolStripMenuItem.Text = "&Verbose Notes";
		//
		// filterSetTraceLevelNotesToolStripMenuItem
		//
		filterSetTraceLevelNotesToolStripMenuItem.Text = "&Notes";
		//
		// filterSetTraceLevelStatusToolStripMenuItem
		//
		filterSetTraceLevelStatusToolStripMenuItem.Text = "&Status";
		//
		// filterSetTraceLevelWarningToolStripMenuItem
		//
		filterSetTraceLevelWarningToolStripMenuItem.Text = "&Warning";
		//
		// filterSetTraceLevelErrorToolStripMenuItem
		//
		filterSetTraceLevelErrorToolStripMenuItem.Text = "&Error";
		//
		// filterSetTraceLevelCriticalToolStripMenuItem
		//
		filterSetTraceLevelCriticalToolStripMenuItem.Text = "&Critical Error";
		// 
		// filterConfigToolStripMenuItem
		// 
		filterConfigToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.filterConfigToolStripMenuItem.MergeIndex = 167;
		filterConfigToolStripMenuItem.Size = new Size (190, 22);
		filterConfigToolStripMenuItem.Text = "&Filter Configuration...";
		// 
		// filterClearAllToolStripMenuItem
		// 
		filterClearAllToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.filterClearAllToolStripMenuItem.MergeIndex = 168;
		filterClearAllToolStripMenuItem.Size = new Size (190, 22);
		filterClearAllToolStripMenuItem.Text = "Clear &All Filters";
		// 
		// filterSavedFiltersToolStripMenuItem
		// 
		filterSavedFiltersToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
            filterSaveCurrentFilterToolStripMenuItem,
            filterImportFiltersToolStripMenuItem});
		filterSavedFiltersToolStripMenuItem.MergeAction = MergeAction.Insert;
		filterSavedFiltersToolStripMenuItem.Size = new Size (190, 22);
		filterSavedFiltersToolStripMenuItem.Text = "Saved Filters";
		// 
		// filterSaveCurrentFilterToolStripMenuItem
		// 
		filterSaveCurrentFilterToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.filterSaveCurrentFilterToolStripMenuItem.MergeIndex = 168;
		filterSaveCurrentFilterToolStripMenuItem.Size = new Size (190, 22);
		filterSaveCurrentFilterToolStripMenuItem.Text = "&Save Current Filter As...";
		// 
		// filterImportFiltersToolStripMenuItem
		// 
		filterImportFiltersToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.filterImportFiltersToolStripMenuItem.MergeIndex = 168;
		filterImportFiltersToolStripMenuItem.Size = new Size (190, 22);
		filterImportFiltersToolStripMenuItem.Text = "I&mport Filters From...";
		// 
		// searchToolStripMenuItem
		// 
		searchToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] {
            searchForwardToolStripMenuItem,
            searchBackwardToolStripMenuItem,
            searchForwardOnNamedFilterToolStripMenuItem,
            searchBackwardOnNamedFilterToolStripMenuItem,
            searchForwardOnMsgTypeFilterToolStripMenuItem,
            searchBackwardOnMsgTypeFilterToolStripMenuItem,
            toolStripSeparator80,
            searchForwardAgainToolStripMenuItem,
            searchBackwardAgainToolStripMenuItem,
            toolStripSeparator81,
            searchMatchingScopeToolStripMenuItem,
            searchTimestampJumpToolStripMenuItem,
            searchNextSameThreadToolStripMenuItem,
            searchPrevSameThreadToolStripMenuItem,
            searchStepOutForwardCallLevelToolStripMenuItem,
            searchStepOutBackwardCallLevelToolStripMenuItem,
            searchStepOverForwardCallLevelToolStripMenuItem,
            searchStepOverBackwardCallLevelToolStripMenuItem,
            searchStepIntoForwardCallLevelToolStripMenuItem,
            searchStepIntoBackwardCallLevelToolStripMenuItem,
            toolStripSeparator82,
            searchToggleBookmarkToolStripMenuItem,
            searchNextBookmarkToolStripMenuItem,
            searchPrevBookmarkToolStripMenuItem});
		searchToolStripMenuItem.MergeAction = MergeAction.Insert;
		searchToolStripMenuItem.MergeIndex = 4;
		searchToolStripMenuItem.Size = new Size (41, 20);
		searchToolStripMenuItem.Text = "&Search";
		// 
		// searchForwardToolStripMenuItem
		// 
		searchForwardToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchForwardToolStripMenuItem.MergeIndex = 167;
		searchForwardToolStripMenuItem.Size = new Size (190, 22);
		searchForwardToolStripMenuItem.Text = "Search &Forward...";
		searchForwardToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F";
		searchForwardToolStripMenuItem.ShowShortcutKeys = true;
		searchForwardToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
		// 
		// searchBackwardToolStripMenuItem
		// 
		searchBackwardToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchBackwardToolStripMenuItem.MergeIndex = 167;
		searchBackwardToolStripMenuItem.Size = new Size (190, 22);
		searchBackwardToolStripMenuItem.Text = "Search &Backward...";
		searchBackwardToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+F";
		searchBackwardToolStripMenuItem.ShowShortcutKeys = true;
		searchBackwardToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.F;
		// 
		// searchForwardOnNamedFilterToolStripMenuItem 
		// 
		searchForwardOnNamedFilterToolStripMenuItem.DropDownItems.Add ("(none)");
		searchForwardOnNamedFilterToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchForwardOnNamedFilterToolStripMenuItem .MergeIndex = 167;
		searchForwardOnNamedFilterToolStripMenuItem.Size = new Size (190, 22);
		searchForwardOnNamedFilterToolStripMenuItem.Text = "Search Forward on Named Expression";
		// 
		// searchBackwardOnNamedFilterToolStripMenuItem 
		// 
		searchBackwardOnNamedFilterToolStripMenuItem.DropDownItems.Add ("(none)");
		searchBackwardOnNamedFilterToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchBackwardOnNamedFilterToolStripMenuItem .MergeIndex = 167;
		searchBackwardOnNamedFilterToolStripMenuItem.Size = new Size (190, 22);
		searchBackwardOnNamedFilterToolStripMenuItem.Text = "Search Backward on Named Expression";
		// 
		// searchForwardOnMsgTypeFilterToolStripMenuItem 
		// 
		searchForwardOnMsgTypeFilterToolStripMenuItem.Size = new Size (190, 22);
		searchForwardOnMsgTypeFilterToolStripMenuItem.Text = "Search Forward on Message Type";
		// 
		// searchBackwardOnMsgTypeFilterToolStripMenuItem 
		// 
		searchBackwardOnMsgTypeFilterToolStripMenuItem.Size = new Size (190, 22);
		searchBackwardOnMsgTypeFilterToolStripMenuItem.Text = "Search Backward on Message Type";
		// 
		// toolStripSeparator80
		// 
		toolStripSeparator80.Size = new Size (148, 6);
		toolStripSeparator80.MergeAction = MergeAction.Insert;
		// 
		// searchForwardAgainToolStripMenuItem
		// 
		searchForwardAgainToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchForwardAgainToolStripMenuItem.MergeIndex = 167;
		searchForwardAgainToolStripMenuItem.Size = new Size (190, 22);
		searchForwardAgainToolStripMenuItem.Text = "Search Forward Again";
		searchForwardAgainToolStripMenuItem.ShortcutKeyDisplayString = "F3";
		searchForwardAgainToolStripMenuItem.ShowShortcutKeys = true;
		searchForwardAgainToolStripMenuItem.ShortcutKeys = Keys.F3;
		// 
		// searchBackwardAgainToolStripMenuItem
		// 
		searchBackwardAgainToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchBackwardAgainToolStripMenuItem.MergeIndex = 167;
		searchBackwardAgainToolStripMenuItem.Size = new Size (190, 22);
		searchBackwardAgainToolStripMenuItem.Text = "Search Backward Again";
		searchBackwardAgainToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F3";
		searchBackwardAgainToolStripMenuItem.ShowShortcutKeys = true;
		searchBackwardAgainToolStripMenuItem.ShortcutKeys = Keys.Shift | Keys.F3;
		// 
		// toolStripSeparator81
		// 
		toolStripSeparator81.Size = new Size (148, 6);
		toolStripSeparator81.MergeAction = MergeAction.Insert;
		// 
		// searchMatchingScopeToolStripMenuItem
		// 
		searchMatchingScopeToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchMatchingScopeToolStripMenuItem.MergeIndex = 167;
		searchMatchingScopeToolStripMenuItem.Size = new Size (190, 22);
		searchMatchingScopeToolStripMenuItem.Text = "Jump to Matching Scope/Create";
		searchMatchingScopeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+E";
		searchMatchingScopeToolStripMenuItem.ShowShortcutKeys = true;
		searchMatchingScopeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
		// 
		// searchTimestampJumpToolStripMenuItem
		// 
		searchTimestampJumpToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchTimestampJumpToolStripMenuItem.MergeIndex = 167;
		searchTimestampJumpToolStripMenuItem.Size = new Size (190, 22);
		searchTimestampJumpToolStripMenuItem.Text = "Jump to Specific Timestamp";
		searchTimestampJumpToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+T";
		searchTimestampJumpToolStripMenuItem.ShowShortcutKeys = true;
		searchTimestampJumpToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
		// 
		// searchNextSameThreadToolStripMenuItem
		// 
		searchNextSameThreadToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchNextSameThreadToolStripMenuItem.MergeIndex = 167;
		searchNextSameThreadToolStripMenuItem.Size = new Size (190, 22);
		searchNextSameThreadToolStripMenuItem.Text = "Jump to Next Thread Message";
		searchNextSameThreadToolStripMenuItem.ShortcutKeyDisplayString = "F4";
		searchNextSameThreadToolStripMenuItem.ShowShortcutKeys = true;
		searchNextSameThreadToolStripMenuItem.ShortcutKeys = Keys.F4;
		// 
		// searchPrevSameThreadToolStripMenuItem
		// 
		searchPrevSameThreadToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchPrevSameThreadToolStripMenuItem.MergeIndex = 167;
		searchPrevSameThreadToolStripMenuItem.Size = new Size (190, 22);
		searchPrevSameThreadToolStripMenuItem.Text = "Jump to Previous Thread Message";
		searchPrevSameThreadToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F4";
		searchPrevSameThreadToolStripMenuItem.ShowShortcutKeys = true;
		searchPrevSameThreadToolStripMenuItem.ShortcutKeys = Keys.Shift | Keys.F4;
		// 
		// searchStepOutForwardCallLevelToolStripMenuItem
		// 
		searchStepOutForwardCallLevelToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchStepOutForwardCallLevelToolStripMenuItem.MergeIndex = 167;
		searchStepOutForwardCallLevelToolStripMenuItem.Size = new Size (190, 22);
		searchStepOutForwardCallLevelToolStripMenuItem.Text = "Jump Out of Current Call Level";
		searchStepOutForwardCallLevelToolStripMenuItem.ShortcutKeyDisplayString = "F12";
		searchStepOutForwardCallLevelToolStripMenuItem.ShowShortcutKeys = true;
		searchStepOutForwardCallLevelToolStripMenuItem.ShortcutKeys = Keys.F12;
		// 
		// searchStepOutBackwardCallLevelToolStripMenuItem
		// 
		searchStepOutBackwardCallLevelToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchStepOutBackwardCallLevelToolStripMenuItem.MergeIndex = 167;
		searchStepOutBackwardCallLevelToolStripMenuItem.Size = new Size (190, 22);
		searchStepOutBackwardCallLevelToolStripMenuItem.Text = "Back Out of Current Call Level";
		searchStepOutBackwardCallLevelToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F12";
		searchStepOutBackwardCallLevelToolStripMenuItem.ShowShortcutKeys = true;
		searchStepOutBackwardCallLevelToolStripMenuItem.ShortcutKeys = Keys.Shift | Keys.F12;
		// 
		// searchStepOverForwardCallLevelToolStripMenuItem
		// 
		searchStepOverForwardCallLevelToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchStepOverForwardCallLevelToolStripMenuItem.MergeIndex = 167;
		searchStepOverForwardCallLevelToolStripMenuItem.Size = new Size (190, 22);
		searchStepOverForwardCallLevelToolStripMenuItem.Text = "Step Over Next Call Level";
		searchStepOverForwardCallLevelToolStripMenuItem.ShortcutKeyDisplayString = "F10";
		searchStepOverForwardCallLevelToolStripMenuItem.ShowShortcutKeys = true;
		searchStepOverForwardCallLevelToolStripMenuItem.ShortcutKeys = Keys.F10;
		// 
		// searchStepOverBackwardCallLevelToolStripMenuItem
		// 
		searchStepOverBackwardCallLevelToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchStepOverBackwardCallLevelToolStripMenuItem.MergeIndex = 167;
		searchStepOverBackwardCallLevelToolStripMenuItem.Size = new Size (190, 22);
		searchStepOverBackwardCallLevelToolStripMenuItem.Text = "Back Over Next Call Level";
		searchStepOverBackwardCallLevelToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F10";
		searchStepOverBackwardCallLevelToolStripMenuItem.ShowShortcutKeys = true;
		searchStepOverBackwardCallLevelToolStripMenuItem.ShortcutKeys = Keys.Shift | Keys.F10;
		// 
		// searchStepIntoForwardCallLevelToolStripMenuItem
		// 
		searchStepIntoForwardCallLevelToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchStepIntoForwardCallLevelToolStripMenuItem.MergeIndex = 167;
		searchStepIntoForwardCallLevelToolStripMenuItem.Size = new Size (190, 22);
		searchStepIntoForwardCallLevelToolStripMenuItem.Text = "Step Into Next Call Level";
		searchStepIntoForwardCallLevelToolStripMenuItem.ShortcutKeyDisplayString = "F11";
		searchStepIntoForwardCallLevelToolStripMenuItem.ShowShortcutKeys = true;
		searchStepIntoForwardCallLevelToolStripMenuItem.ShortcutKeys = Keys.F11;
		// 
		// searchStepIntoBackwardCallLevelToolStripMenuItem
		// 
		searchStepIntoBackwardCallLevelToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchStepIntoBackwardCallLevelToolStripMenuItem.MergeIndex = 167;
		searchStepIntoBackwardCallLevelToolStripMenuItem.Size = new Size (190, 22);
		searchStepIntoBackwardCallLevelToolStripMenuItem.Text = "Back Into Next Call Level";
		searchStepIntoBackwardCallLevelToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F11";
		searchStepIntoBackwardCallLevelToolStripMenuItem.ShowShortcutKeys = true;
		searchStepIntoBackwardCallLevelToolStripMenuItem.ShortcutKeys = Keys.Shift | Keys.F11;
		// 
		// toolStripSeparator82
		// 
		toolStripSeparator82.Size = new Size (148, 6);
		toolStripSeparator82.MergeAction = MergeAction.Insert;
		// 
		// searchToggleBookmarkToolStripMenuItem
		// 
		searchToggleBookmarkToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchToggleBookmarkToolStripMenuItem.MergeIndex = 167;
		searchToggleBookmarkToolStripMenuItem.Size = new Size (190, 22);
		searchToggleBookmarkToolStripMenuItem.Text = "Toggle Bookmark";
		searchToggleBookmarkToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F2";
		searchToggleBookmarkToolStripMenuItem.ShowShortcutKeys = true;
		searchToggleBookmarkToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F2;
		// 
		// searchNextBookmarkToolStripMenuItem
		// 
		searchNextBookmarkToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchNextBookmarkToolStripMenuItem.MergeIndex = 167;
		searchNextBookmarkToolStripMenuItem.Size = new Size (190, 22);
		searchNextBookmarkToolStripMenuItem.Text = "Jump to Next Bookmark";
		searchNextBookmarkToolStripMenuItem.ShortcutKeyDisplayString = "F2";
		searchNextBookmarkToolStripMenuItem.ShowShortcutKeys = true;
		searchNextBookmarkToolStripMenuItem.ShortcutKeys = Keys.F2;
		// 
		// searchPrevBookmarkToolStripMenuItem
		// 
		searchPrevBookmarkToolStripMenuItem.MergeAction = MergeAction.Insert;
		//is.searchPrevBookmarkToolStripMenuItem.MergeIndex = 167;
		searchPrevBookmarkToolStripMenuItem.Size = new Size (190, 22);
		searchPrevBookmarkToolStripMenuItem.Text = "Jump to Previous Bookmark";
		searchPrevBookmarkToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F2";
		searchPrevBookmarkToolStripMenuItem.ShowShortcutKeys = true;
		searchPrevBookmarkToolStripMenuItem.ShortcutKeys = Keys.Shift | Keys.F2;
		// 
		// toolsMenu
		// 
		toolsMenu.DropDownItems.Add (toolsAnaylzeContextAttribs);
		toolsMenu.MergeAction = MergeAction.MatchOnly;
		toolsMenu.MergeIndex = -1;
		toolsMenu.Size = new Size (41, 20);
		toolsMenu.Text = "&Tools";
		// 
		// toolsAnaylzeContextAttribs
		// 
		toolsAnaylzeContextAttribs.Size = new Size (23, 22);
		toolsAnaylzeContextAttribs.Text = "Analyze &Distinct Context Attribute Values";
		// 
		// ChildForm
		// 
		AutoScaleDimensions = new SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (150, 150);
		_menuStrip.ResumeLayout (false);
		_menuStrip.PerformLayout ();
		ResumeLayout (false);
		PerformLayout ();
	}

	private MenuStrip _menuStrip;
	private ToolStripMenuItem fileToolStripMenuItem;
	private ToolStripMenuItem fileNewWindowToolStripMenuItem;
	private ToolStripMenuItem fileOpenLatestToolStripMenuItem;
	private ToolStripMenuItem fileDeleteLogToolStripMenuItem;
	private ToolStripMenuItem editToolStripMenuItem;
	private ToolStripMenuItem copyAsToolStripMenuItem;
	private ToolStripMenuItem copyAsSimpleTextToolStripMenuItem;
	private ToolStripMenuItem copyAsRichTextToolStripMenuItem;
	private ToolStripMenuItem copyAsHtmlToolStripMenuItem;
	private ToolStripMenuItem copyAsCsvToolStripMenuItem;
	private ToolStripMenuItem viewToolStripMenuItem;
	private ToolStripMenuItem timeJitterToolStripMenuItem;
	private ToolStripMenuItem logHeaderToolStripMenuItem;
	private ToolStripMenuItem showFunctionNamesToolStripMenuItem;
	private ToolStripMenuItem showContextInDetailToolStripMenuItem;
	private ToolStripMenuItem manageColumnsToolStripMenuItem;
	private ToolStripMenuItem refreshLogToolStripMenuItem;
	private ToolStripMenuItem autoRefreshLogToolStripMenuItem;
	private ToolStripMenuItem showBookmarksToolStripMenuItem;
	internal ToolStripMenuItem colorColumnToolStripMenuItem;
	private ToolStripMenuItem filterToolStripMenuItem;
	private ToolStripMenuItem filterUndoToolStripMenuItem;
	private ToolStripMenuItem filterRedoToolStripMenuItem;
	private ToolStripSeparator filterSeparator90;
	private ToolStripMenuItem filterQuickStringToolStripMenuItem;
	private ToolStripMenuItem filterAddToCurrentToolStripMenuItem;
	private ToolStripMenuItem filterSetTraceLevelToolStripMenuItem;
	private ToolStripMenuItem filterSetTraceLevelAllToolStripMenuItem;
	private ToolStripMenuItem filterSetTraceLevelVerboseToolStripMenuItem;
	private ToolStripMenuItem filterSetTraceLevelNotesToolStripMenuItem;
	private ToolStripMenuItem filterSetTraceLevelStatusToolStripMenuItem;
	private ToolStripMenuItem filterSetTraceLevelWarningToolStripMenuItem;
	private ToolStripMenuItem filterSetTraceLevelErrorToolStripMenuItem;
	private ToolStripMenuItem filterSetTraceLevelCriticalToolStripMenuItem;
	private ToolStripMenuItem filterConfigToolStripMenuItem;
	private ToolStripMenuItem filterClearAllToolStripMenuItem;
	private ToolStripMenuItem filterSavedFiltersToolStripMenuItem;
	private ToolStripMenuItem filterSaveCurrentFilterToolStripMenuItem;
	private ToolStripMenuItem filterImportFiltersToolStripMenuItem;
	private ToolStripMenuItem searchToolStripMenuItem;
	private ToolStripMenuItem searchForwardToolStripMenuItem;
	private ToolStripMenuItem searchBackwardToolStripMenuItem;
	private ToolStripMenuItem searchForwardOnNamedFilterToolStripMenuItem;
	private ToolStripMenuItem searchBackwardOnNamedFilterToolStripMenuItem;
	private ToolStripMenuItem searchForwardOnMsgTypeFilterToolStripMenuItem;
	private ToolStripMenuItem searchBackwardOnMsgTypeFilterToolStripMenuItem;
	private ToolStripSeparator toolStripSeparator80;
	private ToolStripMenuItem searchForwardAgainToolStripMenuItem;
	private ToolStripMenuItem searchBackwardAgainToolStripMenuItem;
	private ToolStripSeparator toolStripSeparator81;
	private ToolStripMenuItem searchMatchingScopeToolStripMenuItem;
	private ToolStripMenuItem searchTimestampJumpToolStripMenuItem;
	private ToolStripMenuItem searchNextSameThreadToolStripMenuItem;
	private ToolStripMenuItem searchPrevSameThreadToolStripMenuItem;
	private ToolStripMenuItem searchStepOutForwardCallLevelToolStripMenuItem;
	private ToolStripMenuItem searchStepOutBackwardCallLevelToolStripMenuItem;
	private ToolStripMenuItem searchStepOverForwardCallLevelToolStripMenuItem;
	private ToolStripMenuItem searchStepOverBackwardCallLevelToolStripMenuItem;
	private ToolStripMenuItem searchStepIntoForwardCallLevelToolStripMenuItem;
	private ToolStripMenuItem searchStepIntoBackwardCallLevelToolStripMenuItem;
	private ToolStripSeparator toolStripSeparator82;
	private ToolStripMenuItem searchToggleBookmarkToolStripMenuItem;
	private ToolStripMenuItem searchNextBookmarkToolStripMenuItem;
	private ToolStripMenuItem searchPrevBookmarkToolStripMenuItem;
	private ToolStripMenuItem timeSynchroNowToolStripMenuItem;
	private ToolStripMenuItem decryptMessageToolStripMenuItem;
	private ToolStripMenuItem toolsMenu;
	private ToolStripMenuItem toolsAnaylzeContextAttribs;
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
			"1. In the File menu, select Open.{0}{0}" +
			"2. Click the File menu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following menu items are displayed (in order):{0}{0}" +
			"   * Clone Log Window{0}" +
			"   * Open Latest in Series{0}" +
			"   * Open{0}" +
			"   * Reopen{0}" +
			"   * Delete Log{0}" +
			"   * Close{0}" +
			"   * Snip/Merge Log File(s)...{0}" +
			"   * --------------------------------------{0}" +
			"   * Exit",
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
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Close the child form.{0}{0}" +
			"2. Click the File menu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following menu items are displayed (in order):{0}{0}" +
			"   * Open{0}" +
			"   * Reopen{0}" +
			"   * Close{0}" +
			"   * Snip/Merge Log File(s)...{0}" +
			"   * --------------------------------------{0}" +
			"   * Exit{0}{0}" +
			"2. The Filter and Search menu's are no longer displayed.",
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
		ClientSize = new Size (350, 300);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81477";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
