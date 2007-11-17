using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _richtTextBox
		// 
		_richtTextBox = new RichTextBox ();
		_richtTextBox.Dock = DockStyle.Fill;
		_richtTextBox.LinkClicked += new LinkClickedEventHandler (RichTextBox_LinkClicked);
		Controls.Add (_richtTextBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 100);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #342516";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		_richtTextBox.Text = string.Format (CultureInfo.InvariantCulture,
			"For all you ever wanted to know about Mono:{0}{0}"
			+ "http://www.mono-project.com{0}{0}"
			+ "(enter at your own risk)", Environment.NewLine);

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	private void RichTextBox_LinkClicked (object sender, LinkClickedEventArgs e)
	{
		Process.Start (e.LinkText);
	}

	private RichTextBox _richtTextBox;
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
			"Expected result on startup:{0}{0}" +
			"1. The URL for www.mono-project.com is displayed " +
			"as a link.{0}{0}" +
			"2. Clicking the link opens the URL in a browser.",
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
		ClientSize = new Size (300, 140);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #342516";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
