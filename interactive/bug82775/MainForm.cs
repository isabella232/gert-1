using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Top;
		_eventsText.Height = 150;
		_eventsText.Multiline = true;
		_eventsText.ScrollBars = ScrollBars.Vertical;
		Controls.Add (_eventsText);
		// 
		// _toolStrip
		// 
		_toolStrip = new ToolStrip ();
		_toolStrip.Dock = DockStyle.Top;
		_toolStrip.Click += new EventHandler (ToolStrip_Click);
		_toolStrip.ItemClicked += ToolStrip_ItemClicked;
		Controls.Add (_toolStrip);
		// 
		// _fileMenuItem
		// 
		_fileMenuItem = new ToolStripMenuItem ();
		_fileMenuItem.Text = "&File";
		_fileMenuItem.Click += FileMenuItem_Click;
		_toolStrip.Items.Add (_fileMenuItem);
		// 
		// _newFileMenuItem
		// 
		_newFileMenuItem = new ToolStripMenuItem ();
		_newFileMenuItem.Text = "&New";
		_newFileMenuItem.Click += NewFileMenuItem_Click;
		_fileMenuItem.DropDownItems.Add (_newFileMenuItem);
		// 
		// _editMenuItem
		// 
		_editMenuItem = new ToolStripMenuItem ();
		_editMenuItem.Text = "&Edit";
		_editMenuItem.Click += EditMenuItem_Click;
		_toolStrip.Items.Add (_editMenuItem);
		// 
		// _clearButton
		// 
		_clearButton = new Button ();
		_clearButton.Location = new Point (110, 185);
		_clearButton.Text = "Clear";
		_clearButton.Click += ClearButton_Click;
		Controls.Add (_clearButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 220);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82775";
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

	void ToolStrip_Click (object sender, EventArgs e)
	{
		_eventsText.AppendText ("ToolStrip => Click" +
			Environment.NewLine);
	}

	void ToolStrip_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
	{
		_eventsText.AppendText ("ToolStrip => ItemClicked" +
			Environment.NewLine);
	}

	void FileMenuItem_Click (object sender, EventArgs e)
	{
		_eventsText.AppendText ("File => Click" + Environment.NewLine);
	}

	void NewFileMenuItem_Click (object sender, EventArgs e)
	{
		_eventsText.AppendText ("NewFile => Click" + Environment.NewLine);
	}

	void EditMenuItem_Click (object sender, EventArgs e)
	{
		_eventsText.AppendText ("Edit => Click" + Environment.NewLine);
	}

	void ClearButton_Click (object sender, EventArgs e)
	{
		_eventsText.Text = string.Empty;
	}

	private TextBox _eventsText;
	private ToolStrip _toolStrip;
	private ToolStripMenuItem _fileMenuItem;
	private ToolStripMenuItem _newFileMenuItem;
	private ToolStripMenuItem _editMenuItem;
	private Button _clearButton;
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
			"1. Click the Clear button.{0}{0}" +
			"2. Click the Edit menu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No menu is dropped down.{0}{0}" +
			"2. The following events have fired:{0}{0}" +
			"   * ToolStrip => Click{0}" +
			"   * ToolStrip => ItemClicked{0}" +
			"   * Edit => Click",
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
			"1. Click the Clear button.{0}{0}" +
			"2. Click the File menu.{0}{0}" +
			"3. Click the New menuitem.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"   * The File menu is dropped down.{0}" +
			"   * The following events have fired:{0}{0}" +
			"      ToolStrip => Click{0}" +
			"      ToolStrip => ItemClicked{0}" +
			"      File => Click{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * The File menu is closed.{0}" +
			"   * The following events have fired:{0}{0}" +
			"      NewFile => Click",
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
			"1. Click the Clear button.{0}{0}" +
			"2. Click the File menu.{0}{0}" +
			"3. Click inside the textbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"   * The File menu is dropped down.{0}" +
			"   * The following events have fired:{0}{0}" +
			"      ToolStrip => Click{0}" +
			"      ToolStrip => ItemClicked{0}" +
			"      File => Click{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * The File menu is closed.{0}" +
			"   * No events have fired.",
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
			"1. Click the Clear button.{0}{0}" +
			"2. Click the File menu.{0}{0}" +
			"3. Click the File menu.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"   * The File menu is dropped down.{0}" +
			"   * The following events have fired:{0}{0}" +
			"      ToolStrip => Click{0}" +
			"      ToolStrip => ItemClicked{0}" +
			"      File => Click{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * The File menu is closed.{0}" +
			"   * The following events have fired:{0}{0}" +
			"      ToolStrip => Click{0}" +
			"      ToolStrip => ItemClicked{0}" +
			"      File => Click",
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
		ClientSize = new Size (300, 400);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82775";
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
