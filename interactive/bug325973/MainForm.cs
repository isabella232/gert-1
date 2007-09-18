using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		//
		// _table
		//
		_table = new TableLayoutPanel ();
		_table.ColumnCount = 1;
		_table.ColumnStyles.Add (new ColumnStyle (SizeType.Percent, 100F));
		_table.Dock = DockStyle.Fill;
		_table.RowCount = 1;
		_table.RowStyles.Add (new RowStyle ());
		Controls.Add (_table);
		// 
		// _toolStrip
		// 
		_toolStrip = new ToolStrip ();
		_toolStrip.AllowItemReorder = true;
		_toolStrip.Dock = DockStyle.Fill;
		_toolStrip.Margin = new Padding (5);
		_toolStrip.Stretch = true;
		_toolStrip.TabStop = false;
		_table.Controls.Add (_toolStrip, 0, 0);
		// 
		// _textBox
		// 
		_textBox = new ToolStripTextBox ();
		_textBox.AcceptsReturn = true;
		_textBox.AcceptsTab = true;
		_textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		_textBox.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
		_textBox.AutoSize = false;
		_textBox.AutoToolTip = true;
		_textBox.Multiline = true;
		_textBox.Margin = new Padding (5);
		_textBox.Size = new Size(265, 60);
		_textBox.Text = "1";
		_toolStrip.Items.Add (_textBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 165);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #325973";
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

	private TableLayoutPanel _table;
	private ToolStrip _toolStrip;
	private ToolStripTextBox _textBox;
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
			"1. Hover the mouse cursor over the area of the " +
			"toolstrip surrounding the textbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. No tooltip is displayed.",
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
			"1. Hover over the textbox.{0}{0}" +
			"2. Click inside the textbox window.{0}{0}" +
			"3. Enter \"23\" in the textbox.{0}{0}" +
			"4. Move the mouse cursor away from the textbox.{0}{0}" +
			"5. Hover over the textbox.{0}{0}" +
			"6. Hover over the area of the toolstrip surrounding " +
			"the textbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, a tooltip with text \"1\" is displayed " +
			"on the textbox.{0}{0}" +
			"2. On step 5, a tooltip with text \"123\" is displayed " +
			"on the textbox.{0}{0}" +
			"3. On step 6, no tooltip is displayed.",
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
		ClientSize = new Size (350, 330);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #325973";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
