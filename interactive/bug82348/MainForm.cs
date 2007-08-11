using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _buttonOK
		// 
		_buttonOK = new Button ();
		_buttonOK.Location = new Point (110, 25);
		_buttonOK.Size = new Size (80, 20);
		_buttonOK.Text = "OK";
		Controls.Add (_buttonOK);
		// 
		// _toolTip
		// 
		_toolTip = new ToolTip ();
		_toolTip.InitialDelay = 1000;
		_toolTip.ReshowDelay = 0;
		_toolTip.SetToolTip (_buttonOK, "We're doing just fine...");
		// 
		// MainForm
		// 
		Location = new Point (250, 100);
		Size = new Size (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82348";
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

	private Button _buttonOK;
	private ToolTip _toolTip;
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
			"1. Move the mouse cursor over the OK button.{0}{0}" +
			"2. Wait until the tooltip is displayed.{0}{0}" +
			"3. Left-click the button and do not release the mouse button.{0}{0}" +
			"4. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, the tooltip is no longer visible.",
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
			"1. Move the mouse cursor over the OK button.{0}{0}" +
			"2. Wait until the tooltip is displayed.{0}{0}" +
			"3. Right-click the button and do not release the mouse button.{0}{0}" +
			"4. Release the mouse button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 3, the tooltip is no longer visible.",
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
		Text = "Instructions - bug #82348";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
}
