using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Top;
		_eventsText.Height = 200;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// _showDialogButton
		// 
		_showDialogButton = new Button ();
		_showDialogButton.Location = new Point (95, 210);
		_showDialogButton.Size = new Size (100, 20);
		_showDialogButton.Text = "Show Dialog";
		_showDialogButton.Click += new EventHandler (ShowDialogButton_Click);
		Controls.Add (_showDialogButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 240);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81521";
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

	void ShowDialogButton_Click (object sender, EventArgs e)
	{
		ChildForm child = new ChildForm ();
		child.Closed += new EventHandler (ChildForm_Closed);
		child.ShowDialog ();
	}

	void ChildForm_Closed (object sender, EventArgs e)
	{
		_eventsText.AppendText ("Child => Closed" + Environment.NewLine);
	}

	private TextBox _eventsText;
	private Button _showDialogButton;
}

public class ChildForm : Form
{
	public ChildForm ()
	{
		// 
		// ChildForm
		// 
		_visibleCheckBox = new CheckBox ();
		_visibleCheckBox.Checked = true;
		_visibleCheckBox.Location = new Point (8, 8);
		_visibleCheckBox.Text = "Visible";
		_visibleCheckBox.CheckedChanged += new EventHandler (VisibleCheckBox_CheckedChanged);
		Controls.Add (_visibleCheckBox);
		// 
		// ChildForm
		// 
		ClientSize = new Size (120, 50);
		StartPosition = FormStartPosition.CenterParent;
		Text = "Child";
	}

	void VisibleCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		Visible = _visibleCheckBox.Checked;
	}

	private CheckBox _visibleCheckBox;
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
			"1. Click the Show Dialog button.{0}{0}" +
			"2. Uncheck the Visible checkbox.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The dialog is closed.{0}{0}" +
			"2. No Closed event is fired.",
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
		ClientSize = new Size (360, 200);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81521";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
