using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _richTextBox
		// 
		_richTextBox = new RichTextBox ();
		_richTextBox.Dock = DockStyle.Bottom;
		_richTextBox.SelectionAlignment = HorizontalAlignment.Center;
		_richTextBox.AppendText ("Title");
		Controls.Add (_richTextBox);
		// 
		// _alignButton
		// 
		_alignButton = new Button ();
		_alignButton.Text = "Left Align";
		_alignButton.Dock = DockStyle.Top;
		_alignButton.Click += new EventHandler (AlignButton_Click);
		Controls.Add (_alignButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 130);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #351918";
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

	void AlignButton_Click (object sender, EventArgs e)
	{
		_richTextBox.SelectionAlignment = HorizontalAlignment.Left;
		_richTextBox.Focus ();
	}

	private Button _alignButton;
	private RichTextBox _richTextBox;
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
			"1. Press the Enter key.{0}{0}" +
			"2. Click the Left Align button.{0}{0}" +
			"3. Enter some text.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The first line remains centered.{0}{0}" +
			"2. The newly entered text is left aligned.",
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
		Text = "Instructions - bug #351918";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
