using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		_okButton = new Button ();
		_okButton.FlatAppearance.BorderSize = 0;
		_okButton.FlatStyle = FlatStyle.Flat;
		_okButton.Location = new Point (60, 20);
		_okButton.Text = "OK";
		Controls.Add (_okButton);
		_cancelButton = new Button ();
		_cancelButton.FlatAppearance.BorderSize = 0;
		_cancelButton.FlatStyle = FlatStyle.Flat;
		_cancelButton.Location = new Point (180, 20);
		_cancelButton.Text = "Cancel";
		Controls.Add (_cancelButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 70);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82081";
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

	private Button _okButton;
	private Button _cancelButton;
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
			"1. The Cancel button is flat.{0}{0}" +
			"2. The Cancel button has no border.{0}{0}" +
			"3. The Cancel button highlights on mouseover.",
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
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click on the OK button.{0}{0}" +
			"2. Press Tab key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Focus rectangle is drawn around the Cancel button.{0}{0}" +
			"2. The Cancel button highlights on mouseover.",
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
		ClientSize = new Size (360, 190);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82081";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
