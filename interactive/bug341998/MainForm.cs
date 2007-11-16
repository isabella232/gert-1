using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm()
	{
		// 
		// _rightPanel
		// 
		_rightPanel = new ToolStripPanel ();
		_rightPanel.Dock = DockStyle.Right;
		Controls.Add (_rightPanel);
		// 
		// _leftPanel
		// 
		_leftPanel = new ToolStripPanel ();
		_leftPanel.Dock = DockStyle.Left;
		Controls.Add (_leftPanel);
		// 
		// _bottomPanel
		// 
		_bottomPanel = new ToolStripPanel ();
		_bottomPanel.Dock = DockStyle.Bottom;
		Controls.Add (_bottomPanel);
		// 
		// _topPanel
		// 
		_topPanel = new ToolStripPanel ();
		_topPanel.Dock = DockStyle.Top;
		Controls.Add (_topPanel);
		// 
		// _topStrip
		// 
		_topStrip = new ToolStrip ();
		_topStrip.Items.Add ("Top");
		_topPanel.Join (_topStrip);
		// 
		// _bottomStrip
		// 
		_bottomStrip = new ToolStrip ();
		_bottomStrip.Items.Add ("Bottom");
		_bottomPanel.Join (_bottomStrip);
		// 
		// _leftStrip
		// 
		_leftStrip = new ToolStrip ();
		_leftStrip.Items.Add ("Left");
		_leftPanel.Join (_leftStrip);
		// 
		// _leftStrip
		// 
		_rightStrip = new ToolStrip();
		_rightStrip.Items.Add ("Right");
		_rightPanel.Join (_rightStrip);
		// 
		// _menuStrip
		// 
		_menuStrip = new MenuStrip ();
		_menuStrip.Dock = DockStyle.Top;
		Controls.Add (_menuStrip);
		// 
		// _windowMenu
		// 
		_windowMenu = new ToolStripMenuItem ("Window");
		_menuStrip.MdiWindowListItem = _windowMenu;
		((ToolStripDropDownMenu) (_windowMenu.DropDown)).ShowImageMargin = false;
		((ToolStripDropDownMenu) (_windowMenu.DropDown)).ShowCheckMargin = true;
		_menuStrip.Items.Add (_windowMenu);
		// 
		// _newWindowMenu
		// 
		_newWindowMenu = new ToolStripMenuItem ("New", null, new EventHandler (NewWindowMenu_Click));
		_windowMenu.DropDownItems.Add (_newWindowMenu);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		IsMdiContainer = true;
		Location = new Point (250, 100);
		MainMenuStrip = _menuStrip;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #341998";
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

	void NewWindowMenu_Click (object sender, EventArgs e)
	{
		Form child = new Form();
		child.ClientSize = new Size (200, 50);
		child.MdiParent = this;
		child.Text = "Child";
		child.Show ();
	}

	private ToolStripPanel _topPanel;
	private ToolStripPanel _leftPanel;
	private ToolStripPanel _rightPanel;
	private ToolStripPanel _bottomPanel;
	private ToolStrip _topStrip;
	private ToolStrip _leftStrip;
	private ToolStrip _rightStrip;
	private ToolStrip _bottomStrip;
	private MenuStrip _menuStrip;
	private ToolStripMenuItem _windowMenu;
	private ToolStripMenuItem _newWindowMenu;
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
			"Expected result on startup:{0}{0}" +
			"1. A toolstrip is displayed on each side of the form.{0}{0}" +
			"2. The toolstrips can be moved.",
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
			"1. Click the New menu item in the Window menu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A child form is displayed in the MDI child area.",
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
		ClientSize = new Size (300, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #341998";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
