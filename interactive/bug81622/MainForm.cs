using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		Controls.Add (_tabControl);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _textBox1
		// 
		_textBox1 = new TextBox ();
		_textBox1.Dock = DockStyle.Fill;
		_textBox1.Multiline = true;
		_textBox1.TabIndex = 0;
		_textBox1.Text = "Text for page #1";
		_tabPage1.Controls.Add (_textBox1);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _textBox2
		// 
		_textBox2 = new TextBox ();
		_textBox2.Dock = DockStyle.Fill;
		_textBox2.Multiline = true;
		_textBox2.TabIndex = 0;
		_textBox2.Text = "Text for page #2";
		_tabPage2.Controls.Add (_textBox2);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabControl.Controls.Add (_tabPage3);
		// 
		// _textBox3
		// 
		_textBox3 = new TextBox ();
		_textBox3.Dock = DockStyle.Fill;
		_textBox3.Multiline = true;
		_textBox3.TabIndex = 0;
		_textBox3.Text = "Text for page #3";
		_tabPage3.Controls.Add (_textBox3);
		// 
		// MainForm
		// 
		ClientSize = new Size (220, 130);
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81622";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TextBox _textBox1;
	private TabPage _tabPage2;
	private TextBox _textBox2;
	private TabPage _tabPage3;
	private TextBox _textBox3;
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
			"1. Press Ctrl-Tab key.{0}{0}" +
			"2. Press Ctrl-Tab key.{0}{0}" +
			"3. Press Ctrl-Tab key.{0}{0}" +
			"4. Press Ctrl-Shift-Tab key.{0}{0}" +
			"Expected result:{0}" +
			"1. On step 1, tab #2 is activated.{0}{0}" +
			"2. On step 2, tab #3 is activated.{0}{0}" +
			"3. On step 3, tab #1 is activated.{0}{0}" +
			"4. On step 4, tab #3 is activated.",
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
		ClientSize = new Size (300, 300);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81622";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
