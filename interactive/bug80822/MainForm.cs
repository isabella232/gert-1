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
		ClientSize = new Size (400, 400);
		Location = new Point (100, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #80822";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Form childA = new Form ();
		childA.TopLevel = false;
		childA.BackColor = Color.Red;
		childA.Location = new Point (0, 0);
		childA.Size = new Size (150, 100);
		childA.Text = "Child A";
		Controls.Add (childA);
		childA.Visible = true;

		Form childB = new Form ();
		childB.TopLevel = false;
		childB.BackColor = Color.Blue;
		childB.Location = new Point (200, 150);
		childB.Size = new Size (150, 100);
		childB.Text = "Child B";
		childB.Visible = true;
		Controls.Add (childB);

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
			"1. The main form contains two child forms.{0}{0}" +
			"2. Child A is position at {{X=0, Y=0}} inside the main form and " +
			"has a red background.{0}{0}" +
			"3. Child B is position at {{X=200, Y=150}} inside the main form " +
			"and has a blue background.{0}{0}" +
			"4. Moving the main form causes both child forms to move along." +
			"{0}{0}" +
			"5. Both child forms can be moved independently.{0}{0}" +
			"6. Both child form contain a titlebar with title and control box.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Attempt to drag a child form across the border of the main " +
			"form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The point where you're holding the child form cannot be " +
			"dragged across the border of the main form.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (400, 300);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80822";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
