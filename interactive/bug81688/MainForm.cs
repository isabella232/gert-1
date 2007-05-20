using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _displayFormButton
		// 
		_displayFormButton = new Button ();
		_displayFormButton.Location = new Point (80, 8);
		_displayFormButton.Size = new Size (120, 23);
		_displayFormButton.Text = "Display Form";
		_displayFormButton.Click += new EventHandler (DisplayFormButton_Click);
		Controls.Add (_displayFormButton);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 80;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		AutoScaleBaseSize = new Size (5, 13);
		ClientSize = new Size (300, 120);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81688";
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

	void DisplayFormButton_Click (object sender, EventArgs e)
	{
		Form modalForm = new ModalForm ();
		modalForm.Closed += new EventHandler (ModalForm_Closed);
		MessageBox.Show ("Result: " + modalForm.ShowDialog ());
	}

	void ModalForm_Closed (object sender, EventArgs e)
	{
		_eventsText.AppendText ("ModalForm => Closed" + Environment.NewLine);
	}

	private Button _displayFormButton;
	private TextBox _eventsText;
}

public class ModalForm : Form
{
	public ModalForm ()
	{
		// 
		// ModalForm
		// 
		ClientSize = new Size (200, 100);
		StartPosition = FormStartPosition.CenterParent;
		Text = "Modal";
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
		_bugDescriptionText1.Location = new Point (8, 8);
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Display Form button.{0}{0}" +
			"2. Close the Modal form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. A messagebox stating \"Result: Cancel\" is displayed.{0}{0}" +
			"2. The following events are fired:{0}{0}" +
			"   * ModalForm => Closed",
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
		ClientSize = new Size (300, 220);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81688";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
