using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_checkedListBox = new CheckedListBox ();
		_checkedListBox.Dock = DockStyle.Fill;
		_checkedListBox.HorizontalScrollbar = true;
		Controls.Add (_checkedListBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 150);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82097";
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

		_checkedListBox.Items.Add ("Let's add some item that is really long, allowing us to scroll horizontally.");
	}

	private CheckedListBox _checkedListBox;
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
			"1. Scroll horizontally to see the complete text of the item.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The text is not blurred.",
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
		ClientSize = new Size (360, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82097";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
