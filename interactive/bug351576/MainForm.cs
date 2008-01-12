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
		_richTextBox.ReadOnly = true;
		_richTextBox.Dock = DockStyle.Fill;
		_richTextBox.SelectionColor = Color.Black;
		_richTextBox.AppendText ("should be colored black");
		_richTextBox.SelectionColor = Color.Red;
		_richTextBox.AppendText ("\r\nshould have a red color");
		_richTextBox.SelectionColor = Color.Empty;
		_richTextBox.AppendText ("\r\nshould be default color");
		_richTextBox.SelectionColor = Color.Black;
		_richTextBox.AppendText ("\r\nshould be colored black");
		_richTextBox.SelectionFont = new Font (_richTextBox.SelectionFont, FontStyle.Bold);
		_richTextBox.AppendText (" and now bold");
		_richTextBox.SelectionColor = Color.Red;
		_richTextBox.AppendText ("\r\nshould have a red color");
		_richTextBox.SelectionColor = Color.Empty;
		_richTextBox.AppendText ("\r\nshould be default color");
		Controls.Add (_richTextBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 150);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #351576";
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
			"1. Press the Ctrl+A key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. All text is fully highlighted.",
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
		ClientSize = new Size (300, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #351576";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
