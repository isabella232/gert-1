using System;
using System.Drawing;
using System.Globalization;
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
		_eventsText.Height = 150;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// _clearButton
		// 
		_clearButton = new Button ();
		_clearButton.Location = new Point (120, 160);
		_clearButton.Size = new Size (60, 20);
		_clearButton.Text = "Clear";
		_clearButton.Click += new EventHandler (ClearButton_Click);
		Controls.Add (_clearButton);
		// 
		// MainForm
		// 
		ClientSize = new Size (292, 190);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82455";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Form child = new Form ();
		child.Location = new Point (250, 350);
		child.Size = new Size (300, 200);
		child.StartPosition = FormStartPosition.Manual;
		child.Text = "Child";
		child.Resize += new EventHandler (Child_Resize);
		child.Show ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void ClearButton_Click (object sender, EventArgs e)
	{
		_eventsText.Text = string.Empty;
	}

	void Child_Resize (object sender, EventArgs e)
	{
		_eventsText.AppendText ("Resize" + Environment.NewLine);
	}

	private TextBox _eventsText;
	private Button _clearButton;
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
			"1. Click the Clear button.{0}{0}" +
			"2. Minimize the Child form.{0}{0}" +
			"3. Restore the Child form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following events have fired:{0}{0}" +
			"   Resize{0}" +
			"   Resize",
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
			"1. Click the Clear button.{0}{0}" +
			"2. Maximize the Child form.{0}{0}" +
			"3. Restore the Child form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The following events have fired:{0}{0}" +
			"   Resize{0}" +
			"   Resize",
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
		ClientSize = new Size (360, 230);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82455";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
