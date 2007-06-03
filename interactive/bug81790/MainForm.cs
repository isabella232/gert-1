using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _button
		// 
		_button = new Button ();
		_button.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		_button.Location = new Point (180, 200);
		_button.Size = new Size (100, 60);
		Controls.Add (_button);
		// 
		// MainForm
		// 
		ClientSize = new Size (280, 300);
		Location = new Point (275, 100);
		SizeGripStyle = SizeGripStyle.Show;
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81790";
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

//	private TabControl _tabControl;
	private Button _button;
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
			"1. Resize the form.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Button remains anchored to the bottom right corner of the " +
			"form.",
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
		ClientSize = new Size (330, 150);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81790";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
