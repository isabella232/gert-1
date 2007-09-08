using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _toolStrip
		// 
		_toolStrip = new ToolStrip ();
		_toolStrip.Dock = DockStyle.Top;
		_toolStrip.Height = 25;
		Controls.Add (_toolStrip);
		// 
		// _statusStrip;
		// 
		_statusStrip = new StatusStrip ();
		Controls.Add (_statusStrip);
		// 
		// _toolStripLabel1
		// 
		_toolStripLabel1 = new ToolStripLabel ();
		_toolStripLabel1.Text = "Mono";
		_statusStrip.Items.Add (_toolStripLabel1);
		// 
		// _toolStripLabel2
		// 
		_toolStripLabel2 = new ToolStripLabel ();
		_toolStripLabel2.Text = "Mono";
		_toolStrip.Items.Add (_toolStripLabel2);
		// 
		// _menuStrip
		// 
		_menuStrip = new MenuStrip ();
		_menuStrip.Dock = DockStyle.Left;
		_menuStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
		_menuStrip.Location = new Point (0, 0);
		_menuStrip.Size = new Size (303, 23);
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
		_newToolStripMenuItem.Text = "&New";
		_fileToolStripMenuItem.DropDownItems.Add (_newToolStripMenuItem);
		// 
		// _openToolStripMenuItem
		// 
		_openToolStripMenuItem = new ToolStripMenuItem ();
		_openToolStripMenuItem.Text = "&Open";
		_fileToolStripMenuItem.DropDownItems.Add (_openToolStripMenuItem);
		// 
		// _editToolStripMenuItem
		// 
		_editToolStripMenuItem = new ToolStripMenuItem ();
		_editToolStripMenuItem.Text = "&Edit";
		_menuStrip.Items.Add (_editToolStripMenuItem);
		// 
		// _undoToolStripMenuItem
		// 
		_undoToolStripMenuItem = new ToolStripMenuItem ();
		_undoToolStripMenuItem.Text = "&Undo";
		_editToolStripMenuItem.DropDownItems.Add (_undoToolStripMenuItem);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 250);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82739";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		FlowLayoutSettings flowLayout = _menuStrip.LayoutSettings as FlowLayoutSettings;
		flowLayout.FlowDirection = FlowDirection.TopDown;

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private StatusStrip _statusStrip;
	private ToolStrip _toolStrip;
	private ToolStripLabel _toolStripLabel1;
	private ToolStripLabel _toolStripLabel2;
	private MenuStrip _menuStrip;
	private ToolStripMenuItem _fileToolStripMenuItem;
	private ToolStripMenuItem _newToolStripMenuItem;
	private ToolStripMenuItem _openToolStripMenuItem;
	private ToolStripMenuItem _editToolStripMenuItem;
	private ToolStripMenuItem _undoToolStripMenuItem;
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
			"1. A menustrip is drawn as a 22 pixel vertical bar, " +
			"docked to the left border.{0}{0}" +
			"2. A label with text \"Mono\" is displayed in the left " +
			"size of the toolstrip and statusstrip.{0}{0}" +
			"3. The toolstrip and statusstript are drawn immediately " +
			"to the right of the menustrip.",
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
		ClientSize = new Size (330, 180);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82739";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
