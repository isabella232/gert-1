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
		_richTextBox.Dock = DockStyle.Fill;
		_richTextBox.Font = new Font (FontFamily.GenericSansSerif, 14f);
		_richTextBox.SelectionAlignment = HorizontalAlignment.Center;
		Controls.Add (_richTextBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 130);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #351881";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_richTextBox.SelectionAlignment = HorizontalAlignment.Left;
		_richTextBox.AppendText ("Left" + Environment.NewLine);

		_richTextBox.SelectionAlignment = HorizontalAlignment.Center;
		_richTextBox.AppendText ("Center" + Environment.NewLine);

		_richTextBox.SelectionAlignment = HorizontalAlignment.Right;
		_richTextBox.AppendText ("Right" + Environment.NewLine);

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
			"Expected result on start-up:{0}{0}" +
			"1. The centered and right-aligned text can be " +
			"selected with the mouse.",
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
		ClientSize = new Size (300, 100);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #351881";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
