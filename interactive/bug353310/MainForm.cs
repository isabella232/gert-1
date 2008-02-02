using System;
using System.Drawing;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _nameLabel
		// 
		_nameLabel = new Label ();
		_nameLabel.AutoSize = true;
		_nameLabel.Location = new Point (8, 8);
		_nameLabel.Text = "Name:";
		Controls.Add (_nameLabel);
		// 
		// _nameValue
		// 
		_nameValue = new TextBox ();
		_nameValue.Location = new Point (80, 8);
		_nameValue.Size = new Size (120, 20);
		_nameValue.Validating += new CancelEventHandler (NameValue_Validating);
		Controls.Add (_nameValue);
		// 
		// 
		// 
		_quitButton = new Button ();
		_quitButton.Location = new Point (230, 8);
		_quitButton.Size = new Size (60, 20);
		_quitButton.Text = "Quit";
		_quitButton.Click += new EventHandler (QuitButton_Click);
		Controls.Add (_quitButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 50);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #353310";
		Load += new EventHandler (MainForm_Load);
		Closing += new CancelEventHandler (MainForm_Closing);
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

	void MainForm_Closing (object sender, CancelEventArgs e)
	{
		if (e.Cancel) {
			MessageBox.Show ("Allowing application to quit...", "bug #353310");
			e.Cancel = false;
		}
	}

	void QuitButton_Click (object sender, EventArgs e)
	{
		Close ();
	}

	void NameValue_Validating (object sender, CancelEventArgs e)
	{
		if (_nameValue.Text.Length == 0) {
			MessageBox.Show ("Please enter a name.", "bug #353310");
			e.Cancel = true;
		}
	}

	private Label _nameLabel;
	private TextBox _nameValue;
	private Button _quitButton;
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
			"1. Do not enter any text in the textbox.{0}{0}" +
			"2. Click the Quit button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A message box with the following text is displayed:{0}{0}" +
			"   * Please enter a name.{0}{0}" +
			"2. The Name textbox has focus.{0}{0}" +
			"3. The Quit button is in the \"unpressed\" state.",
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
			"1. Do not enter any text in the textbox.{0}{0}" +
			"2. Use the control box to close the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. Two message boxes with the following text are displayed:{0}{0}" +
			"   * Please enter a name.{0}" +
			"   * Allowing application to quit...{0}{0}" +
			"2. The application exits.",
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
		ClientSize = new Size (320, 250);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #353310";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
