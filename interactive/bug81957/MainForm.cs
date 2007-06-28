using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		SuspendLayout ();
		// 
		// _showFormButton
		// 
		_showFormButton = new Button ();
		_showFormButton.Location = new Point (64, 80);
		_showFormButton.Size = new Size (168, 23);
		_showFormButton.TabIndex = 0;
		_showFormButton.Text = "Show Instructions Form";
		_showFormButton.Click += new EventHandler (ShowFormButton_Click);
		Controls.Add (_showFormButton);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (304, 198);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "bug #81957";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.ShowDialog ();
	}

	void ShowFormButton_Click (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.ShowDialog ();
	}

	private Button _showFormButton;
}

public class InstructionsForm : Form
{
	public InstructionsForm ()
	{
		SuspendLayout ();
		// 
		// _showFormButton
		// 
		_showFormButton = new Button ();
		_showFormButton.Location = new Point (85, 8);
		_showFormButton.Size = new Size (176, 23);
		_showFormButton.TabIndex = 1;
		_showFormButton.Text = "Show Modal Form";
		_showFormButton.Click += new EventHandler (ShowFormButton_Click);
		Controls.Add (_showFormButton);
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Bottom;
		_tabControl.Height = 200;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Show Modal Form button.{0}{0}" +
			"2. Close the Modal form.{0}{0}" +
			"3. Repeat steps 1 and 2 several times.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. After step 1, the Modal form is always activated and " +
			"displayed on top of the z-order.",
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
		ClientSize = new Size (360, 240);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Instructions - bug #81957";
		ResumeLayout (false);
	}

	void ShowFormButton_Click (object sender, EventArgs e)
	{
		Form modal = new ModalForm ();
		modal.ShowDialog ();
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private Button _showFormButton;
}

public class ModalForm : Form
{
	public ModalForm ()
	{
		SuspendLayout ();
		// 
		// ModalForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (224, 50);
		Location = new Point (260, 120);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Modal";
		ResumeLayout (false);
	}
}
