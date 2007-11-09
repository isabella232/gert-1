using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_textBox = new TextBox ();
		_textBox.Dock = DockStyle.Fill;
		_textBox.Multiline = true;
		_textBox.KeyPress += new KeyPressEventHandler (TextBox_KeyPress);
		Controls.Add (_textBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 60);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #340078";
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

	void TextBox_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '3' || e.KeyChar == '\r')
			e.Handled = true;
	}

	private TextBox _textBox;
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
			"1. Type \"12345\" and the hit the Enter key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The character \"3\" and the Enter key are ignored.",
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
		ClientSize = new Size (300, 155);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #340078";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
