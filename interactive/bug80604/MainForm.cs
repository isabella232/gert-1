using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// MainForm
		// 
		Location = new Point (200, 500);
		StartPosition = FormStartPosition.Manual;
		Text = "Owner - bug #80604";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Console.WriteLine ("Visible: " + this.Visible.ToString ());

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();

		Form f = new Form ();
		f.Location = new Point (200, 100);
		f.StartPosition = FormStartPosition.Manual;
		f.Text = "Modal - bug #80604";
		f.ShowDialog (this);
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
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Excepted result on start-up:{0}{0}" +
			"1. The Owner form is not displayed.{0}{0}" +
			"======{0}{0}" +
			"Steps to execute:{0}{0}" +
			"1. Close the Modal form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Owner form is displayed.",
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
		ClientSize = new Size (400, 225);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80604";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
