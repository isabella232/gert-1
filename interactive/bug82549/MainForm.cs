using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _myControl
		// 
		_myControl = new MyControl ();
		_myControl.Dock = DockStyle.Fill;
		Controls.Add (_myControl);
		// 
		// MainForm
		// 
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82549";
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

	private MyControl _myControl;
}

class MyControl : Control
{
	public MyControl ()
	{
		this.SuspendLayout ();
		// 
		// _textBox
		// 
		_textBox = new TextBox ();
		_textBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
		_textBox.Location = new Point (0, 0);
		_textBox.Multiline = true;
		_textBox.Size = new Size (60, 60);
		Controls.Add (_textBox);
		// 
		// MyControl
		// 
		BackColor = Color.Red;
		Size = new Size (292, 271);
		ResumeLayout (false);
		PerformLayout ();
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
			"1. Resize the form both horizontally and vertically.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The textbox resizes both horizontally and vertically.",
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
		ClientSize = new Size (300, 140);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82549";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
