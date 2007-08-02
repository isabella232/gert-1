using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _buttonA
		// 
		 _buttonA = new Button ();
		_buttonA.Location = new Point (70, 25);
		_buttonA.Size = new Size (80, 20);
		_buttonA.Text = "A";
		Controls.Add (_buttonA);
		// 
		// _buttonB
		// 
		_buttonB = new Button ();
		_buttonB.Location = new Point (150, 25);
		_buttonB.Size = new Size (80, 20);
		_buttonB.Text = "B";
		Controls.Add (_buttonB);
		// 
		// _toolTip
		// 
		_toolTip = new ToolTip ();
		_toolTip.InitialDelay = 1000;
		_toolTip.ReshowDelay = 0;
		_toolTip.SetToolTip (_buttonA, "Displays form A.");
		_toolTip.SetToolTip (_buttonB, "Displays form B.");
		// 
		// MainForm
		// 
		Location = new Point (250, 100);
		Size = new Size (300, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #82288";
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

	private Button _buttonA;
	private Button _buttonB;
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
			"Expected result on start-up:{0}{0}" +
			"1. Move the mouse cursor over button A.{0}{0}" +
			"2. Move the mouse cursor over button B.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the tooltip for button A is displayed after 1 " +
			"second.{0}{0}" +
			"2. On step 2, the tooltip for button B is displayed immediately.",
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
		ClientSize = new Size (300, 210);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #82288";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
