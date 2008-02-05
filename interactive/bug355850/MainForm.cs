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
		_tabControl.SelectedIndex = 0;
		_tabControl.TabIndex = 0;
		_tabControl.SelectedIndexChanged += new EventHandler (OnSelectedIndexChanged);
		Controls.Add (_tabControl);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Location = new Point (4, 22);
		_tabPage1.Size = new Size (384, 240);
		_tabPage1.TabIndex = 0;
		_tabPage1.Text = "A";
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Location = new Point (4, 22);
		_tabPage2.Size = new Size (192, 74);
		_tabPage2.TabIndex = 1;
		_tabPage2.Text = "B";
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.BackColor = Color.Green;
		_textBox.Dock = DockStyle.Fill;
		_textBox.Multiline = true;
		_tabPage1.Controls.Add (_textBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 240);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #355850";
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

	void OnSelectedIndexChanged (object sender, EventArgs e)
	{
		TabPage page = ((TabControl) sender).SelectedTab;
		if (page == _tabPage2) {
			_control = new TestControl ();
			_control.Dock = DockStyle.Fill;
			_tabPage2.Controls.Clear ();
			_tabPage2.Controls.Add (_control);
		} else {
			if (_control != null)
				_control.Dispose ();
			_control = null;
		}
	}

	private TestControl _control;
	private TextBox _textBox;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabControl _tabControl;
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
			"1. Click on tab B.{0}{0}" +
			"2. Click on tab A.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The background color of the textbox changes from " +
			"green to blue, and back to green.",
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
		ClientSize = new Size (320, 180);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #355850";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
