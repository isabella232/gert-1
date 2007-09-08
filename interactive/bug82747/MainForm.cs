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
		_table.Dock = DockStyle.Top;
		_table.Height = 160;
		_table.RowCount = 2;
		_table.RowStyles.Add (new RowStyle ());
		_table.RowStyles.Add (new RowStyle ());
		Controls.Add (_table);
		// 
		// _toolStrip1
		// 
		_toolStrip1 = new ToolStrip ();
		_toolStrip1.AllowItemReorder = true;
		_toolStrip1.Dock = DockStyle.Fill;
		_toolStrip1.Margin = new Padding (5);
		_toolStrip1.Stretch = true;
		_toolStrip1.TabStop = false;
		_table.Controls.Add (_toolStrip1, 0, 0);
		// 
		// _toolStrip2
		// 
		_toolStrip2 = new ToolStrip();
		_toolStrip2.AllowItemReorder = true;
		_toolStrip2.Dock = DockStyle.Fill;
		_toolStrip2.Margin = new Padding (5);
		_toolStrip2.Stretch = true;
		_toolStrip2.TabStop = true;
		_table.Controls.Add (_toolStrip2, 0, 1);
		// 
		// _textBox1
		// 
		_textBox1 = new ToolStripTextBox ();
		_textBox1.AcceptsReturn = true;
		_textBox1.AcceptsTab = true;
		_textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		_textBox1.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
		_textBox1.AutoSize = false;
		_textBox1.AutoToolTip = true;
		_textBox1.Multiline = true;
		_textBox1.Margin = new Padding (5);
		_textBox1.Size = new Size(265, 60);
		_textBox1.Text = "1";
		_toolStrip1.Items.Add (_textBox1);
		// 
		// _textBox2
		// 
		_textBox2 = new ToolStripTextBox ();
		_textBox2.AcceptsReturn = true;
		_textBox2.AcceptsTab = true;
		_textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		_textBox2.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
		_textBox2.AutoSize = false;
		_textBox2.AutoToolTip = true;
		_textBox2.Multiline = true;
		_textBox2.Margin = new Padding (5);
		_textBox2.Size = new Size (265, 60);
		_textBox2.Text = "2";
		_toolStrip2.Items.Add (_textBox2);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 165);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82747";
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
	private ToolStrip _toolStrip1;
	private ToolStrip _toolStrip2;
	private ToolStripTextBox _textBox1;
	private ToolStripTextBox _textBox2;
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
			"1. Two toolstrip are displayed with the same size.{0}{0}" +
			"2. A textbox containing a number fills each toolstrip " +
			"(with a small margin).{0}{0}" +
			"3. The textbox 2 has focus.",
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
			"1. Reduce the width of the form to a point where the " +
			"textboxes can no longer be fully displayed.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The textboxes are no longer displayed.{0}{0}" +
			"2. Each toolstrip now features a dropdown button which " +
			"can be used to displayed the textbox in a separate " +
			"window.{0}{0}" +
			"3. After increasing the width of the form, the " +
			"textboxes are displayed in the toolstrips again (with " +
			"their original size).",
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
		ClientSize = new Size (330, 245);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82747";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
