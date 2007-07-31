using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _sfd
		// 
		_sfd = new SaveFileDialog ();
		_sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
		// 
		// _saveFileButton
		// 
		_saveFileButton = new Button ();
		_saveFileButton.Location = new Point (25, 25);
		_saveFileButton.Size = new Size (80, 20);
		_saveFileButton.Text = "Save File";
		_saveFileButton.Click += new EventHandler (SaveFileButton_Click);
		Controls.Add (_saveFileButton);
		// 
		// _modalForm
		// 
		_modalForm = new ModalForm ();
		// 
		// _showModalFormButton
		// 
		_showModalFormButton = new Button ();
		_showModalFormButton.Location = new Point (150, 25);
		_showModalFormButton.Size = new Size (120, 20);
		_showModalFormButton.Text = "Show Modal Form";
		_showModalFormButton.Click += new EventHandler (ShowModalFormButton_Click);
		Controls.Add (_showModalFormButton);
		// 
		// MainForm
		// 
		Location = new Point (250, 100);
		Size = new Size (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82187";
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

	void SaveFileButton_Click (object sender, EventArgs e)
	{
		_sfd.ShowDialog ();
	}

	void ShowModalFormButton_Click (object sender, EventArgs e)
	{
		_modalForm.ShowDialog ();
	}

	private SaveFileDialog _sfd;
	private Button _saveFileButton;
	private Form _modalForm;
	private Button _showModalFormButton;
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
			"1. Click the Save File button.{0}{0}" +
			"2. Click the Cancel button.{0}{0}" +
			"3. Click the Save File button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Save dialog box is displayed ok in the center of the " +
			"screen.",
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
			"1. Click the Show Modal Form button.{0}{0}" +
			"2. Click the OK button.{0}{0}" +
			"3. Click the Show Modal Form button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Modal form is displayed in the center of the screen.{0}{0}" +
			"2. The OK button is displayed on the form.",
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
		ClientSize = new Size (300, 220);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82187";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}

class ModalForm : Form
{
	public ModalForm ()
	{
		// 
		// _okButton
		// 
		_okButton = new Button ();
		_okButton.Location = new Point (60, 25);
		_okButton.Size = new Size (80, 20);
		_okButton.Text = "OK";
		_okButton.Click += new EventHandler (OkButton_Click);
		Controls.Add (_okButton);
		// 
		// ModalForm
		// 
		ClientSize = new Size (200, 80);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Modal";
	}

	void OkButton_Click (object sender, EventArgs e)
	{
		DialogResult = DialogResult.OK;
	}

	private Button _okButton;
}
