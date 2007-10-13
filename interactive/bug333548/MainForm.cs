using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Dock = DockStyle.Fill;
		_textBox.Multiline = true;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.Text += "sample text" + System.Environment.NewLine;
		_textBox.ScrollToCaret ();
		Controls.Add (_textBox);
		// 
		// _testMenu
		// 
		_testMenu = new MenuItem ("&Test");
		_testMenu.MenuItems.Add (new MenuItem ("Option 1"));
		_testMenu.MenuItems.Add (new MenuItem ("Option 2"));
		_testMenu.MenuItems.Add (new MenuItem ("Option 3"));
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 300);
		Location = new Point (250, 100);
		Menu = new MainMenu ();
		Menu.MenuItems.Add (_testMenu);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #333548";
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

	private TextBox _textBox;
	private MenuItem _testMenu;
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
			"1. Click the Test menu.{0}{0}" +
			"2. Move the mouse cursor over the \"Option 1\" menuitem.{0}{0}" +
			"3. Use the arrow keys to navigate up and down.{0}{0}" +
			"4. Type some text.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. None of the steps had any effect on the textbox.",
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
		ClientSize = new Size (300, 220);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #333548";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
