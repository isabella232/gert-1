using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _richTextBox
		// 
		_richTextBox = new RichTextBox ();
		_richTextBox.Dock = DockStyle.Fill;
		_richTextBox.ReadOnly = true;
		Controls.Add (_richTextBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 200);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81678";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
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
		_richTextBox.AppendText ("\r\nshould have a red color and bold");
		_richTextBox.SelectionColor = Color.Empty;
		_richTextBox.AppendText ("\r\nshould be default color and bold");

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
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Expected result on start-up:{0}{0}" +
			"1. The RichTextBox contains 6 lines of text.{0}{0}" +
			"2. The lines are formatted as indicated by their text.",
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
		ClientSize = new Size (360, 115);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81678";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
