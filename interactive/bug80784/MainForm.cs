using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _showFormButton
		// 
		_showFormButton = new Button ();
		_showFormButton.Location = new Point (110, 20);
		_showFormButton.Size = new Size (80, 20);
		_showFormButton.Text = "Show Form";
		_showFormButton.Click += new EventHandler (ShowFormButton_Click);
		Controls.Add (_showFormButton);
		// 
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 70);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Owner - bug #80784";
		Load += new EventHandler (MainForm_Load);
	}

	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ShowFormButton_Click (object sender, EventArgs e)
	{
		Form f = new Form ();
		f.Location = new Point (200, 250);
		f.StartPosition = FormStartPosition.Manual;
		f.Text = "Modal - bug #80784";
		f.ShowDialog ();
	}

	private Button _showFormButton;
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
			"Steps to execute:{0}{0}" +
			"1. Click the Show Form button.{0}{0}" +
			"2. Click on the titlebar of the Owner form.{0}{0}" +
			"3. Hold the mousebutton down, and try to move the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the Modal form flashes (3x).{0}{0}" +
			"2. The Owner form does not activate.{0}{0}" +
			"3. The Owner form cannot be moved.{0}{0}" +
			"======{0}{0}" +
			"Steps to execute:{0}{0}" +
			"1. Click on the titlebar of the Instructions form.{0}{0}" +
			"2. Hold the mousebutton down, and try to move the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2, the Modal form does NOT flash.{0}{0}" +
			"2. The Instructions form does not activate.{0}{0}" +
			"3. The Instructions form cannot be moved.",
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
		ClientSize = new Size (400, 460);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #80784";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
