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
		// _userControl
		// 
		_userControl = new UserControl1 ();
		_userControl.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);
		_userControl.BackColor = Color.White;
		_userControl.Location = new Point (8, 8);
		_userControl.Size = new Size (288, 238);
		_userControl.TabIndex = 0;
		Controls.Add (_userControl);
		// 
		// _statusBar
		// 
		_statusBar = new StatusBar ();
		Controls.Add (_statusBar);
		// 
		// MainForm
		// 
		ClientSize = new Size (304, 280);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #81695";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	public void IncrementLocationChanged ()
	{
		_locationChanged++;
		UpdateLocationChanged ();
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		UpdateLocationChanged ();

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void UpdateLocationChanged ()
	{
		_statusBar.Text = string.Format (CultureInfo.InvariantCulture,
			"Location Changed: {0}", _locationChanged);
	}

	private UserControl1 _userControl;
	private StatusBar _statusBar;
	private int _locationChanged;
}

public class UserControl1 : UserControl
{
	private Button _button1;
	private Button _button2;

	public UserControl1 ()
	{
		SuspendLayout ();
		// 
		// _button1
		// 
		_button1 = new Button ();
		_button1.Location = new Point (4, 4);
		_button1.Size = new Size (75, 23);
		_button1.TabIndex = 0;
		_button1.Text = "Button1";
		_button1.Click += new EventHandler (Button1_Click);
		Controls.Add (_button1);
		// 
		// _button2
		// 
		_button2 = new Button ();
		_button2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		_button2.Location = new Point (210, 212);
		_button2.Size = new Size (75, 23);
		_button2.TabIndex = 1;
		_button2.Text = "Button2";
		_button2.LocationChanged += new EventHandler (Button2_LocationChanged);
		Controls.Add (_button2);
		// 
		// UserControl1
		// 
		BackColor = Color.White;
		ClientSize = new Size (288, 238);
		ResumeLayout (false);
	}

	void Button1_Click (object sender, EventArgs e)
	{
		MainForm main = ParentForm as MainForm;
		if (main != null) {
			Size originalSize = main.Size;
			main.Size = new Size (10, 10);
			main.Size = originalSize;
		} else {
			Environment.Exit (1);
		}
	}

	void Button2_LocationChanged (object sender, EventArgs e)
	{
		MainForm main = ParentForm as MainForm;
		if (main != null)
			main.IncrementLocationChanged ();
		else
			Environment.Exit (1);
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
			"1. Click the Button1 button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The layout does not change.{0}{0}" +
			"2. The Location Changed counter in the StatusBar displays 2.",
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
		ClientSize = new Size (330, 160);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #81695";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
