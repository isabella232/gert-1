using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// MainForm
		// 
		ClientSize = new Size (342, 350);
		IsMdiContainer = true;
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #79964";
		Load += new System.EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Form childA = new Form ();
		childA.MdiParent = this;
		childA.Text = "Child A";
		childA.Show ();

		Form childB = new Form ();
		childB.MdiParent = this;
		childB.StartPosition = FormStartPosition.Manual;
		childB.Text = "Child B";
		childB.Top = 100;
		childB.Show ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}
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
			"1. Child B should be displayed at {{X=0, Y=100}}.{0}{0}" +
			"2. Child A is displayed at {{X=0, Y=0}}.{0}{0}" +
			"3. Child B is activate and is displayed on top of Child A.{0}{0}" +
			"4. A vertical scrollbar should be displayed in the MDIMain form.",
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
		ClientSize = new Size (300, 170);
		Location = new Point (570, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #79964";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
