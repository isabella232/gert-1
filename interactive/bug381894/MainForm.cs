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
		// _groupBox
		// 
		_groupBox = new GroupBox ();
		_groupBox.AllowDrop = true;
		_groupBox.Dock = DockStyle.Top;
		_groupBox.Height = 100;
		_groupBox.TabIndex = 0;
		_groupBox.TabStop = false;
		_groupBox.DragEnter += new DragEventHandler (GroupBox_DragEnter);
		_groupBox.DragLeave += new EventHandler (GroupBox_DragLeave);
		_groupBox.DragOver += new DragEventHandler (GroupBox_DragOver);
		_groupBox.MouseDown += new MouseEventHandler (GroupBox_MouseDown);
		Controls.Add (_groupBox);
		// 
		// _eventsText
		// 
		_eventsText = new TextBox ();
		_eventsText.Dock = DockStyle.Bottom;
		_eventsText.Height = 150;
		_eventsText.Multiline = true;
		Controls.Add (_eventsText);
		// 
		// MainForm
		// 
		ClientSize = new Size (400, 265);
		Location = new Point (200, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "bug #381894";
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void GroupBox_DragEnter (object sender, DragEventArgs e)
	{
		_eventsText.AppendText ("GroupBox => DragEnter"
			+ Environment.NewLine);
	}

	void GroupBox_DragOver (object sender, DragEventArgs e)
	{
		e.Effect = DragDropEffects.Move;
	}

	void GroupBox_DragLeave (object sender, EventArgs e)
	{
		_eventsText.AppendText ("GroupBox => DragLeave"
			+ Environment.NewLine);
	}

	void GroupBox_MouseDown (object sender, MouseEventArgs e)
	{
		DoDragDrop (this, DragDropEffects.All);
	}

	private GroupBox _groupBox;
	private TextBox _eventsText;
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
			"1. Click and hold the mouse button on the groupbox.{0}{0}" +
			"2. Move the mouse pointer over the groupbox.{0}{0}" +
			"3. Press the ESC key.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 2:{0}{0}" +
			"   * The DragEnter event is fired.{0}" +
			"   * The mouse pointer changes to a move icon.{0}{0}" +
			"2. On step 3:{0}{0}" +
			"   * The DragLeave event is fired.{0}" +
			"   * The mouse pointer changes to a regular icon.",
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
		ClientSize = new Size (360, 300);
		Location = new Point (650, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #381894";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
