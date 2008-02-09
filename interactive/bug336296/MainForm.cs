using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _menuStrip
		// 
		_menuStrip = new MenuStrip ();
		_menuStrip.Items.Add (new ToolStripMenuItem ("main", null,
			new ToolStripMenuItem ("item1")));
		MainMenuStrip = _menuStrip;
		Controls.Add (_menuStrip);
		// 
		// MainForm
		// 
		ClientSize = new Size (390, 340);
		IsMdiContainer = true;
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #336296";
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

		Form child1 = new Form ();
		child1.BackColor = Color.Blue;
		child1.Height = 200;
		child1.MdiParent = this;
		child1.Text = "Child #1";
		child1.Show ();

		Form child2 = new Form ();
		child2.BackColor = Color.Red;
		child2.Height = 200;
		child2.MdiParent = this;
		child2.Text = "Child #2";
		child2.Show ();

		Form child3 = new Form ();
		child3.BackColor = Color.Green;
		child3.Height = 200;
		child3.MdiParent = this;
		child3.Text = "Child #3";
		child3.Show ();
	}

	private MenuStrip _menuStrip;
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
			"1. Maximize the Child #2 form.{0}{0}" +
			"2. Click the restore / unmaximize button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The form is restored to its original size and " +
			"position.",
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
		ClientSize = new Size (310, 170);
		Location = new Point (690, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #336296";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
